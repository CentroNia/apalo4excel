using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apalo.XlAddin
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
