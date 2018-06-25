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
        userSettingsForm userSettings = new userSettingsForm();
        public formST()
        {
            InitializeComponent();

            audioWorker.DoWork += audioWork;
            audioWorker.RunWorkerAsync();
            restBTWorker.DoWork += restBTWork;
            restBTWorker.RunWorkerAsync();

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

        private void btnUser_Click(object sender, EventArgs e)
        {
            userSettings.ShowDialog();
        }

        //Methods for background work
        private void audioWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void restBTWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SoundTrackRestAPI.SoundTrackRestHandler stRest = 
                new SoundTrackRestAPI.SoundTrackRestHandler("localhost");
            SoundTrackRestAPI.TimeResource serverTime;
            serverTime = stRest.GetServerTime();
            if (!serverTime.Equals(null))
            {
                DateTime actualTimeThing = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                long longTime = (long)serverTime.time;
                actualTimeThing.AddSeconds(longTime);
                MessageBox.Show(String.Format("The server time was: {0:H:mm:ss dd/MM/yy}", actualTimeThing), "NOTE", MessageBoxButtons.OK);
            }
            if (rbOutput.Checked)
            {

            }
            else if (rbTracker.Checked)
            {

            }
            else
            {
                //Shouldn't actually ever reach here
            }
        }
    }
}
