using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sound_Track_Win.SoundTrackRestAPI;
using Sound_Track_Win.SoundTrackAudio;

namespace Sound_Track_Win
{
    public partial class formST : Form
    {
        userSettingsForm userSettings = new userSettingsForm();
        SoundTrackAudioReceiver audioHandle;
        public formST()
        {
            InitializeComponent();

            audioWorker.DoWork += audioWork;
            audioWorker.RunWorkerAsync();
            restBTWorker.DoWork += restBTWork;
            restBTWorker.RunWorkerAsync();

            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                                   Screen.PrimaryScreen.WorkingArea.Height - Height);

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

        private void updateStatusText(string status)
        {
            statusDisplay.Text = status;
            notifyIconST.Text = "Sound Track - Status: " + status;
        }

        //Methods for background work
        private void audioWork(object sender, DoWorkEventArgs e)
        {

        }

        private void restBTWork(object sender, DoWorkEventArgs e)
        {

            statusDisplay.Invoke((MethodInvoker)delegate 
                { updateStatusText("Connecting to server..."); } );

            SoundTrackRestHandler stRest = new SoundTrackRestHandler("localhost");
            TimeResource serverTime = null;

            while (serverTime == null)
            {
                try { serverTime = stRest.GetServerTime(); }
                catch
                {
                    statusDisplay.Invoke((MethodInvoker)delegate
                        { updateStatusText("Connection failed, retrying..."); });
                    Thread.Sleep(5000);
                    statusDisplay.Invoke((MethodInvoker)delegate
                        { updateStatusText("Connecting to server..."); });
                }

            }
            statusDisplay.Invoke((MethodInvoker)delegate
                { updateStatusText("Connected"); });
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
