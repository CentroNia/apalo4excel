using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Apalo.XlAddin
{
public class JTabPage : TabPage
    {

    /// <summary>
    /// Defined for compatability
    /// </summary>
    public string Title        
        {
        get {return this.Text;}
        set {this.Text = value;}
        }        
    
    /// <summary>
    /// Defined for compatability
    /// </summary>
    public bool Selected
        {
        get {return this.Parent is TabControl ? ((TabControl)this.Parent).SelectedTab == this : false;}
        set {if (value && this.Parent is TabControl) ((TabControl)this.Parent).SelectedTab = this;}
        }

    public JTabPage() {}

    public JTabPage(string text) : base(text) {}

    }
}
