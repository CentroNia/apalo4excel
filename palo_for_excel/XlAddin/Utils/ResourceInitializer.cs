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

using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace Apalo.XlAddin.Utils
{
    public class ResourceInitializer
    {
        #region Define Vars

        private static CultureInfo originalExcelCulture = null;

        private CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;

        public static Color FormStdBackgroundColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);//FromArgb(216, 228, 248);//
        public static Color FormStdHighLightColor = System.Drawing.Color.FromKnownColor(KnownColor.ControlDark);//System.Drawing.SystemColors.Desktop;
        public static Color FormStdButtonBackgroundColor = System.Drawing.Color.FromArgb(255, 238, 236, 233); // good is also 255, 237, 235, 232
        
        public static Font RegularFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));


        #region Bitmaps
        public static Bitmap IconRefresh;
        public static Bitmap IconRefreshH;

        public static Bitmap IconCheckmark;
        public static Bitmap IconShowHierarchy;
        //public static Bitmap IconShowFlat;
        public static Bitmap IconShowHierarchyButtonP;
        public static Bitmap IconShowFlatButton;
        public static Bitmap IconCollapseAll;
        public static Bitmap IconExpandAll;

        public static Bitmap StringElement;
        public static Bitmap NumericElement;
        public static Bitmap ConsolidatedElement;

        public static Bitmap IconConnect;
        public static Bitmap IconDisconnect;
        public static Bitmap IconApply;
        public static Bitmap IconCancel;

        public static Bitmap IconConnectH;
        public static Bitmap IconDisconnectH;
        public static Bitmap IconApplyH;
        public static Bitmap IconCancelH;

        public static Bitmap IconUp;
        public static Bitmap IconRight;
        public static Bitmap IconLeft;
        public static Bitmap IconDown;

        public static Bitmap IconUpH;
        public static Bitmap IconRightH;
        public static Bitmap IconLeftH;
        public static Bitmap IconDownH;

        public static Bitmap IconElementAdd;
        public static Bitmap IconElementDelete;
        public static Bitmap IconElementRename;
        public static Bitmap IconElementEdit;
        public static Bitmap IconDimensionAdd;
        public static Bitmap IconDimensionDelete;
        public static Bitmap IconDimensionEdit;
        public static Bitmap IconCubeAdd;
        public static Bitmap IconCubeDelete;
        public static Bitmap IconCubeRule;
        public static Bitmap IconWizard;
        public static Bitmap IconHome;

        public static Bitmap IconElementAddH;
        public static Bitmap IconElementDeleteH;
        public static Bitmap IconElementRenameH;
        public static Bitmap IconElementEditH;
        public static Bitmap IconDimensionAddH;
        public static Bitmap IconDimensionDeleteH;
        public static Bitmap IconDimensionEditH;
        public static Bitmap IconCubeAddH;
        public static Bitmap IconCubeDeleteH;
        public static Bitmap IconCubeRuleH;
        public static Bitmap IconWizardH;
        public static Bitmap IconHomeH;


        //public static Bitmap IconRuleExport;
        //public static Bitmap IconRuleImport;

        public static Bitmap IconPasteVertical;
        public static Bitmap IconPasteHorizontal;
        

        public static Bitmap IconFilterUserOn;
        public static Bitmap IconFilterDataOn;
        public static Bitmap IconFilterAttributeOn;
        public static Bitmap IconFilterAttributeOnH;

        public static Bitmap IconToggleUser;
        public static Bitmap IconToggleUserH;
        public static Bitmap IconToggleCube;
        public static Bitmap IconToggleCubeH;
        public static Bitmap IconToggleAttribute;
        public static Bitmap IconToggleAttributeH;

        public static Bitmap IconToggleCache;
        public static Bitmap IconToggleCacheH;

        public static Bitmap IconImport;
        public static Bitmap IconImportH;
        public static Bitmap IconExport;
        public static Bitmap IconExportH;

        public static Bitmap IconExpandAllButton;
        public static Bitmap IconExpandAllButtonH;
        public static Bitmap IconCollapseAllButton;
        public static Bitmap IconCollapseAllButtonH;

        public static Bitmap IconExpand;
        public static Bitmap IconExpandH;

        public static Bitmap IconCollapse;
        public static Bitmap IconCollapseH;

        public static Bitmap IconExpand1;
        public static Bitmap IconExpand1H;

        public static Bitmap IconExpand2;
        public static Bitmap IconExpand2H;

        public static Bitmap IconExpand3;
        public static Bitmap IconExpand3H;

        public static Bitmap IconExpand4;
        public static Bitmap IconExpand4H;

        public static Bitmap IconExpand5;
        public static Bitmap IconExpand5H;

        public static Bitmap IconExpand6;
        public static Bitmap IconExpand6H;

        public static Bitmap IconExpand7;
        public static Bitmap IconExpand7H;

        public static Bitmap IconExpand8;
        public static Bitmap IconExpand8H;
        //public static System.Windows.Forms.Cursor ButtonCursor;
        public static Icon IconPalo;

        public static Bitmap WizardLogo;

        public static Bitmap ListOrderHistory;
        public static Bitmap ListOrderAZ;
        public static Bitmap ListOrderZA;

        public static Bitmap IconBlank;
        public static Bitmap IconDefaultHome;

        public static Bitmap IconToggleSystemCubes;


        #endregion

        #region Strings

        public static string LabelCheckForUpdates;
        public static string TitleRuleError;
        public static string LabelRuleError;
        public static string CmdRuleAdd;
        public static string CmdRuleDelete;
        public static string CmdRuleEdit;
        public static string CmdRuleMoveUp;
        public static string CmdRuleMoveDown;
        public static string CmdRuleChangeStatus;
        public static string CmdRuleToggleActivity;
        public static string CmdRuleInfo;

        public static string ItemElements;
        public static string ItemAttributes;
        public static string ItemSubsets;

        public static string RuleInfoRule;
        public static string LabelButtonEdit;
        public static string RuleInfoUpdated;
        public static string LabelButtonNewRule;

        public static string AddSubset;
        public static string DeleteSubset;
        public static string RenameSubset;
        public static string LabelSubsetElements;
        public static string TooltipSubsetElements;


        
        public static string MENU_PASTE_SUBSET;
        public static string UpdateButton;
        public static string MENU_TITLE;
        public static string MENU_PASTE_VIEW;
        public static string MENU_SAVE_SNAPSHOT;
        public static string MENU_PASTE_ELEMENTS;
        public static string MENU_PASTE_FUNCTION;
        public static string MENU_MODELLER;
        public static string MENU_DATA_IMPORT;
        public static string MENU_PALO_WIZARD;
        public static string MenuClientCache;
        public static string MENU_ABOUT;
        public static string MENU_BEGIN_UNDO;
        public static string MENU_UNDO;
        public static string MENU_ROLLBACK;
        public static string MENU_COMMIT;

        public static string ServerDNSNameOrIP;

        public static string MoveElementToBeginning;
        public static string MoveElementToEnd;

        public static string CmdDimensionExport;
        public static string LabelDimExportSeparator;
        public static string LabelDimExportHierarchy;
        public static string FILE_WRITTEN_SUCCESS;

        public static string TipCubeFilterData;
        public static string TipCubeFilterAttribute;
        public static string TipCubeFilterUser;
        public static string TipFilterData;
        public static string TipFilterUser;

        public static string TipButtonCreationOrder;
        public static string TipButtonSortAscending;
        public static string TipButtonSortDescending;

        public static string ToolTipShowSystemCubes;

        public static string TipRuleBtnMoveUp;
        public static string TipRuleBtnMoveDown;
        public static string TipRuleBtnExport;
        public static string TipRuleBtnImport;
        public static string TipRuleBtnDelete;
        public static string TipRuleBtnSave;
        public static string TipRuleBtnClose;
        public static string HintNewRule;
        public static string StatusRuleSaved;
        public static string StatusRuleDeleted;
        public static string StatusRuleExportSuccess;
        public static string StatusRuleExportError;
        public static string StatusRuleImportSuccess;
        public static string StatusRuleImportError;
        public static string LabelRuleDefinition;
        public static string QuestionDeleteExistingRules;
        public static string QuestionDeleteRules;

        public static string CmdRuleEditor;
        public static string ButtonRuleSave;
        public static string ButtonRuleDelete;
        public static string ButtonRuleExit;
        public static string TitleRuleEditor;
        public static string LabelRuleEditor;
        public static string LabelNewRule;

        public static string ButtonSearch;
        public static string SearchElementCaption;
        public static string SearchElementTip;
        public static string ClearCubeCaption;
        public static string ButtonClearWholeCube;
        public static string ButtonClearCube;
        public static string ButtonClearWholeCubeTip;
        public static string ButtonClearCubeTip;

        public static string ClearCubeStatus;

        public static string MessageClearCube;
        public static string MessageWholeClearCube;

        public static string CommandSearchElement;

        public static string CommandDimensionInfo;
        public static string CommandCubeRename;


        public static string DimensionInfoTitle;
        public static string DimensionInfoIdentifier;
        public static string DimensionInfoName;
        public static string DimensionInfoNumberElements;
        public static string DimensionInfoElements;
        public static string DimensionInfoNElements;
        public static string DimensionInfoSElements;
        public static string DimensionInfoCElements;
        public static string DimensionInfoMaximumLevel;
        public static string DimensionInfoMaximumIndent;
        public static string DimensionInfoMaximumDepth;
        public static string DimensionInfoAttributeCube;
        public static string DimensionInfoType;

        public static string CubeInfoTitle;
        public static string CubeInfoIdentifier;
        public static string CubeInfoName;
        public static string CubeInfoNumberDimensions;
        public static string CubeInfoDimensions;
        public static string CubeInfoNumberCells;
        public static string CubeInfoNumberFilledCells;
        public static string CubeInfoFillRatio;
        public static string CubeInfoStatus;
        public static string CubeInfoType;

        public static string TipRuleEditor;
        public static string TipFilterAttribute;

        public static string MESSAGE_LIMIT_VIEW_SIZE;
        public static string EXCEL_CHARS_TITLE;
        public static string EXCEL_CHARS_MESSAGE;

        public static string ERROR_CLIPBOARD_PASTE_TITLE;
        public static string ERROR_CLIPBOARD_PASTE;

        public static string LABEL_CHECK_DISABLE_USER_MNG;
        public static string LABEL_CHECK_SHOW_ATTRIB;
        public static string LABEL_CHECK_INDENT;

        public static string LABEL_EXPORT_PAGE2_2;
        public static string LABEL_CHECK_ELEMENT_SELECTOR;
        public static string MESSAGE_MERGED_CELLS;
        public static string LABEL_SELECT_ALL_ELEMENTS;
        public static string LABEL_EXPORT_PAGE_3_1;
        public static string LabelDimExportCaption;
        public static string LABEL_CHECK_WORDWRAP;
        public static string LABEL_CHECK_ZERO_SUPPRESSION;
        public static string LABEL_CHECK_ZERO_SUPPRESSION_ALSO_CALULATED_NULL;

        public static string MESSAGE_ELEMENT_DROP;
        public static string TITLE_MODELLER;

        public static string PALO_ERR_TYPE;
        public static string PALO_ERR_INV_ARG;
        public static string PALO_ERR_CUBE_NOT_FOUND;
        public static string PALO_ERR_DIM_ELEMENT_INV_TYPE;
        public static string PALO_ERR_DIM_ELEMENT_NOT_FOUND;
        public static string PALO_ERR_INV_FORMAT;

        public static string XLL_ERROR_TITLE;
        public static string CMD_ADD_CHILD;
        public static string CMD_ADD_SIBLING;
        public static string CMD_COPY_CHILD;
        public static string CMD_COPY_SIBLING;
        public static string TITLE_EDIT_VALUE;
        public static string LABEL_EDIT_VALUE;
        public static string LABEL_EDIT_VALUE_2007;
        public static string LABEL_CHARS_NUMBER;

        public static string CMD_ADD_ELEMENT;
        public static string CMD_DELETE_ELEMENT;
        public static string CMD_REMOVE_ELEMENT;
        public static string CMD_RENAME_ELEMENT;
        public static string CMD_SHOW_PARENTS;
        public static string CMD_EDIT_ELEMENT;
        public static string CMD_NUMERIC_ELEMENT;
        public static string CMD_STRING_ELEMENT;
        public static string CMD_COPY_ELEMENT;
        public static string CMD_PASTE_ELEMENT;
        public static string CMD_SELECTALL_ELEMENT;
        public static string CMD_COUNT_ELEMENT;

        public static string CMD_FACTOR;
        public static string CMD_DELETE_SOURCE_ELEMENT;

        public static string CMD_ADD_DIMENSION;
        public static string CMD_DELETE_DIMENSION;
        public static string CMD_RENAME_DIMENSION;
        public static string CMD_EDIT_DIMENSION;

        public static string CMD_ADD_CUBE;
        public static string CMD_DELETE_CUBE;
        public static string CMD_CLEAR_CUBE;
        public static string CMD_EXPORT_CUBE;
        public static string CMD_EXPORT_DIM;
        public static string CMD_CONVERT_CUBE;

        public static string MSG_LONG_ACTION;
        public static string QUESTION_LONG_ACTION;

        public static string CmdMeasure;
        public static string CmdTime;

        public static string LABEL_NEW_ELEMENT;
        public static string LABEL_NEW_DIMENSION;
        public static string LABEL_NEW_ATTRIBUTE;
        public static string LABEL_NEW_SUBSET;

        public static string ERROR_CIRCULAR;
        public static string ERROR_ELEMENT_EXISTS;
        public static string ERROR_ELEMENT_NAME_INVALID;
        public static string ERROR_DIMENSION_EXISTS;
        public static string ERROR_DIMENSION_NAME_EMPTY;
        public static string ERROR_DIMENSION_NAME_INVALID;
        public static string ERROR_CUBE_NAME_INVALID;

        public static string ERROR_CUBE_NAME_EMPTY;
        public static string ERROR_CUBE_NO_DIMENSION;
        public static string ERROR_CUBE_EXISTS;
        public static string MESSAGE_COUNT_ELEMENTS;

        public static string LabelDimName;
        public static string LabelTemplate;
        public static string LabelDimTemplateCaption;
        public static string TitleDimTemplate;
        public static string TextWithoutTemplate;

        public static string TITLE_IMPORT_WIZARD;
        public static string LABEL_IMPORT_PAGE1_1;
        public static string LABEL_IMPORT_PAGE1_2;
        public static string LABEL_IMPORT_PAGE1_3;
        public static string LABEL_IMPORT_PAGE1_4;
        public static string LABEL_IMPORT_PAGE1_5;
        public static string LABEL_IMPORT_PAGE1_6;
        public static string LABEL_IMPORT_PAGE1_7;
        public static string LABEL_IMPORT_PAGE2_1;
        public static string LABEL_IMPORT_PAGE2_2;
        public static string LABEL_OPTION_TAB;
        public static string LABEL_OPTION_BLANK;
        public static string LABEL_OPTION_COMMA;
        public static string LABEL_OPTION_USERDEFINED;
        public static string LABEL_OPTION_SEMICOLON;
        public static string LABEL_OPTION_DECIMALPOINT;
        public static string LABEL_IMPORT_PAGE3_1;
        public static string LABEL_IMPORT_PAGE3_2;
        public static string LABEL_IMPORT_PAGE3_3;
        public static string LABEL_IMPORT_PAGE3_4;
        public static string LABEL_IMPORT_PAGE4_1;
        public static string LABEL_IMPORT_PAGE5_1;
        public static string LABEL_IMPORT_PAGE5_2;
        public static string LABEL_IMPORT_PAGE5_3;
        public static string LabelDimExportOneRow;
        public static string LabelDimExportNCFormat;
        public static string STATUS_GENERATE_VIEW;
        public static string STATUS_SCAN_SELECTION;
        public static string STATUS_SCAN_SHEET;
        public static string STATUS_LOAD_XLL;
        public static string STATUS_READ_CSV;
        public static string STATUS_READ_CUBE_WAIT;
        public static string STATUS_READ_SQL_WAIT;
        public static string ERROR_FILE_NOT_FOUND;

        public static string BUTTON_BROWSE;
        public static string BUTTON_DELETE;
        public static string BUTTON_SAVE;

        public static string ERROR_LOADING_MESSAGE1;
        public static string ERROR_LOADING_MESSAGE2;
        public static string ERROR_LOADING_MESSAGE3;
        public static string ERROR_LOADING_MESSAGE4;
        public static string ERROR_LOADING_MESSAGE5;
        public static string STATUS_STARTING_PALO;
        public static string LOADING_MESSAGE1;
        public static string COMMITING_CHANGES;

        public static string LABEL_DIMENSIONS;
        public static string LABEL_CUBES;

        public static string TITLE_EXPORT_WIZARD;
        public static string TITLE_PASTE_FUNCTION;
        public static string TEXT_GUESS_ARG;
        public static string TITLE_CHOOSE_ELEMENT;
        public static string TITLE_CHOOSE_ELEMENT2;
        public static string BUTTON_ALL;
        public static string BUTTON_SELECTED;
        public static string TEXT_ELEMENTS2PASTED;
        public static string BUTTON_HPASTE;
        public static string BUTTON_VPASTE;
        public static string BUTTON_SORT_DOWN;
        public static string BUTTON_SORT_UP;
        public static string BUTTON_CLEAR_LIST;
        public static string TEXT_SHOW_SEL_TOOL;
        public static string BUTTON_SELECT_ALL;
        public static string BUTTON_SELECT_NONE;
        public static string BUTTON_SELECT_BRANCH;
        public static string BUTTON_SELECT_INVERT;
        public static string TEXT_TIP_SHIFT;
        public static string BUTTON_SEARCH_SELECT;
        public static string BUTTON_EXPAND_ALL;
        public static string BUTTON_COLLAPSE_ALL;
        public static string BUTTON_CON_STRING;
        public static string BUTTON_CUBE_STRING;
        public static string BUTTON_DIM_STRING;
        public static string TEXT_RESTRICT_PASTE2CURR_SELECTION;
        public static string STATUS_READING_ELEMENTS_SERVER;
        public static string STATUS_LOOKING4SERVER_WAIT;
        public static string TEXT_ALIAS;
        public static string TEXT_FORMAT;
        public static string TEXT_ALIAS_FORMAT;
        public static string TEXT_ELEMENT_NAME;
        public static string TEXT_SUBSET;
        public static string TEXT_CUBES;
        public static string TEXT_DIMENSIONS;
        public static string TEXT_DIM_ELEMENTS;
        public static string TEXT_DATABASE_ELEMENTS;
        public static string TEXT_META;
        public static string TEXT_SERVER;
        public static string TEXT_CONNECTION;
        public static string TEXT_DATABASE;
        public static string TEXT_VAR_INSERT;
        public static string TEXT_CUBE_NAME;
        public static string TEXT_DIMENSION_NAMES;

        public static string BUTTON_PASTE_HEAD;

        public static string TEXT_HIT_RETURN_VIEWDIMS;
        public static string TEXT_HIT_RETURN_VIEWCUBES;
        public static string TEXT_HIT_RETURN_ELEMENTS;
        public static string TEXT_HIT_RETURN_SOURCEELEMENTS;
        public static string TEXT_HIT_RETURN_ATTRIBUTES;
        public static string TEXT_HIT_RETURN_SUBSETS;

        public static string TEXT_DATAAXIS_INUSE;
        public static string TEXT_DATAAXIS_INUSE_TITLE;

        public static string TEXT_DELETE_DATASTORE;
        public static string TEXT_DELETE_DATASTORE_TITLE;

        public static string TEXT_CLEAR_CUBE;
        public static string TEXT_CLEAR_CUBE_TITLE;

        public static string TEXT_DELETE_DATAAXIS;
        public static string TEXT_DELETE_DATAAXIS_TITLE;

        public static string TEXT_DELETE_ELEMENTS;
        public static string TEXT_DELETE_ELEMENTS_TITLE;

        public static string TEXT_CONVERT_TO_NUMERIC;
        public static string TEXT_CONVERT_TO_NUMERIC_TITLE;

        public static string TEXT_CONVERT_CONS_TO_NUMERIC;
        public static string TEXT_CONVERT_CONS_TO_NUMERIC_TITLE;

        public static string TEXT_CONVERT_TO_STRING;
        public static string TEXT_CONVERT_TO_STRING_TITLE;

        public static string TEXT_CONVERT_CONS_TO_STRING;
        public static string TEXT_CONVERT_CONS_TO_STRING_TITLE;

        public static string TEXT_CONVERT_TO_CONS;
        public static string TEXT_CONVERT_TO_CONS_TITLE;

        public static string TEXT_PASTE_ELEMENTS;
        public static string TEXT_PASTE_ELEMENTS_TITLE;
        public static string TEXT_DIMELEMENT_NOT_FOUND;
        public static string TEXT_NO_FURTHER_DIMELEMENT;

        public static string TEXT_HAS_HEADER;
        public static string TEXT_APPEND2CSV;

        public static string TIP_CHOOSE_ELEMENTS;
        public static string TIP_CHOOSE_CUBE;
        public static string TIP_COMBO_CONNECTIONS;
        public static string TIP_BUTTON_ADD_DIMENSION;
        public static string TIP_BUTTON_DELETE_DIMENSION;
        public static string TIP_BUTTON_RENAME_DIMENSION;
        public static string TIP_BUTTON_EDIT_DIMENSION;
        public static string TIP_BUTTON_ADD_CUBE;
        public static string TIP_BUTTON_DELETE_CUBE;

        public static string TIP_BUTTON_ADD_ELEMENT;
        public static string TIP_BUTTON_DELETE_ELEMENT;
        public static string TIP_BUTTON_RENAME_ELEMENT;
        public static string TIP_BUTTON_CONSOLIDATE_ELEMENT;

        public static string TIP_BUTTON_MOVE_ELEMENT_UP;
        public static string TIP_BUTTON_MOVE_ELEMENT_LEFT;
        public static string TIP_BUTTON_MOVE_ELEMENT_RIGHT;
        public static string TIP_BUTTON_MOVE_ELEMENT_DOWN;

        public static string TIP_BUTTON_APPLY_CHANGES;
        public static string TIP_BUTTON_CANCEL_CHANGES;

        public static string TIP_CHECK_TREE;
        public static string TIP_CHECK_FACTOR;

        public static string TIP_BUTTON_DATABASE;
        public static string TIP_BUTTON_MODELLER_CLOSE;
        public static string TIP_BUTTON_TOGGLE_CONNECTION;
        public static string TIP_BUTTON_PALO_WIZARD;

        public static string TIP_TREE_DIMENSIONS;
        public static string TIP_TREE_CUBES;
        public static string TIP_TREE_ELEMENTS;
        public static string TIP_TREE_ELEMENTS_CONSOLIDATED;

        public static string TIP_BUTTON_TOGGLE_CONNECT;
        public static string TIP_BUTTON_TOGGLE_DISCONNECT;

        public static string BUTTON_DATABASE;
        public static string LABEL_ELEMENTS_CONSOLIDATED;
        public static string LABEL_ELEMENTS;
        public static string LABEL_CHECK_FACTOR;
        public static string LABEL_CHECK_TREE;
        public static string LABEL_CHECK_WITHHEADER;
        public static string LABEL_HEADER_NAME;
        public static string LABEL_HEADER_FACTOR;

        public static string TITLE_EXPORT_DIMENSION;
        public static string TITLE_CUBE_WIZARD;
        public static string LABEL_CUBE_WIZARD_1;
        public static string LABEL_CUBE_WIZARD_2;
        public static string LABEL_AVAILABLE_DIMENSIONS;
        public static string LABEL_SELECTED_DIMENSIONS;
        public static string BUTTON_CANCEL;
        public static string BUTTON_FINISH;
        public static string TIP_TREE_AVAILABLE_DIMENSIONS;
        public static string TIP_TREE_SELECTED_DIMENSIONS;
        public static string TIP_BUTTON_MOVE_UP_DIMENSION;
        public static string TIP_BUTTON_MOVE_RIGHT_DIMENSION;
        public static string TIP_BUTTON_MOVE_LEFT_DIMENSION;
        public static string TIP_BUTTON_MOVE_DOWN_DIMENSION;
        public static string TIP_BUTTON_CLOSE_WIZARD;
        public static string TIP_BUTTON_OK_CUBE_WIZARD;
        public static string QUESTION_CUBE_WIZARD;

        public static string WIZARD_LABEL1;
        public static string WIZARD_LABEL2;
        public static string WIZARD_LABEL3;
        public static string WIZARD_LABEL4;
        public static string WIZARD_LABEL5;

        public static string WIZARD_LABEL7;
        public static string WIZARD_LABEL7E;
        public static string WIZARD_LABEL8;
        public static string WIZARD_LABEL8E;
        public static string WIZARD_LABEL29;
        public static string WIZARD_LABEL32;
        public static string WIZARD_LABEL30;
        public static string WIZARD_LABEL31;

        public static string WIZARD_LABEL13;
        public static string WIZARD_LABEL12;

        public static string WIZARD_LABEL16;
        public static string WIZARD_LABEL18;
        public static string WIZARD_LABEL19;
        public static string TIP_CHOOSE_DATABASE;

        public static string WIZARD_TITLE;
        public static string WIZARD_PAGE_TITLE;

        public static string WIZARD_OPTION1;
        public static string WIZARD_OPTION2;
        public static string WIZARD_OPTION3;
        public static string WIZARD_OPTION4;
        public static string WIZARD_OPTION5;
        public static string WIZARD_OPTION6;
        public static string WizardPaloAuthentication;
        public static string WizardWindowsAuthentication;
        public static string TipSVS;

        public static string BUTTON_CONNECT;
        public static string BUTTON_DISCONNECT;
        public static string BUTTON_NEXT;
        public static string BUTTON_BACK;
        public static string BUTTON_CLOSE;
        public static string BUTTON_OK;
        public static string BUTTON_TEST_CONNECTION;

        public static string TIP_STEP_BACK;
        public static string TIP_STEP_NEXT;

        public static string LABEL_LOGON_DATA;
        public static string TIP_CHOOSE_SERVER;

        public static string ERROR_DATABASE_EXISTS;
        public static string ERROR_DATABASE_INVALID_NAME;
        public static string QUESTION_DELETE_DATABASE;
        public static string QUESTION_DELETE_DATABASE_TITLE;
        public static string INFO_DATABASE_DELETED;
        public static string INFO_DATABASE_CREATED;
        public static string INFO_SERVER_REGISTERED;
        public static string ERROR_REGISTER_SERVER;
        public static string QUESTION_UNREGISTER_SERVER;
        public static string QUESTION_UNREGISTER_TITLE;
        public static string INFO_SERVER_UNREGISTERED;
        public static string INFO_TEST_OK;
        public static string ERROR_CONNECTING;
        public static string ERROR_INVALID_DATA;

        public static string PASTE_VIEW_WAIT;
        public static string PASTE_VIEW_TITLE;
        public static string TEXT_CHOOSE_SERVER_DB;
        public static string TEXT_CHOOSE_CUBE;
        public static string TEXT_CHOOSE_STYLE;
        public static string PASTE_VIEW_LABEL3;
        public static string PASTE_VIEW_LABEL4;
        public static string PASTE_VIEW_LABEL5;
        public static string PASTE_VIEW_LABEL6;
        public static string PASTE_VIEW_LABEL7;
        public static string LABEL_CHECK_AUTOFIT;
        public static string BUTTON_PASTE;
        public static string TIP_FUCTION_TYPE;
        public static string TIP_AUTOFIT;
        public static string TIP_BUTTON_PASTE_VIEW;
        public static string TIP_BUTTON_CLOSE_PASTE_VIEW;

        public static string ERROR_DATA_NOT_FOUND;
        public static string ERROR_READING_FROM_DATABASE;
        public static string WARNING_DELETE_SQL_FILE;
        public static string TEXT_SELECT_DSN;
        public static string TITLE_DELETE;
        public static string LABEL_NEW;
        public static string LABEL_CSV_FILTER;
        public static string LABEL_SELECT_ACTION;
        public static string LABEL_SQL_FILTER;

        public static string TEXT_ATTRIBUTE;
        public static string TEXT_ATTRIBUTE_CUBES;
        public static string TEXT_SHOW_ATTRIBUTE;
        public static string TEXT_NONE;
        public static string ERROR_INSUFFICIENT_RIGTHS;
        public static string ERROR_NO_FORMULA_B1;
        public static string ErrorUsername;

        public static string QUESTION_DELETE_CELLS;
        public static string ERROR_COPY_ARGS_NOT_UNIQUE;
        public static string LABEL_EXPORT_USE_RULES;
        public static string LABEL_IMPORT_BLANK_LINE;
        public static string LABEL_NEWLINE;

        public static string CMD_CUBE_INFO;
        public static string MESSAGE_CUBE_INFO;
        public static string TEXT_UNLOADED;
        public static string TEXT_LOADED;
        public static string TEXT_CHANGED;
        public static string TEXT_UNKNOWN;
        public static string TEXT_SYSTEM;
        public static string TEXT_ATTRIBUT;
        public static string TEXT_NORMAL;
        public static string TEXT_USER_INFO;

        public static string CacheRadio1Label;
        public static string CacheRadio2Label;
        public static string CacheRadio3Label;
        public static string CacheDialogGroupCaption;
        public static string CacheDialogCaption;
        public static string TipCacheDialog;
        public static string TipCacheRadio1;
        public static string TipCacheRadio2;
        public static string TipCacheRadio3;

        public static string TEXT_SELECT_ELEMENTS;
        public static string TEXT_CHOOSE_ELEMENT;

        public static string TEXT_EXPAND_ALL;
        public static string TEXT_COLLAPSE_ALL;
        public static string BUTTON_PARSE;
        public static string BUTTON_MAXIMIZE;
        public static string TEXT_RULE;
        public static string TEXT_RULEEDITOR_ADVANCED;
        public static string TEXT_COMMENT;
        public static string BUTTON_HIDECOMMENT;
        public static string BUTTON_SHOWCOMMENT;
        public static string BUTTON_REFRESH_LIST;

        public static string RB_CONSOLIDATION_PRIORITY;
        public static string RB_PRIORITY_NONE;
        public static string RB_PRIORITY_N;
        public static string RB_PRIORITY_C;

        public static string PaloOnlineMenu;
        public static string PaloOnlineLogin;
        public static string PaloOnlineLogOut;
        public static string PaloOnlineBasicHelp;
        public static string PaloOnlineAdvancedHelp;

        public static string PaloWebMenu;
        public static string PaloWebSaveAs;
        public static string PaloWebOpen;
        public static string PaloWebWizard;

        public static string URL_EMPTY;
        public static string URL_NOT_WELLFOMED;

        public static string PWW_T1Heading;
        public static string PWW_T1ConnectionHeading;
        public static string PWW_T1ConnectionLabel;
        public static string PWW_T1ConnectionMarkDefault;
        public static string PWW_T1ConnectionAction;
        public static string PWW_T1New;
        public static string PWW_T1Remove;
        public static string PWW_T1Edit;
        public static string PWW_T2Heading;
        public static string PWW_T2ConnectionHeading;
        public static string PWW_T2ConnectionName;
        public static string PWW_T2ConnectionURL;
        public static string PWW_T2Username;
        public static string PWW_T2Password;
        public static string PWW_T2Secret;
        public static string PWW_DefaultConnectionTitle;
        public static string PWW_DefaultConnectionMsg;
        public static string PWW_Title;
        
        public static string lblPaloOnlineUsername;
        public static string lblPaloOnlinePassword;
        public static string lblPaloOnlineLink;
        public static string lblPaloOnlineText;
        public static string txtPaloOnline;
        public static string strPaloOnlineTitle;
        public static string btnPaloOnlineOK;
        public static string btnPaloOnlineCancel;

        public static string TITLE_SVS_WIZARD;
        public static string SVS_WIZARD_SETP1_TEXT;
        public static string SVS_WIZARD_SETP2_TEXT;
        public static string SVS_WIZARD_SETP3_TEXT;
        public static string SVS_WIZARD_SETP4_TEXT;
        public static string SVS_WIZARD_SETP5_TEXT;
        public static string CMD_SVS_WIZARD;
        public static string SVS_RADIOBUTTON1_TEXT;
        public static string SVS_RADIOBUTTON1_DESCRIPTION;
        public static string SVS_RADIOBUTTON2_TEXT;
        public static string SVS_RADIOBUTTON2_DESCRIPTION;
        public static string SVS_RADIOBUTTON3_TEXT;
        public static string SVS_RADIOBUTTON3_DESCRIPTION;
        public static string SVS_RADIOBUTTON4_TEXT;
        public static string SVS_RADIOBUTTON4_DESCRIPTION;
        public static string SVS_RADIOBUTTON5_TEXT;
        public static string SVS_RADIOBUTTON5_DESCRIPTION;
        public static string SVS_RADIOBUTTON6_TEXT;
        public static string SVS_RADIOBUTTON6_DESCRIPTION;
        public static string SVS_SAVE_TEXT;

        public static string updateCheckTitle;
        public static string updateCheckText;


        public static string ACTIVATE_UPDATE_SEARCH;

        #region InfoBox
        public static string InfoBox_btnDemoApp;
        public static string InfoBox_btnFirstSteps;
        public static string InfoBox_btnAdvancedManual;
        public static string InfoBox_btnTraining;
        public static string InfoBox_bntAbout;
        public static string InfoBox_btnClose;
        public static string InfoBox_adTitle;
        public static string InfoBox_adTitleLogo;
        public static string InfoBox_lblDemoApp;
        public static string InfoBox_lblFirstSteps;
        public static string InfoBox_lblPaloMenu1;
        public static string InfoBox_lblMyPalo;
        public static string InfoBox_lblPaloMenu2;
        public static string InfoBox_chkAnnoyBox;
        #endregion

        #region LicenseBox
        public static string LicenseBox_btnContinue;
        public static string LicenseBox_btnCompare;
        public static string LicenseBox_btnCEDownload;
        public static string LicenseBox_btnQuote;
        public static string LicenseBox_lblLicense;
        public static string LicenseBox_lblLicenseExpired;
        public static string LicenseBox_lblQuote;
        public static string LicenseBox_lblComparison;
        public static string LicenseBox_lblCommunity;
        #endregion

        #endregion

        #endregion

        public static Hashtable HT_SB_RES;

        public ResourceInitializer(CultureInfo ExcelCulture)
		{
            if (ExcelCulture == null)
            {
                originalExcelCulture = originalUICulture;
                return;
            }

            originalExcelCulture = ExcelCulture;

			Thread thisThread = Thread.CurrentThread;

			#region Image resources


			try
			{
				thisThread.CurrentUICulture = new CultureInfo("en-US");

				System.IO.Stream picture_stream1 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.connect24.png");
				System.IO.Stream picture_stream2 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.disconnect24.png");
				System.IO.Stream picture_stream3 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.apply24.png");
				System.IO.Stream picture_stream4 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.cancel24.png");
				System.IO.Stream picture_stream5 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.up24.png");
				System.IO.Stream picture_stream6 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.right24.png");
				System.IO.Stream picture_stream7 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.left24.png");
				System.IO.Stream picture_stream8 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.down24.png");
				System.IO.Stream picture_stream11 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.newElement24.png");
				System.IO.Stream picture_stream12 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.deleteElement24.png");
				System.IO.Stream picture_stream13 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.renameElement24.png");
				System.IO.Stream picture_stream14 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.consolidateElement24.png");
				System.IO.Stream picture_stream15 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Dimesion_new.png");
				System.IO.Stream picture_stream16 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Dimesion_delete.png");
				System.IO.Stream picture_stream17 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Dimesion_edit.png");
				System.IO.Stream picture_stream18 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.newCube24.png");
				System.IO.Stream picture_stream19 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.deleteCube24.png");
				System.IO.Stream picture_stream20 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.wizard.png");
				System.IO.Stream picture_stream21 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.v.ico");
				System.IO.Stream picture_stream22 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.h.ico");
				System.IO.Stream picture_stream23 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.string.png");
				System.IO.Stream picture_stream24 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.numeric.png");
				System.IO.Stream picture_stream25 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.consolidated.png");

				System.IO.Stream picture_stream26 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.attrib16_filter_on.png");
				System.IO.Stream picture_stream27 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.data16_filter_on.png");
				System.IO.Stream picture_stream28 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.user16_filter_on.png");

                System.IO.Stream picture_stream29 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.toggleuser24.png");
                System.IO.Stream picture_stream30 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.togglecube24.png");
                System.IO.Stream picture_stream31 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.rule_editor24.png");

                System.IO.Stream picture_stream34 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.databaseSettings1.png");

                System.IO.Stream picture_stream35 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.up24_h.png");
                System.IO.Stream picture_stream36 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.down24_h.png");
                System.IO.Stream picture_stream37 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.left24_h.png");
                System.IO.Stream picture_stream38 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.right24_h.png");

                System.IO.Stream picture_stream39 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Home1.png");

                System.IO.Stream picture_stream40 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.add2.png");
                System.IO.Stream picture_stream41 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.remove2.png");
                System.IO.Stream picture_stream42 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.rename2.png");
                System.IO.Stream picture_stream43 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.edit2.png");


                System.IO.Stream picture_stream44 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Import1.png");
                System.IO.Stream picture_stream45 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Import2.png");
                System.IO.Stream picture_stream46 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Export1.png");

                System.IO.Stream picture_stream47 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.cubeadd2.png");
                System.IO.Stream picture_stream48 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.cuberemove2.png");

                System.IO.Stream picture_stream49 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.rule_editor24h.png");
                System.IO.Stream picture_stream50 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.wizardh.png");
                System.IO.Stream picture_stream51 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Home2.png");
                System.IO.Stream picture_stream52 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.databaseSettings2.png");

                System.IO.Stream picture_stream53 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.connect24h.png");
                System.IO.Stream picture_stream54 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.disconnect24h.png");
                System.IO.Stream picture_stream55 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.apply24h.png");
                System.IO.Stream picture_stream56 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.cancel24h.png");

                System.IO.Stream picture_stream57 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.toggleuser24h.png");
                System.IO.Stream picture_stream58 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.togglecube24h.png");
                System.IO.Stream picture_stream59 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Table2.png");
                System.IO.Stream picture_stream60 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Table1.png");
                System.IO.Stream picture_stream61 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Export2.png");

                System.IO.Stream picture_stream32 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.ShowHierarchy16x16.png");
                System.IO.Stream picture_stream33 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.CollapseAll16x16.png");
                System.IO.Stream picture_stream62 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.ExpandAll16x16.png");
                //System.IO.Stream picture_stream63 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.ShowFlat16x16.png");

                System.IO.Stream picture_stream64 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.ShowHierarchy.png");
                System.IO.Stream picture_stream65 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.ShowFlat.png");

                System.IO.Stream picture_stream66 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Expand_All_1.png");
                System.IO.Stream picture_stream67 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Expand_All_2.png");
                System.IO.Stream picture_stream68 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Collapse_All_1.png");
                System.IO.Stream picture_stream69 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Collapse_All_2.png");

                System.IO.Stream picture_stream70 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.plus_1.png");
                System.IO.Stream picture_stream71 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.plus_2.png");

                System.IO.Stream picture_stream72 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.minus_1.png");
                System.IO.Stream picture_stream73 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.minus_2.png");

                System.IO.Stream picture_stream74 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.1_1.png");
                System.IO.Stream picture_stream75 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.1_2.png");

                System.IO.Stream picture_stream76 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.2_1.png");
                System.IO.Stream picture_stream77 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.2_2.png");

                System.IO.Stream picture_stream78 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.3_1.png");
                System.IO.Stream picture_stream79 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.3_2.png");

                System.IO.Stream picture_stream80 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.4_1.png");
                System.IO.Stream picture_stream81 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.4_2.png");

                System.IO.Stream picture_stream82 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.5_1.png");
                System.IO.Stream picture_stream83 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.5_2.png");

                System.IO.Stream picture_stream84 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.6_1.png");
                System.IO.Stream picture_stream85 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.6_2.png");

                System.IO.Stream picture_stream86 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.7_1.png");
                System.IO.Stream picture_stream87 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.7_2.png");

                System.IO.Stream picture_stream88 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.8_1.png");
                System.IO.Stream picture_stream89 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.8_2.png");

                System.IO.Stream picture_stream90 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Checkmark.png");

                System.IO.Stream picture_stream91 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Refresh1.png");
                System.IO.Stream picture_stream92 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Refresh2.png");

                System.IO.Stream picture_stream93 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.palo.ico");

                System.IO.Stream picture_stream94 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.list-time-prazno.png");
                System.IO.Stream picture_stream95 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.list-A-Z-prazno.png");
                System.IO.Stream picture_stream96 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.list-Z-A-prazno.png");

                System.IO.Stream picture_stream97 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.blank.PNG");
                System.IO.Stream picture_stream98 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.Home2.png");

                System.IO.Stream picture_stream99 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.toggleSystemCubes.png");


				System.IO.Stream picture_stream0 = this.GetType().Assembly.GetManifestResourceStream("Apalo.XlAddin.Resource.wizard_logo.png");

                IconBlank = new Bitmap(picture_stream97);
                IconDefaultHome = new Bitmap(picture_stream98);

                ListOrderHistory = new Bitmap(picture_stream94);
                ListOrderAZ = new Bitmap(picture_stream95);
                ListOrderZA = new Bitmap(picture_stream96);

                IconPalo = new Icon(picture_stream93);
				IconConnect = new Bitmap(picture_stream1);
				IconDisconnect = new Bitmap(picture_stream2);
				
                IconApply = new Bitmap(picture_stream3);
				IconCancel = new Bitmap(picture_stream4);
				
                IconUp = new Bitmap(picture_stream5);
				IconRight = new Bitmap(picture_stream6);
				IconLeft = new Bitmap(picture_stream7);
				IconDown = new Bitmap(picture_stream8);

				IconElementAdd = new Bitmap(picture_stream11);
				IconElementDelete = new Bitmap(picture_stream12);
				IconElementRename = new Bitmap(picture_stream13);
				IconElementEdit = new Bitmap(picture_stream14);

				IconDimensionAdd = new Bitmap(picture_stream15);
				IconDimensionDelete = new Bitmap(picture_stream16);
				IconDimensionEdit = new Bitmap(picture_stream17);
				
                IconCubeAdd = new Bitmap(picture_stream18);
				IconCubeDelete = new Bitmap(picture_stream19);
				IconWizard = new Bitmap(picture_stream20);
				
                IconPasteVertical = new Bitmap(picture_stream21);
				IconPasteHorizontal = new Bitmap(picture_stream22);
				
                StringElement = new Bitmap(picture_stream23);
				NumericElement = new Bitmap(picture_stream24);
				ConsolidatedElement = new Bitmap(picture_stream25);

				IconFilterAttributeOn = new Bitmap(picture_stream26);
                
				IconFilterDataOn = new Bitmap(picture_stream27);
				IconFilterUserOn = new Bitmap(picture_stream28);


                IconToggleUser = new Bitmap(picture_stream29);
                IconToggleCube = new Bitmap(picture_stream30);

                IconToggleUserH = new Bitmap(picture_stream57);
                IconToggleCubeH = new Bitmap(picture_stream58);
                
                IconCubeRule = new Bitmap(picture_stream31);
                
                IconToggleCache = new Bitmap(picture_stream34);

                IconUpH = new Bitmap(picture_stream35);
                IconDownH = new Bitmap(picture_stream36);
                IconLeftH = new Bitmap(picture_stream37);
                IconRightH = new Bitmap(picture_stream38);

                IconHome = new Bitmap(picture_stream39);

                IconElementAddH = new Bitmap(picture_stream40);
                IconElementDeleteH = new Bitmap(picture_stream41);
                IconElementRenameH = new Bitmap(picture_stream42);
                IconElementEditH = new Bitmap(picture_stream43);
                IconDimensionAddH = IconElementAddH;
                IconDimensionDeleteH = IconElementDeleteH;
                IconDimensionEditH = IconElementRenameH;
                
                IconCubeAddH = new Bitmap(picture_stream47);
                IconCubeDeleteH = new Bitmap(picture_stream48);

                IconCubeRuleH = new Bitmap(picture_stream49);
                IconWizardH = new Bitmap(picture_stream50);
                IconHomeH = new Bitmap(picture_stream51);
                
                IconConnectH = new Bitmap(picture_stream53);
                IconDisconnectH = new Bitmap(picture_stream54);

                IconApplyH = new Bitmap(picture_stream55);
                IconCancelH = new Bitmap(picture_stream56);

                IconToggleCacheH = new Bitmap(picture_stream52);
                IconToggleAttribute = new Bitmap(picture_stream60);
                IconToggleAttributeH = new Bitmap(picture_stream59);

                IconImport = new Bitmap(picture_stream44);
                IconImportH = new Bitmap(picture_stream45);
                IconExport = new Bitmap(picture_stream46);
                IconExportH = new Bitmap(picture_stream61);
				// logo
				WizardLogo = new System.Drawing.Bitmap(picture_stream0);

                IconShowHierarchy = new Bitmap(picture_stream32);
                //IconShowFlat = new Bitmap(picture_stream63);
                IconCollapseAll = new Bitmap(picture_stream33);
                IconExpandAll = new Bitmap(picture_stream62);

                IconShowHierarchyButtonP = new Bitmap(picture_stream64);
                IconShowFlatButton = new Bitmap(picture_stream65);


                IconExpandAllButton = new Bitmap(picture_stream66);
                IconExpandAllButtonH = new Bitmap(picture_stream67);
                IconCollapseAllButton = new Bitmap(picture_stream68);
                IconCollapseAllButtonH = new Bitmap(picture_stream69);

                IconExpand = new Bitmap(picture_stream70);
                IconExpandH = new Bitmap(picture_stream71);

                IconCollapse = new Bitmap(picture_stream72);
                IconCollapseH = new Bitmap(picture_stream73);

                IconExpand1 = new Bitmap(picture_stream74);
                IconExpand1H = new Bitmap(picture_stream75);

                IconExpand2 = new Bitmap(picture_stream76);
                IconExpand2H = new Bitmap(picture_stream77);

                IconExpand3 = new Bitmap(picture_stream78);
                IconExpand3H = new Bitmap(picture_stream79);

                IconExpand4 = new Bitmap(picture_stream80);
                IconExpand4H = new Bitmap(picture_stream81);

                IconExpand5 = new Bitmap(picture_stream82);
                IconExpand5H = new Bitmap(picture_stream83);

                IconExpand6 = new Bitmap(picture_stream84);
                IconExpand6H = new Bitmap(picture_stream85);

                IconExpand7 = new Bitmap(picture_stream86);
                IconExpand7H = new Bitmap(picture_stream87);

                IconExpand8 = new Bitmap(picture_stream88);
                IconExpand8H = new Bitmap(picture_stream89);

                IconCheckmark = new Bitmap(picture_stream90);

                IconRefresh = new Bitmap(picture_stream91);
                IconRefreshH = new Bitmap(picture_stream92);

                IconToggleSystemCubes = new Bitmap(picture_stream99);

			}
			catch(Exception exb)
			{
				ErrorHandler.DisplayError("Error in InitializeFormElements", exb);
			}
			finally
			{
				// Restore the culture information for the thread after the
				// Excel calls have completed.
				thisThread.CurrentUICulture = this.originalUICulture;
			}


			#endregion

			#region Text resources

			try
			{
				ResourceManager rm = new ResourceManager("Apalo.XlAddin.Resource.Strings", System.Reflection.Assembly.GetExecutingAssembly());

				thisThread.CurrentUICulture = new CultureInfo("en-US");

				#region Menu

#if BPSBI
				MENU_TITLE = "&BPS-BI";
#else
                MENU_TITLE = rm.GetString("MENU_TITLE", ExcelCulture);
#endif
                MENU_PASTE_VIEW = rm.GetString("MENU_PASTE_VIEW", ExcelCulture);
				MENU_SAVE_SNAPSHOT = rm.GetString("MENU_SAVE_SNAPSHOT", ExcelCulture);
				MENU_PASTE_ELEMENTS = rm.GetString("MENU_PASTE_ELEMENTS", ExcelCulture);
				MENU_PASTE_FUNCTION = rm.GetString("MENU_PASTE_FUNCTION", ExcelCulture);
				MENU_MODELLER = rm.GetString("MENU_MODELLER", ExcelCulture);
				MENU_DATA_IMPORT = rm.GetString("MENU_DATA_IMPORT", ExcelCulture);
				MENU_PALO_WIZARD = rm.GetString("MENU_PALO_WIZARD", ExcelCulture);
                MenuClientCache = rm.GetString("MenuClientCache", ExcelCulture);
				MENU_ABOUT = rm.GetString("MENU_ABOUT", ExcelCulture);
                MENU_PASTE_SUBSET = rm.GetString("MENU_PASTE_SUBSET", ExcelCulture);
                MENU_BEGIN_UNDO = rm.GetString("MENU_BEGIN_UNDO", ExcelCulture);
                MENU_UNDO = rm.GetString("MENU_UNDO", ExcelCulture);
                MENU_ROLLBACK = rm.GetString("MENU_ROLLBACK", ExcelCulture);
                MENU_COMMIT = rm.GetString("MENU_COMMIT", ExcelCulture);

                CmdDimensionExport = rm.GetString("CmdDimensionExport", ExcelCulture);
                LabelDimExportSeparator = rm.GetString("LabelDimExportSeparator", ExcelCulture);
                LabelDimExportHierarchy = rm.GetString("LabelDimExportHierarchy", ExcelCulture);

                PaloOnlineMenu = rm.GetString("PaloOnlineMenu", ExcelCulture);
                PaloOnlineLogin = rm.GetString("PaloOnlineLogin", ExcelCulture);
                PaloOnlineLogOut = rm.GetString("PaloOnlineLogOut", ExcelCulture);
                PaloOnlineBasicHelp = rm.GetString("PaloOnlineBasicHelp", ExcelCulture);
                PaloOnlineAdvancedHelp = rm.GetString("PaloOnlineAdvancedHelp", ExcelCulture);

                lblPaloOnlineUsername = rm.GetString("lblPaloOnlineUsername", ExcelCulture);
                lblPaloOnlinePassword = rm.GetString("lblPaloOnlinePassword", ExcelCulture);
                lblPaloOnlineLink = rm.GetString("lblPaloOnlineLink", ExcelCulture);
                lblPaloOnlineText = rm.GetString("lblPaloOnlineText", ExcelCulture);
                txtPaloOnline = rm.GetString("txtPaloOnline", ExcelCulture);
                strPaloOnlineTitle = rm.GetString("strPaloOnlineTitle", ExcelCulture);
                btnPaloOnlineOK = rm.GetString("btnPaloOnlineOK", ExcelCulture);
                btnPaloOnlineCancel = rm.GetString("btnPaloOnlineCancel", ExcelCulture);

				#endregion

                #region Messages
                ACTIVATE_UPDATE_SEARCH = rm.GetString("ACTIVATE_UPDATE_SEARCH", ExcelCulture);
                
                TitleRuleError = rm.GetString("TitleRuleError", ExcelCulture);
                LabelRuleError = rm.GetString("LabelRuleError", ExcelCulture);
                LabelCheckForUpdates = rm.GetString("LabelCheckForUpdates", ExcelCulture);
                ServerDNSNameOrIP = rm.GetString("ServerDNSNameOrIP", ExcelCulture);
                CacheRadio1Label = rm.GetString("CacheRadio1Label", ExcelCulture);
                CacheRadio2Label = rm.GetString("CacheRadio2Label", ExcelCulture);
                CacheRadio3Label = rm.GetString("CacheRadio3Label", ExcelCulture);
                CacheDialogGroupCaption = rm.GetString("CacheDialogGroupCaption", ExcelCulture);
                CacheDialogCaption = rm.GetString("CacheDialogCaption", ExcelCulture);
                TipCacheDialog = rm.GetString("TipCacheDialog", ExcelCulture);
                TipCacheRadio1 = rm.GetString("TipCacheRadio1", ExcelCulture);
                TipCacheRadio2 = rm.GetString("TipCacheRadio2", ExcelCulture);
                TipCacheRadio3 = rm.GetString("TipCacheRadio3", ExcelCulture);

                CommandCubeRename = rm.GetString("CommandCubeRename", ExcelCulture);
                TipRuleBtnMoveUp = rm.GetString("TipRuleBtnMoveUp", ExcelCulture);
                TipRuleBtnMoveDown = rm.GetString("TipRuleBtnMoveDown", ExcelCulture);
                TipRuleBtnDelete = rm.GetString("TipRuleBtnDelete", ExcelCulture);
                TipRuleBtnSave = rm.GetString("TipRuleBtnSave", ExcelCulture);
                TipRuleBtnClose = rm.GetString("TipRuleBtnClose", ExcelCulture);
                HintNewRule = rm.GetString("HintNewRule", ExcelCulture);
                StatusRuleSaved = rm.GetString("StatusRuleSaved", ExcelCulture);
                StatusRuleDeleted = rm.GetString("StatusRuleDeleted", ExcelCulture);
                LabelRuleDefinition = rm.GetString("LabelRuleDefinition", ExcelCulture);

                StatusRuleExportSuccess = rm.GetString("StatusRuleExportSuccess", ExcelCulture);
                StatusRuleExportError = rm.GetString("StatusRuleExportError", ExcelCulture);
                StatusRuleImportSuccess = rm.GetString("StatusRuleImportSuccess", ExcelCulture);
                StatusRuleImportError = rm.GetString("StatusRuleImportError", ExcelCulture);
                QuestionDeleteExistingRules = rm.GetString("QuestionDeleteExistingRules", ExcelCulture);
                QuestionDeleteRules = rm.GetString("QuestionDeleteRules", ExcelCulture);
                DimensionInfoTitle = rm.GetString("DimensionInfoTitle", ExcelCulture);
                DimensionInfoIdentifier = rm.GetString("DimensionInfoIdentifier", ExcelCulture);
                DimensionInfoName = rm.GetString("DimensionInfoName", ExcelCulture);
                DimensionInfoNumberElements = rm.GetString("DimensionInfoNumberElements", ExcelCulture);
                DimensionInfoElements = rm.GetString("DimensionInfoElements", ExcelCulture);
                DimensionInfoNElements = rm.GetString("DimensionInfoNElements", ExcelCulture);
                DimensionInfoSElements = rm.GetString("DimensionInfoSElements", ExcelCulture);
                DimensionInfoCElements = rm.GetString("DimensionInfoCElements", ExcelCulture);
                DimensionInfoMaximumLevel = rm.GetString("DimensionInfoMaximumLevel", ExcelCulture);
                DimensionInfoMaximumIndent = rm.GetString("DimensionInfoMaximumIndent", ExcelCulture);
                DimensionInfoMaximumDepth = rm.GetString("DimensionInfoMaximumDepth", ExcelCulture);
                DimensionInfoAttributeCube = rm.GetString("DimensionInfoAttributeCube", ExcelCulture);
                DimensionInfoType = rm.GetString("DimensionInfoType", ExcelCulture);

                CubeInfoTitle = rm.GetString("CubeInfoTitle", ExcelCulture);
                CubeInfoIdentifier = rm.GetString("CubeInfoIdentifier", ExcelCulture);
                CubeInfoName = rm.GetString("CubeInfoName", ExcelCulture);
                CubeInfoNumberDimensions = rm.GetString("CubeInfoNumberDimensions", ExcelCulture);
                CubeInfoDimensions = rm.GetString("CubeInfoDimensions", ExcelCulture);
                CubeInfoNumberCells = rm.GetString("CubeInfoNumberCells", ExcelCulture);
                CubeInfoNumberFilledCells = rm.GetString("CubeInfoNumberFilledCells", ExcelCulture);
                CubeInfoFillRatio = rm.GetString("CubeInfoFillRatio", ExcelCulture);
                CubeInfoStatus = rm.GetString("CubeInfoStatus", ExcelCulture);
                CubeInfoType = rm.GetString("CubeInfoType", ExcelCulture);

                TipRuleEditor = rm.GetString("TipRuleEditor", ExcelCulture);
                TipFilterAttribute = rm.GetString("TipFilterAttribute", ExcelCulture);

                CommandDimensionInfo = rm.GetString("CommandDimensionInfo", ExcelCulture);
                MessageClearCube = rm.GetString("MessageClearCube", ExcelCulture);
                MessageWholeClearCube = rm.GetString("MessageWholeClearCube", ExcelCulture);

                ClearCubeStatus = rm.GetString("ClearCubeStatus", ExcelCulture);
                TipCubeFilterData = rm.GetString("TipCubeFilterData", ExcelCulture);
                TipCubeFilterAttribute = rm.GetString("TipCubeFilterAttribute", ExcelCulture);
                TipCubeFilterUser = rm.GetString("TipCubeFilterUser", ExcelCulture);
                TipFilterData = rm.GetString("TipFilterData", ExcelCulture);
                TipFilterUser = rm.GetString("TipFilterUser", ExcelCulture);

                TipButtonCreationOrder = rm.GetString("TipButtonCreationOrder", ExcelCulture);
                TipButtonSortAscending = rm.GetString("TipButtonSortAscending", ExcelCulture);
                TipButtonSortDescending = rm.GetString("TipButtonSortDescending", ExcelCulture);

                ButtonSearch = rm.GetString("ButtonSearch", ExcelCulture);
                SearchElementCaption = rm.GetString("SearchElementCaption", ExcelCulture);
                SearchElementTip = rm.GetString("SearchElementTip", ExcelCulture);
                ClearCubeCaption = rm.GetString("ClearCubeCaption", ExcelCulture);
                ButtonClearWholeCube = rm.GetString("ButtonClearWholeCube", ExcelCulture);
                ButtonClearCube = rm.GetString("ButtonClearCube", ExcelCulture);
                ButtonClearWholeCubeTip = rm.GetString("ButtonClearWholeCubeTip", ExcelCulture);
                ButtonClearCubeTip = rm.GetString("ButtonClearCubeTip", ExcelCulture);
                CommandSearchElement = rm.GetString("CommandSearchElement", ExcelCulture);

                MoveElementToBeginning = rm.GetString("CMD_MOVE_ELEMENT_TO_BEGINNING", ExcelCulture);
                MoveElementToEnd = rm.GetString("CMD_MOVE_ELEMENT_TO_END", ExcelCulture);
				LABEL_CHECK_DISABLE_USER_MNG = rm.GetString("LABEL_CHECK_DISABLE_USER_MNG", ExcelCulture); 
				LABEL_CHECK_SHOW_ATTRIB = rm.GetString("LABEL_CHECK_SHOW_ATTRIB", ExcelCulture);
                LABEL_CHECK_INDENT = rm.GetString("LABEL_CHECK_INDENT", ExcelCulture);

				MESSAGE_LIMIT_VIEW_SIZE = rm.GetString("MESSAGE_LIMIT_VIEW_SIZE", ExcelCulture);
				ERROR_CLIPBOARD_PASTE_TITLE = rm.GetString("ERROR_CLIPBOARD_PASTE_TITLE", ExcelCulture);
				ERROR_CLIPBOARD_PASTE = rm.GetString("ERROR_CLIPBOARD_PASTE", ExcelCulture);
				EXCEL_CHARS_TITLE = rm.GetString("EXCEL_CHARS_TITLE", ExcelCulture);
				EXCEL_CHARS_MESSAGE = rm.GetString("EXCEL_CHARS_MESSAGE", ExcelCulture);
				LABEL_EXPORT_PAGE2_2 = rm.GetString("LABEL_EXPORT_PAGE2_2", ExcelCulture);
				LABEL_CHECK_ELEMENT_SELECTOR = rm.GetString("LABEL_CHECK_ELEMENT_SELECTOR", ExcelCulture);
                LABEL_CHECK_ZERO_SUPPRESSION = rm.GetString("LABEL_CHECK_ZERO_SUPPRESSION", ExcelCulture);
                LABEL_CHECK_ZERO_SUPPRESSION_ALSO_CALULATED_NULL = rm.GetString("LABEL_CHECK_ZERO_SUPPRESSION_ALSO_CALULATED_NULL", ExcelCulture);
                MESSAGE_MERGED_CELLS = rm.GetString("MESSAGE_MERGED_CELLS", ExcelCulture);
				TITLE_MODELLER = rm.GetString("TITLE_MODELLER", ExcelCulture);
				LABEL_CHECK_WORDWRAP = rm.GetString("LABEL_CHECK_WORDWRAP", ExcelCulture);
				MESSAGE_ELEMENT_DROP = rm.GetString("MESSAGE_ELEMENT_DROP", ExcelCulture);
				LABEL_SELECT_ALL_ELEMENTS = rm.GetString("LABEL_SELECT_ALL_ELEMENTS", ExcelCulture);
				COMMITING_CHANGES = rm.GetString("COMMITING_CHANGES", ExcelCulture);
				PALO_ERR_TYPE = rm.GetString("PALO_ERR_TYPE", ExcelCulture);
				PALO_ERR_INV_ARG = rm.GetString("PALO_ERR_INV_ARG", ExcelCulture);
				PALO_ERR_CUBE_NOT_FOUND = rm.GetString("PALO_ERR_CUBE_NOT_FOUND", ExcelCulture);
				PALO_ERR_DIM_ELEMENT_INV_TYPE = rm.GetString("PALO_ERR_DIM_ELEMENT_INV_TYPE", ExcelCulture);
				PALO_ERR_DIM_ELEMENT_NOT_FOUND = rm.GetString("PALO_ERR_DIM_ELEMENT_NOT_FOUND", ExcelCulture);
				PALO_ERR_INV_FORMAT = rm.GetString("PALO_ERR_INV_FORMAT", ExcelCulture);
				LABEL_EXPORT_PAGE_3_1 = rm.GetString("LABEL_EXPORT_PAGE_3_1", ExcelCulture);
                LabelDimExportCaption = rm.GetString("LabelDimExportCaption", ExcelCulture);

				XLL_ERROR_TITLE = rm.GetString("XLL_ERROR_TITLE", ExcelCulture);
				CMD_ADD_CHILD = rm.GetString("CMD_ADD_CHILD", ExcelCulture);
				CMD_ADD_SIBLING = rm.GetString("CMD_ADD_SIBLING", ExcelCulture);
				CMD_COPY_CHILD = rm.GetString("CMD_COPY_CHILD", ExcelCulture);
				CMD_COPY_SIBLING = rm.GetString("CMD_COPY_SIBLING", ExcelCulture);

                TITLE_EXPORT_DIMENSION = rm.GetString("TITLE_EXPORT_DIMENSION", ExcelCulture);
                TITLE_EXPORT_WIZARD = rm.GetString("TITLE_EXPORT_WIZARD", ExcelCulture);
				TITLE_EDIT_VALUE = rm.GetString("TITLE_EDIT_VALUE", ExcelCulture);
				LABEL_EDIT_VALUE = rm.GetString("LABEL_EDIT_VALUE", ExcelCulture);
                LABEL_EDIT_VALUE_2007 = rm.GetString("LABEL_EDIT_VALUE_2007", ExcelCulture);
                LABEL_CHARS_NUMBER = rm.GetString("LABEL_CHARS_NUMBER", ExcelCulture);

				CMD_ADD_ELEMENT = rm.GetString("CMD_ADD_ELEMENT", ExcelCulture);
				CMD_DELETE_ELEMENT = rm.GetString("CMD_DELETE_ELEMENT", ExcelCulture);
                CMD_REMOVE_ELEMENT = rm.GetString("CMD_REMOVE_ELEMENT", ExcelCulture);
				CMD_RENAME_ELEMENT = rm.GetString("CMD_RENAME_ELEMENT", ExcelCulture);
                CMD_SHOW_PARENTS = rm.GetString("CMD_SHOW_PARENTS", ExcelCulture);
                CMD_EDIT_ELEMENT = rm.GetString("CMD_EDIT_ELEMENT", ExcelCulture);
				CMD_NUMERIC_ELEMENT = rm.GetString("CMD_NUMERIC_ELEMENT", ExcelCulture);
				CMD_STRING_ELEMENT = rm.GetString("CMD_STRING_ELEMENT", ExcelCulture);
				CMD_COPY_ELEMENT = rm.GetString("CMD_COPY_ELEMENT", ExcelCulture);
				CMD_PASTE_ELEMENT = rm.GetString("CMD_PASTE_ELEMENT", ExcelCulture);
				CMD_SELECTALL_ELEMENT = rm.GetString("CMD_SELECTALL_ELEMENT", ExcelCulture);
				CMD_COUNT_ELEMENT = rm.GetString("CMD_COUNT_ELEMENT", ExcelCulture);
				CMD_EXPORT_CUBE = rm.GetString("CMD_EXPORT_CUBE", ExcelCulture);
                CMD_EXPORT_DIM = rm.GetString("CMD_EXPORT_DIM", ExcelCulture);

                CmdMeasure = rm.GetString("CmdMeasure", ExcelCulture);
                CmdTime = rm.GetString("CmdTime", ExcelCulture);

				CMD_FACTOR = rm.GetString("CMD_FACTOR", ExcelCulture);
				CMD_DELETE_SOURCE_ELEMENT = rm.GetString("CMD_DELETE_SOURCE_ELEMENT", ExcelCulture);

				CMD_ADD_DIMENSION = rm.GetString("CMD_ADD_DIMENSION", ExcelCulture);
				CMD_DELETE_DIMENSION = rm.GetString("CMD_DELETE_DIMENSION", ExcelCulture);
				CMD_RENAME_DIMENSION = rm.GetString("CMD_RENAME_DIMENSION", ExcelCulture);
				CMD_EDIT_DIMENSION = rm.GetString("CMD_EDIT_DIMENSION", ExcelCulture);

				CMD_ADD_CUBE = rm.GetString("CMD_ADD_CUBE", ExcelCulture);
				CMD_DELETE_CUBE = rm.GetString("CMD_DELETE_CUBE", ExcelCulture);
				CMD_CLEAR_CUBE = rm.GetString("CMD_CLEAR_CUBE", ExcelCulture);
                CMD_CONVERT_CUBE = rm.GetString("CMD_CONVERT_CUBE", ExcelCulture);

                MSG_LONG_ACTION = rm.GetString("MSG_LONG_ACTION", ExcelCulture);
                QUESTION_LONG_ACTION = rm.GetString("QUESTION_LONG_ACTION", ExcelCulture);

				ERROR_CIRCULAR = rm.GetString("ERROR_CIRCULAR", ExcelCulture);
				ERROR_ELEMENT_EXISTS = rm.GetString("ERROR_ELEMENT_EXISTS", ExcelCulture);
				ERROR_ELEMENT_NAME_INVALID = rm.GetString("ERROR_ELEMENT_NAME_INVALID", ExcelCulture);
				ERROR_DIMENSION_EXISTS = rm.GetString("ERROR_DIMENSION_EXISTS", ExcelCulture);
                ERROR_DIMENSION_NAME_EMPTY = rm.GetString("ERROR_DIMENSION_NAME_EMPTY", ExcelCulture);
                ERROR_DIMENSION_NAME_INVALID = rm.GetString("ERROR_DIMENSION_NAME_INVALID", ExcelCulture);
				ERROR_CUBE_NAME_INVALID = rm.GetString("ERROR_CUBE_NAME_INVALID", ExcelCulture);

				ERROR_CUBE_NAME_EMPTY = rm.GetString("ERROR_CUBE_NAME_EMPTY", ExcelCulture);
				ERROR_CUBE_NO_DIMENSION = rm.GetString("ERROR_CUBE_NO_DIMENSION", ExcelCulture);
				ERROR_CUBE_EXISTS = rm.GetString("ERROR_CUBE_EXISTS", ExcelCulture);

				MESSAGE_COUNT_ELEMENTS = rm.GetString("MESSAGE_COUNT_ELEMENTS", ExcelCulture);

                LabelDimName = rm.GetString("LabelDimName", ExcelCulture);
                LabelTemplate = rm.GetString("LabelTemplate", ExcelCulture);
                LabelDimTemplateCaption = rm.GetString("LabelDimTemplateCaption", ExcelCulture);
                TitleDimTemplate = rm.GetString("TitleDimTemplate", ExcelCulture);
                TextWithoutTemplate = rm.GetString("TextWithoutTemplate", ExcelCulture);

				LABEL_NEW_ELEMENT = rm.GetString("LABEL_NEW_ELEMENT", ExcelCulture);
				LABEL_NEW_DIMENSION = rm.GetString("LABEL_NEW_DIMENSION", ExcelCulture);
                LABEL_NEW_ATTRIBUTE = rm.GetString("LABEL_NEW_ATTRIBUTE", ExcelCulture);
                LABEL_NEW_SUBSET = rm.GetString("LABEL_NEW_SUBSET", ExcelCulture);

                FILE_WRITTEN_SUCCESS = rm.GetString("FILE_WRITTEN_SUCCESS", ExcelCulture);
				ERROR_DATA_NOT_FOUND = rm.GetString("ERROR_DATA_NOT_FOUND", ExcelCulture);
				ERROR_READING_FROM_DATABASE = rm.GetString("ERROR_READING_FROM_DATABASE", ExcelCulture);
				WARNING_DELETE_SQL_FILE = rm.GetString("WARNING_DELETE_SQL_FILE", ExcelCulture);
				TEXT_SELECT_DSN = rm.GetString("TEXT_SELECT_DSN", ExcelCulture);
				TITLE_DELETE = rm.GetString("TITLE_DELETE", ExcelCulture);
				LABEL_NEW = rm.GetString("LABEL_NEW", ExcelCulture);
				LABEL_CSV_FILTER = rm.GetString("LABEL_CSV_FILTER", ExcelCulture);
				LABEL_SELECT_ACTION = rm.GetString("LABEL_SELECT_ACTION", ExcelCulture);
				LABEL_SQL_FILTER = rm.GetString("LABEL_SQL_FILTER", ExcelCulture);

				TITLE_PASTE_FUNCTION = rm.GetString("TITLE_PASTE_FUNCTION", ExcelCulture);
				TEXT_GUESS_ARG = rm.GetString("TEXT_GUESS_ARG", ExcelCulture);
				TITLE_CHOOSE_ELEMENT = rm.GetString("TITLE_CHOOSE_ELEMENT", ExcelCulture);
				TITLE_CHOOSE_ELEMENT2 = rm.GetString("TITLE_CHOOSE_ELEMENT2", ExcelCulture);
				TEXT_ELEMENTS2PASTED = rm.GetString("TEXT_ELEMENTS2PASTED", ExcelCulture);
				TEXT_SHOW_SEL_TOOL = rm.GetString("TEXT_SHOW_SEL_TOOL", ExcelCulture);
				TEXT_TIP_SHIFT = rm.GetString("TEXT_TIP_SHIFT", ExcelCulture);
				TEXT_RESTRICT_PASTE2CURR_SELECTION = rm.GetString("TEXT_RESTRICT_PASTE2CURR_SELECTION", ExcelCulture);
                TEXT_ALIAS = rm.GetString("TEXT_ALIAS", ExcelCulture);
                TEXT_ALIAS_FORMAT = rm.GetString("TEXT_ALIAS_FORMAT", ExcelCulture);
                TEXT_FORMAT = rm.GetString("TEXT_FORMAT", ExcelCulture);
                TEXT_ELEMENT_NAME = rm.GetString("TEXT_ELEMENT_NAME", ExcelCulture);
                TEXT_CUBES = rm.GetString("TEXT_CUBES", ExcelCulture);
                TEXT_DIMENSIONS = rm.GetString("TEXT_DIMENSIONS", ExcelCulture);
                TEXT_DIM_ELEMENTS = rm.GetString("TEXT_DIM_ELEMENTS", ExcelCulture);
                TEXT_DATABASE_ELEMENTS = rm.GetString("TEXT_DATABASE_ELEMENTS", ExcelCulture);
                TEXT_SERVER = rm.GetString("TEXT_SERVER", ExcelCulture);
                TEXT_DATABASE = rm.GetString("TEXT_DATABASE", ExcelCulture);
                TEXT_CONNECTION = rm.GetString("TEXT_CONNECTION", ExcelCulture);
                TEXT_META = rm.GetString("TEXT_META", ExcelCulture);
                TEXT_VAR_INSERT = rm.GetString("TEXT_VAR_INSERT", ExcelCulture);
                TEXT_CUBE_NAME = rm.GetString("TEXT_CUBE_NAME", ExcelCulture);
                TEXT_DIMENSION_NAMES = rm.GetString("TEXT_DIMENSION_NAMES", ExcelCulture);
                TEXT_SUBSET = rm.GetString("TEXT_SUBSET", ExcelCulture);
                STATUS_READING_ELEMENTS_SERVER = rm.GetString("STATUS_READING_ELEMENTS_SERVER", ExcelCulture);
				STATUS_LOOKING4SERVER_WAIT = rm.GetString("STATUS_LOOKING4SERVER_WAIT", ExcelCulture);
				ERROR_DATABASE_EXISTS = rm.GetString("ERROR_DATABASE_EXISTS", ExcelCulture);
				ERROR_DATABASE_INVALID_NAME = rm.GetString("ERROR_DATABASE_INVALID_NAME", ExcelCulture);
				QUESTION_DELETE_DATABASE = rm.GetString("QUESTION_DELETE_DATABASE", ExcelCulture);
				QUESTION_DELETE_DATABASE_TITLE = rm.GetString("QUESTION_DELETE_DATABASE_TITLE", ExcelCulture);
				INFO_DATABASE_DELETED = rm.GetString("INFO_DATABASE_DELETED", ExcelCulture);
				INFO_DATABASE_CREATED = rm.GetString("INFO_DATABASE_CREATED", ExcelCulture);
				INFO_SERVER_REGISTERED = rm.GetString("INFO_SERVER_REGISTERED", ExcelCulture);
				ERROR_REGISTER_SERVER = rm.GetString("ERROR_REGISTER_SERVER", ExcelCulture);
				QUESTION_UNREGISTER_SERVER = rm.GetString("QUESTION_UNREGISTER_SERVER", ExcelCulture);
				QUESTION_UNREGISTER_TITLE = rm.GetString("QUESTION_UNREGISTER_TITLE", ExcelCulture);
				INFO_SERVER_UNREGISTERED = rm.GetString("INFO_SERVER_UNREGISTERED", ExcelCulture);
				INFO_TEST_OK = rm.GetString("INFO_TEST_OK", ExcelCulture);
				ERROR_CONNECTING = rm.GetString("ERROR_CONNECTING", ExcelCulture);
				ERROR_INVALID_DATA = rm.GetString("ERROR_INVALID_DATA", ExcelCulture);

				WIZARD_OPTION1 = rm.GetString("WIZARD_OPTION1", ExcelCulture);
				WIZARD_OPTION2 = rm.GetString("WIZARD_OPTION2", ExcelCulture);
				WIZARD_OPTION3 = rm.GetString("WIZARD_OPTION3", ExcelCulture);
				WIZARD_OPTION4 = rm.GetString("WIZARD_OPTION4", ExcelCulture);
				WIZARD_OPTION5 = rm.GetString("WIZARD_OPTION5", ExcelCulture);
                WIZARD_OPTION6 = rm.GetString("WIZARD_OPTION6", ExcelCulture);
                WizardPaloAuthentication = rm.GetString("WizardPaloAuthentication", ExcelCulture);
                WizardWindowsAuthentication = rm.GetString("WizardWindowsAuthentication", ExcelCulture);
                TipSVS = rm.GetString("TipSVS", ExcelCulture);

				WIZARD_LABEL1  = rm.GetString("WIZARD_LABEL1", ExcelCulture);
				WIZARD_LABEL2  = rm.GetString("WIZARD_LABEL2", ExcelCulture);
				WIZARD_LABEL3  = rm.GetString("WIZARD_LABEL3", ExcelCulture);
				WIZARD_LABEL4  = rm.GetString("WIZARD_LABEL4", ExcelCulture);
				WIZARD_LABEL5  = rm.GetString("WIZARD_LABEL5", ExcelCulture);

				WIZARD_LABEL7  = rm.GetString("WIZARD_LABEL7", ExcelCulture);
                WIZARD_LABEL7E = rm.GetString("WIZARD_LABEL7E", ExcelCulture);
				WIZARD_LABEL8  = rm.GetString("WIZARD_LABEL8", ExcelCulture);
                WIZARD_LABEL8E = rm.GetString("WIZARD_LABEL8E", ExcelCulture);
				WIZARD_LABEL29  = rm.GetString("WIZARD_LABEL29", ExcelCulture);
				WIZARD_LABEL32  = rm.GetString("WIZARD_LABEL32", ExcelCulture);
				WIZARD_LABEL30  = rm.GetString("WIZARD_LABEL30", ExcelCulture);
				WIZARD_LABEL31  = rm.GetString("WIZARD_LABEL31", ExcelCulture);

				WIZARD_LABEL13  = rm.GetString("WIZARD_LABEL13", ExcelCulture);
				WIZARD_LABEL12  = rm.GetString("WIZARD_LABEL12", ExcelCulture);

				WIZARD_LABEL16  = rm.GetString("WIZARD_LABEL16", ExcelCulture);
				WIZARD_LABEL18  = rm.GetString("WIZARD_LABEL18", ExcelCulture);
				WIZARD_LABEL19  = rm.GetString("WIZARD_LABEL19", ExcelCulture);

				LABEL_LOGON_DATA = rm.GetString("LABEL_LOGON_DATA", ExcelCulture);

				LABEL_DIMENSIONS = rm.GetString("LABEL_DIMENSIONS", ExcelCulture);
				LABEL_CUBES = rm.GetString("LABEL_CUBES", ExcelCulture);

				WIZARD_TITLE  = rm.GetString("WIZARD_TITLE", ExcelCulture);
				WIZARD_PAGE_TITLE  = rm.GetString("WIZARD_PAGE_TITLE", ExcelCulture);

				TEXT_HIT_RETURN_VIEWDIMS = rm.GetString("TEXT_HIT_RETURN_VIEWDIMS", ExcelCulture);
				TEXT_HIT_RETURN_VIEWCUBES = rm.GetString("TEXT_HIT_RETURN_VIEWCUBES", ExcelCulture);
				TEXT_HIT_RETURN_ELEMENTS = rm.GetString("TEXT_HIT_RETURN_ELEMENTS", ExcelCulture);
				TEXT_HIT_RETURN_SOURCEELEMENTS = rm.GetString("TEXT_HIT_RETURN_SOURCEELEMENTS", ExcelCulture);
                TEXT_HIT_RETURN_ATTRIBUTES = rm.GetString("TEXT_HIT_RETURN_ATTRIBUTES", ExcelCulture);
                TEXT_HIT_RETURN_SUBSETS = rm.GetString("TEXT_HIT_RETURN_SUBSETS", ExcelCulture);
				
				TEXT_DATAAXIS_INUSE = rm.GetString("TEXT_DATAAXIS_INUSE", ExcelCulture);
				TEXT_DATAAXIS_INUSE_TITLE = rm.GetString("TEXT_DATAAXIS_INUSE_TITLE", ExcelCulture);

				TEXT_DELETE_DATASTORE = rm.GetString("TEXT_DELETE_DATASTORE", ExcelCulture);
				TEXT_DELETE_DATASTORE_TITLE = rm.GetString("TEXT_DELETE_DATASTORE_TITLE", ExcelCulture);
				
				TEXT_CLEAR_CUBE = rm.GetString("TEXT_CLEAR_CUBE", ExcelCulture);
				TEXT_CLEAR_CUBE_TITLE = rm.GetString("TEXT_CLEAR_CUBE_TITLE", ExcelCulture);
				
				TEXT_DELETE_DATAAXIS = rm.GetString("TEXT_DELETE_DATAAXIS", ExcelCulture);
				TEXT_DELETE_DATAAXIS_TITLE = rm.GetString("TEXT_DELETE_DATAAXIS_TITLE", ExcelCulture);
				
				TEXT_DELETE_ELEMENTS = rm.GetString("TEXT_DELETE_ELEMENTS", ExcelCulture);
				TEXT_DELETE_ELEMENTS_TITLE = rm.GetString("TEXT_DELETE_ELEMENTS_TITLE", ExcelCulture);

				TEXT_CONVERT_TO_NUMERIC = rm.GetString("TEXT_CONVERT_TO_NUMERIC", ExcelCulture);
				TEXT_CONVERT_TO_NUMERIC_TITLE = rm.GetString("TEXT_CONVERT_TO_NUMERIC_TITLE", ExcelCulture);

				TEXT_CONVERT_CONS_TO_NUMERIC = rm.GetString("TEXT_CONVERT_CONS_TO_NUMERIC", ExcelCulture);
				TEXT_CONVERT_CONS_TO_NUMERIC_TITLE = rm.GetString("TEXT_CONVERT_CONS_TO_NUMERIC_TITLE", ExcelCulture);

				TEXT_CONVERT_TO_STRING = rm.GetString("TEXT_CONVERT_TO_STRING", ExcelCulture);
				TEXT_CONVERT_TO_STRING_TITLE = rm.GetString("TEXT_CONVERT_TO_STRING_TITLE", ExcelCulture);

				TEXT_CONVERT_CONS_TO_STRING = rm.GetString("TEXT_CONVERT_CONS_TO_STRING", ExcelCulture);
				TEXT_CONVERT_CONS_TO_STRING_TITLE = rm.GetString("TEXT_CONVERT_CONS_TO_STRING_TITLE", ExcelCulture);

				TEXT_CONVERT_TO_CONS = rm.GetString("TEXT_CONVERT_TO_CONS", ExcelCulture);
				TEXT_CONVERT_TO_CONS_TITLE = rm.GetString("TEXT_CONVERT_TO_CONS_TITLE", ExcelCulture);

				TEXT_PASTE_ELEMENTS = rm.GetString("TEXT_PASTE_ELEMENTS", ExcelCulture);
				TEXT_PASTE_ELEMENTS_TITLE = rm.GetString("TEXT_PASTE_ELEMENTS_TITLE", ExcelCulture);
				TEXT_DIMELEMENT_NOT_FOUND = rm.GetString("TEXT_DIMELEMENT_NOT_FOUND", ExcelCulture);
                TEXT_NO_FURTHER_DIMELEMENT = rm.GetString("TEXT_NO_FURTHER_DIMELEMENT", ExcelCulture);
				TEXT_HAS_HEADER = rm.GetString("TEXT_HAS_HEADER", ExcelCulture);
				TEXT_APPEND2CSV = rm.GetString("TEXT_APPEND2CSV", ExcelCulture);
				TITLE_CUBE_WIZARD = rm.GetString("TITLE_CUBE_WIZARD", ExcelCulture);
				LABEL_CUBE_WIZARD_1 = rm.GetString("LABEL_CUBE_WIZARD_1", ExcelCulture);
				LABEL_CUBE_WIZARD_2 = rm.GetString("LABEL_CUBE_WIZARD_2", ExcelCulture);
				LABEL_AVAILABLE_DIMENSIONS = rm.GetString("LABEL_AVAILABLE_DIMENSIONS", ExcelCulture);
				LABEL_SELECTED_DIMENSIONS = rm.GetString("LABEL_SELECTED_DIMENSIONS", ExcelCulture);
				BUTTON_CANCEL = rm.GetString("BUTTON_CANCEL", ExcelCulture);
				BUTTON_FINISH = rm.GetString("BUTTON_FINISH", ExcelCulture);
				TIP_TREE_AVAILABLE_DIMENSIONS = rm.GetString("TIP_TREE_AVAILABLE_DIMENSIONS", ExcelCulture);
				TIP_TREE_SELECTED_DIMENSIONS = rm.GetString("TIP_TREE_SELECTED_DIMENSIONS", ExcelCulture);
				TIP_BUTTON_MOVE_UP_DIMENSION = rm.GetString("TIP_BUTTON_MOVE_UP_DIMENSION", ExcelCulture);
				TIP_BUTTON_MOVE_RIGHT_DIMENSION = rm.GetString("TIP_BUTTON_MOVE_RIGHT_DIMENSION", ExcelCulture);
				TIP_BUTTON_MOVE_LEFT_DIMENSION = rm.GetString("TIP_BUTTON_MOVE_LEFT_DIMENSION", ExcelCulture);
				TIP_BUTTON_MOVE_DOWN_DIMENSION = rm.GetString("TIP_BUTTON_MOVE_DOWN_DIMENSION", ExcelCulture);
				TIP_BUTTON_CLOSE_WIZARD = rm.GetString("TIP_BUTTON_CLOSE_WIZARD", ExcelCulture);
				TIP_BUTTON_OK_CUBE_WIZARD = rm.GetString("TIP_BUTTON_OK_CUBE_WIZARD", ExcelCulture);
				QUESTION_CUBE_WIZARD = rm.GetString("QUESTION_CUBE_WIZARD", ExcelCulture);

                PASTE_VIEW_WAIT = rm.GetString("PASTE_VIEW_WAIT", ExcelCulture);
                PASTE_VIEW_TITLE = rm.GetString("PASTE_VIEW_TITLE", ExcelCulture);
				TEXT_CHOOSE_SERVER_DB = rm.GetString("TEXT_CHOOSE_SERVER_DB", ExcelCulture);
				TEXT_CHOOSE_CUBE = rm.GetString("TEXT_CHOOSE_CUBE", ExcelCulture);
                TEXT_CHOOSE_STYLE = rm.GetString("TEXT_CHOOSE_STYLE", ExcelCulture);
                PASTE_VIEW_LABEL3 = rm.GetString("PASTE_VIEW_LABEL3", ExcelCulture);
				PASTE_VIEW_LABEL4 = rm.GetString("PASTE_VIEW_LABEL4", ExcelCulture);
				PASTE_VIEW_LABEL5 = rm.GetString("PASTE_VIEW_LABEL5", ExcelCulture);
				PASTE_VIEW_LABEL6 = rm.GetString("PASTE_VIEW_LABEL6", ExcelCulture);
				PASTE_VIEW_LABEL7 = rm.GetString("PASTE_VIEW_LABEL7", ExcelCulture);
				LABEL_CHECK_AUTOFIT = rm.GetString("LABEL_CHECK_AUTOFIT", ExcelCulture);

				LABEL_ELEMENTS_CONSOLIDATED = rm.GetString("LABEL_ELEMENTS_CONSOLIDATED", ExcelCulture);
				LABEL_ELEMENTS = rm.GetString("LABEL_ELEMENTS", ExcelCulture);
				LABEL_CHECK_FACTOR = rm.GetString("LABEL_CHECK_FACTOR", ExcelCulture);
				LABEL_CHECK_TREE = rm.GetString("LABEL_CHECK_TREE", ExcelCulture);
                LABEL_CHECK_WITHHEADER = rm.GetString("LABEL_CHECK_WITHHEADER", ExcelCulture);
				LABEL_HEADER_NAME = rm.GetString("LABEL_HEADER_NAME", ExcelCulture);
				LABEL_HEADER_FACTOR = rm.GetString("LABEL_HEADER_FACTOR", ExcelCulture);

				TITLE_IMPORT_WIZARD = rm.GetString("TITLE_IMPORT_WIZARD", ExcelCulture);
				LABEL_IMPORT_PAGE1_1 = rm.GetString("LABEL_IMPORT_PAGE1_1", ExcelCulture);
				LABEL_IMPORT_PAGE1_2 = rm.GetString("LABEL_IMPORT_PAGE1_2", ExcelCulture);
				LABEL_IMPORT_PAGE1_3 = rm.GetString("LABEL_IMPORT_PAGE1_3", ExcelCulture);
				LABEL_IMPORT_PAGE1_4 = rm.GetString("LABEL_IMPORT_PAGE1_4", ExcelCulture);
				LABEL_IMPORT_PAGE1_5 = rm.GetString("LABEL_IMPORT_PAGE1_5", ExcelCulture);
				LABEL_IMPORT_PAGE1_6 = rm.GetString("LABEL_IMPORT_PAGE1_6", ExcelCulture);
                LABEL_IMPORT_PAGE1_7 = rm.GetString("LABEL_IMPORT_PAGE1_7", ExcelCulture);
                LABEL_IMPORT_PAGE2_1 = rm.GetString("LABEL_IMPORT_PAGE2_1", ExcelCulture);
				LABEL_IMPORT_PAGE2_2 = rm.GetString("LABEL_IMPORT_PAGE2_2", ExcelCulture);
				LABEL_OPTION_TAB = rm.GetString("LABEL_OPTION_TAB", ExcelCulture);
				LABEL_OPTION_BLANK = rm.GetString("LABEL_OPTION_BLANK", ExcelCulture);
				LABEL_OPTION_COMMA = rm.GetString("LABEL_OPTION_COMMA", ExcelCulture);
				LABEL_OPTION_USERDEFINED = rm.GetString("LABEL_OPTION_USERDEFINED", ExcelCulture);
				LABEL_OPTION_SEMICOLON = rm.GetString("LABEL_OPTION_SEMICOLON", ExcelCulture);
				LABEL_OPTION_DECIMALPOINT = rm.GetString("LABEL_OPTION_DECIMALPOINT", ExcelCulture);
				LABEL_IMPORT_PAGE3_1 = rm.GetString("LABEL_IMPORT_PAGE3_1", ExcelCulture);
				LABEL_IMPORT_PAGE3_2 = rm.GetString("LABEL_IMPORT_PAGE3_2", ExcelCulture);
				LABEL_IMPORT_PAGE3_3 = rm.GetString("LABEL_IMPORT_PAGE3_3", ExcelCulture);
				LABEL_IMPORT_PAGE3_4 = rm.GetString("LABEL_IMPORT_PAGE3_4", ExcelCulture);
				LABEL_IMPORT_PAGE4_1 = rm.GetString("LABEL_IMPORT_PAGE4_1", ExcelCulture);
				LABEL_IMPORT_PAGE5_1 = rm.GetString("LABEL_IMPORT_PAGE5_1", ExcelCulture);
				LABEL_IMPORT_PAGE5_2 = rm.GetString("LABEL_IMPORT_PAGE5_2", ExcelCulture);
				LABEL_IMPORT_PAGE5_3 = rm.GetString("LABEL_IMPORT_PAGE5_3", ExcelCulture);
                LabelDimExportOneRow = rm.GetString("LabelDimExportOneRow", ExcelCulture);
                LabelDimExportNCFormat = rm.GetString("LabelDimExportNCFormat", ExcelCulture);
                STATUS_GENERATE_VIEW = rm.GetString("STATUS_GENERATE_VIEW", ExcelCulture);
				STATUS_SCAN_SELECTION = rm.GetString("STATUS_SCAN_SELECTION", ExcelCulture);
				STATUS_SCAN_SHEET = rm.GetString("STATUS_SCAN_SHEET", ExcelCulture);
				STATUS_LOAD_XLL = rm.GetString("STATUS_LOAD_XLL", ExcelCulture);
				STATUS_READ_CSV = rm.GetString("STATUS_READ_CSV", ExcelCulture);
				STATUS_READ_CUBE_WAIT = rm.GetString("STATUS_READ_CUBE_WAIT", ExcelCulture);
				STATUS_READ_SQL_WAIT = rm.GetString("STATUS_READ_SQL_WAIT", ExcelCulture);

				ERROR_LOADING_MESSAGE1 = rm.GetString("ERROR_LOADING_MESSAGE1", ExcelCulture);
				ERROR_LOADING_MESSAGE2 = rm.GetString("ERROR_LOADING_MESSAGE2", ExcelCulture);
				ERROR_LOADING_MESSAGE3 = rm.GetString("ERROR_LOADING_MESSAGE3", ExcelCulture);
				ERROR_LOADING_MESSAGE4 = rm.GetString("ERROR_LOADING_MESSAGE4", ExcelCulture);
				ERROR_LOADING_MESSAGE5 = rm.GetString("ERROR_LOADING_MESSAGE5", ExcelCulture);
				STATUS_STARTING_PALO = rm.GetString("STATUS_STARTING_PALO", ExcelCulture);
				LOADING_MESSAGE1 = rm.GetString("LOADING_MESSAGE1", ExcelCulture);

                TEXT_ATTRIBUTE = rm.GetString("TEXT_ATTRIBUTE", ExcelCulture);
                TEXT_ATTRIBUTE_CUBES= rm.GetString("TEXT_ATTRIBUTE_CUBES", ExcelCulture);
                TEXT_SHOW_ATTRIBUTE = rm.GetString("TEXT_SHOW_ATTRIBUTE", ExcelCulture);
                TEXT_NONE = rm.GetString("TEXT_NONE", ExcelCulture);
                ERROR_INSUFFICIENT_RIGTHS = rm.GetString("ERROR_INSUFFICIENT_RIGTHS", ExcelCulture);
                ERROR_NO_FORMULA_B1 = rm.GetString("ErrorNoFormulaB1", ExcelCulture);
                ErrorUsername = rm.GetString("ErrorUsername", ExcelCulture);
                ERROR_FILE_NOT_FOUND = rm.GetString("ERROR_FILE_NOT_FOUND", ExcelCulture);

                QUESTION_DELETE_CELLS = rm.GetString("QUESTION_DELETE_CELLS", ExcelCulture);
                ERROR_COPY_ARGS_NOT_UNIQUE = rm.GetString("ERROR_COPY_ARGS_NOT_UNIQUE", ExcelCulture);

                LABEL_EXPORT_USE_RULES = rm.GetString("LABEL_EXPORT_USE_RULES", ExcelCulture);
                LABEL_IMPORT_BLANK_LINE = rm.GetString("LABEL_IMPORT_BLANK_LINE", ExcelCulture);
                LABEL_NEWLINE = rm.GetString("LABEL_NEWLINE", ExcelCulture);

                CMD_CUBE_INFO = rm.GetString("CMD_CUBE_INFO", ExcelCulture);
                MESSAGE_CUBE_INFO = rm.GetString("MESSAGE_CUBE_INFO", ExcelCulture);
                TEXT_UNLOADED = rm.GetString("TEXT_UNLOADED", ExcelCulture);
                TEXT_LOADED = rm.GetString("TEXT_LOADED", ExcelCulture);
                TEXT_CHANGED = rm.GetString("TEXT_CHANGED", ExcelCulture);
                TEXT_UNKNOWN = rm.GetString("TEXT_UNKNOWN", ExcelCulture);
                TEXT_NORMAL = rm.GetString("TEXT_NORMAL", ExcelCulture);
                TEXT_SYSTEM = rm.GetString("TEXT_SYSTEM", ExcelCulture);
                TEXT_ATTRIBUT = rm.GetString("TEXT_ATTRIBUT", ExcelCulture);
                TEXT_USER_INFO = rm.GetString("TEXT_USER_INFO", ExcelCulture);

                TEXT_SELECT_ELEMENTS = rm.GetString("TEXT_SELECT_ELEMENTS", ExcelCulture);
                TEXT_CHOOSE_ELEMENT = rm.GetString("TEXT_CHOOSE_ELEMENT", ExcelCulture);

                TEXT_EXPAND_ALL = rm.GetString("TEXT_EXPAND_ALL", ExcelCulture);
                TEXT_COLLAPSE_ALL = rm.GetString("TEXT_COLLAPSE_ALL", ExcelCulture);
                BUTTON_PARSE = rm.GetString("BUTTON_PARSE", ExcelCulture);
                BUTTON_REFRESH_LIST = rm.GetString("BUTTON_REFRESH_LIST", ExcelCulture);
                BUTTON_MAXIMIZE = rm.GetString("BUTTON_MAXIMIZE", ExcelCulture);
                TEXT_RULE = rm.GetString("TEXT_RULE", ExcelCulture);
                TEXT_RULEEDITOR_ADVANCED = rm.GetString("TEXT_RULEEDITOR_ADVANCED", ExcelCulture);
                TEXT_COMMENT = rm.GetString("TEXT_COMMENT", ExcelCulture);
                BUTTON_HIDECOMMENT = rm.GetString("BUTTON_HIDECOMMENT", ExcelCulture);
                BUTTON_SHOWCOMMENT = rm.GetString("BUTTON_SHOWCOMMENT", ExcelCulture);

                
                #endregion

				#region Buttons

                CmdRuleAdd = rm.GetString("CmdRuleAdd", ExcelCulture);
                CmdRuleDelete = rm.GetString("CmdRuleDelete", ExcelCulture);
                CmdRuleEdit = rm.GetString("CmdRuleEdit", ExcelCulture);
                CmdRuleMoveUp = rm.GetString("CmdRuleMoveUp", ExcelCulture);
                CmdRuleMoveDown = rm.GetString("CmdRuleMoveDown", ExcelCulture);
                CmdRuleChangeStatus = rm.GetString("CmdRuleChangeStatus", ExcelCulture);
                CmdRuleToggleActivity = rm.GetString("CmdRuleToggleActivity", ExcelCulture);
                CmdRuleInfo = rm.GetString("CmdRuleInfo", ExcelCulture);

                ItemElements = rm.GetString("ItemElements", ExcelCulture);
                ItemAttributes = rm.GetString("ItemAttributes", ExcelCulture);
                ItemSubsets = rm.GetString("ItemSubsets", ExcelCulture);

                RuleInfoRule = rm.GetString("RuleInfoRule", ExcelCulture);
                LabelButtonEdit = rm.GetString("LabelButtonEdit", ExcelCulture);
                RuleInfoUpdated = rm.GetString("RuleInfoUpdated", ExcelCulture);
                LabelButtonNewRule = rm.GetString("LabelButtonNewRule", ExcelCulture);

                AddSubset = rm.GetString("AddSubset", ExcelCulture);
                DeleteSubset = rm.GetString("DeleteSubset", ExcelCulture);
                RenameSubset = rm.GetString("RenameSubset", ExcelCulture);
                LabelSubsetElements = rm.GetString("LabelSubsetElements", ExcelCulture);
                TooltipSubsetElements = rm.GetString("TooltipSubsetElements", ExcelCulture);

                UpdateButton = rm.GetString("UpdateButton", ExcelCulture);
                CmdRuleEditor = rm.GetString("CmdRuleEditor", ExcelCulture);
                ButtonRuleSave = rm.GetString("ButtonRuleSave", ExcelCulture);
                ButtonRuleDelete = rm.GetString("ButtonRuleDelete", ExcelCulture);
                ButtonRuleExit = rm.GetString("ButtonRuleExit", ExcelCulture);
                TitleRuleEditor = rm.GetString("TitleRuleEditor", ExcelCulture);
                LabelRuleEditor = rm.GetString("LabelRuleEditor", ExcelCulture);
                LabelNewRule = rm.GetString("LabelNewRule", ExcelCulture);

				BUTTON_SELECT_ALL = rm.GetString("BUTTON_SELECT_ALL", ExcelCulture);
				BUTTON_SELECT_NONE = rm.GetString("BUTTON_SELECT_NONE", ExcelCulture);
				BUTTON_SELECT_BRANCH = rm.GetString("BUTTON_SELECT_BRANCH", ExcelCulture);
				BUTTON_SELECT_INVERT = rm.GetString("BUTTON_SELECT_INVERT", ExcelCulture);
				BUTTON_SEARCH_SELECT = rm.GetString("BUTTON_SEARCH_SELECT", ExcelCulture);
				BUTTON_EXPAND_ALL = rm.GetString("BUTTON_EXPAND_ALL", ExcelCulture);
				BUTTON_COLLAPSE_ALL = rm.GetString("BUTTON_COLLAPSE_ALL", ExcelCulture);
                BUTTON_CON_STRING = rm.GetString("BUTTON_CON_STRING", ExcelCulture);
                BUTTON_CUBE_STRING = rm.GetString("BUTTON_CUBE_STRING", ExcelCulture);
                BUTTON_DIM_STRING = rm.GetString("BUTTON_DIM_STRING", ExcelCulture);
                BUTTON_HPASTE = rm.GetString("BUTTON_HPASTE", ExcelCulture);
				BUTTON_VPASTE = rm.GetString("BUTTON_VPASTE", ExcelCulture);
				BUTTON_SORT_DOWN = rm.GetString("BUTTON_SORT_DOWN", ExcelCulture);
				BUTTON_SORT_UP = rm.GetString("BUTTON_SORT_UP", ExcelCulture);
				BUTTON_CLEAR_LIST = rm.GetString("BUTTON_CLEAR_LIST", ExcelCulture);
				BUTTON_ALL = rm.GetString("BUTTON_ALL", ExcelCulture);
				BUTTON_SELECTED = rm.GetString("BUTTON_SELECTED", ExcelCulture);
                BUTTON_PASTE_HEAD = rm.GetString("BUTTON_PASTE_HEAD", ExcelCulture);

				BUTTON_TEST_CONNECTION = rm.GetString("BUTTON_TEST_CONNECTION", ExcelCulture);
				BUTTON_CLOSE = rm.GetString("BUTTON_CLOSE", ExcelCulture);
				BUTTON_OK = rm.GetString("BUTTON_OK", ExcelCulture);
				BUTTON_BACK = rm.GetString("BUTTON_BACK", ExcelCulture);
				BUTTON_NEXT = rm.GetString("BUTTON_NEXT", ExcelCulture);
				BUTTON_DATABASE = rm.GetString("BUTTON_DATABASE", ExcelCulture);
				BUTTON_CONNECT = rm.GetString("BUTTON_CONNECT", ExcelCulture);
				BUTTON_DISCONNECT = rm.GetString("BUTTON_DISCONNECT", ExcelCulture);
				BUTTON_PASTE = rm.GetString("BUTTON_PASTE", ExcelCulture);

				BUTTON_BROWSE = rm.GetString("BUTTON_BROWSE", ExcelCulture);
				BUTTON_DELETE = rm.GetString("BUTTON_DELETE", ExcelCulture);
				BUTTON_SAVE = rm.GetString("BUTTON_SAVE", ExcelCulture);

				#endregion

				#region ToolTip

                TipRuleBtnExport = rm.GetString("TipRuleBtnExport", ExcelCulture);
                TipRuleBtnImport = rm.GetString("TipRuleBtnImport", ExcelCulture);
				TIP_STEP_BACK = rm.GetString("TIP_STEP_BACK", ExcelCulture);
				TIP_STEP_NEXT = rm.GetString("TIP_STEP_NEXT", ExcelCulture);

				TIP_CHOOSE_CUBE = rm.GetString("TIP_CHOOSE_CUBE", ExcelCulture);
				TIP_CHOOSE_ELEMENTS = rm.GetString("TIP_CHOOSE_ELEMENTS", ExcelCulture);
				TIP_CHOOSE_SERVER = rm.GetString("TIP_CHOOSE_SERVER", ExcelCulture);
				TIP_CHOOSE_DATABASE = rm.GetString("TIP_CHOOSE_DATABASE", ExcelCulture);
				TIP_COMBO_CONNECTIONS = rm.GetString("TIP_COMBO_CONNECTIONS", ExcelCulture);
				TIP_BUTTON_ADD_DIMENSION = rm.GetString("TIP_BUTTON_ADD_DIMENSION", ExcelCulture);
				TIP_BUTTON_DELETE_DIMENSION = rm.GetString("TIP_BUTTON_DELETE_DIMENSION", ExcelCulture);
				TIP_BUTTON_RENAME_DIMENSION = rm.GetString("TIP_BUTTON_RENAME_DIMENSION", ExcelCulture);
				TIP_BUTTON_EDIT_DIMENSION = rm.GetString("TIP_BUTTON_EDIT_DIMENSION", ExcelCulture);
				TIP_BUTTON_ADD_CUBE = rm.GetString("TIP_BUTTON_ADD_CUBE", ExcelCulture);
				TIP_BUTTON_DELETE_CUBE = rm.GetString("TIP_BUTTON_DELETE_CUBE", ExcelCulture);

				TIP_BUTTON_ADD_ELEMENT = rm.GetString("TIP_BUTTON_ADD_ELEMENT", ExcelCulture);
				TIP_BUTTON_DELETE_ELEMENT = rm.GetString("TIP_BUTTON_DELETE_ELEMENT", ExcelCulture);
				TIP_BUTTON_RENAME_ELEMENT = rm.GetString("TIP_BUTTON_RENAME_ELEMENT", ExcelCulture);
				TIP_BUTTON_CONSOLIDATE_ELEMENT = rm.GetString("TIP_BUTTON_CONSOLIDATE_ELEMENT", ExcelCulture);

				TIP_BUTTON_MOVE_ELEMENT_UP = rm.GetString("TIP_BUTTON_MOVE_ELEMENT_UP", ExcelCulture);
				TIP_BUTTON_MOVE_ELEMENT_LEFT = rm.GetString("TIP_BUTTON_MOVE_ELEMENT_LEFT", ExcelCulture);
				TIP_BUTTON_MOVE_ELEMENT_RIGHT = rm.GetString("TIP_BUTTON_MOVE_ELEMENT_RIGHT", ExcelCulture);
				TIP_BUTTON_MOVE_ELEMENT_DOWN = rm.GetString("TIP_BUTTON_MOVE_ELEMENT_DOWN", ExcelCulture);

				TIP_BUTTON_APPLY_CHANGES = rm.GetString("TIP_BUTTON_APPLY_CHANGES", ExcelCulture);
				TIP_BUTTON_CANCEL_CHANGES = rm.GetString("TIP_BUTTON_CANCEL_CHANGES", ExcelCulture);

				TIP_CHECK_TREE = rm.GetString("TIP_CHECK_TREE", ExcelCulture);
				TIP_CHECK_FACTOR = rm.GetString("TIP_CHECK_FACTOR", ExcelCulture);

				TIP_BUTTON_DATABASE = rm.GetString("TIP_BUTTON_DATABASE", ExcelCulture);
				TIP_BUTTON_MODELLER_CLOSE = rm.GetString("TIP_BUTTON_MODELLER_CLOSE", ExcelCulture);
				TIP_BUTTON_TOGGLE_CONNECTION = rm.GetString("TIP_BUTTON_TOGGLE_CONNECTION", ExcelCulture);
				TIP_BUTTON_PALO_WIZARD = rm.GetString("TIP_BUTTON_PALO_WIZARD", ExcelCulture);

				TIP_TREE_DIMENSIONS = rm.GetString("TIP_TREE_DIMENSIONS", ExcelCulture);
				TIP_TREE_CUBES = rm.GetString("TIP_TREE_CUBES", ExcelCulture);
				TIP_TREE_ELEMENTS = rm.GetString("TIP_TREE_ELEMENTS", ExcelCulture);
				TIP_TREE_ELEMENTS_CONSOLIDATED = rm.GetString("TIP_TREE_ELEMENTS_CONSOLIDATED", ExcelCulture);

				TIP_BUTTON_TOGGLE_CONNECT = rm.GetString("TIP_BUTTON_TOGGLE_CONNECT", ExcelCulture);
				TIP_BUTTON_TOGGLE_DISCONNECT = rm.GetString("TIP_BUTTON_TOGGLE_DISCONNECT", ExcelCulture);

				TIP_FUCTION_TYPE = rm.GetString("TIP_FUCTION_TYPE", ExcelCulture);
				TIP_AUTOFIT = rm.GetString("TIP_AUTOFIT", ExcelCulture);
				TIP_BUTTON_PASTE_VIEW = rm.GetString("TIP_BUTTON_PASTE_VIEW", ExcelCulture);
				TIP_BUTTON_CLOSE_PASTE_VIEW = rm.GetString("TIP_BUTTON_CLOSE_PASTE_VIEW", ExcelCulture);


                ToolTipShowSystemCubes = rm.GetString("ToolTipShowSystemCubes", ExcelCulture);


				#endregion

                #region Advanced Rule Editor Strings
                RB_CONSOLIDATION_PRIORITY = rm.GetString("RB_CONSOLIDATION_PRIORITY", ExcelCulture);
                RB_PRIORITY_C = rm.GetString("RB_PRIORITY_C", ExcelCulture);
                RB_PRIORITY_N = rm.GetString("RB_PRIORITY_N", ExcelCulture);
                RB_PRIORITY_NONE = rm.GetString("RB_PRIORITY_NONE", ExcelCulture);
                #endregion

                #region SubSet Strings (Generated Code)

                HT_SB_RES = new Hashtable();

                HT_SB_RES.Add("SB_ABOVE", rm.GetString("SB_ABOVE", ExcelCulture));
                HT_SB_RES.Add("SB_ABOVE_DESC_LONG", rm.GetString("SB_ABOVE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ALIAS", rm.GetString("SB_ALIAS", ExcelCulture));
                HT_SB_RES.Add("SB_ALIAS1", rm.GetString("SB_ALIAS1", ExcelCulture));
                HT_SB_RES.Add("SB_ALIAS1_DESC_LONG", rm.GetString("SB_ALIAS1_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ALIAS2", rm.GetString("SB_ALIAS2", ExcelCulture));
                HT_SB_RES.Add("SB_ALIAS2_DESC_LONG", rm.GetString("SB_ALIAS2_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ALL", rm.GetString("SB_ALL", ExcelCulture));
                HT_SB_RES.Add("SB_ANY", rm.GetString("SB_ANY", ExcelCulture));
                HT_SB_RES.Add("SB_ATTRIBUTE", rm.GetString("SB_ATTRIBUTE", ExcelCulture));
                HT_SB_RES.Add("SB_ATTRIBUTE_DESC_LONG", rm.GetString("SB_ATTRIBUTE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ATTRIBUTE_FILTERS", rm.GetString("SB_ATTRIBUTE_FILTERS", ExcelCulture));
                HT_SB_RES.Add("SB_ATTRIBUTE_FILTERS_DESC_LONG", rm.GetString("SB_ATTRIBUTE_FILTERS_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_AVERAGE", rm.GetString("SB_AVERAGE", ExcelCulture));
                HT_SB_RES.Add("SB_BACK", rm.GetString("SB_BACK", ExcelCulture));
                HT_SB_RES.Add("SB_CELL_OPERATOR", rm.GetString("SB_CELL_OPERATOR", ExcelCulture));
                HT_SB_RES.Add("SB_CELL_OPERATOR_DESC_LONG", rm.GetString("SB_CELL_OPERATOR_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_CLOSE", rm.GetString("SB_CLOSE", ExcelCulture));
                HT_SB_RES.Add("SB_COPY_TO_CLIPBOARD", rm.GetString("SB_COPY_TO_CLIPBOARD", ExcelCulture));
                HT_SB_RES.Add("SB_CRITERIA", rm.GetString("SB_CRITERIA", ExcelCulture));
                HT_SB_RES.Add("SB_CRITERIA_DESC_LONG", rm.GetString("SB_CRITERIA_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DEFINITION", rm.GetString("SB_DEFINITION", ExcelCulture));
                HT_SB_RES.Add("SB_DEFINITION_DESC_LONG", rm.GetString("SB_DEFINITION_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DETAILS", rm.GetString("SB_DETAILS", ExcelCulture));
                HT_SB_RES.Add("SB_ELEMENT", rm.GetString("SB_ELEMENT", ExcelCulture));
                HT_SB_RES.Add("SB_ELEMENT_DESC_LONG", rm.GetString("SB_ELEMENT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_EXCLUSIVE", rm.GetString("SB_EXCLUSIVE", ExcelCulture));
                HT_SB_RES.Add("SB_EXCLUSIVE_DESC_LONG", rm.GetString("SB_EXCLUSIVE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_EXTENDED", rm.GetString("SB_EXTENDED", ExcelCulture));
                HT_SB_RES.Add("SB_EXTENDED_DESC_LONG", rm.GetString("SB_EXTENDED_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_ATTRIBUTE", rm.GetString("SB_FILTER_ATTRIBUTE", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_DATA", rm.GetString("SB_FILTER_DATA", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_HIERARCHY", rm.GetString("SB_FILTER_HIERARCHY", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_PICKLIST", rm.GetString("SB_FILTER_PICKLIST", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_SORT", rm.GetString("SB_FILTER_SORT", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_TEXT", rm.GetString("SB_FILTER_TEXT", ExcelCulture));
                HT_SB_RES.Add("SB_FRONT", rm.GetString("SB_FRONT", ExcelCulture));
                HT_SB_RES.Add("SB_GENERAL", rm.GetString("SB_GENERAL", ExcelCulture));
                HT_SB_RES.Add("SB_GROUP_GENERAL", rm.GetString("SB_GROUP_GENERAL", ExcelCulture));
                HT_SB_RES.Add("SB_GROUP_LEVEL", rm.GetString("SB_GROUP_LEVEL", ExcelCulture));
                HT_SB_RES.Add("SB_GROUP_REVOLVE", rm.GetString("SB_GROUP_REVOLVE", ExcelCulture));
                HT_SB_RES.Add("SB_HIDE", rm.GetString("SB_HIDE", ExcelCulture));
                HT_SB_RES.Add("SB_HIDE_DESC_LONG", rm.GetString("SB_HIDE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_HIDE_OPT1", rm.GetString("SB_HIDE_OPT1", ExcelCulture));
                HT_SB_RES.Add("SB_HIDE_OPT2", rm.GetString("SB_HIDE_OPT2", ExcelCulture));
                HT_SB_RES.Add("SB_HIDE_OPT3", rm.GetString("SB_HIDE_OPT3", ExcelCulture));
                HT_SB_RES.Add("SB_INDENT", rm.GetString("SB_INDENT", ExcelCulture));
                HT_SB_RES.Add("SB_INDENT_DESC_LONG", rm.GetString("SB_INDENT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_ELEMENT", rm.GetString("SB_LEVEL_ELEMENT", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_ELEMENT_DESC_LONG", rm.GetString("SB_LEVEL_ELEMENT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_END", rm.GetString("SB_LEVEL_END", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_END_DESC_LONG", rm.GetString("SB_LEVEL_END_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_START", rm.GetString("SB_LEVEL_START", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_START_DESC_LONG", rm.GetString("SB_LEVEL_START_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_LOAD", rm.GetString("SB_LOAD", ExcelCulture));
                HT_SB_RES.Add("SB_LOWER_PERCENTAGE", rm.GetString("SB_LOWER_PERCENTAGE", ExcelCulture));
                HT_SB_RES.Add("SB_LOWER_PERCENTAGE_DESC_LONG", rm.GetString("SB_LOWER_PERCENTAGE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_MAX", rm.GetString("SB_MAX", ExcelCulture));
                HT_SB_RES.Add("SB_MB_APPLY_SUBSET", rm.GetString("SB_MB_APPLY_SUBSET", ExcelCulture));
                HT_SB_RES.Add("SB_MB_CANCEL_SUBSET", rm.GetString("SB_MB_CANCEL_SUBSET", ExcelCulture));
                HT_SB_RES.Add("SB_MB_CLIPBOARD", rm.GetString("SB_MB_CLIPBOARD", ExcelCulture));
                HT_SB_RES.Add("SB_MB_ERROR", rm.GetString("SB_MB_ERROR", ExcelCulture));
                HT_SB_RES.Add("SB_MB_INFO", rm.GetString("SB_MB_INFO", ExcelCulture));
                HT_SB_RES.Add("SB_MB_INTERNAL_ERROR", rm.GetString("SB_MB_INTERNAL_ERROR", ExcelCulture));
                HT_SB_RES.Add("SB_MB_INVALID_SUBSET", rm.GetString("SB_MB_INVALID_SUBSET", ExcelCulture));
                HT_SB_RES.Add("SB_MB_REQUIRED_PARAM", rm.GetString("SB_MB_REQUIRED_PARAM", ExcelCulture));
                HT_SB_RES.Add("SB_MERGE", rm.GetString("SB_MERGE", ExcelCulture));
                HT_SB_RES.Add("SB_MIN", rm.GetString("SB_MIN", ExcelCulture));
                HT_SB_RES.Add("SB_NAMED_PARAMETERS", rm.GetString("SB_NAMED_PARAMETERS", ExcelCulture));
                HT_SB_RES.Add("SB_NEW", rm.GetString("SB_NEW", ExcelCulture));
                HT_SB_RES.Add("SB_NORULES_OPT_1", rm.GetString("SB_NORULES_OPT_1", ExcelCulture));
                HT_SB_RES.Add("SB_NORULES_OPT_2", rm.GetString("SB_NORULES_OPT_2", ExcelCulture));
                HT_SB_RES.Add("SB_NO_RULES", rm.GetString("SB_NO_RULES", ExcelCulture));
                HT_SB_RES.Add("SB_NO_RULES_DESC_LONG", rm.GetString("SB_NO_RULES_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_NUMERIC", rm.GetString("SB_NUMERIC", ExcelCulture));
                HT_SB_RES.Add("SB_PARAM", rm.GetString("SB_PARAM", ExcelCulture));
                HT_SB_RES.Add("SB_PREVIEW", rm.GetString("SB_PREVIEW", ExcelCulture));
                HT_SB_RES.Add("SB_REGEXES", rm.GetString("SB_REGEXES", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE", rm.GetString("SB_REVERSE", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_DESC_LONG", rm.GetString("SB_REVERSE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_OPT1", rm.GetString("SB_REVERSE_OPT1", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_OPT2", rm.GetString("SB_REVERSE_OPT2", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_OPT3", rm.GetString("SB_REVERSE_OPT3", ExcelCulture));
                HT_SB_RES.Add("SB_REVOLVE_ADD", rm.GetString("SB_REVOLVE_ADD", ExcelCulture));
                HT_SB_RES.Add("SB_REVOLVE_ADD_DESC_LONG", rm.GetString("SB_REVOLVE_ADD_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REVOLVE_COUNT", rm.GetString("SB_REVOLVE_COUNT", ExcelCulture));
                HT_SB_RES.Add("SB_REVOLVE_COUNT_DESC_LONG", rm.GetString("SB_REVOLVE_COUNT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REVOLVE_ELEMENT", rm.GetString("SB_REVOLVE_ELEMENT", ExcelCulture));
                HT_SB_RES.Add("SB_REVOLVE_ELEMENT_DESC_LONG", rm.GetString("SB_REVOLVE_ELEMENT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SAVE", rm.GetString("SB_SAVE", ExcelCulture));
                HT_SB_RES.Add("SB_SHOW_CHILDREN", rm.GetString("SB_SHOW_CHILDREN", ExcelCulture));
                HT_SB_RES.Add("SB_SHOW_NONE", rm.GetString("SB_SHOW_NONE", ExcelCulture));
                HT_SB_RES.Add("SB_SORTING_CRITERIA", rm.GetString("SB_SORTING_CRITERIA", ExcelCulture));
                HT_SB_RES.Add("SB_SORTING_CRITERIA_DESC_LONG", rm.GetString("SB_SORTING_CRITERIA_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SOURCE_CUBE", rm.GetString("SB_SOURCE_CUBE", ExcelCulture));
                HT_SB_RES.Add("SB_SOURCE_CUBE_DESC_LONG", rm.GetString("SB_SOURCE_CUBE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_STORED_SUBSETS", rm.GetString("SB_STORED_SUBSETS", ExcelCulture));
                HT_SB_RES.Add("SB_SUB", rm.GetString("SB_SUB", ExcelCulture));
                HT_SB_RES.Add("SB_SUBCUBE", rm.GetString("SB_SUBCUBE", ExcelCulture));
                HT_SB_RES.Add("SB_SUBCUBE_DESC_LONG", rm.GetString("SB_SUBCUBE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_NAME", rm.GetString("SB_SUBSET_NAME", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_NAME_DESC_LONG", rm.GetString("SB_SUBSET_NAME_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SUM", rm.GetString("SB_SUM", ExcelCulture));
                HT_SB_RES.Add("SB_TEXT", rm.GetString("SB_TEXT", ExcelCulture));
                HT_SB_RES.Add("SB_TOP", rm.GetString("SB_TOP", ExcelCulture));
                HT_SB_RES.Add("SB_TOP_DESC_LONG", rm.GetString("SB_TOP_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_TYPE", rm.GetString("SB_TYPE", ExcelCulture));
                HT_SB_RES.Add("SB_TYPELIMIT_OPT1", rm.GetString("SB_TYPELIMIT_OPT1", ExcelCulture));
                HT_SB_RES.Add("SB_TYPELIMIT_OPT2", rm.GetString("SB_TYPELIMIT_OPT2", ExcelCulture));
                HT_SB_RES.Add("SB_TYPELIMIT_OPT3", rm.GetString("SB_TYPELIMIT_OPT3", ExcelCulture));
                HT_SB_RES.Add("SB_TYPE_DESC_LONG", rm.GetString("SB_TYPE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_TYPE_LIMITATION", rm.GetString("SB_TYPE_LIMITATION", ExcelCulture));
                HT_SB_RES.Add("SB_TYPE_LIMITATION_DESC_LONG", rm.GetString("SB_TYPE_LIMITATION_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_UPPER_PERCENTAGE", rm.GetString("SB_UPPER_PERCENTAGE", ExcelCulture));
                HT_SB_RES.Add("SB_UPPER_PERCENTAGE_DESC_LONG", rm.GetString("SB_UPPER_PERCENTAGE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_USE", rm.GetString("SB_USE", ExcelCulture));
                HT_SB_RES.Add("SB_USE_FILTER", rm.GetString("SB_USE_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_VALUE", rm.GetString("SB_VALUE", ExcelCulture));
                HT_SB_RES.Add("SB_WHOLE", rm.GetString("SB_WHOLE", ExcelCulture));
                HT_SB_RES.Add("SB_WHOLE_DESC_LONG", rm.GetString("SB_WHOLE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DESCRIPTION", rm.GetString("SB_DESCRIPTION", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_ALIAS", rm.GetString("SB_FILTER_ALIAS", ExcelCulture));

                HT_SB_RES.Add("SB_PASTE", rm.GetString("SB_PASTE", ExcelCulture));
                HT_SB_RES.Add("SB_BELOW", rm.GetString("SB_BELOW", ExcelCulture));
                HT_SB_RES.Add("SB_BELOW_DESC_LONG", rm.GetString("SB_BELOW_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_CONSOLIDATED", rm.GetString("SB_CONSOLIDATED", ExcelCulture));
                HT_SB_RES.Add("SB_CONSOLIDATED_DESC_LONG", rm.GetString("SB_CONSOLIDATED_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_LEAVES", rm.GetString("SB_LEAVES", ExcelCulture));
                HT_SB_RES.Add("SB_LEAVES_DESC_LONG", rm.GetString("SB_LEAVES_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_PARAMETER", rm.GetString("SB_PARAMETER", ExcelCulture));
                HT_SB_RES.Add("SB_REFRESH", rm.GetString("SB_REFRESH", ExcelCulture));
                HT_SB_RES.Add("SB_AUTO_REFRESH", rm.GetString("SB_AUTO_REFRESH", ExcelCulture));

                HT_SB_RES.Add("SB_CONNECTION_DESC_LONG", rm.GetString("SB_CONNECTION_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SERVER_SELECTION", rm.GetString("SB_SERVER_SELECTION", ExcelCulture));
                HT_SB_RES.Add("SB_DIMENSION_DESC_LONG", rm.GetString("SB_DIMENSION_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DIMENSION", rm.GetString("SB_DIMENSION", ExcelCulture));
                HT_SB_RES.Add("SB_SELECT_FIRST_ALIAS", rm.GetString("SB_SELECT_FIRST_ALIAS", ExcelCulture));
                HT_SB_RES.Add("SB_SELECT_SECOND_ALIAS", rm.GetString("SB_SELECT_SECOND_ALIAS", ExcelCulture));
                HT_SB_RES.Add("SB_FLAT", rm.GetString("SB_FLAT", ExcelCulture));
                HT_SB_RES.Add("SB_FLAT_DESC_LONG", rm.GetString("SB_FLAT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_HIERARCHY", rm.GetString("SB_HIERARCHY", ExcelCulture));
                HT_SB_RES.Add("SB_HIERARCHY_DESC_LONG", rm.GetString("SB_HIERARCHY_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_HIERARCHY", rm.GetString("SB_REVERSE_HIERARCHY", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_HIERARCHY_DESC_LONG", rm.GetString("SB_REVERSE_HIERARCHY_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SHOW_HIDDEN_CHILDREN", rm.GetString("SB_SHOW_HIDDEN_CHILDREN", ExcelCulture));
                HT_SB_RES.Add("SB_SHOW_HIDDEN_CHILDREN_DESC_LONG", rm.GetString("SB_SHOW_HIDDEN_CHILDREN_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SHOW_DUPLICATES", rm.GetString("SB_SHOW_DUPLICATES", ExcelCulture));
                HT_SB_RES.Add("SB_SHOW_DUPLICATES_DESC_LONG", rm.GetString("SB_SHOW_DUPLICATES_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL", rm.GetString("SB_LEVEL", ExcelCulture));
                HT_SB_RES.Add("SB_LEVEL_DESC_LONG", rm.GetString("SB_LEVEL_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DEPTH", rm.GetString("SB_DEPTH", ExcelCulture));
                HT_SB_RES.Add("SB_DEPTH_DESC_LONG", rm.GetString("SB_DEPTH_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SERVER", rm.GetString("SB_SERVER", ExcelCulture));
                HT_SB_RES.Add("SB_LAYOUT", rm.GetString("SB_LAYOUT", ExcelCulture));
                HT_SB_RES.Add("SB_HIERARCHY_ENUMERATION", rm.GetString("SB_HIERARCHY_ENUMERATION", ExcelCulture));
                HT_SB_RES.Add("SB_SETTINGS", rm.GetString("SB_SETTINGS", ExcelCulture));
                HT_SB_RES.Add("SB_REGEXTITLE", rm.GetString("SB_REGEXTITLE", ExcelCulture));
                HT_SB_RES.Add("SB_REGEXEXAMPLES", rm.GetString("SB_REGEXEXAMPLES", ExcelCulture));
                HT_SB_RES.Add("SB_REGULAR_EXPRESSIONS", rm.GetString("SB_REGULAR_EXPRESSIONS", ExcelCulture));
                HT_SB_RES.Add("SB_REGULAR_EXPRESSIONS_DESC_LONG", rm.GetString("SB_REGULAR_EXPRESSIONS_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_CHOSEN_ELEMENTS", rm.GetString("SB_CHOSEN_ELEMENTS", ExcelCulture));
                HT_SB_RES.Add("SB_EDIT", rm.GetString("SB_EDIT", ExcelCulture));
                HT_SB_RES.Add("SB_SELECT_INSERTION", rm.GetString("SB_SELECT_INSERTION", ExcelCulture));
                HT_SB_RES.Add("SB_FRONT_DESC_LONG", rm.GetString("SB_FRONT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_BACK_DESC_LONG", rm.GetString("SB_BACK_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_MERGE_DESC_LONG", rm.GetString("SB_MERGE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SUBTRACT", rm.GetString("SB_SUBTRACT", ExcelCulture));
                HT_SB_RES.Add("SB_SUBTRACT_DESC_LONG", rm.GetString("SB_SUBTRACT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DIMENSION_CONTENTS", rm.GetString("SB_DIMENSION_CONTENTS", ExcelCulture));
                HT_SB_RES.Add("SB_BEHAVIOUR", rm.GetString("SB_BEHAVIOUR", ExcelCulture));
                HT_SB_RES.Add("SB_SELECT_ATTRIBUTE_FIELDS", rm.GetString("SB_SELECT_ATTRIBUTE_FIELDS", ExcelCulture));
                HT_SB_RES.Add("SB_ATTRIBUTE_EXAMPLES", rm.GetString("SB_ATTRIBUTE_EXAMPLES", ExcelCulture));
                HT_SB_RES.Add("SB_AND", rm.GetString("SB_AND", ExcelCulture));
                HT_SB_RES.Add("SB_OPTIONAL_SETTINGS", rm.GetString("SB_OPTIONAL_SETTINGS", ExcelCulture));
                HT_SB_RES.Add("SB_SLICE_OPERATORS", rm.GetString("SB_SLICE_OPERATORS", ExcelCulture));
                HT_SB_RES.Add("SB_CUBE", rm.GetString("SB_CUBE", ExcelCulture));
                HT_SB_RES.Add("SB_SUM_DESC_LONG", rm.GetString("SB_SUM_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ALL_DESC_LONG", rm.GetString("SB_ALL_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_AVERAGE_DESC_LONG", rm.GetString("SB_AVERAGE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_MAX_DESC_LONG", rm.GetString("SB_MAX_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ANY_DESC_LONG", rm.GetString("SB_ANY_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_MIN_DESC_LONG", rm.GetString("SB_MIN_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_STRING", rm.GetString("SB_STRING", ExcelCulture));
                HT_SB_RES.Add("SB_STRING_DESC_LONG", rm.GetString("SB_STRING_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_TAKE_TOPMOST", rm.GetString("SB_TAKE_TOPMOST", ExcelCulture));
                HT_SB_RES.Add("SB_TAKE_TOPMOST_DESC_LONG", rm.GetString("SB_TAKE_TOPMOST_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_TAKE_UPPER", rm.GetString("SB_TAKE_UPPER", ExcelCulture));
                HT_SB_RES.Add("SB_TAKE_UPPER_DESC_LONG", rm.GetString("SB_TAKE_UPPER_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_TAKE_LOWER", rm.GetString("SB_TAKE_LOWER", ExcelCulture));
                HT_SB_RES.Add("SB_TAKE_LOWER_DESC_LONG", rm.GetString("SB_TAKE_LOWER_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SORTING_BEHAVIOUR", rm.GetString("SB_SORTING_BEHAVIOUR", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_ORDER", rm.GetString("SB_REVERSE_ORDER", ExcelCulture));
                HT_SB_RES.Add("SB_BY_DEFINITION", rm.GetString("SB_BY_DEFINITION", ExcelCulture));
                HT_SB_RES.Add("SB_BY_DEFINITION_DESC_LONG", rm.GetString("SB_BY_DEFINITION_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_BY_ELEMENT_NAME", rm.GetString("SB_BY_ELEMENT_NAME", ExcelCulture));
                HT_SB_RES.Add("SB_BY_ELEMENT_NAME_DESC_LONG", rm.GetString("SB_BY_ELEMENT_NAME_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_BY_ALIAS", rm.GetString("SB_BY_ALIAS", ExcelCulture));
                HT_SB_RES.Add("SB_BY_ALIAS_DESC_LONG", rm.GetString("SB_BY_ALIAS_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_BY_VALUE", rm.GetString("SB_BY_VALUE", ExcelCulture));
                HT_SB_RES.Add("SB_BY_VALUE_DESC_LONG", rm.GetString("SB_BY_VALUE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_BY_ATTRIBUTE", rm.GetString("SB_BY_ATTRIBUTE", ExcelCulture));
                HT_SB_RES.Add("SB_BY_ATTRIBUTE_DESC_LONG", rm.GetString("SB_BY_ATTRIBUTE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_PER_LEVEL", rm.GetString("SB_REVERSE_PER_LEVEL", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_PER_LEVEL_DESC_LONG", rm.GetString("SB_REVERSE_PER_LEVEL_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_TOTAL", rm.GetString("SB_REVERSE_TOTAL", ExcelCulture));
                HT_SB_RES.Add("SB_REVERSE_TOTAL_DESC_LONG", rm.GetString("SB_REVERSE_TOTAL_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ALL_ELEMENTS", rm.GetString("SB_ALL_ELEMENTS", ExcelCulture));
                HT_SB_RES.Add("SB_ALL_ELEMENTS_DESC_LONG", rm.GetString("SB_ALL_ELEMENTS_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_BASE_ELEMENTS", rm.GetString("SB_BASE_ELEMENTS", ExcelCulture));
                HT_SB_RES.Add("SB_BASE_ELEMENTS_DESC_LONG", rm.GetString("SB_BASE_ELEMENTS_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_CONSOLIDATED_ELEMENTS", rm.GetString("SB_CONSOLIDATED_ELEMENTS", ExcelCulture));
                HT_SB_RES.Add("SB_CONSOLIDATED_ELEMENTS_DESC_LONG", rm.GetString("SB_CONSOLIDATED_ELEMENTS_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SORT_LEVEL", rm.GetString("SB_SORT_LEVEL", ExcelCulture));
                HT_SB_RES.Add("SB_SORT_LEVEL_DESC_LONG", rm.GetString("SB_SORT_LEVEL_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_ACTIVATE_FILTER", rm.GetString("SB_ACTIVATE_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_GENERAL_SETTINGS", rm.GetString("SB_SUBSET_GENERAL_SETTINGS", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_HIERARCHY_FILTER", rm.GetString("SB_SUBSET_HIERARCHY_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_TEXT_FILTER", rm.GetString("SB_SUBSET_TEXT_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_PICKLIST_FILTER", rm.GetString("SB_SUBSET_PICKLIST_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_ATTRIBUTE_FILTER", rm.GetString("SB_SUBSET_ATTRIBUTE_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_DATA_FILTER", rm.GetString("SB_SUBSET_DATA_FILTER", ExcelCulture));
                HT_SB_RES.Add("SB_SUBSET_SORTING", rm.GetString("SB_SUBSET_SORTING", ExcelCulture));
                HT_SB_RES.Add("SB_FILTER_GENERAL", rm.GetString("SB_FILTER_GENERAL", ExcelCulture));
                HT_SB_RES.Add("SB_ADD", rm.GetString("SB_ADD", ExcelCulture));
                HT_SB_RES.Add("SB_DELETE", rm.GetString("SB_DELETE", ExcelCulture));
                HT_SB_RES.Add("SB_RENAME", rm.GetString("SB_RENAME", ExcelCulture));
                HT_SB_RES.Add("SB_FORMULA_SUBSET", rm.GetString("SB_FORMULA_SUBSET", ExcelCulture));
                HT_SB_RES.Add("SB_LOCAL_SUBSETS", rm.GetString("SB_LOCAL_SUBSETS", ExcelCulture));
                HT_SB_RES.Add("SB_GLOBAL_SUBSETS", rm.GetString("SB_GLOBAL_SUBSETS", ExcelCulture));
                HT_SB_RES.Add("SB_PASTE_DESC_LONG", rm.GetString("SB_PASTE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_COPY_DESC_LONG", rm.GetString("SB_COPY_DESC_LONG", ExcelCulture));

                HT_SB_RES.Add("SB_MB_SUBSET_DELETED", rm.GetString("SB_MB_SUBSET_DELETED", ExcelCulture));
                HT_SB_RES.Add("SB_MB_PASTE_ERROR", rm.GetString("SB_MB_PASTE_ERROR", ExcelCulture));
                HT_SB_RES.Add("SB_MB_NP_HIDE_DISABLED", rm.GetString("SB_MB_NP_HIDE_DISABLED", ExcelCulture));
                HT_SB_RES.Add("SB_MB_SAVE_QUESTION", rm.GetString("SB_MB_SAVE_QUESTION", ExcelCulture));
                HT_SB_RES.Add("SB_MB_SAVE_SUBSET", rm.GetString("SB_MB_SAVE_SUBSET", ExcelCulture));
                HT_SB_RES.Add("SB_CB_ALL_ELEMENTS", rm.GetString("SB_CB_ALL_ELEMENTS", ExcelCulture));

                HT_SB_RES.Add("SB_LB_HIERARCHY_INDENT", rm.GetString("SB_LB_HIERARCHY_INDENT", ExcelCulture));
                HT_SB_RES.Add("SB_LB_HIERARCHY_LEVEL", rm.GetString("SB_LB_HIERARCHY_LEVEL", ExcelCulture));
                HT_SB_RES.Add("SB_LB_HIERARCHY_DEPTH", rm.GetString("SB_LB_HIERARCHY_DEPTH", ExcelCulture));

                HT_SB_RES.Add("SB_SUBSET_EDITOR", rm.GetString("SB_SUBSET_EDITOR", ExcelCulture));
                HT_SB_RES.Add("SB_AUTOREFRESH_WARNING", rm.GetString("SB_AUTOREFRESH_WARNING", ExcelCulture));
                HT_SB_RES.Add("SB_AUTOREFRESH_DONT_SHOW", rm.GetString("SB_AUTOREFRESH_DONT_SHOW", ExcelCulture));

                HT_SB_RES.Add("SB_ADD_DESC_LONG", rm.GetString("SB_ADD_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_DELETE_DESC_LONG", rm.GetString("SB_DELETE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_EDIT_DESC_LONG", rm.GetString("SB_EDIT_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_SAVE_DESC_LONG", rm.GetString("SB_SAVE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_CLOSE_DESC_LONG", rm.GetString("SB_CLOSE_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_AUTO_REFRESH_DESC_LONG", rm.GetString("SB_AUTO_REFRESH_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_REFRESH_DESC_LONG", rm.GetString("SB_REFRESH_DESC_LONG", ExcelCulture));
                HT_SB_RES.Add("SB_MB_CONFIRM_DELETE", rm.GetString("SB_MB_CONFIRM_DELETE", ExcelCulture));

                #endregion

                #region InfoBox
                InfoBox_btnDemoApp = rm.GetString("InfoBox_btnDemoApp", ExcelCulture);
                InfoBox_btnFirstSteps = rm.GetString("InfoBox_btnFirstSteps", ExcelCulture);
                InfoBox_btnAdvancedManual = rm.GetString("InfoBox_btnAdvancedManual", ExcelCulture);
                InfoBox_btnTraining = rm.GetString("InfoBox_btnTraining", ExcelCulture);
                InfoBox_bntAbout = rm.GetString("InfoBox_bntAbout", ExcelCulture);
                InfoBox_btnClose = rm.GetString("InfoBox_btnClose", ExcelCulture);
                InfoBox_adTitle = rm.GetString("InfoBox_adTitle", ExcelCulture);
                InfoBox_adTitleLogo = rm.GetString("InfoBox_adTitleLogo", ExcelCulture);
                InfoBox_lblDemoApp = rm.GetString("InfoBox_lblDemoApp", ExcelCulture);
                InfoBox_lblFirstSteps = rm.GetString("InfoBox_lblFirstSteps", ExcelCulture);
                InfoBox_lblPaloMenu1 = rm.GetString("InfoBox_lblPaloMenu1", ExcelCulture);
                InfoBox_lblMyPalo = rm.GetString("InfoBox_lblMyPalo", ExcelCulture);
                InfoBox_lblPaloMenu2 = rm.GetString("InfoBox_lblPaloMenu2", ExcelCulture);
                InfoBox_chkAnnoyBox = rm.GetString("InfoBox_chkAnnoyBox", ExcelCulture);
                #endregion

                #region LicenseBox
                LicenseBox_btnContinue = rm.GetString("LicenseBox_btnContinue", ExcelCulture);
                LicenseBox_btnCompare = rm.GetString("LicenseBox_btnCompare", ExcelCulture);
                LicenseBox_btnCEDownload = rm.GetString("LicenseBox_btnCEDownload", ExcelCulture);
                LicenseBox_btnQuote = rm.GetString("LicenseBox_btnQuote", ExcelCulture);
                LicenseBox_lblLicense = rm.GetString("LicenseBox_lblLicense", ExcelCulture);
                LicenseBox_lblLicenseExpired = rm.GetString("LicenseBox_lblLicenseExpired", ExcelCulture);
                LicenseBox_lblQuote = rm.GetString("LicenseBox_lblQuote", ExcelCulture);
                LicenseBox_lblComparison = rm.GetString("LicenseBox_lblComparison", ExcelCulture);
                LicenseBox_lblCommunity = rm.GetString("LicenseBox_lblCommunity", ExcelCulture);
                #endregion

                #region Palo Web
                PaloWebMenu = rm.GetString("PaloWebMenu", ExcelCulture);
                PaloWebWizard = rm.GetString("PaloWebWizard", ExcelCulture);
                PaloWebOpen = rm.GetString("PaloWebOpen", ExcelCulture);
                PaloWebSaveAs = rm.GetString("PaloWebSaveAs", ExcelCulture);

                URL_EMPTY = rm.GetString("URL_EMPTY", ExcelCulture);
                URL_NOT_WELLFOMED = rm.GetString("URL_NOT_WELLFOMED", ExcelCulture);

                PWW_T1Heading = rm.GetString("PWW_T1Heading", ExcelCulture);
                PWW_T1ConnectionHeading = rm.GetString("PWW_T1ConnectionHeading", ExcelCulture);
                PWW_T1ConnectionLabel = rm.GetString("PWW_T1ConnectionLabel", ExcelCulture);
                PWW_T1ConnectionMarkDefault = rm.GetString("PWW_T1ConnectionMarkDefault", ExcelCulture);
                PWW_T1ConnectionAction = rm.GetString("PWW_T1ConnectionAction", ExcelCulture);
                PWW_T1New = rm.GetString("PWW_T1New", ExcelCulture);
                PWW_T1Remove = rm.GetString("PWW_T1Remove", ExcelCulture);
                PWW_T1Edit = rm.GetString("PWW_T1Edit", ExcelCulture);

                PWW_T2Heading = rm.GetString("PWW_T2Heading", ExcelCulture);
                PWW_T2ConnectionHeading = rm.GetString("PWW_T2ConnectionHeading", ExcelCulture);
                PWW_T2ConnectionName = rm.GetString("PWW_T2ConnectionName", ExcelCulture);
                PWW_T2ConnectionURL = rm.GetString("PWW_T2ConnectionURL", ExcelCulture);
                PWW_T2Username = rm.GetString("PWW_T2Username", ExcelCulture);
                PWW_T2Password = rm.GetString("PWW_T2Password", ExcelCulture);
                PWW_T2Secret = rm.GetString("PWW_T2Secret", ExcelCulture);

                PWW_DefaultConnectionTitle = rm.GetString("PWW_DefaultConnectionTitle", ExcelCulture);
                PWW_DefaultConnectionMsg = rm.GetString("PWW_DefaultConnectionMsg", ExcelCulture);
                PWW_Title = rm.GetString("PWW_Title", ExcelCulture);

                updateCheckTitle = rm.GetString("updateCheckTitle", ExcelCulture);
                updateCheckText = rm.GetString("updateCheckText", ExcelCulture);
                #endregion

                #region SVS Wizard

                CMD_SVS_WIZARD = rm.GetString("CMD_SVS_WIZARD", ExcelCulture);
                TITLE_SVS_WIZARD = rm.GetString("TITLE_SVS_WIZARD", ExcelCulture);
                
                SVS_WIZARD_SETP1_TEXT = rm.GetString("SVS_SETP1_TEXT", ExcelCulture);
                SVS_WIZARD_SETP2_TEXT = rm.GetString("SVS_SETP2_TEXT", ExcelCulture);
                SVS_WIZARD_SETP3_TEXT = rm.GetString("SVS_SETP3_TEXT", ExcelCulture);
                SVS_WIZARD_SETP4_TEXT = rm.GetString("SVS_SETP4_TEXT", ExcelCulture);
                SVS_WIZARD_SETP5_TEXT = rm.GetString("SVS_SETP5_TEXT", ExcelCulture);
                SVS_SAVE_TEXT = rm.GetString("SVS_SAVE_TEXT", ExcelCulture);                

                SVS_RADIOBUTTON1_TEXT = rm.GetString("SVS_RADIOBUTTON1_TEXT", ExcelCulture);
                SVS_RADIOBUTTON1_DESCRIPTION = rm.GetString("SVS_RADIOBUTTON1_DESCRIPTION", ExcelCulture);
                SVS_RADIOBUTTON2_TEXT = rm.GetString("SVS_RADIOBUTTON2_TEXT", ExcelCulture);
                SVS_RADIOBUTTON2_DESCRIPTION = rm.GetString("SVS_RADIOBUTTON2_DESCRIPTION", ExcelCulture);
                SVS_RADIOBUTTON3_TEXT = rm.GetString("SVS_RADIOBUTTON3_TEXT", ExcelCulture);
                SVS_RADIOBUTTON3_DESCRIPTION = rm.GetString("SVS_RADIOBUTTON3_DESCRIPTION", ExcelCulture);
                SVS_RADIOBUTTON4_TEXT = rm.GetString("SVS_RADIOBUTTON4_TEXT", ExcelCulture);
                SVS_RADIOBUTTON4_DESCRIPTION = rm.GetString("SVS_RADIOBUTTON4_DESCRIPTION", ExcelCulture);
                SVS_RADIOBUTTON5_TEXT = rm.GetString("SVS_RADIOBUTTON5_TEXT", ExcelCulture);
                SVS_RADIOBUTTON5_DESCRIPTION = rm.GetString("SVS_RADIOBUTTON5_DESCRIPTION", ExcelCulture);
                SVS_RADIOBUTTON6_TEXT = rm.GetString("SVS_RADIOBUTTON6_TEXT", ExcelCulture);
                SVS_RADIOBUTTON6_DESCRIPTION = rm.GetString("SVS_RADIOBUTTON6_DESCRIPTION", ExcelCulture);

                #endregion

            }
			catch(Exception ResExc)
			{
				ErrorHandler.DisplayError("Error fetching resource data.", ResExc);
			}
			finally
			{
				thisThread.CurrentUICulture = this.originalUICulture;
			}


			#endregion
		}

        public static CultureInfo getExcelCulture()
        {
            return originalExcelCulture;
        }


        public static string Replace(string template, object[] args)
        {
            if (template == null)
                return "";

            int count = args.Length;
            string tmpstr = template;

            for (int i = 1; i <= count; i++)
                tmpstr = tmpstr.Replace("%" + i.ToString(), args[i - 1].ToString());
            return tmpstr;
        }
    }
}
