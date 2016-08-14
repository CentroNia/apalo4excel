using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apalo.XlAddin;

namespace PaloDesigner
    {
    public partial class PaloTestForm : Form
        {
        public PaloTestForm()
            {
            InitializeComponent();
            Apalo.XlAddin.Utils.ExcelHelper.TestWithoutExcel = true;
            }

        private void button1_Click(object sender, EventArgs e)
            {
            Connect.Checkinit();
            }

        private void button2_Click(object sender, EventArgs e)
            {
            try
                {
                Connect.Checkinit();
                using (var FrmDlg = new Apalo.XlAddin.Forms.Modeller(new System.Globalization.CultureInfo(0x0409)))
                    {
                    FrmDlg.ShowDialog(this);
                    }
                }
            catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message, "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        private void button3_Click(object sender, EventArgs e)
            {
            try
                {
                Connect.Checkinit();
                using (var FrmDlg = new Apalo.XlAddin.Forms.PaloWizard())
                    {
                    FrmDlg.ShowDialog(this);
                    }
                }
            catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message, "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        private void button4_Click(object sender, EventArgs e)
            {
            try
                {
                Connect.Checkinit();
                using (var FrmPaste = new Apalo.XlAddin.Forms.PasteElements2())
                    {
                    FrmPaste.set_default();
                    FrmPaste.ShowDialog(this);
                    }
                }
            catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message, "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        private void button5_Click(object sender, EventArgs e)
            {
            try
                {
                Connect.Checkinit();
                using (var FrmPaste = new Apalo.XlAddin.Forms.FrmPasteView())
                    {
                    FrmPaste.ShowDialog(this);
                    }
                }
            catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message, "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        private void button6_Click(object sender, EventArgs e)
            {
            try
                {
                Connect.Checkinit();
                using (var FrmPaste = new Apalo.XlAddin.Forms.PasteElements2())
                    {
                    FrmPaste.set_default();
                    FrmPaste.ShowDialog(this);
                    }
                }
            catch (Exception Ex)
                {
                MessageBox.Show(Ex.Message, "Function Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
