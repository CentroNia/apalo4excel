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
 *   http://www.jedox.com/license_palo_bi_suite.txt
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

////////////////////////////////////////////////////////////////////////////////
/// @brief  Collapsible Function Chooser Control
///
/// @file   CFChooser.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JControls
{

    public partial class CFChooser : CComputable
    {
        private ComboBox cbOption;
        private XMLDescription xmlDescription;
        private string cbTextLast = "";
        private Filter fDBList;
        private Filter fDatabase;
        private Filter fCube;
        private Filter fDimension;
        private Filter fElement;
        private bool marker = false;

        public CFChooser()
        {
            InitializeComponent();
            InitializeControls();
        }

        public CFChooser(string id)
        {
            InitializeComponent();
            InitializeControls();
            cbOption.Text = id;
        }

        public ComboBox CBOption
        {
            get { return cbOption; }
        }

        public int ArgCount
        {
            get { return TControls.Count - 2; }
        }

        public override void BuildCacheExp(bool propagateDown)
        {
            base.BuildCacheExp(propagateDown);
            if (propagateDown)
            {
                for (int i = 2; i < TControls.Count; i++)
                {
                    ((IComputable)TControls[i]).BuildCacheExp(propagateDown);
                }
            }

            if (cbOption.SelectedItem is Function)
            {
                cacheExpr = "";

                // We go from the end to the first non-null value:
                int right;
                for (right = TControls.Count - 1; right >= 2 && ((ArgControl)TControls[right]).Optional; right--)
                {
                    if (((ArgControl)TControls[right]).ExprValue != Constants.nullStr) break;
                }

                for (int i = 2; i <= right; i++)
                {
                    ArgControl ac = (ArgControl)TControls[i];
                    cacheExpr += ac.ExprValue + ((i != right) ? ", " : "");
                }
                cacheExpr = cbOption.Text + "(" + cacheExpr + ")";
            }
            else if (cbOption.Text == Constants.strParen)
            {
                cacheExpr = "(" + ((ArgControl)TControls[2]).ExprValue + ")";
            }
            else if (cbOption.Text == Constants.strNot || cbOption.Text == Constants.strMinus)
            {
                cacheExpr = ((ArgControl)TControls[2]).ExprValue;
                if (((ArgControl)TControls[2]).TControls.Count > 4) cacheExpr = "(" + cacheExpr + ")";
                cacheExpr = cbOption.Text + cacheExpr;
            }
            else if (cbOption.Text == Constants.strBrack)
            {
                cacheExpr = "[" + ((AreaControl)TControls[2]).ExprValue + "]";
            }
            else if (cbOption.Text == Constants.strMarker)
            {
                cacheExpr = "[[" + ((AreaControl)TControls[2]).ExprValue + "]]";
            }
            else if (cbOption.Text != "")
            {
                cacheExpr = cbOption.Text;
            }
            else cacheExpr = Constants.nullStr;
        }

        /// <summary>
        /// Sets the text for CFChooser and does UpdateStructure() if needed
        /// </summary>
        public string FNText
        {
            get { return cbOption.Text; }
            set
            {
                if (value.ToUpper() != cbTextLast.ToUpper())
                {
                    object selectedItem = null;
                    foreach (object item in cbOption.Items)
                    {
                        if (item.ToString().ToUpper() == value.ToUpper())
                        {
                            selectedItem = item;
                            break;
                        }
                    }
                        
                    cbTextLast = value;
                    // HACK: We may change cbOption.SelectedItem, because we 
                    // have already set the cbTextLast, so that the next call of _set
                    // will not past the topmost "if".
                    cbOption.SelectedItem = selectedItem;

                    if (selectedItem == null)
                    {
                        cbOption.Text = value;
                    }

                    if (!Collapsed)
                    {
                        SuspendLayout();
                        UpdateStructure();
                        ResumeLayout();
                    }
                    else
                    {
                        UpdateStructure();
                    }
                }
            }
        }

        public EBuilder EBuilder
        {
            get
            {
                if (!(cbOption.Text == Constants.strParen
                        | cbOption.Text == Constants.strNot | cbOption.Text == Constants.strMinus))
                    throw new ArgumentException("Unsupported argument for: " + cbOption.Text);
                return (EBuilder)TControls[2];
            }
        }

        public AreaControl AreaControl
        {
            get
            {
                if (cbOption.Text != Constants.strBrack && cbOption.Text != Constants.strMarker)
                    throw new ArgumentException("Unsupported argument for: " + cbOption.Text);
                return (AreaControl)TControls[2];
            }
        }

        public ArgControl ArgControlAt(int index)
        {
            if (TControls[TControls.Count - 1] is OArgControl)
                for (int i = TControls.Count; i <= index + 2; i++)
                {
                    AddOArgControl();
                    if (TControls[TControls.Count - 2] is OArgControl)
                        ((OArgControl)TControls[TControls.Count - 2]).LButton.Visible = false;
                }
            if (TControls.Count - 1 < index + 2)
                throw new ArgumentException("Too many arguments (" + (index + 1) + ") for function: " + FNText + " or expression too complex");
            return (ArgControl)TControls[index + 2];
        }

        private void AddArgControl(Argument arg)
        {
            ArgControl aControl = new ArgControl(arg);
            if (this.suspended) aControl.SuspendUpdate();
            aControl.CParent = this;
            aControl.Dock = DockStyle.Fill;
            aControl.Visible = !this.Collapsed;
            aControl.BorderColor = Color.FromArgb(164, 164, 164);
            AddControlDim(aControl);

            if (!arg.description.ContainsKey(RegionalSettings.English))
            {
                arg.description[RegionalSettings.English] = "?";
            }

            if (arg.description[RegionalSettings.English].StartsWith("database"))
            {
                CFChooser cfc = aControl.CFChooserAt(0);
                fDatabase.CBFilter = cfc.CBOption;
            }

            if (arg.description[RegionalSettings.English].StartsWith("cube"))
            {
                CFChooser cfc = aControl.CFChooserAt(0);
                fCube.CBFilter = cfc.CBOption;
                if (cbOption.Text.ToUpper() == "PALO.DATA" || cbOption.Text.ToUpper() == "PALO.MARKER")
                {
                    cfc.CBOption.SelectedIndexChanged += new EventHandler(cubes_SelectedIndexChanged);
                    cfc.CBOption.KeyUp += new KeyEventHandler(cubes_KeyUp);
                    cfc.CBOption.Leave += new EventHandler(cubes_Leave);
                }
            }

            if (arg.description[RegionalSettings.English].StartsWith("dimension"))
            {
                CFChooser cfc = aControl.CFChooserAt(0);
                fDimension.CBFilter = cfc.CBOption;
            }

            if (arg.description[RegionalSettings.English].StartsWith("element"))
            {
                CFChooser cfc = aControl.CFChooserAt(0);
                fElement.ContainsBangDim = false;
                fElement.UsesOrdinal = false;
                fElement.CBFilter = cfc.CBOption;
            }

            OnExpressionUpdate(this, new EventArgs());
        }

        private void AddOArgControl(Argument arg)
        {
            OArgControl aControl = new OArgControl(arg);

            if (this.suspended) aControl.SuspendUpdate();
            aControl.LButton.Click += new EventHandler(LButton_Click);
            aControl.MButton.Click += new EventHandler(MButton_Click);
            aControl.Dock = DockStyle.Fill;
            aControl.CParent = this;
            aControl.Visible = !this.Collapsed;
            aControl.BorderColor = Color.FromArgb(164, 164, 164);
            AddControlDim(aControl);
            marker = false;
        
            if (cbOption.Text.ToUpper() == "PALO.DATA")
            {
                if ((arg != null) && (arg.description[RegionalSettings.English] == "1st dim coordinate"))
                {
                    CFChooser cfc = aControl.CFChooserAt(0);
                    aControl.TitleControl.Text = "[...]";
                    fElement.ContainsBangDim = true;
                    fElement.UsesOrdinal = true;
                    fElement.CBFilter = cfc.CBOption;
                }
                else
                {
                    CFChooser cfc = aControl.CFChooserAt(0);
                    // Filter fDimension2 = new Filter();
                    Filter fElement2 = new Filter();
                    fDimension.AddChild(fElement2);
                    fElement2.Delimiter = Constants.DQUOTE;
                    fElement2.ContainsBangDim = true;
                    fElement2.UsesOrdinal = true;
                    fElement2.CBFilter = cfc.CBOption;
                }
            }
            else if (cbOption.Text.ToUpper() == "PALO.MARKER")
            {
                marker = true;
                if ((arg != null) && (arg.description[RegionalSettings.English] == "1st marker coordinate"))
                {
                    CFChooser cfc = aControl.CFChooserAt(0);
                    aControl.TitleControl.Text = "[...]";
                    fElement.ContainsBangDim = true;
                    fElement.UsesOrdinal = true;
                    fElement.CBFilter = cfc.CBOption;
                    fElement.Delimiter = Constants.DQUOTE;               
                }
                else
                {
                    CFChooser cfc = aControl.CFChooserAt(0);
                    // Filter fDimension2 = new Filter();
                    Filter fElement2 = new Filter();
                    fDimension.AddChild(fElement2);
                    fElement2.Delimiter = Constants.DQUOTE;
                    fElement2.ContainsBangDim = true;
                    fElement2.UsesOrdinal = true;
                    fElement2.CBFilter = cfc.CBOption;
                   
                }
            }

            OnExpressionUpdate(this, new EventArgs()); ;
        }

        private void AddOArgControl()
        {
            AddOArgControl(null);
        }

        private void AddEBuilder()
        {
            EBuilder eb = new EBuilder();
            if (this.suspended) eb.SuspendUpdate();
            eb.CParent = this;
            eb.Dock = DockStyle.Fill;
            eb.Visible = !this.Collapsed;
            eb.BackColor = Color.FromArgb(164, 164, 164);
            AddControlDim(eb);
            OnExpressionUpdate(this, new EventArgs());
        }

        private void AddAreaControl(AreaControl ac)
        {
            ac.CParent = this;
            ac.Visible = !this.Collapsed;
            AddControlDim(ac);
            OnExpressionUpdate(this, new EventArgs());
        }

        public void ClearAreaControl()
        {
            while (AreaControl.DECount > 1)
            {
                AreaControl.RemoveDEAt(AreaControl.DECount - 1);
            }
            AreaControl.DEAt(0).ExprValue = "";
        }

        private void cbOption_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void InitializeControls()
        {
            cbOption = new ComboBox();
            cbOption.MouseWheel += new MouseEventHandler(cbOption_MouseWheel);
            Button bClear = new Button();

            xmlDescription = XMLDescription.Instance;

            cbOption.MaxLength = 64;

            cbOption.Items.Add(Constants.strBrack);
            XMLDescription.Instance.FillCombo(cbOption);
            cbOption.Items.Add(Constants.strMarker);
            cbOption.Items.Add(Constants.strParen);
            cbOption.Items.Add(Constants.strNot);
            cbOption.Items.Add(Constants.strMinus);

            cbOption.DropDownStyle = ComboBoxStyle.DropDown;
            cbOption.AutoCompleteMode = AutoCompleteMode.Suggest;
            // WARNING (AutoComplete memory leak):
            cbOption.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbOption.SelectedValueChanged += new EventHandler(cbOption_SelectedValueChanged);
            cbOption.Leave += new EventHandler(cbOption_Leave);
            cbOption.KeyUp += new KeyEventHandler(cbOption_KeyUp);
            cbOption.Margin = new Padding(3, 3, 3, 0);

            this.TitleControl = cbOption;
        }

        private void UpdateTooltip()
        {
            if (cbOption.SelectedItem is Function)
            {
                Function fn = (Function)cbOption.SelectedItem;
                // ToolTipTitle:
                try
                {
                    funcTTip.ToolTipTitle = fn.shortDescription[RegionalSettings.Instance.Language];
                }
                catch (KeyNotFoundException)
                {
                    funcTTip.ToolTipTitle = fn.name;
                }

                // ToolTip text:
                try
                {
                    funcTTip.SetToolTip(cbOption, fn.longDescription[RegionalSettings.Instance.Language]);
                }
                catch (KeyNotFoundException)
                {
                    try
                    {
                        funcTTip.SetToolTip(cbOption, fn.shortDescription[RegionalSettings.Instance.Language]);
                    }
                    catch (KeyNotFoundException)
                    {
                        funcTTip.SetToolTip(cbOption, "?");
                    }
                }
            }
            else
            {
                funcTTip.SetToolTip(cbOption, "");
                funcTTip.ToolTipTitle = "";
            }
        }

        private void SelectFunction()
        {
            Function fn = (Function)cbOption.SelectedItem;
            while (TControls.Count > 2)
            {
                TCDisposeAt(TControls.Count - 1);
            }

            bool varArgs = ((fn.maximalArguments == 0) && (fn.minimalArguments != 0));
            
            // Assume nothing:
            if (varArgs && fn.arguments.Count == 0) {
                Argument arg = new Argument();
                arg.description["english"] = "x";
                arg.description["german"] = "x";
                arg.number = 0;
                arg.optional = false;
                arg.type = "?";
                fn.arguments.Add(arg);
            }

            foreach (Argument arg in fn.arguments)
            {
                // Fix XML bug:
                if (arg.number >= fn.maximalArguments && fn.maximalArguments != 0)
                {
                    break;
                }
                if (!varArgs || arg != fn.arguments[fn.arguments.Count - 1])
                {
                    AddArgControl(arg);
                }
                else
                {
                    AddOArgControl(arg);
                    ((OArgControl)ArgControlAt(TControls.Count - 3)).LButton.Visible = false;
                }
            }

            if (fn.minimalArguments == 0)
            {
                OnExpressionUpdate(this, new EventArgs());
            }

            // Fix XML bug:
            for (int i = ArgCount; i < fn.minimalArguments; i++)
            {
                Argument arg = new Argument();
                arg.description.Add(RegionalSettings.English, "?");
                arg.description.Add(RegionalSettings.German, "?");
                arg.number = i;
                arg.optional = false;
                arg.type = "unknown";

                AddArgControl(arg);
            }
        }

        private void SelectSubExpr()
        {
            while (TControls.Count > 2)
            {
                TCDisposeAt(TControls.Count - 1);
            }
            AddEBuilder();
        }

  
        private void SelectElementList(bool filter)
        {
            while (TControls.Count > 2)
            {
                TCDisposeAt(TControls.Count - 1);
            }
            AddAreaControl(new AreaControl(filter));                       
            
        }

        private void SelectEmpty()
        {
            while (TControls.Count > 2)
            {
                TCDisposeAt(TControls.Count - 1);
            }
            OnExpressionUpdate(this, new EventArgs());
        }
        
        private void UpdateStructure()
        {
            fDBList = new Filter();
            fDatabase = new Filter();
            fCube = new Filter();
            fDimension = new Filter();
            fElement = new Filter();

            fDBList.Delimiter = Constants.DQUOTE;
            fDatabase.Delimiter = Constants.DQUOTE;
            fCube.Delimiter = Constants.DQUOTE;
            fDimension.Delimiter = Constants.DQUOTE;
            fElement.Delimiter = Constants.DQUOTE;

            fDBList.AddEntity(DBList.Instance);
            fDBList.SelectedCBEntity = fDBList.CBEList[0];
            fDBList.AddChild(fDatabase);
            fDatabase.AddChild(fCube);
            fCube.AddChild(fDimension);
            fDimension.AddChild(fElement);

            try
            {
                if (cbOption.SelectedItem is Function)
                {
                    SelectFunction();
                }
                else if ((cbOption.Text == Constants.strParen) || (cbOption.Text == Constants.strNot) || (cbOption.Text == Constants.strMinus))
                {
                    SelectSubExpr();
                }
                else if (cbOption.Text == Constants.strBrack)
                {
                    SelectElementList(false);
                }
                else if (cbOption.Text == Constants.strMarker)
                {
                    SelectElementList(true);
                }
                else
                {
                    SelectEmpty();
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Expression too complex! Expressions that are too complex cannot be edited using Visual Rule Editor. We are sorry for the inconvenience.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FNText = Constants.tooComplex;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error has occured. We are sorry for the inconvenience.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FNText = Constants.error;
            }

            UpdateTooltip();
           
        }

        private void cbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            FNText = cbOption.Text;
            cbOption.Focus();
        }

        private void cbOption_Leave(object sender, EventArgs e)
        {
            FNText = cbOption.Text;
        }

        private void cbOption_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbOption.Text.StartsWith("[["))
                {
                    cbOption.Text = Constants.strMarker;
                }
                else if (cbOption.Text.StartsWith("[") || cbOption.Text == "...")
                {
                    cbOption.Text = Constants.strBrack;
                }
                else if (cbOption.Text.StartsWith("("))
                {
                    cbOption.Text = Constants.strParen;
                }
                FNText = cbOption.Text;
            }
            else if (cbOption.Text.Length > 1 && cbOption.Text[cbOption.Text.Length - 1] == '(') // Like IF(
            {
                cbOption.Text = cbOption.Text.Substring(0, cbOption.Text.Length - 1);
                if (!this.Collapsed && FNText != "" && ArgCount > 0)
                {
                    TControls[2].Focus();
                }
            }
        }

        private void MButton_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            AddOArgControl();
            ((OArgControl)ArgControlAt(TControls.Count - 4)).LButton.Hide();
            ((OArgControl)ArgControlAt(TControls.Count - 4)).MButton.Hide();
            ResumeLayout();
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            TableLayoutPanel tlb = (TableLayoutPanel)lb.Parent;
            MoreLess ml = (MoreLess)tlb.Parent;
            TableLayoutPanel ptlb = (TableLayoutPanel)ml.Parent;
            TableLayoutPanel pptlb = (TableLayoutPanel)ptlb.Parent;
            OArgControl oac = (OArgControl)pptlb.Parent;

            SuspendLayout();
            TControls.Remove(oac);
            ResumeLayout();
            if (TControls[TControls.Count - 2] is OArgControl)  // Don't show "-" if we're on the first OArgControl
            {
                ((OArgControl)TControls[TControls.Count - 1]).LButton.Show();
            }
            ((OArgControl)TControls[TControls.Count - 1]).MButton.Show();
            fDimension.RemoveLastChild();
            OnExpressionUpdate(this, new EventArgs());
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            this.FNText = "";
        }

        #region AufoFill (beta)

        // This one is a wish from Jedox. Though we're not ready yet to efficiently implement this
        // feature, let's try and make a quick-and-dirty solution :-)

        private string cbCubesOldText = "";
        private void cubes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbCubes = sender as ComboBox;

            cbCubesOldText = cbCubes.Text;

            if (marker)
            {
                this.fDimension.Filtered = true;
            }

            if (!(cbCubes.SelectedItem is CBEntity))
            {
                this.SuspendLayout();
                while (ArgCount > 3)
                {
                    TCDisposeAt(TControls.Count - 1);
                    fDimension.RemoveLastChild();
                }
                ArgControlAt(2).TitleControl.Text = "[...]";
                ((OArgControl)ArgControlAt(2)).MButton.Show();

                this.ResumeLayout();
                OnExpressionUpdate(this, new EventArgs());
                return;
            }

            if (cbCubes.SelectedItem != null && cbCubes.SelectedItem is CBEntity)
            {
                int nDims = fDimension.FValue.CBEList.Count;
                this.SuspendLayout();
                while (ArgCount > nDims + 2 && ArgCount > 3)// Always leave "1st dim coordinate"
                {
                    TCDisposeAt(TControls.Count - 1);
                    fDimension.RemoveLastChild();
                }

                while (ArgCount < nDims + 2)
                {
                    AddOArgControl();
                }

                int i = 0;
                fCube.UpdateChildren();
                fDimension.UpdateChildren();
                foreach (CBEntity cbe in fDimension.FValue.CBEList)
                {
                    ArgControlAt(i + 2).TitleControl.Text = cbe.Entity.Name;
                    ((OArgControl)ArgControlAt(i + 2)).LButton.Hide();
                    ((OArgControl)ArgControlAt(i + 2)).MButton.Hide();
                    try
                    {
                        ArgControlAt(i + 2).CFChooserAt(0).CBOption.SelectedIndex = 0;
                    }
                    catch
                    { }
                    i++;
                }
                if (i == 0)
                {
                    ArgControlAt(2).TitleControl.Text = "[...]";
                    ((OArgControl)ArgControlAt(i + 2)).MButton.Show();
                }
                this.ResumeLayout();
            }
        }

        private void cubes_KeyUp(object sender, KeyEventArgs e)
        {
            if (((ComboBox)sender).Text == cbCubesOldText)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                cubes_SelectedIndexChanged(sender, e);
            }
        }

        private void cubes_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == cbCubesOldText)
            {
                return;
            }

            cubes_SelectedIndexChanged(sender, e);
        }

        #endregion
    }
}

