 /*
 *
 * Copyright (C) 2006-2011 Jedox AG
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License (Version 2) as published
 * by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 59 Temple
 * Place, Suite 330, Boston, MA 02111-1307 USA
 *
 * You may obtain a copy of the License at
 *
 * <a href="http://www.jedox.com/license_palo_bi_suite.txt">
 *	 http://www.jedox.com/license_palo_bi_suite.txt
 * </a>
 *
 * If you are developing and distributing open source applications under the
 * GPL License, then you are free to use Palo under the GPL License.  For OEMs,
 * ISVs, and VARs who distribute Palo with their products, and do not license
 * and distribute their source code under the GPL, Jedox provides a flexible
 * OEM Commercial License.
 *
 * \author
 *
 *
 */

//  Additional Revisions to Palo (c) Junction BI LLC:
//  JMM 09-01-15 Updates to connection function calls for 5.1 compatability
//  JMM 03-30-14 Derive Connect class from StandardOleMarshalObject allows access through VSTO COMAddIns
//  JMM 09-24-13 Various changes for 5.0 library compatability


using System;
using System.Collections;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Net;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Text;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;
using Apalo.XlAddin.Forms;
using Apalo.CommonInterfaces;

namespace Apalo.XlAddin
{

		#region Read me for Add-in installation and setup information.
		// When run, the Add-in wizard prepared the registry for the Add-in.
		// At a later time, if the Add-in becomes unavailable for reasons such as:
		//	 1) You moved this project to a computer other than which is was originally created on.
		//	 2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
		//	 3) Registry corruption.
		// you will need to re-register the Add-in by building the Setup project
		// by right clicking the project in the Solution Explorer, then choosing install.

		// Make sure you have these data
		// [HKEY_CURRENT_USER\SOFTWARE\Microsoft\Office\Excel\AddIns\Apalo.XlAddin.Connect]
		// "FriendlyName"="APaloDesigner"
		// "Description"="Apalo Excel Designer Addin."
		// "LoadBehavior"=dword:00000003
		// "CommandLineSafe"=dword:00000000
		#endregion

		[ComVisible(true)]
	[GuidAttribute("35F3F44A-BCCB-4B67-AEDF-D57F65F10993"), ProgId("Apalo.XlAddin.Connect")]
	public class Connect :
						   // JMM 03-30-14, derive from StandardOleMarshalObject allows access through VSTO COMAddIns
						   StandardOleMarshalObject, IPaloConnect, Extensibility.IDTExtensibility2, System.IDisposable
						   // was: Object, Extensibility.IDTExtensibility2, System.IDisposable
		{
		#region Define Vars

		private static bool isInitialized = false;

		public static string PaloOnlineLanguage
		{
			get
			{
				string lang = RegUtils.ActiveLanguage.Substring(0, 2).ToLowerInvariant();

				switch (lang)
				{
					case "de":
					case "fr":
						return lang;

					default:
						return "en";
				}
			}
		}

				private static string PaloErrorString;
		private static bool DisableModeller;

				public static bool InPaste;
		public static bool changesMade = false;
		public static bool OpenSpecialCase = false;

		private static ResourceInitializer ResourceInitializer;
		private bool ScreenUpdating;
				private static string CurrentFormula;
		private static string CurrentFormulaLocal;
		private string CurrentStrValue;
				private double CurrentDblValue;
				private int CurrentRow;
				private int CurrentColumn;
				private bool CurrentTab;
		private Excel.Application applicationObject;
		private object o;
				private Thread thisThread = Thread.CurrentThread;
				private CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
				private CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;

		#region Menu/Contextmenu Items
		private Office.CommandBarPopup olapMenu;
		private Office.CommandBarButton mItemModeller;
				private Office.CommandBarButton mItemImportWizard;
				private Office.CommandBarButton mItemPasteElements;
				private Office.CommandBarButton mItemPaloWizard;
				private Office.CommandBarButton mItemPasteFunctions;
				private Office.CommandBarButton mItemAbout;
		private Office.CommandBarButton mItemPasteView;
		private Office.CommandBarButton mItemSaveAsSnapshot;
		private Office.CommandBarButton mItemPasteSubset;
		private Office.CommandBarButton mItemContextPasteView;
		private Office.CommandBarButton mItemDrillRule;
		private Office.CommandBarButton mItemDrillThrough;
		private Office.CommandBarButton mItemDrillHistory;
				private Office.CommandBarButton mItemError;
		private Office.CommandBarPopup mItemPaloOnline;
		private Office.CommandBarButton mItemLogIn;
		private Office.CommandBarButton mItemLogOut;
		private Office.CommandBarButton mItemBasicHelp;
		public static Office.CommandBarButton mItemAdvancedHelp;

		public static bool enablePaloOnline
				{
						get
						{
				return mItemAdvancedHelp.Enabled;
						}
						set
						{
				mItemAdvancedHelp.Enabled = value;
				tbAdvancedHelp.Enabled = value;
						}
				}

		#endregion

		#region Toolbar Items
		private Office.CommandBar olapBar;
		private Office.CommandBarButton tbModeller;
				private Office.CommandBarButton tbImportWizard;
				private Office.CommandBarButton tbPasteElements;
				private Office.CommandBarButton tbPaloWizard;
				private Office.CommandBarButton tbPasteFunctions;
				private Office.CommandBarButton tbPasteView;
		private Office.CommandBarButton tbBeginUndo;
		private Office.CommandBarButton tbCommit;
		private Office.CommandBarButton tbRollback;
		private Office.CommandBarButton tbUndo;

		private Office.CommandBarButton tbLogin;
		private Office.CommandBarButton tbLogOut;
		private Office.CommandBarButton tbBasicHelp;
		private static Office.CommandBarButton tbAdvancedHelp;
		#endregion

		private static int CurrentLockId;
		private static Connection CurrentConnection;
		private static string CurrentDb;
		private static string CurrentCube;
		private static Excel.Range CurrentRange;

				private Apalo.XlAddin.Forms.Modeller MainForm;
				private Apalo.XlAddin.Forms.ImportWizard ImportForm;
		private Apalo.XlAddin.Forms.PasteElements2 PasteElementsForm;
				private Apalo.XlAddin.Forms.PasteFunction PasteFunctionsForm;
		private Apalo.XlAddin.Forms.FrmPasteView FrmPasteView;
		public static Apalo.XlAddin.Forms.PaloWizard WizardForm;

				private const string XLL_FILE = "Palo.xll";
		#if WIN64
		private const string XLL12_FILE = "Palo12_x64.xll";
		#else
		private const string XLL12_FILE = "Palo12.xll";
		#endif
		private const string SERVICE_NAME = "PALOServerService";
		private const string LOCALHOST = "localhost";
		public const char SPLASH_PREFIX_CHAR = '|';
		public const char SPLASH_HASH = '#';
		public const char SPLASH_EXCL = '!';
		public const char SPLASH_PERCT = '%';
		public const char SPLASH_GOALSEEK = '?';
		public const string myPaloURL = "http://www.jedox.com/";
		private const string myPaloLoginURL = "https://www.jedox.com/";
		public static string firstStepsURL
		{
			get
			{
				switch(PaloOnlineLanguage)
				{
					case "de":
						return myPaloURL + "?id=1380";

					case "fr":
						return myPaloURL + "?id=1378";

					default:
						return myPaloURL + "?id=1379";
				}
			}
		}
				#endregion


		#region Construct/Destruct

				public Connect()
				{
		//System.Windows.Forms.MessageBox.Show("Palo Connect Loaded", "Debugging");
		}

		public void Dispose()
				{
						this.Dispose(true);
				}

				private void Dispose( bool disposing )
				{
						if( disposing )
						{
				if (this.MainForm != null)
									this.MainForm.Dispose();
				if (this.ImportForm != null)
									this.ImportForm.Dispose();
				if (this.FrmPasteView != null)
					this.FrmPasteView.Dispose();
				if (this.PasteElementsForm != null)
					this.PasteElementsForm.Dispose();
				if (this.PasteFunctionsForm != null)
									this.PasteFunctionsForm.Dispose();
						}
				}

				#endregion


		#region Public COM Interfaces
		[ComVisible(true)]
		public void ShowModeller()
			{
			bool CancelDefault = false;
			mItemModeller_Click(null, ref CancelDefault);
			}

		[ComVisible(true)]
		public void DoPasteView()
			{
			bool CancelDefault = false;
			mItemPasteView_Click(null, ref CancelDefault);
			}

		[ComVisible(true)]
		public void DoPasteElement()
			{
			bool CancelDefault = false;
			mItemPasteElements_Click(null, ref CancelDefault);
			}
            
		[ComVisible(true)]
		public void DoPasteSubset()
			{
			bool CancelDefault = false;
			mItemPasteSubset_Click(null, ref CancelDefault);
			}

		[ComVisible(true)]
		public void SaveSnapshot()
			{
			bool CancelDefault = false;
			mItemSaveAsSnapshot_Click(null, ref CancelDefault);
			}
		#endregion


		#region Button clicks

		#region Helpers
		private void check_menuitems(int offset)
		{
			bool enable = false;

			try
			{
				if ((applicationObject.Workbooks.Count + offset) > 0)
				{
					enable = true;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("error in check_menuitems", e);
			}

			if (!DisableModeller)
			{
				this.mItemImportWizard.Enabled = enable;
				this.tbImportWizard.Enabled = enable;
#if Sales
				this.tbImportWizard.Enabled = true;
#endif
			}

			this.mItemPasteElements.Enabled = enable;
			this.mItemPasteFunctions.Enabled = enable;
			this.mItemPasteView.Enabled = enable;
			this.mItemSaveAsSnapshot.Enabled = enable;
			this.tbPasteElements.Enabled = enable;
			this.tbPasteFunctions.Enabled = enable;
			this.tbPasteView.Enabled = enable;
			this.mItemPasteSubset.Enabled = enable;

#if Sales
			this.tbPasteElements.Enabled = true;
						this.tbPasteFunctions.Enabled = true;
						this.tbPasteView.Enabled = true;
#endif
		}

		private static bool IsFileOpenEnabled()
		{
			return (bool)ExcelHelper.oExcelApp.CommandBars.FindControl(Type.Missing, 23, Type.Missing, Type.Missing).Enabled;
		}

		public static bool NotInEditMode()
				{
						bool FileOpenEnabled = true;

			CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
			CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;

			try
			{
				// set current thread's culture to en-US
				Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
				if (!GeneralConst.isClickToRun())
				{
					FileOpenEnabled = IsFileOpenEnabled();
				}
			}
			catch (Exception ex)
			{
				ErrorHandler.DisplayError("Error in NotInEditMode !", ex);
			}
			finally
			{

				Thread.CurrentThread.CurrentCulture = originalCulture;
				Thread.CurrentThread.CurrentCulture = originalUICulture;
			}

						return FileOpenEnabled;
		}

		private bool CheckFormula(string formula)
		{
			string formula2 = formula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).Trim();
			return formula2.StartsWith("=" + GeneralConst.PALO_DATA, true, CultureInfo.InvariantCulture)
					|| formula2.StartsWith("=INDEX(" + GeneralConst.PALO_DATAT + "(", true, CultureInfo.InvariantCulture);
		}

		private string[] CreateCoordArray(string formula)
		{
			string db = "";
			string cube = "";
			string conn = "";
			return CreateCoordArray(formula, ref conn, ref db, ref cube, false);
		}

		private string[] CreateCoordArray(string formula, ref string conn, ref string db, ref string cube, bool check)
		{
			if (CheckFormula(formula))
			{
				ExcelHelper eH = new ExcelHelper();
				Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
				string connString = "";

				if (check)
				{
					connString = eH.get_params(formula, 1, true);
					connString = eH.get_value(connString, ws);
					int lenght = connString.IndexOf('/');
					conn = connString.Substring(0, lenght);
					db = connString.Substring(lenght + 1);

					cube = eH.get_params(formula, 2, true);
					cube = eH.DeEscapeDoubleQuote(eH.get_value(cube, ws));
				}
				formula = formula.Substring(formula.IndexOf('(') + 1);
				formula = formula.Substring(0, formula.Length - 1);
				string[] b = formula.Split(',');
				if (b.LongLength == 1)
				{
					b = formula.Split(';');
				}
				string[] coords = new string[b.LongLength - 2];
				for (int i = 0; i < b.Length; i++)
				{
					if (i > 1)
					{
						string s = b[i];
						coords[i - 2] = eH.DeEscapeDoubleQuote(eH.get_value(b[i], ws));
					}
				}
				return coords;
			}
			else
				return new string[] { };

		}
		#endregion

		#region Commit/Rollback
		private void tbUndo_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			Excel.XlCalculation tmpCalculation = Excel.XlCalculation.xlCalculationManual;

			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				tmpCalculation = ExcelHelper.DisableAutomaticRecalc();

				CurrentConnection.CubeRollback(CurrentDb, CurrentCube, CurrentLockId, 1);

				LockInfo[] li = CurrentConnection.CubeLocks(CurrentDb, CurrentCube);

				for (int i = 0; i < li.Length; i++)
				{
					LockInfo l = li[i];

					if (l.id == CurrentLockId)
					{
						this.tbBeginUndo.Enabled = false;
						this.tbCommit.Enabled = true;
						this.tbRollback.Enabled = true;
						this.tbUndo.Enabled = true;
					}
				}
			}
			catch (PaloException pe)
			{
				if (pe.ErrorCode == 5013)
				{
					this.tbBeginUndo.Enabled = true;
					this.tbCommit.Enabled = false;
					this.tbRollback.Enabled = false;
					this.tbUndo.Enabled = false;
					CurrentLockId = 0;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error Initialising CubeRollback Mode.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				ExcelHelper.SetCalculation(tmpCalculation);
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
			}
		}

		private void tbCommit_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			Excel.XlCalculation tmpCalculation = Excel.XlCalculation.xlCalculationManual;

			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				tmpCalculation = ExcelHelper.DisableAutomaticRecalc();

				CurrentConnection.CubeCommit(CurrentDb, CurrentCube, CurrentLockId);

				this.tbBeginUndo.Enabled = true;
				this.tbCommit.Enabled = false;
				this.tbRollback.Enabled = false;
				this.tbUndo.Enabled = false;
				CurrentLockId = 0;
			}
			catch (PaloException pe)
			{
				if (pe.ErrorCode == 5013)
				{
					this.tbBeginUndo.Enabled = true;
					this.tbCommit.Enabled = false;
					this.tbRollback.Enabled = false;
					this.tbUndo.Enabled = false;
					CurrentLockId = 0;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error Initialising CubeCommit Mode.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				ExcelHelper.SetCalculation(tmpCalculation);
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
			}
		}

		private void tbRollback_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			Excel.XlCalculation tmpCalculation = Excel.XlCalculation.xlCalculationManual;

			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				tmpCalculation = ExcelHelper.DisableAutomaticRecalc();

				CurrentConnection.CubeRollback(CurrentDb, CurrentCube, CurrentLockId);

				this.tbBeginUndo.Enabled = true;
				this.tbCommit.Enabled = false;
				this.tbRollback.Enabled = false;
				this.tbUndo.Enabled = false;
				CurrentLockId = 0;
			}
			catch (PaloException pe)
			{
				if (pe.ErrorCode == 5013)
				{
					this.tbBeginUndo.Enabled = true;
					this.tbCommit.Enabled = false;
					this.tbRollback.Enabled = false;
					this.tbUndo.Enabled = false;
					CurrentLockId = 0;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error Initialising CubeRollback Mode.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				ExcelHelper.SetCalculation(tmpCalculation);
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
			}
		}

		private bool CheckFormulaV(string formula)
		{
			string tmpformula = formula.ToUpper().Trim();

			return (tmpformula.StartsWith("=" + GeneralConst.PALO_DATA) && !tmpformula.StartsWith("=" + GeneralConst.PALO_DATAV));
		}

		private void tbBeginUndo_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			// skip if allready locked
			if (CurrentLockId != 0)
			{
				this.tbBeginUndo.Enabled = false;
				return;
			}

			Excel.XlCalculation tmpCalculation = Excel.XlCalculation.xlCalculationManual;

			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				tmpCalculation = ExcelHelper.DisableAutomaticRecalc();

				Excel.Range range = ExcelHelper.GetSelection();
				CurrentRange = range;

				object fo = range.Formula;
				string formula = "";
				string conn = "";
				string db = "";
				string cube = "";

				if (fo.GetType().IsArray)
				{
					object[,] tmpFo = (object[,])fo;
					int numberOfCells = tmpFo.Length;
					formula = tmpFo[1, 1].ToString();

					if (!CheckFormulaV(formula))
					{
						return;
					}
					string[] tuple = CreateCoordArray(formula, ref conn, ref db, ref cube, true);
					int numberOfCoordinates = tuple.Length;
					int j = 0;
					string[][] tuples = new string[numberOfCoordinates][];
					foreach (object f in tmpFo)
					{
						formula = f.ToString();
						tuple = CreateCoordArray(formula);

						for (int i = 0; i < numberOfCoordinates; i++)
						{
							if (j == 0)
								tuples[i] = new string[numberOfCells];

							tuples[i][j] = tuple[i];
						}
						j++;
					}

					Jedox.Palo.Comm.Connection c = Apalo.XlAddin.Connections.GetConnection(conn);
					LockInfo li = c.CubeLock(db, cube, tuples);
					CurrentLockId = li.id;
					CurrentConnection = c;
					CurrentDb = db;
					CurrentCube = cube;
				}
				else
				{
					formula = fo.ToString();
					if (!CheckFormulaV(formula))
					{
						return;
					}

					string[] tuple = CreateCoordArray(formula, ref conn, ref db, ref cube, true);
					int numberOfCoordinates = tuple.Length;
					string[][] tuples = new string[numberOfCoordinates][];
					for (int i = 0; i < numberOfCoordinates; i++)
					{
						tuples[i] = new string[] { tuple[i]};
					}

					Jedox.Palo.Comm.Connection c = Apalo.XlAddin.Connections.GetConnection(conn);
					LockInfo li = c.CubeLock(db, cube, tuples);
					CurrentLockId = li.id;
					CurrentConnection = c;
					CurrentDb = db;
					CurrentCube = cube;
				}

				// disable further locking
				this.tbBeginUndo.Enabled = false;
				this.tbCommit.Enabled = true;
				this.tbRollback.Enabled = true;
				this.tbUndo.Enabled = true;
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error Locking Cell.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				ExcelHelper.SetCalculation(tmpCalculation);
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
			}
		}
		#endregion

		#region Other clicks
		private void mItemModeller_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
				{
						try
						{
								thisThread.CurrentCulture = new CultureInfo("en-US");
								thisThread.CurrentUICulture = new CultureInfo("en-US");

								if( this.MainForm == null )
								{
										// show main form
										this.MainForm = new Apalo.XlAddin.Forms.Modeller(this.originalCulture);
										this.MainForm.Tag = "Main Form Window";
								}
								this.MainForm.ShowDialog();
								this.MainForm.Hide();
						}
						catch(Exception e)
						{
								ErrorHandler.DisplayError("Error Initialising Modeller Form Window.", e);
						}
						finally
						{
				// Restore the culture information for the thread after the
								// Excel calls have completed.
								this.thisThread.CurrentCulture = this.originalCulture;
								this.thisThread.CurrentUICulture = this.originalUICulture;
						}
				}

		private void mItemImportWizard_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
			{
			bool? tmpEnableEvt = true;

						try
						{
								this.thisThread.CurrentCulture = new CultureInfo("en-US");
								this.thisThread.CurrentUICulture = new CultureInfo("en-US");

				if (!NotInEditMode())
				{
					return;
				}

				tmpEnableEvt = ExcelHelper.EnableEvents(false);
                if (tmpEnableEvt == null)
                    return;

								if( this.ImportForm == null )
								{
										// show main form
										this.ImportForm = new Apalo.XlAddin.Forms.ImportWizard(originalCulture.NumberFormat.CurrencyDecimalSeparator, this.originalCulture);
										this.ImportForm.Tag = "Import Form Window";
								}
								else
								{
										this.ImportForm.reinit();
								}
								this.ImportForm.ShowDialog();
						}
						catch(Exception e)
						{
								ErrorHandler.DisplayError("Error Initialising Import Wizard Window.", e);
						}
						finally
						{
				this.ImportForm.clean_up();
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
				ExcelHelper.EnableEvents(tmpEnableEvt);

				// Restore the culture information for the thread after the
								// Excel calls have completed.
								this.thisThread.CurrentCulture = this.originalCulture;
								this.thisThread.CurrentUICulture = this.originalUICulture;
						}
				}

		private void mItemPasteElements_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
				{
			Excel.XlCalculation oldcalculation = Excel.XlCalculation.xlCalculationManual;

			try
						{
								this.thisThread.CurrentCulture = new CultureInfo("en-US");
								this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				this.ScreenUpdating = ExcelHelper.GetScreenUpdating();

				if (!NotInEditMode())
				{
					return;
				}

				oldcalculation = ExcelHelper.DisableAutomaticRecalc();

				if (this.PasteElementsForm == null)
								{
										// show main form
					this.PasteElementsForm = new Apalo.XlAddin.Forms.PasteElements2();
					this.PasteElementsForm.Tag = "Paste Dimensions Window";
								}
				this.PasteElementsForm.set_default();
				this.PasteElementsForm.ShowDialog();
						}
						catch(Exception e)
						{
								ErrorHandler.DisplayError("Error Initialising Paste Dimensions Form Window.", e);
						}
						finally
						{
								// Restore the culture information for the thread after the
								// Excel calls have completed.
				if ((oldcalculation != ExcelHelper.GetCalculation()))
				{
					ExcelHelper.SetCalculation(oldcalculation);
				}
				ExcelHelper.SetScreenUpdating(true);
				ExcelHelper.SetScreenUpdating(this.ScreenUpdating);
								this.thisThread.CurrentCulture = this.originalCulture;
								this.thisThread.CurrentUICulture = this.originalUICulture;
						}
				}

		private void mItemPaloWizard_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
				{
						try
						{
								this.thisThread.CurrentCulture = new CultureInfo("en-US");
								this.thisThread.CurrentUICulture = new CultureInfo("en-US");

				if (Apalo.XlAddin.Connect.WizardForm == null)
								{
										// show main form
										Apalo.XlAddin.Connect.WizardForm = new Apalo.XlAddin.Forms.PaloWizard();
										Apalo.XlAddin.Connect.WizardForm.Tag = "Database Wizard Window";
								}
								Apalo.XlAddin.Connect.WizardForm.ShowDialog();
						}
						catch(Exception e)
						{
				ErrorHandler.DisplayError("Error Initialising Database Wizard Window.", e);
						}
						finally
						{
								// Restore the culture information for the thread after the
								// Excel calls have completed.
								this.thisThread.CurrentCulture = this.originalCulture;
								this.thisThread.CurrentUICulture = this.originalUICulture;
						}
				}

		private void mItemPasteFunctions_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
				{
			ExcelHelper eH = null;

						try
						{
								this.thisThread.CurrentCulture = new CultureInfo("en-US");
								this.thisThread.CurrentUICulture = new CultureInfo("en-US");

				if (!NotInEditMode())
				{
					return;

				}

				eH = new ExcelHelper();

				ArrayList opts = new ArrayList();
				if (this.PasteFunctionsForm == null)
								{
										// show main form
										this.PasteFunctionsForm = new Apalo.XlAddin.Forms.PasteFunction(ref opts);
										this.PasteFunctionsForm.Tag = "Paste Function Window";
								}
								else
								{
										this.PasteFunctionsForm.set_default(ref opts);
								}
								this.PasteFunctionsForm.ShowDialog();

				if (opts.Count > 0)
				{
					this.ScreenUpdating = ExcelHelper.GetScreenUpdating();
					ExcelHelper.SetScreenUpdating(false);
					ProvokeSelectionChange();
					ExcelHelper.SetScreenUpdating(true);
					ExcelHelper.SetScreenUpdating(this.ScreenUpdating);
				}
						}
						catch(Exception e)
						{
								ErrorHandler.DisplayError("Error Initialising Paste Functions Form Window.", e);
						}
						finally
						{
								// Restore the culture information for the thread after the
								// Excel calls have completed.
								this.thisThread.CurrentCulture = this.originalCulture;
								this.thisThread.CurrentUICulture = this.originalUICulture;
						}
				}

		private void mItemPasteView_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			 Excel.XlCalculation oldcalculation = Excel.XlCalculation.xlCalculationManual;

			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				this.ScreenUpdating = ExcelHelper.GetScreenUpdating();

				if (!NotInEditMode())
				{
					return;
				}

				oldcalculation = ExcelHelper.DisableAutomaticRecalc();

				if (this.FrmPasteView == null)
				{
					// show main form
					this.FrmPasteView = new Apalo.XlAddin.Forms.FrmPasteView();
					this.FrmPasteView.Tag = "Pivot Window";
				}
				this.FrmPasteView.ShowDialog();
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error Initialising Paste View Form Window.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				if ((oldcalculation != ExcelHelper.GetCalculation()))
				{
					ExcelHelper.SetCalculation(oldcalculation);
				}
				ExcelHelper.SetScreenUpdating(true);
				ExcelHelper.SetScreenUpdating(this.ScreenUpdating);
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
			}
		}

		private void mItemAbout_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
				{
			DisplayInfoBox();
				}

		[ComVisible(true)]
		public void DisplayInfoBox()
		{
			InfoBox a = new InfoBox();
			a.displayLicensePage = false;
			// special way for handling open demo
			if (a.ShowDialog() == System.Windows.Forms.DialogResult.Retry)
			{
				string demoPath = RegUtils.GetStringValue(@"TemplatePath") + @"\\mis.xls";

				try
				{
					this.thisThread.CurrentCulture = new CultureInfo("en-US");
					this.thisThread.CurrentUICulture = new CultureInfo("en-US");
					Connect.OpenSpecialCase = true;
					ExcelHelper.oExcelApp.Run("PALO.EXCEL.OPEN", demoPath, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);
				}
				catch (Exception e)
				{
					ErrorHandler.DisplayError("Error opening demofile .", e);
				}
				finally
				{
					// Restore the culture information for the thread after the
					// Excel calls have completed.
					this.thisThread.CurrentCulture = this.originalCulture;
					this.thisThread.CurrentUICulture = this.originalUICulture;
				}
			}
			a.Dispose();
			a = null;
		}

		private void mItemLogIn_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			Forms.PaloOnline a = new Forms.PaloOnline();
			a.ShowDialog();
			a.Dispose();
			a = null;
		}

		private void mItemBasicHelp_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			try
			{
				System.Diagnostics.Process.Start(firstStepsURL);
			}
			catch
			{ }
		}

		public static void myPalo()
		{
			PaloWebClient wc = new PaloWebClient();

			string u = Crypto.DESd(RegUtils.PaloOnlineUsername);
			string p = Crypto.DESd(RegUtils.PaloOnlinePassword);
			// first step - login per POST = fetch SID
			string sid = wc.StringGetWebPage(myPaloLoginURL + "login.php?login", "username=" + u + "&password=" + p);

			// open the page per GET
			System.Diagnostics.Process.Start(myPaloLoginURL + "login.php?sid=" + sid + "&lang=" + PaloOnlineLanguage);

			wc = null;
		}

		private void mItemAdvancedHelp_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			myPalo();
		}

		private void mItemSaveAsSnapshot_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
				{
						try
						{
								this.thisThread.CurrentCulture = new CultureInfo("en-US");
								this.thisThread.CurrentUICulture = new CultureInfo("en-US");

				if (!NotInEditMode())
				{
					return;
				}

				ExcelHelper.SaveAsSnapshot();
						}
						catch(Exception e)
						{
								ErrorHandler.DisplayError("Error Initialising Paste View Form Window.", e);
						}
						finally
						{
								// Restore the culture information for the thread after the
								// Excel calls have completed.
								this.thisThread.CurrentCulture = this.originalCulture;
								this.thisThread.CurrentUICulture = this.originalUICulture;
						}
				}

		private void mItemDrillRule_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				this.mItemDrillRule.Enabled = false;
				Excel.Range range = ExcelHelper.GetActiveCell();

				object fo = range.Formula;
				string formula = "";

				if (fo.GetType().IsArray)
				{
					object[,] foa = (object[,])fo;
					formula = foa[1, 1].ToString();
				}
				else
				{
					formula = fo.ToString();
				}

				if (CheckFormula(formula))
				{
					ExcelHelper eH = new ExcelHelper();
					Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
					string connString = "";
					string conn = "";
					string db = "";
					string cube = "";

					connString = eH.get_params(formula, 1, true);
					connString = eH.get_value(connString, ws);
					int lenght = connString.IndexOf('/');
					conn = connString.Substring(0, lenght);
					db = connString.Substring(lenght + 1);

					cube = eH.get_params(formula, 2, true);
					cube = eH.DeEscapeDoubleQuote(eH.get_value(cube, ws));

					formula = formula.Substring(formula.IndexOf('(') + 1);
					formula = formula.Substring(0, formula.Length - 1);
					string[] b = formula.Split(',');
					if (b.LongLength == 1)
					{
						b = formula.Split(';');
					}
					string[] coords = new string[b.LongLength - 2];
					for (int i = 0; i < b.Length; i++)
					{
						if (i > 1)
						{
							string s = b[i];
							if (s.IndexOf(':') > -1)
							{
								System.Windows.Forms.MessageBox.Show("This doesn't work for Datav");
								return;
							}
							coords[i - 2] = eH.DeEscapeDoubleQuote(eH.get_value(s, ws));
						}
					}

					Jedox.Palo.Comm.Connection c = Apalo.XlAddin.Connections.GetConnection(conn);
					RuleInfo ri = c.CellRuleInformation(db, cube, coords);

					if (ri.id == -1)
					{
						System.Windows.Forms.MessageBox.Show("There's no rule for this cell");
						return;
					}

					Forms.InformationDialog idd = new Forms.InformationDialog();

					idd.Title = "Rule Info";

					idd.l1 = "activated";
					idd.v1 = ri.activated.ToString();

					idd.l2 = "comment";
					idd.v2 = (!String.IsNullOrEmpty(ri.comment)) ? ri.comment.ToString() : " ";

					idd.l3 = "definition";
					idd.v3 = ri.definition.ToString();

					idd.l4 = "extern_id";
					idd.v4 = (!String.IsNullOrEmpty(ri.extern_id)) ? ri.extern_id.ToString() : " ";

					idd.l5 = "id";
					idd.v5 = ri.id.ToString();

					idd.l6 = "timestamp";
					idd.v6 = ri.timestamp.ToString();

					idd.ShowDialog(true);
					idd.Dispose();
					idd = null;
				}
				else
				{
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ProcessError("Error getting Rule Information.", e);
				ErrorHandler.ErrorPopup(e.Message);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
				this.mItemDrillRule.Enabled = true;
			}
		}

		private void mItemDrillThrough_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{
			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");
				this.mItemDrillThrough.Enabled = false;
				Excel.Range range = ExcelHelper.GetActiveCell();

				object fo = range.Formula;
				string formula = "";

				if (fo.GetType().IsArray)
				{
					object[,] foa = (object[,])fo;
					formula = foa[1, 1].ToString();
				}
				else
				{
					formula = fo.ToString();
				}

				if (CheckFormula(formula))
				{
					ExcelHelper eH = new ExcelHelper();
					Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();
					string connString = "";
					string conn = "";
					string db = "";
					string cube = "";

					connString = eH.get_params(formula, 1, true);
					connString = eH.get_value(connString, ws);
					int lenght = connString.IndexOf('/');
					conn = connString.Substring(0, lenght);
					db = connString.Substring(lenght + 1);

					cube = eH.get_params(formula, 2, true);
					cube = eH.DeEscapeDoubleQuote(eH.get_value(cube, ws));

					formula = formula.Substring(formula.IndexOf('(') + 1);
					formula = formula.Substring(0, formula.Length - 1);
					string[] b = formula.Split(',');
					if (b.LongLength == 1)
					{
						b = formula.Split(';');
					}
					string[] coords = new string[b.LongLength - 2];
					for (int i = 0; i < b.Length; i++)
					{
						if (i > 1)
						{
							string s = b[i];
							coords[i - 2] = eH.DeEscapeDoubleQuote(eH.get_value(b[i], ws));
						}
					}
                    
                    #if NOTUSED     // JMM 09-01-15 Temporarily removed for compability with Palo 5.1 libraries:
					Jedox.Palo.Comm.Connection c = Apalo.XlAddin.Connections.GetConnection(conn);
					Jedox.Palo.Comm.SuperVisionServerInfo svs = c.SVSInformation();
					if (svs.SVSActive == true && svs.DrillThroughEnabled == true)
					{
						Jedox.Palo.Comm.DrillThroughSet[] dts = c.CellDrillThrough(db, cube, coords, DrillThroughType.Details);

						if (dts.Length > 2)
						{
							int wbExists = -1;
							Excel._Workbook wb;
							for (int i = 1; i <= ExcelHelper.oExcelApp.Workbooks.Count; i++)
							{
								Excel.Workbook twb = ExcelHelper.oExcelApp.Workbooks[i];
								if (!twb.Title.Equals("[DrillThrough]", StringComparison.InvariantCultureIgnoreCase))
									continue;
								else
								{
									wbExists = i;
									wb = (Excel._Workbook)ExcelHelper.oExcelApp.Workbooks[wbExists];
									wb.Activate();
									break;
								}
							}

							if (wbExists == -1)
							{
								wb = ExcelHelper.oExcelApp.Workbooks.Add(o);
								wb.Title = "[DrillThrough]";
							}

							for (int i = 0; i < dts.Length; i++)
							{
								string line = dts[i].Items[0];
								if (line.Length > 4)
								{
									line = line.Replace("\"", "");
									ExcelHelper.oExcelApp.Run("PALO.WRITE_ARRAY", line.Split(';'), 255, i, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o, o);
								}
							}
						}
						else
						{
							System.Windows.Forms.MessageBox.Show("No data returned for this area.", "Drill Through", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
						}
					}
                    #endif
				}
				else
				{
					this.mItemDrillThrough.Enabled = false;
				}
			}
			catch (Exception e)
			{
				ErrorHandler.ErrorPopup(e.Message);
				ErrorHandler.DisplayError("Error getting Drill through Information.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
			}
		}

		private void mItemPasteSubset_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
		{

			try
			{
				this.thisThread.CurrentCulture = new CultureInfo("en-US");
				this.thisThread.CurrentUICulture = new CultureInfo("en-US");

				if (NotInEditMode() == false)
				{
					return;
				}

				SubSetEditor ast = new SubSetEditor(EditorType.GlobalAndLocal, "", "", "");

				try
				{
					Excel.Range eR = ExcelHelper.GetFormulaArrayFromSelection();

					string formula = (eR.Count == 1) ? eR.Formula.ToString() : eR.FormulaArray.ToString();

					if (!String.IsNullOrEmpty(formula))
					{
						XmlDocument xmlDoc = Subset.Parser.ExcelFormulaParser.ConvertToSubsetXml(formula);
						StringBuilder sb = new StringBuilder();
						XmlWriter xmlWriter = XmlWriter.Create(sb);
						xmlDoc.WriteTo(xmlWriter);
						xmlWriter.Close();
						ast.aSubSet.SetSubsetFromXml_Safe(sb.ToString());
					}
				}
				catch(Exception ex)
				{
					ErrorHandler.DisplayError("Error Parsing for Subset Formula.", ex);
				}

				ast.ShowDialog();
				ast.Dispose();
				ast = null;
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error calling Subsets Editor.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				this.thisThread.CurrentCulture = this.originalCulture;
				this.thisThread.CurrentUICulture = this.originalUICulture;
			}
		}
		#endregion


		#endregion


		#region Other events
		public void OnConnection(object Application, Extensibility.ext_ConnectMode ConnectMode, object AddInInst, ref System.Array custom)
				{
			// JMM 03-30-14
			applicationObject = (Excel.Application)Application;
			ExcelHelper.RegisterExcel((Excel.Application)applicationObject);
			if(ConnectMode != Extensibility.ext_ConnectMode.ext_cm_Startup)
						{
						OnStartupComplete(ref custom);
						}

			// JMM 03-30-14 Add VSTO Interface:
			applicationObject.COMAddIns.Item("Apalo.XlAddin.Connect").Object = this;
				}

				public void OnDisconnection(Extensibility.ext_DisconnectMode RemoveMode, ref System.Array custom)
				{
			//	JMM 03-30-14 Moved to OnBeginShutdown
			#if NOTUSED
			try
			{
				// set current thread's culture to en-US
				thisThread.CurrentCulture = new CultureInfo("en-US");
				thisThread.CurrentUICulture = new CultureInfo("en-US");
				if (applicationObject != null)
					applicationObject.OnKey("+{F9}", Type.Missing);
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error resetting Shift F9 handler !", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				thisThread.CurrentCulture = originalCulture;
				thisThread.CurrentUICulture = originalUICulture;
			}
			#endif

			#region Disable if Add-in disabled
			if ((int)RegUtils.Active == 0)
			{
				return;
			}
			#endregion

						if(RemoveMode != Extensibility.ext_DisconnectMode.ext_dm_HostShutdown)
						{
								OnBeginShutdown(ref custom);
						}
						applicationObject = null;
			ResourceInitializer = null;
				}

				public void OnAddInsUpdate(ref System.Array custom)
				{
				}

				#endregion


		#region OnLoad
		public static void Checkinit()
		{
			if (!isInitialized)
			{
				SimpleInit();
			}

		}

		public static void SimpleInit()
		{
			try
			{
				// Instantiate SubsetUtils
				SubsetUtils.Instance();

				// Initialise Registry entries and set some defaults
				RegUtils.Init();
				XmlUtils.ReadXmlInitial();
				Connections.init();

				// Load resources for the current Excel Language
				ResourceInitializer = new ResourceInitializer(new System.Globalization.CultureInfo(RegUtils.ActiveLanguage));

				isInitialized = true;

			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error while doing simple init", e);
			}
		}


		private void Initiliaze()
		{
			try
			{
				SimpleInit();

				try
					{
					System.Windows.Forms.Application.EnableVisualStyles();
					System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
					}
				catch (Exception)
					{
					}
			}
			catch(Exception e)
			{
				ErrorHandler.DisplayError("Error while doing initialisation", e);
			}
		}

		public void OnStartupComplete(ref Array custom)
			{
		    //	JMM 09-24-13 Added for testing:
		    #if DEBUG
            if (RegUtils.DebugBreak)
		        System.Windows.Forms.MessageBox.Show("Loading Apalo Excel Addin", "Debug");
		    #endif

            //  Insure OpenSSL is available:
            if (findFile("libeay32.dll") == null)
                ErrorHandler.DisplayError("Error starting Apalo", "OpenSSL is not installed. This is a required prerequisite for Apalo.", null);

			#region Init

			Initiliaze();

			#region Disable if Add-in disabled
			if ((int)RegUtils.Active == 0)
			{
				return;
			}
			#endregion

			Thread thisThread = Thread.CurrentThread;
			CultureInfo originalCulture = thisThread.CurrentCulture;
			CultureInfo originalUICulture = thisThread.CurrentUICulture;

			try
			{
				thisThread.CurrentCulture = new CultureInfo("en-US");
				thisThread.CurrentUICulture = new CultureInfo("en-US");
				ExcelHelper.RegisterExcel((Excel.Application)applicationObject);
			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error setting eapp", e);
			}

			this.o = System.Reflection.Missing.Value;
			InPaste = true;

			#region Major check for DisableModeller
			#if NOTUSED
			string sSourceData = "84553ce29d06ca9211e028fd38a3f0a9" + RegUtils.GetStringValue(GeneralConst.LOG_FILE_PATH).Replace('\\', '|');
			string tmpStr = Crypto.MD5(sSourceData);
			sSourceData = RegUtils.GetStringValue("DisableModeller");
			DisableModeller = !tmpStr.Equals(sSourceData, StringComparison.InvariantCultureIgnoreCase);
			#endif
			#endregion

			#endregion

			#region Disable if Add-in disabled
			if ((int)RegUtils.Active == 0)
			{
				return;
			}
			#endregion

						#region Menu Items

						Office.CommandBars oCommandBars;
						Office.CommandBar oMenuBar;
						Office.CommandBar oContextBar;

			bool enablePaloweb = (GeneralConst.isNewExcel() || RegUtils.CompatibilityPackInstalled());

						oCommandBars = (Office.CommandBars)applicationObject.GetType().InvokeMember("CommandBars", BindingFlags.GetProperty , null, applicationObject ,null, System.Globalization.CultureInfo.InvariantCulture);
						oMenuBar = oCommandBars["Worksheet Menu Bar"];

						#region Context Menu / PaloError

						oContextBar = oCommandBars["Cell"];
						try
			{
				#region Drill
				this.mItemContextPasteView = (Office.CommandBarButton)oContextBar.Controls.Add(Office.MsoControlType.msoControlButton, o, o, oContextBar.Controls.Count + 1, true);
				this.mItemContextPasteView.Caption = ResourceInitializer.MENU_PASTE_VIEW;
				this.mItemContextPasteView.Tag = "Paste View Context";
				this.mItemContextPasteView.Enabled = true;
				this.mItemContextPasteView.Visible = true;
				this.mItemContextPasteView.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemContextPasteView.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(mItemPasteView_Click);
				this.mItemContextPasteView.BeginGroup = true;
				this.mItemContextPasteView.FaceId = 457;

				this.mItemDrillRule = (Office.CommandBarButton)oContextBar.Controls.Add(Office.MsoControlType.msoControlButton, o, o, oContextBar.Controls.Count + 1, true);
				this.mItemDrillRule.Caption = "Drill Palo Rule";
				this.mItemDrillRule.Tag = "Drill Palo Rule";
				this.mItemDrillRule.Enabled = false;
				this.mItemDrillRule.Visible = true;
				this.mItemDrillRule.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemDrillRule.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(mItemDrillRule_Click);
				this.mItemDrillRule.BeginGroup = true;
				this.mItemDrillRule.FaceId = 385;

				this.mItemDrillThrough = (Office.CommandBarButton)oContextBar.Controls.Add(Office.MsoControlType.msoControlButton, o, o, oContextBar.Controls.Count + 1, true);
				this.mItemDrillThrough.Caption = "Drill Through";
				this.mItemDrillThrough.Tag = "Drill Through";
				this.mItemDrillThrough.Enabled = false;
				this.mItemDrillThrough.Visible = true;
				this.mItemDrillThrough.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemDrillThrough.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(mItemDrillThrough_Click);
				this.mItemDrillThrough.BeginGroup = false;
				this.mItemDrillThrough.FaceId = 107;

				this.mItemDrillHistory = (Office.CommandBarButton)oContextBar.Controls.Add(Office.MsoControlType.msoControlButton, o, o, oContextBar.Controls.Count + 1, true);
				this.mItemDrillHistory.Caption = "Drill History";
				this.mItemDrillHistory.Tag = "Drill History";
				this.mItemDrillHistory.Enabled = false;
				this.mItemDrillHistory.Visible = true;
				this.mItemDrillHistory.OnAction = "!<Apalo.XlAddin.Connect>";
				//this.mItem10.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemDrillHistory_Click);
				this.mItemDrillHistory.BeginGroup = false;
				this.mItemDrillHistory.FaceId = 125;

				#endregion

				#region Error
				//Comm.CommandBarButton test = (Office.CommandBarButton)oContextBar.Controls.Add(Office.MsoControlType.msoControlButton, o, o, mItem9.Controls.Count + 1, true);
				//MsoBarTypePopup d = mItem9.Controls.Add(
								this.mItemError = (Office.CommandBarButton)oContextBar.Controls.Add(Office.MsoControlType.msoControlButton, o, o, oContextBar.Controls.Count + 1, true);
								this.mItemError.Caption = ResourceInitializer.XLL_ERROR_TITLE;
								this.mItemError.Tag = "Error Message";
								this.mItemError.Visible = true;
								this.mItemError.OnAction = "!<Apalo.XlAddin.Connect>";
								this.mItemError.Click +=new Office._CommandBarButtonEvents_ClickEventHandler(mItemError_Click);
								this.mItemError.BeginGroup = true;

								try
								{
										this.mItemError.FaceId = 202;
								}
								catch(COMException)// e1)
								{
										//ErrorHandler.DisplayError("Icon missing - 1", e1);
				}

				#endregion
			}
						catch(COMException excContextMenuItems)
						{
								ErrorHandler.DisplayError("Error initialising context menu", excContextMenuItems);
						}

						#endregion

						try
						{
								int count = oMenuBar.Controls.Count;
								int position = count;

				if (count > 3)
				{
					position = count - 3;
				}

								int tmpCounter = 0;

								for(int i = 1;i <= count;i++)
								{
					if (oMenuBar.Controls[i].Visible && (oMenuBar.Controls[i].Id > 30000))
					{
						tmpCounter++;
					}

										if(oMenuBar.Controls[i].Id == 30007)
										{
												position = tmpCounter + 1;
												break;
										}
								}

								this.olapMenu = (Office.CommandBarPopup) oMenuBar.Controls.Add(Office.MsoControlType.msoControlPopup, o, o, position, true);

				// very important to keep this one "Palo"
				// othervise ribbon will not work
				// has to stay like this for now
				this.olapMenu.Caption = "Palo"; // ResourceInitializer.MENU_TITLE;
								this.olapMenu.Tag = "Palo Menu Bar";
								Office.CommandBar newMenu = this.olapMenu.CommandBar;

				#region Paste View new

				this.mItemPasteView = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				this.mItemPasteView.Caption = ResourceInitializer.MENU_PASTE_VIEW;
				this.mItemPasteView.Tag = "Pivot button";
				this.mItemPasteView.Visible = true;
				this.mItemPasteView.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemPasteView.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteView_Click);
				try
				{
					this.mItemPasteView.FaceId = 457;
				}
				catch
				{
				}

				#endregion

				#region Paste Elements
				this.mItemPasteElements = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
								this.mItemPasteElements.BeginGroup = true;
								this.mItemPasteElements.Caption = ResourceInitializer.MENU_PASTE_ELEMENTS;//"Paste &Elements...";
								this.mItemPasteElements.Tag = "Paste Elements Button";
								this.mItemPasteElements.Visible = true;
								this.mItemPasteElements.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemPasteElements.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteElements_Click);
								try
								{
										this.mItemPasteElements.FaceId = 371;
								}
								catch(COMException)// e2)
								{
										//ErrorHandler.DisplayError("Icon missing - 2", e2);
				}
				#endregion

				#region PasteSubset
				this.mItemPasteSubset = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				this.mItemPasteSubset.BeginGroup = false;
				this.mItemPasteSubset.Caption = ResourceInitializer.MENU_PASTE_SUBSET;
				this.mItemPasteSubset.Tag = "Paste SubSets Button";
				this.mItemPasteSubset.Visible = true;
				this.mItemPasteSubset.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemPasteSubset.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteSubset_Click);
				//this.mItem11.Enabled = false;
				try
				{
					this.mItemPasteSubset.FaceId = 3852;
				}
				catch (COMException)// e2)
				{
					//ErrorHandler.DisplayError("Icon missing - 2", e2);
				}
				#endregion

				#region Paste Functions
				this.mItemPasteFunctions = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
								this.mItemPasteFunctions.Caption = ResourceInitializer.MENU_PASTE_FUNCTION;//"Paste Data &Function...";
								this.mItemPasteFunctions.Tag = "Paste Functions Button";
								this.mItemPasteFunctions.Visible = true;
								this.mItemPasteFunctions.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemPasteFunctions.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteFunctions_Click);
								try
								{
										this.mItemPasteFunctions.FaceId = 385;
								}
								catch(COMException)// e3)
								{
										// ErrorHandler.DisplayError("Icon missing - 3", e3);
				}
				#endregion

				if (!DisableModeller)
				{
					#region Modeller
					this.mItemModeller = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
					this.mItemModeller.BeginGroup = true;
					this.mItemModeller.Caption = ResourceInitializer.MENU_MODELLER;//"&Modeller...";
					this.mItemModeller.Tag = "PALO Button";
					this.mItemModeller.Visible = true;
					this.mItemModeller.OnAction = "!<Apalo.XlAddin.Connect>";
					this.mItemModeller.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemModeller_Click);
					try
					{
						this.mItemModeller.FaceId = 1950;
					}
					catch (COMException)// e4)
					{
						//ErrorHandler.DisplayError("Icon missing - 4", e4);
					}
					#endregion

					#region Import Wizard
					this.mItemImportWizard = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
					this.mItemImportWizard.Caption = ResourceInitializer.MENU_DATA_IMPORT;//"Data &Import...";
					this.mItemImportWizard.Tag = "Data Import Button";
					this.mItemImportWizard.Visible = true;
					this.mItemImportWizard.OnAction = "!<Apalo.XlAddin.Connect>";
					this.mItemImportWizard.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemImportWizard_Click);
					try
					{
						this.mItemImportWizard.FaceId = 7433;
					}
					catch (COMException)
					{
						try
						{
							this.mItemImportWizard.FaceId = 3829;
						}
						catch (COMException)
						{ }
					}
					#endregion
				}
				else
				{
					#region Palo Wizard
					this.mItemPaloWizard = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
					this.mItemPaloWizard.BeginGroup = true;
					this.mItemPaloWizard.Caption = ResourceInitializer.MENU_PALO_WIZARD;//"Palo &Wizard...";
					this.mItemPaloWizard.Tag = "Database Wizard Button";
					this.mItemPaloWizard.Visible = true;
					this.mItemPaloWizard.OnAction = "!<Apalo.XlAddin.Connect>";
					this.mItemPaloWizard.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPaloWizard_Click);
					try
					{
						this.mItemPaloWizard.FaceId = 2138;
					}
					catch (COMException)
					{ }
					#endregion
				}


				#region Save As Snapshot
				this.mItemSaveAsSnapshot = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				this.mItemSaveAsSnapshot.Caption = ResourceInitializer.MENU_SAVE_SNAPSHOT;//"Paste &View...";
				this.mItemSaveAsSnapshot.Tag = "Snapshot button";
				this.mItemSaveAsSnapshot.Visible = true;
				this.mItemSaveAsSnapshot.BeginGroup = true;
				this.mItemSaveAsSnapshot.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemSaveAsSnapshot.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemSaveAsSnapshot_Click);
				try
				{
					this.mItemSaveAsSnapshot.FaceId = 3;
				}
				catch (COMException)
				{ }
				#endregion

				#region Palo Online Menu


				#region Palo Online SubMenu Item
				this.mItemPaloOnline = (Office.CommandBarPopup)newMenu.Controls.Add(Office.MsoControlType.msoControlPopup, o, o, o, true);
				this.mItemPaloOnline.Caption = ResourceInitializer.PaloOnlineMenu;
				this.mItemPaloOnline.Tag = "Palo Online Menu";
				this.mItemPaloOnline.Visible = true;
				this.mItemPaloOnline.BeginGroup = true;
				#endregion

				this.mItemLogIn = (Office.CommandBarButton)mItemPaloOnline.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				this.mItemLogIn.Caption = ResourceInitializer.PaloOnlineLogin;
				this.mItemLogIn.Tag = "Palo Online Login";
				this.mItemLogIn.Visible = true;
				this.mItemLogIn.BeginGroup = true;
				this.mItemLogIn.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemLogIn.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemLogIn_Click);
				try
				{
					this.mItemLogIn.FaceId = 505;
				}
				catch (COMException)
				{ }

				this.mItemLogOut = (Office.CommandBarButton)mItemPaloOnline.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				this.mItemLogOut.Caption = ResourceInitializer.PaloOnlineLogOut;
				this.mItemLogOut.Tag = "Palo Online Logout";
				this.mItemLogOut.Visible = false;
				this.mItemLogOut.BeginGroup = true;
				this.mItemLogOut.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemLogOut.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemLogIn_Click);
				try
				{
					this.mItemLogOut.FaceId = this.mItemLogIn.FaceId;
				}
				catch (COMException)
				{ }


				this.mItemBasicHelp = (Office.CommandBarButton)mItemPaloOnline.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				this.mItemBasicHelp.Caption = ResourceInitializer.PaloOnlineBasicHelp;
				this.mItemBasicHelp.Tag = "Palo Online Basic Help";
				this.mItemBasicHelp.Visible = true;
				this.mItemBasicHelp.BeginGroup = true;
				this.mItemBasicHelp.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemBasicHelp.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemBasicHelp_Click);
				try
				{
					this.mItemBasicHelp.FaceId = 168;
				}
				catch (COMException)
				{ }

				mItemAdvancedHelp = (Office.CommandBarButton)mItemPaloOnline.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
				mItemAdvancedHelp.Caption = ResourceInitializer.PaloOnlineAdvancedHelp;
				mItemAdvancedHelp.Tag = "Palo Online Advanced Help";
				mItemAdvancedHelp.Visible = true;
				mItemAdvancedHelp.BeginGroup = false;
				{
					string u = Crypto.DESd(RegUtils.PaloOnlineUsername);
					string p = Crypto.DESd(RegUtils.PaloOnlinePassword);
					mItemAdvancedHelp.Enabled = ((u.Length != 0) && (p.Length != 0));
				}

				mItemAdvancedHelp.OnAction = "!<Apalo.XlAddin.Connect>";
				mItemAdvancedHelp.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemAdvancedHelp_Click);
				try
				{
					mItemAdvancedHelp.FaceId = 610;
				}
				catch (COMException)
				{ }
				#endregion

				#region About
				this.mItemAbout = (Office.CommandBarButton)newMenu.Controls.Add(Office.MsoControlType.msoControlButton, o, o, o, true);
								this.mItemAbout.BeginGroup = true;
								this.mItemAbout.Caption = ResourceInitializer.MENU_ABOUT;//"&About";
								this.mItemAbout.Tag = "About Button";
								this.mItemAbout.Visible = true;
								this.mItemAbout.OnAction = "!<Apalo.XlAddin.Connect>";
				this.mItemAbout.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemAbout_Click);
				#endregion
			}
						catch(COMException excMenuItems)
						{
								ErrorHandler.DisplayError("Error initialising menu", excMenuItems);
						}

						#region Palo Tool Bar
						this.olapBar = oCommandBars.Add(Office.MsoControlType.msoControlPopup, o, o, true);
						this.olapBar.Name = "Palo";

						this.tbPasteView = (Microsoft.Office.Core.CommandBarButton) this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
						this.tbPasteView.Caption = this.mItemPasteView.Caption;
						this.tbPasteView.OnAction = this.mItemPasteView.OnAction;
						this.tbPasteView.FaceId = this.mItemPasteView.FaceId;
			this.tbPasteView.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteView_Click);

						this.tbPasteElements = (Microsoft.Office.Core.CommandBarButton) this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
						this.tbPasteElements.Caption = this.mItemPasteElements.Caption;
						this.tbPasteElements.OnAction = this.mItemPasteElements.OnAction;
						this.tbPasteElements.FaceId = this.mItemPasteElements.FaceId;
			this.tbPasteElements.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteElements_Click);

						this.tbPasteFunctions = (Microsoft.Office.Core.CommandBarButton) this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
						this.tbPasteFunctions.Caption = this.mItemPasteFunctions.Caption;
						this.tbPasteFunctions.OnAction = this.mItemPasteFunctions.OnAction;
						this.tbPasteFunctions.FaceId = this.mItemPasteFunctions.FaceId;
			this.tbPasteFunctions.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPasteFunctions_Click);

			if (!DisableModeller)
			{
				this.tbModeller = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
				this.tbModeller.Caption = this.mItemModeller.Caption;
				this.tbModeller.OnAction = this.mItemModeller.OnAction;
				this.tbModeller.FaceId = this.mItemModeller.FaceId;
				this.tbModeller.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemModeller_Click);

				this.tbImportWizard = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
				this.tbImportWizard.Caption = this.mItemImportWizard.Caption;
				this.tbImportWizard.OnAction = this.mItemImportWizard.OnAction;
				this.tbImportWizard.FaceId = this.mItemImportWizard.FaceId;
				this.tbImportWizard.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemImportWizard_Click);
			}
			else
			{
				this.tbPaloWizard = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
				this.tbPaloWizard.Caption = this.mItemPaloWizard.Caption;
				this.tbPaloWizard.OnAction = this.mItemPaloWizard.OnAction;
				this.tbPaloWizard.FaceId = this.mItemPaloWizard.FaceId;
				this.tbPaloWizard.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemPaloWizard_Click);
			}
			#region Commit/Rollback

			this.tbBeginUndo = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbBeginUndo.Caption = ResourceInitializer.MENU_BEGIN_UNDO;
			this.tbBeginUndo.Enabled = true;
			this.tbBeginUndo.FaceId = 51;
			this.tbBeginUndo.BeginGroup = true;
			this.tbBeginUndo.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tbBeginUndo_Click);

			this.tbUndo = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbUndo.Caption = ResourceInitializer.MENU_UNDO;
			this.tbUndo.Enabled = false;
			this.tbUndo.FaceId = 128;
			this.tbUndo.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tbUndo_Click);

			this.tbRollback = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbRollback.Caption = ResourceInitializer.MENU_ROLLBACK;
			this.tbRollback.Enabled = false;
			this.tbRollback.FaceId = 37;
			this.tbRollback.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tbRollback_Click);

			this.tbCommit = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbCommit.Caption = ResourceInitializer.MENU_COMMIT;
			this.tbCommit.Enabled = false;
			this.tbCommit.FaceId = 135;
			this.tbCommit.Click += new Office._CommandBarButtonEvents_ClickEventHandler(tbCommit_Click);

			#endregion

			#region Palo Online
			this.tbLogin = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbLogin.Caption = this.mItemLogIn.Caption;
			this.tbLogin.OnAction = this.mItemLogIn.OnAction;
			this.tbLogin.FaceId = this.mItemLogIn.FaceId;
			this.tbLogin.Visible = true;
			this.tbLogin.BeginGroup = true;
			this.tbLogin.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemLogIn_Click);

			this.tbLogOut = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbLogOut.Caption = this.mItemLogOut.Caption;
			this.tbLogOut.OnAction = this.mItemLogOut.OnAction;
			this.tbLogOut.FaceId = this.mItemLogOut.FaceId;
			this.tbLogOut.Visible = false;
			this.tbLogOut.BeginGroup = true;
			this.tbLogOut.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemLogIn_Click);

			this.tbBasicHelp = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			this.tbBasicHelp.Caption = this.mItemBasicHelp.Caption;
			this.tbBasicHelp.OnAction = this.mItemBasicHelp.OnAction;
			this.tbBasicHelp.FaceId = this.mItemBasicHelp.FaceId;
			this.tbBasicHelp.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemBasicHelp_Click);

			tbAdvancedHelp = (Microsoft.Office.Core.CommandBarButton)this.olapBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, o, o, o, true);
			tbAdvancedHelp.Caption = mItemAdvancedHelp.Caption;
			tbAdvancedHelp.OnAction = mItemAdvancedHelp.OnAction;
			tbAdvancedHelp.FaceId = mItemAdvancedHelp.FaceId;
			tbAdvancedHelp.Enabled = mItemAdvancedHelp.Enabled;
			tbAdvancedHelp.Click += new Office._CommandBarButtonEvents_ClickEventHandler(mItemAdvancedHelp_Click);
			#endregion

			#region Toolbar position handling
			switch ((int)RegUtils.PalobarPosition)
						{
								case RegUtils.IPOSBOTTOM:
					this.olapBar.Position = Office.MsoBarPosition.msoBarBottom;
										break;
								case RegUtils.IPOSFLOATING:
					this.olapBar.Position = Office.MsoBarPosition.msoBarFloating;
										break;
								case RegUtils.IPOSLEFT:
					this.olapBar.Position = Office.MsoBarPosition.msoBarLeft;
										break;
								case RegUtils.IPOSMENUBAR:
					this.olapBar.Position = Office.MsoBarPosition.msoBarMenuBar;
										break;
								case RegUtils.IPOSPOPUP:
					this.olapBar.Position = Office.MsoBarPosition.msoBarPopup;
										break;
								case RegUtils.IPOSRIGHT:
					this.olapBar.Position = Office.MsoBarPosition.msoBarRight;
										break;
								default:
					this.olapBar.Position = Office.MsoBarPosition.msoBarTop;
										break;
						}

			int itmp = (int)RegUtils.PalobarLeft;

						if (itmp >= 0)
						{
								this.olapBar.Left = itmp;
						}

			itmp = (int)RegUtils.PalobarTop;

						if (itmp >= 0)
						{
								this.olapBar.Top = itmp;
						}

			// always enable palobar, since I don't see how an user can enable it manually
			this.olapBar.Enabled = true;

			if (((int)RegUtils.PalobarVisible == 0) && !GeneralConst.isNewExcel())
						{
								this.olapBar.Visible = false;
						}
						else
						{
				this.olapBar.Visible = this.olapBar.Enabled;
			}
			#endregion

			#endregion

			oMenuBar = null;
						oCommandBars = null;

						#endregion

						#region ROT write

						try
						{
				// make sure we apear in the ROT Table
				ComInterface.GetConnection();
						}
			catch (Exception excMenuItems)
			{
				ErrorHandler.DisplayError("Error initialising menu", excMenuItems);
			}


						#endregion

						try
						{
								thisThread.CurrentCulture = new CultureInfo("en-US");
								thisThread.CurrentUICulture = new CultureInfo("en-US");

								#region Load XLL
								try
								{
										ExcelHelper.oExcelApp.Visible = true;
					ExcelHelper.SetExcelStatusbar(ResourceInitializer.STATUS_LOAD_XLL);
					Connection.InitSSL(RegUtils.GetTrustfile());

					// JMM 09-24-13
										string XllDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					//System.IO.Directory.GetCurrentDirectory();
					string XllFile = "";

					XllFile = (GeneralConst.isNewExcel()) ? XLL12_FILE : XLL_FILE;

					string XllPath = XllDir + "\\" + XllFile;

					if (!System.IO.File.Exists(XllPath))
										{
						XllDir = GeneralConst.ExecutePath;
												XllPath = XllDir + XllFile;
										}

					// JMM 09-24-13
					string OldPath = ExcelHelper.oExcelApp.DefaultFilePath;
					ExcelHelper.oExcelApp.DefaultFilePath = XllDir;

										if (!ExcelHelper.oExcelApp.RegisterXLL(XllPath))
										{
												Forms.About fA = new Forms.About(true, ResourceInitializer.Replace(ResourceInitializer.ERROR_LOADING_MESSAGE1, new object[]{ XllPath } ));
												fA.Activate();
												fA.ShowDialog();
												fA.Dispose();
												fA = null;
						ExcelHelper.oExcelApp.DefaultFilePath = OldPath;
						ExcelHelper.ResetExcelStatusbar();
						return;
										}
					ExcelHelper.oExcelApp.DefaultFilePath = OldPath;
					ExcelHelper.ResetExcelStatusbar();

										ExcelHelper.PaloEnableLoop(false);

								}
								catch(Exception e8)
								{
										ErrorHandler.DisplayError("Error loading XLL - 8", e8);
										Forms.About fA = new Forms.About(true, ResourceInitializer.ERROR_LOADING_MESSAGE2);
										fA.Activate();
										fA.ShowDialog();
										fA.Dispose();
										fA = null;
					return;
								}


								#endregion

				this.AttachEventHandlers(ExcelHelper.oExcelApp);
								this.check_menuitems(0);

				// JMM 2013-12-11 Removed
				#if NOTUSED
				Heartbeat();
				#endif
				//ErrorHandler.WriteToLog("This is a test");

				if (RegUtils.ShowInfoBox )
				{
					DisplayInfoBox();
				}

				try
				{
					ExcelHelper.oExcelApp.OnKey("+{F9}", "PALO.CALCSHEET");
				}
				catch (Exception e)
				{
					ErrorHandler.DisplayError("Error setting Shift F9 handler !", e);
				}
						}
						catch(Exception)// e10)
						{
								Forms.About fA = new Forms.About(true, ResourceInitializer.ERROR_LOADING_MESSAGE5);
								fA.Activate();
								fA.ShowDialog();
								fA.Dispose();
								fA = null;
						}
						finally
						{
								// Restore the culture information for the thread after the
								// Excel calls have completed.
								thisThread.CurrentCulture = originalCulture;
								thisThread.CurrentUICulture = originalUICulture;
						}
				}


        /// <summary>
        /// Helper function to locate a file, either in executing directory or on path
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns>Directory in which file is found.</returns>
        private string findFile(string FileName)
            {
            string FindFile = "ssleay32.dll";
            Assembly Me = Assembly.GetExecutingAssembly();
			string ExecPath = Path.GetDirectoryName(Me.Location);
            if (File.Exists(Path.Combine(ExecPath, FindFile)))
                return ExecPath;

            string[] Paths = Environment.GetEnvironmentVariable("PATH").Split(';');
            foreach (string PathName in Paths)
                {
                if (File.Exists(Path.Combine(PathName, FileName)))
                    return PathName;
                }

            return null;
            }
		#endregion


		#region OnUnload

		public void OnBeginShutdown(ref System.Array custom)
		{
			#region Disable if Add-in disabled
			if ((int)RegUtils.Active == 0)
			{
				return;
			}
			#endregion

						Thread thisThread = Thread.CurrentThread;
						CultureInfo originalCulture = thisThread.CurrentCulture;
						CultureInfo originalUICulture = thisThread.CurrentUICulture;

						try
						{
								thisThread.CurrentCulture = new CultureInfo("en-US");
								thisThread.CurrentUICulture = new CultureInfo("en-US");

				//	JMM 03-30-14
				if (applicationObject != null)
					{
					try
						{applicationObject.OnKey("+{F9}", Type.Missing);}
					catch (Exception) {}
					}

								#region Commit all changes
								try
								{
										ServiceController sc  = new ServiceController();
										sc.ServiceName = SERVICE_NAME;
										if(changesMade && sc.Status == ServiceControllerStatus.Running)
										{
						ExcelHelper.SetExcelStatusbar(ResourceInitializer.COMMITING_CHANGES);

						Jedox.Palo.Comm.Connection c = Apalo.XlAddin.Connections.GetConnection(LOCALHOST);
						Apalo.XlAddin.Connections.credentials cred = Apalo.XlAddin.Connections.GetCredentials(LOCALHOST);

						string user = cred.user, db, cube;
						string[] dbl = c.RootListDatabases(), cubel;
						int CntDb = dbl.Length, CntCube, i, j, k, countlocks;
						bool logwritten = false;

						LockInfo[] locks;

												for(i = 0;i < CntDb;i++)
												{
							db = dbl[i];
							cubel = c.DatabaseListCubes(db);
							CntCube = cubel.Length;

							for(j = 0;j < CntCube;j++)
														{
								cube = cubel[j];
								try
																{
									locks = c.CubeLocks(db, cube);
									countlocks = locks.Length;
									logwritten = false;
									for (k = 0; k < countlocks; k++)
									{
										if (locks[k].user == user)
										{
											if (!logwritten)
											{
												ErrorHandler.WriteToLog("Rollback locks for connection Localhost : database=" + db + " and cube=" + cube + " !\n");
												logwritten = true;
											}
											c.CubeRollback(db, cube, locks[k].id);
										}
									}
									c.CubeCommitLog(db, cube);
																}
																catch
																{}
														}

														c.DatabaseSave(db);
												}
										}
								}
#if DEBUG
								catch(Exception)
								{


				}
#else
				catch(Exception ExcStopService)
								{

					ErrorHandler.DisplayError("Commiting changes failed!", ExcStopService);
				}
#endif
								finally
								{
					ExcelHelper.ResetExcelStatusbar();
								}
								#endregion

								#region Close all connections
								try
								{
										Connections.CloseConnection(true);
								}
								catch(Exception ExcConnClose)
								{
										ErrorHandler.DisplayError("Close all connections failed!", ExcConnClose);
								}
								#endregion

								#region Write toolbar position into registry
								try
								{
										if (this.olapBar.Position == Office.MsoBarPosition.msoBarBottom)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSBOTTOM;
										}

					if (this.olapBar.Position == Office.MsoBarPosition.msoBarFloating)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSFLOATING;
										}

					if (this.olapBar.Position == Office.MsoBarPosition.msoBarLeft)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSLEFT;
										}

					if (this.olapBar.Position == Office.MsoBarPosition.msoBarMenuBar)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSMENUBAR;
										}

					if (this.olapBar.Position == Office.MsoBarPosition.msoBarPopup)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSPOPUP;
										}

					if (this.olapBar.Position == Office.MsoBarPosition.msoBarRight)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSRIGHT;
										}

					if (this.olapBar.Position == Office.MsoBarPosition.msoBarTop)
										{
						RegUtils.PalobarPosition = RegUtils.IPOSTOP;
										}

					RegUtils.PalobarLeft = this.olapBar.Left;
					RegUtils.PalobarTop = this.olapBar.Top;

										if (this.olapBar.Enabled)
										{
						RegUtils.PalobarEnabled = 1;
										}
										else
										{
						RegUtils.PalobarEnabled = 0;
										}

										if (this.olapBar.Visible)
										{
						RegUtils.PalobarVisible = 1;
										}
										else
										{
						RegUtils.PalobarVisible = 0;
										}
								}
								catch(Exception ExcWriteToolbarPos)
								{
										ErrorHandler.DisplayError("Writting toolbar position failed!", ExcWriteToolbarPos);
								}
								#endregion

								#region Destroy objects

								try
								{
										this.DeAttachEventHandlers(ExcelHelper.oExcelApp);
										this.mItemModeller = null;
										this.mItemImportWizard = null;
										this.mItemPasteElements = null;
										this.mItemPaloWizard = null;
										this.mItemPasteFunctions = null;
										this.mItemAbout = null;
										//this.mItem7 = null;
					this.mItemPasteView = null;
										this.mItemSaveAsSnapshot = null;
										this.tbModeller = null;
										this.tbImportWizard = null;
										this.tbPasteElements = null;
										this.tbPaloWizard = null;
										this.tbPasteFunctions = null;
										this.tbPasteView = null;
										if(this.applicationObject != null)
										{
												while( Marshal.ReleaseComObject( this.applicationObject ) > 0 );
												this.applicationObject = null;
										}

					ExcelHelper.UnRegisterExcel();

										this.ImportForm = null;
										this.MainForm = null;
										this.ImportForm = null;
										this.PasteElementsForm = null;
										this.PasteFunctionsForm = null;
										//this.PasteViewForm = null;

					// should help a bit against Password prompt (WSS2 / XLA)
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					GC.WaitForPendingFinalizers();
								}
								catch(Exception ExcObjectDest)
								{
										ErrorHandler.DisplayError("Destroying objects failed!", ExcObjectDest);
								}

								#endregion
						}
						catch(Exception ExcShutdown)
						{
								ErrorHandler.DisplayError("Error shuting down Palo Addin!", ExcShutdown);
						}
						finally
						{
								// Restore the culture information for the thread after the
								// Excel calls have completed.
								thisThread.CurrentCulture = originalCulture;
								thisThread.CurrentUICulture = originalUICulture;
						}
				}
				#endregion

				#region eApp_SheetBeforeDoubleClick
				private void eApp_SheetBeforeDoubleClick(object sh, Excel.Range range, ref bool doCancel)
				{
			if (range == null)
			{
				return;
			}

						Thread thisThread = Thread.CurrentThread;
						CultureInfo originalCulture = thisThread.CurrentCulture;
						CultureInfo originalUICulture = thisThread.CurrentUICulture;
			Excel.XlCalculation oldcalculation = Excel.XlCalculation.xlCalculationManual;
			ExcelHelper eH = null;

						try
						{
								thisThread.CurrentCulture = new CultureInfo("en-US");
								thisThread.CurrentUICulture = new CultureInfo("en-US");
				eH = new ExcelHelper();

				oldcalculation = ExcelHelper.DisableAutomaticRecalc();

				object fo = range.Formula;

								string formula = "";

				if (fo.GetType().IsArray)
				{
					object[,] foa = (object[,])fo;
					formula = foa[1, 1].ToString();
				}
				else
				{
					formula = fo.ToString();
				}

				if (CheckFormula(formula))
								{
					// Invoke String Editor
					if (this.CurrentStrValue != null && this.CurrentDblValue == 0)
					{
						Apalo.XlAddin.Forms.EditValue ev = new Apalo.XlAddin.Forms.EditValue();
						ev.Formula = CurrentFormula;
						ev.Value.Text = this.CurrentStrValue;
						ev.CheckValue();
						System.Windows.Forms.DialogResult tmpDr = ev.ShowDialog();
						ev.Dispose();
						ev = null;
						if (tmpDr == System.Windows.Forms.DialogResult.OK)
						{
							ExcelHelper.PaloEnableLoop(true);
							range.Calculate();
							ExcelHelper.PaloEnableLoop(false);
						}
					}
					else
					{
						mItemDrillThrough.Execute();
					}
					doCancel = true;
								}
				else if (formula.StartsWith("=PALO.ENAME(", true, CultureInfo.InvariantCulture))
								{
										string olapdb = "";
										string dim = "";
										string olapdborig = "";
										string dimorig = "";
										string elem = "";
										string formula_orig = formula;
										string dummy = "";
										int  length = 0;

					Excel.Worksheet ws = ExcelHelper.GetActiveWorkSheet();

										olapdborig = eH.get_params(formula,1,true);
										olapdb = eH.get_value(olapdborig, ws);

										dimorig = eH.get_params(formula,2, true);
										dim = eH.DeEscapeDoubleQuote(eH.get_value(dimorig, ws));
										elem = eH.get_params(formula,3);
										length = elem.Length;
										dummy = eH.get_params(formula,4);

										if ((length > 0) && (dummy != "2") && (dummy != "0"))
										{

						if (dummy == "3")
												{
							PasteUtils.do_doubleclick(range.Column , range.Row, oldcalculation);
							doCancel = true;
						}
												else
												{
														if (dummy == "1")
														{
								elem = eH.DeEscapeDoubleQuote(elem);
																Apalo.XlAddin.Forms.ChooseElements frmename = new Apalo.XlAddin.Forms.ChooseElements(olapdb, dim);
								frmename.set_default(elem, range, olapdborig, dimorig, eH.DeEscapeDoubleQuote(eH.get_params(formula_orig, 6)), eH.DeEscapeDoubleQuote(eH.get_params(formula_orig, 7)));
																System.Windows.Forms.DialogResult ret = frmename.ShowDialog();
																frmename.Dispose();
								frmename = null;

								if (ret == System.Windows.Forms.DialogResult.OK)
								{
									if (oldcalculation != ExcelHelper.GetCalculation())
									{
										ExcelHelper.SetCalculation(oldcalculation);
									}
								}
								doCancel = true;
														}
												}
										}
										else
										{
												if (dummy == "2")
												{
							if (this.FrmPasteView == null)
							{
								this.FrmPasteView = new Apalo.XlAddin.Forms.FrmPasteView();
							}
							this.FrmPasteView.DrawTableOnly();
							this.FrmPasteView.EditDimensionNode(dim, "", "", eH.DeEscapeDoubleQuote(eH.get_params(formula_orig, 6)));
							doCancel = true;
						}
										}
								}
								else
								{
										// check if this cell is empty and surrounding cells are ENAME
										// if so then display paste view
										if(formula.Length != 0)
										{
												return;
										}

										int x = range.Column;
										int y = range.Row;

										// we have a max of 14 dims per cube which makes check a bit easier
										if(x > 3 || y > 16)
										{
												return;
										}

										string tmpFormula = "";
										bool detectedDown = false;
										bool detectedRight = false;
										bool detectedUp = false;

										#region ROW CHECK
					Excel.Range tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[y + 1, x];
										object tmpFo = tmpRange.Formula;
					if (tmpFo.GetType().IsArray)
					{
						object[,] foa = (object[,])tmpFo;
						tmpFormula = foa[1, 1].ToString();
					}
					else
					{
						tmpFormula = tmpFo.ToString();
					}

					if (!tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).StartsWith("=PALO.ENAME("))
					{
						tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[y + 2, x];
						tmpFo = tmpRange.Formula;
						if (tmpFo.GetType().IsArray)
						{
							object[,] foa = (object[,])tmpFo;
							tmpFormula = foa[1, 1].ToString();
						}
						else
						{
							tmpFormula = tmpFo.ToString();
						}

						if (!tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).StartsWith("=PALO.ENAME("))
						{
							tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[y + 3, x];
							tmpFo = tmpRange.Formula;
							if (tmpFo.GetType().IsArray)
							{
								object[,] foa = (object[,])tmpFo;
								tmpFormula = foa[1, 1].ToString();
							}
							else
							{
								tmpFormula = tmpFo.ToString();
							}

							if (tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).StartsWith("=PALO.ENAME("))
							{
								detectedDown = true;
							}
						}
						else
						{
							detectedDown = true;
						}
					}
					else
					{
						detectedDown = true;
					}
										#endregion

										#region COLUMN CHECK
					tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[y, x + 1];
										tmpFo = tmpRange.Formula;
					if (tmpFo.GetType().IsArray)
					{
						object[,] foa = (object[,])tmpFo;
						tmpFormula = foa[1, 1].ToString();
					}
					else
					{
						tmpFormula = tmpFo.ToString();
					}

					if (!tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).StartsWith("=PALO.ENAME("))
					{
						tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[y, x + 2];
						tmpFo = tmpRange.Formula;
						if (tmpFo.GetType().IsArray)
						{
							object[,] foa = (object[,])tmpFo;
							tmpFormula = foa[1, 1].ToString();
						}
						else
						{
							tmpFormula = tmpFo.ToString();
						}

						if (!tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).StartsWith("=PALO.ENAME("))
						{
							tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[y, x + 3];
							tmpFo = tmpRange.Formula;
							if (tmpFo.GetType().IsArray)
							{
								object[,] foa = (object[,])tmpFo;
								tmpFormula = foa[1, 1].ToString();
							}
							else
							{
								tmpFormula = tmpFo.ToString();
							}

							if (tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).StartsWith("=PALO.ENAME("))
							{
								detectedRight = true;
							}
						}
						else
						{
							detectedRight = true;
						}
					}
					else
					{
						detectedRight = true;
					}
										#endregion

										if(!detectedDown || !detectedRight)
										{
												#region CONNECTION CHECK
						tmpRange = (Excel.Range)ExcelHelper.oExcelApp.Cells[1, 1];
												tmpFo = tmpRange.Formula;
						if (tmpFo.GetType().IsArray)
						{
							object[,] foa = (object[,])tmpFo;
							tmpFormula = foa[1, 1].ToString();
						}
						else
						{
							tmpFormula = tmpFo.ToString();
						}

						if (tmpFormula.ToUpper(System.Globalization.CultureInfo.InvariantCulture).LastIndexOf('/') != -1)
						{
							detectedUp = true;
						}

												#endregion
										}

										if( (detectedDown && detectedRight )
												|| (detectedDown && detectedUp)
												|| (detectedUp && detectedRight) )
										{
						if (!NotInEditMode())
						{
							return;
						}
						if (this.FrmPasteView == null)
						{
							// show main form
							this.FrmPasteView = new Apalo.XlAddin.Forms.FrmPasteView();
							this.FrmPasteView.Tag = "Pivot Window";
						}
						this.FrmPasteView.ShowDialog();
												doCancel = true;
										}
										tmpRange = null;
								}
						}
						catch(Exception ex)
						{
								ErrorHandler.DisplayError("Error handling doubleclick.", ex);
						}
						finally
						{
				if (oldcalculation != ExcelHelper.GetCalculation())
				{
					ExcelHelper.SetCalculation(oldcalculation);
				}

				// Restore the culture information for the thread after the
				// Excel calls have completed.
								thisThread.CurrentCulture = originalCulture;
								thisThread.CurrentCulture = originalUICulture;
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
			}
				}
				#endregion

				#region eApp_SheetActivate/eApp_WorkbookActivate/eApp_WorkbookDeactivate

				private void eApp_WorkbookActivate(Excel.Workbook ws)
				{
						this.check_menuitems(0);
						ProvokeSelectionChange();
				}

				private void eApp_WorkbookDeactivate(Excel.Workbook ws)
				{
			this.check_menuitems(-1);
		}

				private void eApp_SheetActivate(object Sh)
				{
			ProvokeSelectionChange();
			Excel._Worksheet ws = (Excel._Worksheet)(Sh);
			if (ExcelHelper.Test4Name(GeneralConst.PASTE_VIEW_X_CALC, true, ws) && (ExcelHelper.GetCalculation() == Excel.XlCalculation.xlCalculationAutomatic))
			{
				ExcelHelper.DataxCalc();
			}
				}

				private static void ProvokeSelectionChange()
				{
						// don't do anything if not doing it from addin
			if (InPaste == false)
			{
				return;
			}

						// get current thread's culture
						Thread thisThread = Thread.CurrentThread;
						CultureInfo originalCulture = thisThread.CurrentCulture;
						CultureInfo originalUICulture = thisThread.CurrentUICulture;
			bool tmpSu = false;

						try
						{
								// set current thread's culture to en-US
								thisThread.CurrentCulture = new CultureInfo("en-US");
								thisThread.CurrentUICulture = new CultureInfo("en-US");

				// set current ScreenUpdating;
				tmpSu = ExcelHelper.GetScreenUpdating();
							ExcelHelper.SetScreenUpdating(false);

								// provoke cell change on sheetchange
								Excel.Range tmpRng = ExcelHelper.GetSelection();
								Excel.Range newRng = (Excel.Range)ExcelHelper.oExcelApp.Cells[1,1];
								newRng.Select();
								tmpRng.Select();
						}
						catch
						{}

						ExcelHelper.SetScreenUpdating(tmpSu);
						thisThread.CurrentCulture = originalCulture;
						thisThread.CurrentCulture = originalUICulture;
				}

				#endregion

				#region eApp_SheetChange/eApp_SheetSelectionChange

		#region Helpers for eApp_SheetChange/eApp_SheetSelectionChange
		public static void SetCurrFormulaFromActiveCell()
		{
			Excel.Range ac = ExcelHelper.GetActiveCell();
			CurrentFormula = ExcelHelper.getFormulaFromSpreadsheet(ac);
			CurrentFormulaLocal = ExcelHelper.getFormulaLocalFromSpreadsheet(ac);
		}

		private string InsertNewline(string message)
		{
			string tmpstr = "", tmp = message;
			string[] tmpstrs = message.Split(new string[] { "\\n" }, System.StringSplitOptions.None);

			int slen = tmpstrs.Length;
			tmpstr = "";
			for (int i = 0; i < slen; i++)
			{
				tmpstr += tmpstrs[i] + '\n';
			}

			if (slen > 0)
			{
				tmpstr = tmpstr.Substring(0, tmpstr.Length - 1);
			}

			return tmpstr;
		}

		private void CalculateNumberBaseElement0(Jedox.Palo.Comm.Connection c, string db, string dim, int id, Hashtable ht, ref Hashtable ht2, ref double number)
		{
			if (!ht2.ContainsKey(id))
			{
				ht2[id] = true;
				ElementInfo eleminfo = (ElementInfo)ht[id];
				int i, childcount = eleminfo.Children.Length;
				if (childcount == 0)
				{
					number++;
				}
				else
				{
					for (i = 0; i < childcount; i++)
					{
						CalculateNumberBaseElement0(c, db, dim, eleminfo.Children[i].Identifier, ht, ref ht2, ref number);
					}
				}
			}
		}

		private double CalculateNumberBaseElement(Jedox.Palo.Comm.Connection c, string db, string dim, string element)
		{
			double number = 0;

			int id = -1;
			string cmpstr = element.ToUpper();
			ElementInfo[] elems = c.DimensionListElements(db, dim);
			ElementInfo elem;
			int i, elemscount = elems.Length;
			Hashtable ht = new Hashtable(elemscount), ht2 = new Hashtable(elemscount);

			for (i = 0; i < elemscount; i++)
			{
				elem = elems[i];

				if (elem.Identifier > -1)
				{
					ht[elem.Identifier] = elem;

					if (elem.Name.ToUpper() == cmpstr)
					{
						id = elem.Identifier;
					}
				}
			}

			CalculateNumberBaseElement0(c, db, dim, id, ht, ref ht2, ref number);
			return number;

		}

		private double CalculateNumberBaseCells(Jedox.Palo.Comm.Connection c, string db, string cube, string[] coord)
		{
			double number = 1;

			string[] dims = c.CubeListDimensions(db, cube);
			int dimcount = dims.Length, i;

			for (i = 0; i < dimcount; i++)
			{
				number *= CalculateNumberBaseElement(c, db, dims[i], coord[i].ToUpper());
			}

			return number;
		}

		private double CalculateValueByPercent(Jedox.Palo.Comm.Connection c, double percvalue, string db, string cube, string[] coords)
		{
			double tmpDblVal = 0.0, progress = 0;
			long anzahl = coords.Length;
			GetDataExportOptions opts = new GetDataExportOptions();
				String[][] dimelements = new String[anzahl][];

			for (int i = 0; i < anzahl; i++)
			{
				dimelements[i] = new String[1];
				dimelements[i][0] = coords[i];
			};

			opts.Filter.CmpOp1 = CompareOp.CompareOpTRUE;
			opts.Filter.Value1.Type = CellValueType.CellValueTypeDouble;
			opts.Filter.Value1.Value.DblValue = 0;

			opts.Filter.CmpOp2 = CompareOp.CompareOpTRUE;
			opts.Filter.Value2.Type = CellValueType.CellValueTypeDouble;
			opts.Filter.Value2.Value.DblValue = 0;

			opts.Filter.AndOr12 = BoolOp.BoolOpAND;

			opts.IngoreEmptyCells = false;
			opts.BaseElementsOnly = false;
			opts.LastCoordinates = new String[0];
						opts.NumDatasets = 1;

			Dataset[] dsa = c.GetDataExport(db, cube, dimelements, opts, false, ref progress);

			if (dsa.Length > 0)
			{
				tmpDblVal = dsa[0].Value.Value.DblValue;
			}

			return (tmpDblVal + (tmpDblVal * percvalue / 100));
		}

		private bool userChangedFormulaCheck(object oformula, bool oformulaIsArray, object ovalue2)
		{
			Type booleantyp = false.GetType();
			Type doubletyp = 0.0.GetType();
			Type ovalue2typ = ovalue2.GetType();
			string sovalue2 = ovalue2.ToString();
			string soformula = oformula.ToString();

			bool tmp = (soformula != sovalue2);

			if (tmp && (ovalue2typ == doubletyp))
			{
				int pos = sovalue2.IndexOf("E", StringComparison.InvariantCultureIgnoreCase);
				if (pos > -1)
				{
					int i, len;
					string tmp1 = sovalue2.Substring(0, pos);
					string tmp2 = sovalue2.Substring(pos+1);

					string sout = "";
					if (tmp1[0] == '-')
					{
						sout = "-";
						tmp1= tmp1.Substring(1);
					}
					pos = tmp1.IndexOf('.');
					if (pos > -1)
					{
						tmp1 = tmp1.Remove(pos, 1);
					}
					else
					{
						pos = 0;
					}
					if (tmp2[0] == '-')
					{
						tmp2 = tmp2.Substring(1);
						len = System.Int32.Parse(tmp2, NumberStyles.Number)-1;
						sout += "0.";
						for (i = 0; i < len; i++)
						{
							sout += "0";
						}
						sout += tmp1;
					}
					else
					{
						sout += tmp1;
						len = len = System.Int32.Parse(tmp2, NumberStyles.Number) - tmp1.Length + pos;
						for (i = 0; i < len; i++)
						{
							sout += "0";
						}
					}
					tmp = (soformula != sout);
				}
			}

				// or user changed formula
			 return (ovalue2typ != booleantyp) && (oformula != null) && (ovalue2 != null) && !oformulaIsArray && tmp && (soformula != CurrentFormula);
		 }

		#region Helper for getting coordinates for copy/like splashing
		private static string[] GetFromCoordinates(Jedox.Palo.Comm.Connection c, string db, string cube, string[] toCoords, string[] userInput)
		{
			if (c == null || String.IsNullOrEmpty(db) || String.IsNullOrEmpty(cube) || toCoords == null || userInput == null)
				return new string[] { };

			string[] CubeDimensions = c.CubeListDimensions(db, cube);
			int noElem = userInput.Length;
			Hashtable Coords = new Hashtable(CubeDimensions.Length);
			string[] fromCoords = new string[CubeDimensions.Length];

			// fill the hashtable with keys (CubeDimensions)
			for (int i = 0; i < CubeDimensions.Length; i++)
			{
				Coords[CubeDimensions[i].ToLower()] = "";
			}

		   string elem = "";


			// fill the hashtable with known values
			for (int i = 0; i < noElem; i++)
			{
				string arg = userInput[i];
				string[] tmpCoord = arg.Split(':');
				string tmpDimsInUse = "";

				int j, len = tmpCoord.Length;

				for (j = 0; j < len; j++)
				{
					tmpCoord[j] = tmpCoord[j].Trim();
				}

				if (tmpCoord.Length == 2 && Coords.ContainsKey(tmpCoord[0].ToLower()))
				{
					Coords[tmpCoord[0].ToLower()] = tmpCoord[1];
				}
				else if (tmpCoord.Length == 1)
				{
					elem = tmpCoord[0];

					try
					{
						tmpDimsInUse = c.ElementCubeDimension(db, cube, new string[1] { elem }, true).ToLower();
					}
					catch (PaloException pcx)
					{
						if (pcx.ErrorCode == -49)
						{
							string mess = ResourceInitializer.Replace(ResourceInitializer.ERROR_COPY_ARGS_NOT_UNIQUE, new object[] { arg });
							System.Windows.Forms.MessageBox.Show(mess);
							throw;
						}

						if (pcx.ErrorCode == -37)
						{
							string mess = ResourceInitializer.PALO_ERR_DIM_ELEMENT_NOT_FOUND + " <" + elem + ">";
							System.Windows.Forms.MessageBox.Show(mess);
							throw;
						}
					}

					if ((tmpDimsInUse.Length != 0) && Coords.ContainsKey(tmpDimsInUse))
					{
						Coords[tmpDimsInUse] = tmpCoord[0];
					}
				}
			}

			// fill the rest of the hashtable (either known values or the the target coordinates)
			string dim = "";
			for (int i = 0; i < CubeDimensions.Length; i++)
			{
				dim = CubeDimensions[i].ToLower();
				if (String.IsNullOrEmpty((string)Coords[dim]))
				{
					fromCoords[i] = toCoords[i];
				}
				else
				{
					fromCoords[i] = (string)Coords[dim];
				}
			}

			return fromCoords;
		}
		#endregion
		#endregion

		#region eApp_SheetChange
		private void eApp_SheetChange(object Sh, Excel.Range Target)
		{

			// don't do anything if not doing it from addin
			if (InPaste == false)
			{
				return;
			}

			// get current thread's culture
			Thread thisThread = Thread.CurrentThread;
			CultureInfo originalCulture = thisThread.CurrentCulture;
			CultureInfo originalUICulture = thisThread.CurrentUICulture;
			bool? tmpEnableEvt = true;

			try
			{
				// set current thread's culture to en-US
				thisThread.CurrentCulture = new CultureInfo("en-US");
				thisThread.CurrentUICulture = new CultureInfo("en-US");

				// don't do anything if not doing it from addin
				if (NotInEditMode() == false)
				{
					return;
				}

				// JMM 09-24-13 Fix for DBNull reference
				if ((Target != null) && (Target.HasFormula != null) && !(Target.HasFormula is DBNull)  && ((bool)Target.HasFormula))
				{
					return;
				}


				if ((ExcelHelper.oExcelApp.CutCopyMode == Excel.XlCutCopyMode.xlCopy) || (ExcelHelper.oExcelApp.CutCopyMode == Excel.XlCutCopyMode.xlCut))
				{
					return;
				}

				// check for TAB or other cursor move
				string activsheetname = (ExcelHelper.GetActiveWorkSheet()).Name;

				if (Target.Worksheet.Name != activsheetname)
				{
					return;
				}

				// disable events
				tmpEnableEvt = ExcelHelper.EnableEvents(false, false);
                if (tmpEnableEvt == null)
                    return;

				#region Begin

				// no need to do anything if formula not defined
				if (string.IsNullOrEmpty(CurrentFormula))
				{
					return;
				}

				object oformula = Target.Formula;
				bool oformulaIsArray = oformula.GetType().IsArray;

				// or if formula is array
				if (oformula != null && oformulaIsArray == true)
				{
					return;
				}

				// init some tmp values
				string origStrValue = null;
				double tmpDblValue = 0;
				bool tmpDoneUndo = false;
				bool tmpDetectedDelete = false;
				bool tmpProtected = false;

				// init where to move after the job is done
				Excel.Range tmpRng = ExcelHelper.GetActiveCell();

				object ovalue2 = null;

				try
				{
					ovalue2 = Target.Value2;
				}
				catch
				{
					try
					{
						ovalue2 = Target.Text;
					}
					catch (Exception ex)
					{
						ovalue2 = null;
						ErrorHandler.DisplayError("Error reading Target value.", ex);
					}
				}

				// detected {DELETE}
				if (ovalue2 == null || (ovalue2.GetType() == typeof(System.Int32)))
				{
					if (tmpRng.Column != Target.Column && tmpRng.Row != Target.Row)
					{
						tmpDetectedDelete = true;
					}
					else
					{
						return;
					}
				}

				bool FormualComented = (oformula.ToString() == CurrentFormulaLocal);

				if (FormualComented || (ovalue2 != null && userChangedFormulaCheck(oformula, oformulaIsArray, ovalue2)))
				{
					return;
				}

				// check for TAB or other cursor move
				if ((Target.Column != this.CurrentColumn)
					|| (Target.Row != this.CurrentRow))
				{
					this.CurrentTab = true;
				}
				else
				{
					this.CurrentTab = false;
				}

				if (this.CurrentTab == true)
				{
					//	ExcelHelper.oExcelApp.Undo();
					return;
				}

				#endregion

				#region Parse old formula

				// some inits before we write data to server
				ExcelHelper eH = new ExcelHelper();
				Excel._Worksheet ws = ExcelHelper.GetActiveWorkSheet();

				// read the value
				if (tmpDetectedDelete != true)
				{
					if (ovalue2.GetType() == typeof(System.String))
					{
						origStrValue = ovalue2.ToString();
					}
					else
					{
						if (ovalue2.GetType() == typeof(System.Double))
						{
							tmpDblValue = (double)ovalue2;
						}
					}
				}
				else
				{
					if ((bool)ws.ProtectContents == false)
					{
						return;
					}
					else
					{
						tmpProtected = true;
					}
				}

				int pos = 0;

				if (CurrentFormula.StartsWith("=" + GeneralConst.PALO_DATA + "(", true, CultureInfo.InvariantCulture) != false)
				{
					pos = 11;
				}
				else if (CurrentFormula.StartsWith("=" + GeneralConst.PALO_DATA, true, CultureInfo.InvariantCulture) != false)
				{
					pos = 12;
				}

				string tmpFormula = CurrentFormula.Substring(pos);

				tmpFormula = tmpFormula.Substring(0, tmpFormula.Length - 1);

				string[] b = tmpFormula.Split(',');
				if (b.LongLength == 1)
				{
					b = tmpFormula.Split(';');
				}

				// some more inits before we write data to server
				Jedox.Palo.Comm.Connection c = null;

				#endregion

				try
				{
					#region Implementation
					string[] tmpConnStr = eH.get_value(b[0], ws).Split('/');
					int startindex = 2;
					bool doevalute = false;
					if (b[1].Contains("&"))
					{
						doevalute = true;
					}

					if (b[1].StartsWith("CONCATENATE"))
					{
						doevalute = true;
						if (!b[1].Contains(")"))
						{
							while ((b.Length > startindex) && !b[startindex].Contains(")"))
							{
								b[1] += "," + b[startindex];
								startindex++;
							}
							if ((b.Length > startindex))
							{
								b[1] += "," + b[startindex];
								startindex++;
							}
						}
					}

					if (doevalute)
					{
						b[1] = '"' + ExcelHelper.oExcelApp._Evaluate(b[1]).ToString() + '"';
					}


					string tmpCube = eH.get_value(b[1], ws);
					string[] tmpCoords = new string[b.LongLength - startindex];
					bool iserror = false;


					c = Apalo.XlAddin.Connections.GetConnection(tmpConnStr[0]);
					string coordvalue = "";

					for (int i = startindex; i < b.LongLength; i++)
					{
						coordvalue = eH.get_value(b[i], ws);
						if (String.IsNullOrEmpty(coordvalue))
						{
							coordvalue = eH.get_value(b[i], ws, b[i], ref iserror);
						}

						if (String.IsNullOrEmpty(coordvalue))
						{
							coordvalue = (string)ExcelHelper.oExcelApp._Evaluate(b[i]);
						}

						tmpCoords.SetValue(coordvalue, i - startindex);
					}

					// if protected and {DELETE} then write "zero" values
					if (tmpProtected == true)
					{
						if (this.CurrentStrValue != null)
						{
							origStrValue = "";
						}
						else
						{
							tmpDblValue = 0;
						}
					}


					#region SetData

					bool docopy = false;
					bool dostring = false;
					Jedox.Palo.Comm.SplashMode splashmode = SplashMode.SplashModeDefault;

					if (origStrValue != null)
					{
						// make sure it works for any locale
						string tmpStrValue = origStrValue.Replace(',', '.');
						// Decide which splash action to take
						if (tmpStrValue.Length > 1 && tmpStrValue.IndexOf("like", StringComparison.InvariantCultureIgnoreCase) != -1)
						{
							#region Like
							bool doproz = false;
							string[] tmpArg = tmpStrValue.Split(' ');
							if (tmpArg.Length > 2)
							{

								string tmpsVal = tmpArg[0];

								if (tmpsVal.Length > 0)
								{

									docopy = true;

									int len = tmpsVal.Length;

									if ((tmpsVal[0] == SPLASH_HASH) && (tmpsVal[len - 1] == SPLASH_PERCT))
									{
										doproz = true;
										tmpsVal = tmpsVal.Substring(1, len - 2);
									}

									double tmpVal = System.Convert.ToDouble(tmpsVal.Replace(',', '.'));

									if (doproz)
									{
										tmpVal = CalculateValueByPercent(c, tmpVal, tmpConnStr[1], tmpCube, tmpCoords);
									}

									tmpArg = tmpStrValue.Substring(tmpStrValue.IndexOf("like", StringComparison.InvariantCultureIgnoreCase) + 5).Split(';');
									try
									{
										string[] fromCoords = GetFromCoordinates(c, tmpConnStr[1], tmpCube, tmpCoords, tmpArg);
										c.CopyCell(tmpConnStr[1], tmpCube, fromCoords, tmpCoords, tmpVal);
									}
									catch (PaloException pcx)
									{
										if (pcx.ErrorCode != -49)
										{
											throw;
										}
									}
								}
							}

							dostring = !docopy;
							#endregion
						}
						else if (tmpStrValue.Length > 0 && tmpStrValue[0] == SPLASH_PREFIX_CHAR)// |
						{
							tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(1));
						}
						else if (tmpStrValue.Length > 0 && tmpStrValue[0] == SPLASH_EXCL)
						{
							#region SPLASH_EXCL !/!!
							if (tmpStrValue.Length > 1 && tmpStrValue[1] == SPLASH_EXCL)// !!
							{
								tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(2));
								splashmode = Jedox.Palo.Comm.SplashMode.SplashModeBaseAdd;
							}
							else // !
							{
								tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(1));
								splashmode = Jedox.Palo.Comm.SplashMode.SplashModeBaseSet;
							}
							#endregion
						}
						else if (tmpStrValue.Length > 0 && tmpStrValue[0] == SPLASH_GOALSEEK)
						{
							#region SPLASH_GOALSEEK
							docopy = true;
							tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(1));
							try
							{
								c.GoalSeek(tmpConnStr[1], tmpCube, tmpCoords, tmpDblValue);
							}
							catch (PaloException pcx)
							{
								if ((pcx.ErrorCode != -49) && (pcx.ErrorCode != -37))
								{
									throw;
								}
							}
							#endregion
						}
						else if (tmpStrValue.Length > 0 && tmpStrValue[0] == SPLASH_HASH)// #
						{
							string tmpStrVal = "";
							double tmpDblVal = 0.0;
							double tmpCurrVal;

							#region SPLASH_HASH/SPLASH_PERCT
							if (tmpStrValue.LastIndexOf(SPLASH_PERCT) == -1)
							{
								#region double HASH
								if (tmpStrValue[1].Equals('#'))
								{
									c.GetData(ref tmpStrVal, ref tmpDblVal, tmpConnStr[1], tmpCube, tmpCoords);

									if (tmpStrValue[2].Equals('-'))
									{
										tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(3));
										tmpDblValue = tmpDblVal - tmpDblValue;
									}
									else if (tmpStrValue[2].Equals('+'))
									{
										tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(3));
										tmpDblValue = tmpDblVal + tmpDblValue;
									}
									else
									{
										tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(2));
										tmpDblValue = tmpDblVal + tmpDblValue;
									}
								}
								#endregion
								else
								{
									tmpDblValue = System.Convert.ToDouble(tmpStrValue.Substring(1));
								}
							}
							else
							{
								c.GetData(ref tmpStrVal, ref tmpDblVal, tmpConnStr[1], tmpCube, tmpCoords);

								if ((tmpStrValue.Length > 1) && (tmpStrValue[1] == SPLASH_PERCT))
								{
									tmpCurrVal = (double)System.Convert.ToDouble(tmpStrValue.Substring(2));
									if (tmpDblVal != tmpCurrVal)
									{
										if (tmpDblVal == 0)
										{
											c.SetData(tmpConnStr[1], tmpCube, tmpCoords, tmpCurrVal);
											c.GetData(ref tmpStrVal, ref tmpDblVal, tmpConnStr[1], tmpCube, tmpCoords);
										}

										tmpCurrVal = (tmpCurrVal - tmpDblVal) / tmpDblVal * 100;
										tmpDblValue = CalculateValueByPercent(c, tmpCurrVal, tmpConnStr[1], tmpCube, tmpCoords);
									}
								}
								else
								{
									tmpCurrVal = (double)System.Convert.ToDouble(tmpStrValue.Substring(1, tmpStrValue.Length - 2));
									tmpDblValue = CalculateValueByPercent(c, tmpCurrVal, tmpConnStr[1], tmpCube, tmpCoords);
								}
							}
							#endregion
						}
						else if (tmpStrValue.Length > 1 && tmpStrValue.StartsWith("copy", StringComparison.InvariantCultureIgnoreCase))
						{
							#region Copy
							docopy = true;
							string[] tmpArg = tmpStrValue.Substring(5).Split(';');
							try
							{
								string[] fromCoords = GetFromCoordinates(c, tmpConnStr[1], tmpCube, tmpCoords, tmpArg);
								c.CopyCell(tmpConnStr[1], tmpCube, fromCoords, tmpCoords);
							}
							catch (PaloException pcx)
							{
								if ((pcx.ErrorCode != -49) && (pcx.ErrorCode != -37))
								{
									throw;
								}
							}

							#endregion
						}
						else
						{
							dostring = true;
						}
					}
					else if (this.CurrentStrValue != null)//  || (ExcelHelper.oExcelApp.ActiveCell.Formula != null && ExcelHelper.oExcelApp.ActiveCell.Formula.ToString().Length == 0))
					{
						dostring = true;
						origStrValue = Target.FormulaLocal.ToString();
					}
					else
					{
						splashmode = SplashMode.SplashModeDisable;
					}
					#endregion

					if (!docopy && (!dostring) && (tmpDblValue == 0))
					{
						double number = CalculateNumberBaseCells(c, tmpConnStr[1], tmpCube, tmpCoords);

						if (number >= 10000000)
						{
							string mess = ResourceInitializer.Replace(ResourceInitializer.QUESTION_DELETE_CELLS, new object[] { number });
							if (System.Windows.Forms.MessageBox.Show(mess, "", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Cancel)
							{
								if (tmpDoneUndo == false)
								{
									ExcelHelper.oExcelApp.Undo();
								}

								return;
							}
						}
					}

					if (!docopy)
					{
						if (!dostring)
						{
							c.SetData(tmpConnStr[1], tmpCube, tmpCoords, tmpDblValue, splashmode);
						}
						else
						{
							c.SetData(tmpConnStr[1], tmpCube, tmpCoords, origStrValue);
						}
					}

					changesMade = true;

					// set the formula back to the old value
					if (tmpDoneUndo == false)
					{
						ExcelHelper.oExcelApp.Undo();
					}

					#endregion
				}
				catch (Exception eadd)
				{
					ErrorHandler.ProcessError("Error setting data\n", eadd);
					#region Clean after error
					// do undo and select if problem occured
					if (tmpDoneUndo == false)
					{
						// assign position where to move after the job is done
						ExcelHelper.oExcelApp.Undo();
					}

					String errmsg = "";
					string svsMsgType = "";
					if (typeof(Jedox.Palo.Comm.PaloException) == eadd.GetType())
					{
						Jedox.Palo.Comm.PaloException pe = (Jedox.Palo.Comm.PaloException)eadd;
						if ((pe.ErrorCode == -44) || (pe.ErrorCode == 1009)) // NOT_AUTHORIZED - insufficient rights
						{
							errmsg = ResourceInitializer.ERROR_INSUFFICIENT_RIGTHS;
						}
						else if ((pe.ErrorCode == -38) || (pe.ErrorCode == 4008) || (pe.ErrorCode == 1018) || (pe.ErrorCode == 5005))// PALO_ERR_DIM_ELEMENT_INV_TYPE/SPLASH_DISABLED_FAILED - Cannot write to a agregated cell
						{
							errmsg = ResourceInitializer.PALO_ERR_DIM_ELEMENT_INV_TYPE + "\n(" + pe.PaloMessage + ')';
						}
						else if ((pe.ErrorCode == -36) || (pe.ErrorCode == 5000))// PALO_ERR_CUBE_NOT_FOUND
						{
							errmsg = ResourceInitializer.PALO_ERR_CUBE_NOT_FOUND;
						}
						else if ((pe.ErrorCode == -26) || (pe.ErrorCode == 1005))// PALO_ERR_TYPE - Cannot write string to a number cell or Cannot write number to a string cell => Type mismatch
						{
							errmsg = ResourceInitializer.PALO_ERR_TYPE;
						}
						else if (pe.ErrorCode == -27)// PALO_ERR_INV_ARG
						{
							errmsg = ResourceInitializer.PALO_ERR_INV_ARG;
						}
						else if ((pe.ErrorCode == -37) || (pe.ErrorCode == 4004))// PALO_ERR_DIM_ELEMENT_NOT_FOUND
						{
							errmsg = ResourceInitializer.PALO_ERR_DIM_ELEMENT_NOT_FOUND;
						}

						if (string.IsNullOrEmpty(errmsg))
						{
							errmsg = (string)pe.PaloMessage;
						}

						if (pe.ErrorCode == 1020)
						{
							svsMsgType = errmsg.Substring(0, 1);
							errmsg = errmsg.Substring(errmsg.IndexOf(" : ", 0) + 3);
							errmsg = errmsg.Substring(0, errmsg.Length - 13);
							errmsg = InsertNewline(errmsg);
						}

					}
					else
					{
						errmsg = ResourceInitializer.PALO_ERR_INV_FORMAT;
					}

					/// In case error comes from Supervision-Server - pe.ErrorCode == 1020
					/// then we do special handling to display either
					/// Information - 0, Warning - 1 or Error - 2 dialog
					switch (svsMsgType)
					{
						case "0":
							ErrorHandler.ErrorPopup(errmsg, System.Windows.Forms.MessageBoxIcon.Information);
							break;

						case "1":
							ErrorHandler.ErrorPopup(errmsg);
							break;

						case "2":
							ErrorHandler.ErrorPopup(errmsg, System.Windows.Forms.MessageBoxIcon.Error);
							break;

						default:
							ErrorHandler.ErrorPopup(errmsg);
							break;
					}

					return;
					#endregion
				}
				finally
				{
					#region End
					SetCurrFormulaFromActiveCell();
					this.CurrentStrValue = null;
					this.CurrentDblValue = 0;

					if (ExcelHelper.GetCalculation() != Excel.XlCalculation.xlCalculationAutomatic)
					{
						ExcelHelper.PaloEnableLoop(true);
						Target.Calculate();
						ExcelHelper.PaloEnableLoop(false);
					}

					//move to requested position
					ExcelHelper.oExcelApp.get_Range((Excel.Range)ExcelHelper.oExcelApp.Cells[tmpRng.Cells.Row, tmpRng.Cells.Column], (Excel.Range)ExcelHelper.oExcelApp.Cells[tmpRng.Cells.Row, tmpRng.Cells.Column]).Select();
					eH.Dispose();
					eH = null;
					#endregion
				}
			}
			catch (Exception ex)
			{
				ErrorHandler.DisplayError("Error handling SheetChange.", ex);
			}
			finally
			{
				#region Final cleanup
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				// turn back events on if not allready on

				ExcelHelper.EnableEvents(tmpEnableEvt);

				thisThread.CurrentCulture = originalCulture;
				thisThread.CurrentCulture = originalUICulture;
				#endregion
			}
		}
		#endregion

		#region eApp_SheetSelectionChange
		private void eApp_SheetSelectionChange(object Sh, Excel.Range Target)
				{
			// don't do anything if not doing it from addin
			if (InPaste == false)
			{
				return;
			}

			Thread thisThread = Thread.CurrentThread;
			CultureInfo originalCulture = thisThread.CurrentCulture;
			CultureInfo originalUICulture = thisThread.CurrentUICulture;
			bool? tmpEnableEvt = true;

			try
				{
				#region Implementation
				thisThread.CurrentCulture = new CultureInfo("en-US");
				thisThread.CurrentUICulture = new CultureInfo("en-US");

				if (NotInEditMode() == false)
				{
					return;
				}

				Excel._Worksheet ws = ExcelHelper.GetActiveWorkSheet();
				/*
				if (ExcelHelper.GetActiveWorkSheet().ProtectContents)
				{
					return;
				}
				*/

				// Make sure we exit if we select whole sheet or single row/column
				Excel.Range tmpSel = ExcelHelper.GetSelection();
				int maxrow = GeneralConst.getMaxRow(), maxcol = GeneralConst.getMaxColumn(), maxrang = maxrow * maxcol;
				if ((tmpSel.Column == 1) && (tmpSel.Row == 1) && (tmpSel.Cells.Count == maxrang))
					{
						return;
					}

				if ((tmpSel.Cells.Count >= maxrow) && (tmpSel.Row == 1))
					{
						return;
					}

				if ((tmpSel.Cells.Count >= maxcol) && (tmpSel.Column == 1))
					{
						return;
					}

				// fix for Excel 2000 ... making corrupt files upon save when using painter format
				if (ExcelHelper.oExcelApp.CutCopyMode == Excel.XlCutCopyMode.xlCopy)
					{
						return;
					}

				// disable events
				tmpEnableEvt = ExcelHelper.EnableEvents(false);
                if (tmpEnableEvt == null)
                    return;

				CurrentFormula = null;
				CurrentFormula = "";
								this.CurrentStrValue = null;
								this.CurrentDblValue = 0;
								this.CurrentRow = 0;
								this.CurrentColumn = 0;
								string tmpFormula = "", tmpFormulaLocal;

				// Dummerweise ist Target.Locked auch dann true, wenn nichts gesperrt ist.
				if (Target == null || Target.Formula == null || Target.Formula is DBNull)
				{
					return;
				}

				if (Target.HasFormula is DBNull && Target.Formula.GetType().IsArray == false)
				{
					return;
				}

				if (Target.Formula.GetType().IsArray == true)
				{
					object[,] foa = (object[,])Target.Formula;
					tmpFormula = foa[1, 1].ToString();
					object[,] foaloc = (object[,])Target.FormulaLocal;
					tmpFormulaLocal = foaloc[1, 1].ToString();
				}
				else
				{
					tmpFormula = Target.Formula.ToString();
					tmpFormulaLocal = Target.FormulaLocal.ToString();
				}

				if (tmpFormula.Length == 0)
				{
					return;
				}


				if (CheckFormula(tmpFormula))
				{
					CurrentFormula = tmpFormula;
					CurrentFormulaLocal = tmpFormulaLocal;
					this.CurrentRow = (int)Target.Row;
					this.CurrentColumn = (int)Target.Column;
					this.mItemDrillRule.Enabled = true;
					this.mItemDrillThrough.Enabled = true;
					try
					{
						if (Target.Value2.GetType() == typeof(System.String))
						{
							this.CurrentStrValue = (string)Target.Value2;
						}
						else if (Target.Value2.GetType() == typeof(System.Double))
						{
							this.CurrentDblValue = (double)Target.Value2;
						}
						else if (Target.Value2.GetType().IsArray == true)
						{
							object[,] vala = (object[,])Target.Value2;
							if (vala[1, 1].GetType() == typeof(System.String))
							{
								this.CurrentStrValue = (string)vala[1, 1];
							}
							else if (vala[1, 1].GetType() == typeof(System.Double))
							{
								this.CurrentDblValue = (double)vala[1, 1];
							}
						}
					}
					catch (System.Runtime.InteropServices.COMException)
					{ }
				}
				else
				{
					this.mItemDrillRule.Enabled = false;
					this.mItemDrillThrough.Enabled = false;
				}
				#endregion
				}
			catch(Exception ex)
			    {
                // JMM 09-24-13 No error on exceptions here:
				//ErrorHandler.DisplayError("Error handling SheetSelectionChange.", ex);
			    }
		    finally
				{
				#region Final cleanup
				// Restore the culture information for the thread after the
			    // Excel calls have completed.
				// enable events
				ExcelHelper.EnableEvents(tmpEnableEvt);
				thisThread.CurrentCulture = originalCulture;
				thisThread.CurrentCulture = originalUICulture;
				#endregion
			    }
		}
		#endregion

		#endregion

		#region PaloErrorMessage Context Menu

		private void mItemError_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
				{
			ErrorHandler.ErrorPopup(String.IsNullOrEmpty(PaloErrorString) ? "No error." : PaloErrorString, System.Windows.Forms.MessageBoxIcon.Error);
				}

		private void CheckForPaloError()
		{
			String errmsg = null;
			try
			{
				Object error_info = ExcelHelper.oExcelApp.Run("PALO.ERROR_INFO");
				if (error_info != null)
				{
					errmsg = error_info.ToString();
				}
			}
			catch (Exception ce)
			{
				ErrorHandler.DisplayError("Error Calling PALO.ERROR_INFO.", ce);
				errmsg = ce.Message;
			}

			PaloErrorString = errmsg;

			this.mItemError.Enabled = !String.IsNullOrEmpty(errmsg);

		}


				private void eApp_SheetBeforeRightClick(object Sh, Excel.Range Target, ref bool Cancel)
				{
			CheckForPaloError();
		}

				#endregion

				#region eApp_WorkbookOpen

				private void eApp_WorkbookOpen(Excel.Workbook Wb)
				{
			// don't do anything if not doing it from addin
			if (OpenSpecialCase || !InPaste || (Wb.Name == "wstools.xla") || (Wb.Name == "wscom.xla") )
			{
				OpenSpecialCase = false;
				return;
			}

			try
			{
				// get current thread's culture
				Thread thisThread = Thread.CurrentThread;
				CultureInfo originalCulture = thisThread.CurrentCulture;
				CultureInfo originalUICulture = thisThread.CurrentUICulture;
				thisThread.CurrentCulture = new CultureInfo("en-US");
				thisThread.CurrentUICulture = new CultureInfo("en-US");
				bool tmpSu = ExcelHelper.GetScreenUpdating();
				ExcelHelper.SetScreenUpdating(false);

				try
				{
					//ensure change event happens
					Excel.Range tmpRng = ExcelHelper.GetSelection();
					Excel.Range newRng = (Excel.Range)ExcelHelper.oExcelApp.Cells[1, 1];
					newRng.Select();
					tmpRng.Select();
				}
				catch
				{ }

				CheckForPaloError();

				ExcelHelper.SetScreenUpdating(tmpSu);
			}
			catch(Exception e)
			{
				ErrorHandler.DisplayError("Error open workbook " + Wb.Name, e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				thisThread.CurrentCulture = originalCulture;
				thisThread.CurrentUICulture = originalUICulture;
			}
				}

				#endregion

				#region eApp_WorkbookBeforeClose
				private void eApp_WorkbookBeforeClose(Excel.Workbook Wb, ref bool Cancel)
				{
			// don't do anything if not doing it from addin
			if (InPaste == false)
				return;

						if(Wb != null)
						{
								while( Marshal.ReleaseComObject( Wb ) > 0 );
								Wb = null;
						}

				// maybe helpfull for removing references to closed workbooks
			// being sometimes seen in VBA Editor
//						GC.Collect();
//						GC.WaitForPendingFinalizers();
//						GC.Collect();
//						GC.WaitForPendingFinalizers();
				}
				#endregion

				#region AttachEventHandlers
		private void AttachEventHandlers(Excel.Application eApp)
				{
						/* 1 */ eApp.WorkbookActivate += new Excel.AppEvents_WorkbookActivateEventHandler(eApp_WorkbookActivate);
						/* 2 */ eApp.WorkbookDeactivate += new Excel.AppEvents_WorkbookDeactivateEventHandler(eApp_WorkbookDeactivate);
						/* 3 */ eApp.SheetBeforeDoubleClick += new Excel.AppEvents_SheetBeforeDoubleClickEventHandler(eApp_SheetBeforeDoubleClick);
						/* 4 */ eApp.SheetBeforeRightClick +=new Excel.AppEvents_SheetBeforeRightClickEventHandler(eApp_SheetBeforeRightClick);
						/* 5 */ eApp.WorkbookOpen +=new Excel.AppEvents_WorkbookOpenEventHandler(eApp_WorkbookOpen);
						/* 6 */ eApp.WorkbookBeforeClose +=new Excel.AppEvents_WorkbookBeforeCloseEventHandler(eApp_WorkbookBeforeClose);
						/* 7 */ eApp.SheetChange +=new Excel.AppEvents_SheetChangeEventHandler(eApp_SheetChange);
						/* 8 */ eApp.SheetSelectionChange +=new Excel.AppEvents_SheetSelectionChangeEventHandler(eApp_SheetSelectionChange);
						/* 9 */ eApp.SheetActivate +=new Excel.AppEvents_SheetActivateEventHandler(eApp_SheetActivate);
				}
				#endregion

				#region DetachEventHandlers
		private void DeAttachEventHandlers(Excel.Application eApp)
				{
						/* 1 */ eApp.WorkbookActivate -= new Excel.AppEvents_WorkbookActivateEventHandler(eApp_WorkbookActivate);
						/* 2 */ eApp.WorkbookDeactivate -= new Excel.AppEvents_WorkbookDeactivateEventHandler(eApp_WorkbookDeactivate);
						/* 3 */ eApp.SheetBeforeDoubleClick -= new Excel.AppEvents_SheetBeforeDoubleClickEventHandler(eApp_SheetBeforeDoubleClick);
						/* 4 */ eApp.SheetBeforeRightClick -=new Excel.AppEvents_SheetBeforeRightClickEventHandler(eApp_SheetBeforeRightClick);
						/* 5 */ eApp.WorkbookOpen -=new Excel.AppEvents_WorkbookOpenEventHandler(eApp_WorkbookOpen);
						/* 6 */ eApp.WorkbookBeforeClose -=new Excel.AppEvents_WorkbookBeforeCloseEventHandler(eApp_WorkbookBeforeClose);
						/* 7 */ eApp.SheetChange -=new Excel.AppEvents_SheetChangeEventHandler(eApp_SheetChange);
						/* 8 */ eApp.SheetSelectionChange -=new Excel.AppEvents_SheetSelectionChangeEventHandler(eApp_SheetSelectionChange);
						/* 9 */ eApp.SheetActivate -=new Excel.AppEvents_SheetActivateEventHandler(eApp_SheetActivate);
				}
				#endregion

		#region HeartBeat
		private static void t_Heartbeat()
		{
			CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
					CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;

			try
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

				bool newUpdate = false;
				string url = "http://up.palo.net/update/?os=win&lang=" + RegUtils.ActiveLanguage.Substring(0, 2);

				url += "&xl=" + ExcelHelper.ShortVersion() + "&xla=" + About.revision.Replace("$WCREV$", "0000");

				ApiInfo apiinfo = Jedox.Palo.Comm.Connection.ApiInformation();

				url += "&api=" + apiinfo.MajorVersion + "." + apiinfo.MinorVersion + "." + apiinfo.BuildNumber + "." + apiinfo.BugfixVersion;

				WebRequest myRequest = WebRequest.Create(url);

				WebResponse myResponse = myRequest.GetResponse();
				Stream ReceiveStream = myResponse.GetResponseStream();

				StreamReader reader = new StreamReader(ReceiveStream);

				string result = reader.ReadToEnd();
				reader.Close();
				ReceiveStream.Close();

				myResponse.Close();
				myRequest.Abort();

				newUpdate = ((result.Length > 0) && (result[0] == '1'));

				int beginurl = 2;
				if (newUpdate && (result.Length > beginurl) && (System.Windows.Forms.MessageBox.Show(ResourceInitializer.updateCheckText, ResourceInitializer.updateCheckTitle, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
				{
					System.Diagnostics.Process.Start(result.Substring(beginurl));
				}

			}
			catch (Exception e)
			{
				ErrorHandler.DisplayError("Error Heartbeat.", e);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				Thread.CurrentThread.CurrentCulture = originalCulture;
				Thread.CurrentThread.CurrentUICulture = originalUICulture;
			}
		}

		private static void Heartbeat(bool check)
		{
			if (!check || (RegUtils.HeartBeat != 0))
			{
				Thread thread = new Thread(new ThreadStart(t_Heartbeat));
				thread.Start();
			}
		}

		private static void Heartbeat()
		{
			Heartbeat(true);
		}

		#endregion
	}
}
