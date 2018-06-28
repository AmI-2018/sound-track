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
    public partial class UserNameForm : Form
    {
        public string UserName { get; protected set; }

        public UserNameForm(string descrtiption)
        {
            InitializeComponent();

            descriptionLabel.Text = descrtiption;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("You must have at least 3 characters for the name.", "Warning");
                return;
            }
            UserName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UserNameForm_Load(object sender, EventArgs e)
        {
            descriptionLabel.Location = new Point((this.Width / 2) - (descriptionLabel.Width / 2) - 10, descriptionLabel.Location.Y);
        }
    }
}
