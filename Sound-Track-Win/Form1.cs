using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sound_Track_Win
{
    public partial class formST : Form
    {
        public formST()
        {
            InitializeComponent();
        }

        private void formST_SizeChanged(object sender, EventArgs e)
        {

            //Hide the form to remove it from taskbar when minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIconST.Visible = true;
            }
        }

        private void showForm(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconST.Visible = false;
        }

        private void closeForm(object sender, EventArgs e)
        {
            Close();
        }
    }
}
