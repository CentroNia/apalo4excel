using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apalo.XlAddin.Forms
{
    public partial class PaloMessage : Form
    {
        public PaloMessage(Form parent, string message)
        {
            InitializeComponent();

            this.Message.Text = message;
            this.StartPosition = FormStartPosition.Manual;
            
            Rectangle pbounds = parent.DesktopBounds;
            Size mysize = this.Size;

            int newy = pbounds.Top + (int)(pbounds.Height/2 - mysize.Height/2);
            int newx = pbounds.Left + (int)(pbounds.Width/2 - mysize.Width/2);
            
            this.SetDesktopLocation(newx, newy);
        }
    }
}