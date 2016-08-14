using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aPalo.XlAddin
{
public partial class Modeller2 : Form
    {
    
    public Modeller2()
        {
        InitializeComponent();
        }
    
    private void Modeller_Load(object sender, System.EventArgs e)
        {
        }
    
    private void Modeller_VisibleChanged(object sender, System.EventArgs e)
        {
        }
    
    private void _Resize(object sender, System.EventArgs e)
        {
        //this.setSizes();
        }

    private void btnConnAdd_Click(object sender, System.EventArgs e)
        {
        }
            
    private void btnClose_Click(object sender, System.EventArgs e)
        {
        }
        
    private void btnRuleEditor_Click(object sender, EventArgs e)
        {
        }
        
    private void btnCopy_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnPaste_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnConnToggle_Click(object sender, System.EventArgs e)
        {
        }

    private void btnUserManagment_Click(object sender, EventArgs e)
        {
        }
    
    private void btnDataManagment_Click(object sender, EventArgs e)
        {         
        }

    private void btnAttributeManagment_Click(object sender, EventArgs e)
        {    
        }

    private void btnOrigDims_Click(object sender, EventArgs e)
        {
        }
    
    private void btnAscDims_Click(object sender, EventArgs e)
        {
        }
    
    private void btnDescDims_Click(object sender, EventArgs e)
        {
        }

    private void btnAscElems_Click(object sender, System.EventArgs e)
        {
        }

    private void btnDescElems_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnOrigElems_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnCubeAdd_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnCubeRemove_Click(object sender, System.EventArgs e)
        {
        }

    private void btnDimensionAdd_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnDimensionRemove_Click(object sender, System.EventArgs e)
        {   
        }

    private void btnDimensionRename_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnElementRemove_Click(object sender, System.EventArgs e)
        {   
        }

    private void btnElementRename_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnElementEdit_Click(object sender, System.EventArgs e)
        {
        }
    
    private void btnEnableTree_Click(object sender, System.EventArgs e)
        {
        }

    private void cmdNumeric_Click(object sender, System.EventArgs e)
        {
        }
        
    private void cmdString_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdAddN_Click(object sender, System.EventArgs e)
        {
        }
        
    private void cmdClearCube_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdExportCube_Click(object sender, System.EventArgs e)
        {
        }

    private void cmdSVSWizard_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdCubeConvert_Click(object sender, System.EventArgs e)
        {
        }

    private void cmdCountElements_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdMeasure_Click(object sender, EventArgs e)
        {
        }

    private void cmdSearchElements_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdTabDatabase_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdChild_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdSibling_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdChildCopy_Click(object sender, System.EventArgs e)
        {
        this.cmdChild_Click(sender, e);
        }

    private void cmdSiblingCopy_Click(object sender, System.EventArgs e)
        {
        this.cmdSibling_Click(sender, e);
        }

    private void cmdTime_Click(object sender, EventArgs e)
        {
        }

    private void cmdElemCopy_Click(object sender, System.EventArgs e)
        {
        this.btnCopy_Click(sender, e);
        }

    private void cmdElemPaste_Click(object sender, System.EventArgs e)
        {
        this.btnPaste_Click(sender, e);
        }

    private void cmdElemSelectAll_Click(object sender, System.EventArgs e)
        {
        }

    private void cmdElementMoveBegin_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdElementMoveEnd_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdDelSrcElem_Click(object sender, System.EventArgs e)
        {
        //this.removeSelectedSourceElements();
        }

    private void cmdFactor_Click(object sender, System.EventArgs e)
        {
        //this.showFactor();
        }

    private void cmdShowParents_Click(object sender, System.EventArgs e)
        {
        }
    
    private void cmdSrcElementMoveBegin_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdSrcElementMoveEnd_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdAddSubset_Click(object sender, EventArgs e)
        {
        //DoCallSubSetEditor();
        }

    private void cmdEditSubset_Click(object sender, EventArgs e)
        {
        //renameSubset(); 
        }
    
    private void cmdRemoveSubset_Click(object sender, EventArgs e)
        {
        //RemoveSubset();
        }

    private void cmdDimExport_Click(object sender, EventArgs e)
        {
        }
    
    private void cmdDimInfo_Click(object sender, EventArgs e)
        {
        }

    private void Modeller_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }
        
    private void tabMain_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
        {
        }

    private void tabMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }
        
    private void doElementTypeSelectedIndexChangedHelper()
        {

        }

    private void doElementTypeSelectedIndexChanged0()
        {
   
        }

    private void cmbElementType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    
    private void cmdCubeRename_Click(object sender, EventArgs e)
        {
        }
    
    private void treeViewCubes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
        }

    private void treeViewDims_DoubleClick(object sender, System.EventArgs e)
        {
        }

    private void treeViewCubes_DoubleClick(object sender, System.EventArgs e)
        {
        }

    private void btnDimensionEdit_Click(object sender, System.EventArgs e)
        {
        }

    private void btnHome_Click(object sender, System.EventArgs e)
        {
        }

    private void treeViewCubes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

    private void treeViewDims_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }

    }
}
