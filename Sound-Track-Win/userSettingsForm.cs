using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sound_Track_Win.SoundTrackRestAPI;

namespace Sound_Track_Win
{
    public partial class userSettingsForm : Form
    {
        List<TextBox> startBoxes = new List<TextBox>();
        List<TextBox> endBoxes = new List<TextBox>();
        DateTime[] startTimes = new DateTime[7];
        DateTime[] endTimes = new DateTime[7];
        setTimeForm setTime;

        int index;
        bool changesMade = false;

        List<UserResource> allUsers;
        SoundTrackRestHandler stRest;


        public userSettingsForm(SoundTrackRestHandler stHandler, string userID = "")
        {
            InitializeComponent();

            startBoxes.Add(monStartBox);
            startBoxes.Add(tueStartBox);
            startBoxes.Add(wedStartBox);
            startBoxes.Add(thrStartBox);
            startBoxes.Add(friStartBox);
            startBoxes.Add(satStartBox);
            startBoxes.Add(sunStartBox);

            endBoxes.Add(monEndBox);
            endBoxes.Add(tueEndBox);
            endBoxes.Add(wedEndBox);
            endBoxes.Add(thrEndBox);
            endBoxes.Add(friEndBox);
            endBoxes.Add(satEndBox);
            endBoxes.Add(sunEndBox);

            setTime = new setTimeForm(SetTimeFromForm);
            setTime.Disposed += formDisposed;

            stRest = stHandler;

            allUsers = stRest.GetAllUsers();

            UserSelect selectUser = new UserSelect(stRest, allUsers);

            if (allUsers.Count == 0)
            {
                index = selectUser.CreateNewUser();
                if (index == -1) { this.Close(); }
                usernameBox.Text = allUsers[index].user_name;
            }
            else if (userID == "")
            {
                selectUser.ShowDialog();
                if (selectUser.DialogResult == DialogResult.OK)
                {
                    index = selectUser.UserListIndex;
                    usernameBox.Text = allUsers[index].user_name;
                }
            }
            else
            {
                for (int i = 0; i < allUsers.Count; i++)
                {

                }
            }
            List<int> loadedStartTimes = new List<int>() {
                        allUsers[index].mon_start, allUsers[index].tue_start, allUsers[index].wed_start,
                        allUsers[index].thr_start, allUsers[index].fri_start, allUsers[index].sat_start, allUsers[index].sun_start };

            List<int> loadedEndTimes = new List<int>() {
                        allUsers[index].mon_end, allUsers[index].tue_end, allUsers[index].wed_end,
                        allUsers[index].thr_end, allUsers[index].fri_end, allUsers[index].sat_end, allUsers[index].sun_end };
            for (int i = 0; i < allUsers.Count(); i++)
            {
                if (loadedStartTimes[i] > -1)
                {
                    startTimes[i]
                }
            }
        }

        void formDisposed(object sender, EventArgs e)
        {
            setTime = new setTimeForm(SetTimeFromForm);
            setTime.Disposed += formDisposed;
        }

        void refreshBoxes()
        {
            for (int i = 0; i < 7; i++)
            {
                if (startTimes[i].Equals(endTimes[i]))
                {
                    startBoxes[i].Text = "Not Set";
                    endBoxes[i].Text = "Not Set";
                }
                else
                {
                    if (rb24Hr.Checked)
                    {
                        startBoxes[i].Text = string.Format("{0:HH:mm}", startTimes[i]);
                        endBoxes[i].Text = string.Format("{0:HH:mm}", endTimes[i]);
                    }
                    else
                    {
                        startBoxes[i].Text = string.Format("{0:hh:mm tt}", startTimes[i]);
                        endBoxes[i].Text = string.Format("{0:hh:mm tt}", endTimes[i]);
                    }
                }
            }
        }

        void SetTimeFromForm(setTimeForm.SetTimeReturnObj obj)
        {
            changesMade = true;
            for (int i = 0; i < 7; i++)
            {
                if (obj.SetDays[i])
                {
                    startTimes[i] = obj.StartTime;
                    endTimes[i] = obj.EndTime;
                    if (obj.StartTime.Equals(obj.EndTime))
                    {
                        startBoxes[i].Text = "Not Set";
                        endBoxes[i].Text = "Not Set";
                    }
                    else
                    {
                        if (rb24Hr.Checked)
                        {
                            startBoxes[i].Text = string.Format("{0:HH:mm}", startTimes[i]);
                            endBoxes[i].Text = string.Format("{0:HH:mm}", endTimes[i]);
                        }
                        else
                        {
                            startBoxes[i].Text = string.Format("{0:hh:mm tt}", startTimes[i]);
                            endBoxes[i].Text = string.Format("{0:hh:mm tt}", endTimes[i]);
                        }
                    }
                }
            }
        }

        private void btnEditTimes_Click(object sender, EventArgs e)
        {
            setTime.Show();
        }

        private void rbHour_CheckedChanged(object sender, EventArgs e)
        {
            refreshBoxes();
        }

        void timeBox_Click(object sender, EventArgs e)
        {
            //btnEditTimes.Focus();
            TextBox senderBox = (TextBox)sender;
            int dayID = int.Parse((string)senderBox.Tag);

            if (!setTime.Visible)
            {
                setTime.SetTimesAndDay(startTimes[dayID], endTimes[dayID], dayID);
                setTime.Show();
                setTime.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {

        }
    }
}
