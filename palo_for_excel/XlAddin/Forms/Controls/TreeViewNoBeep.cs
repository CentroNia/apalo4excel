using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using JControls;
using Jedox.Palo.Comm;
using Apalo.XlAddin.Utils;

namespace Apalo.XlAddin.Forms.Controls
    {
    public class TreeViewNoBeep : TreeView
        {
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                if(e.KeyChar == (int)System.Windows.Forms.Keys.Return || e.KeyChar == (int)System.Windows.Forms.Keys.Escape || e.KeyChar == (int)System.Windows.Forms.Keys.Delete)
                    e.Handled = true;
                else
                    base.OnKeyPress(e);
            }
        }

    }
