using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Apalo.XlAddin
{
public class JTabControl : TabControl
    {

    /// <summary>Set this property to hide the tabs</summary>
    [Browsable(true)]
    [Category("Appearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool HideTabs {get;set;}

    /// <summary>
    /// Handle windows messages
    /// </summary>
    /// <param name="m"></param>
    protected override void WndProc(ref Message m)
        {
        // Hide tabs by trapping the TCM_ADJUSTRECT message
        if (HideTabs && m.Msg == 0x1328 && !DesignMode)
            m.Result = (IntPtr)1;
        else
            base.WndProc(ref m);
        }


    }
}
