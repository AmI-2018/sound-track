using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sound_Track_Win.RestAPI;

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
        public bool changesMade { get; protected set; } = false;
        public string UserID { get; protected set; }
        public string UserName { get; protected set; }

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

            UserID = userID;


        }

        void formDisposed(object sender, EventArgs e)
        {
            setTime = new setTimeForm(SetTimeFromForm);
            setTime.Disposed += formDisposed;
            btnEditTimes.Focus();
        }

        void loadUserData()
        {
            UserID = allUsers[index].user_id;


            UserName = allUsers[index].user_name;
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
                    startTimes[i] = startTimes[i].AddMinutes(loadedStartTimes[i]);
                    endTimes[i] = endTimes[i].AddMinutes(loadedEndTimes[i]);
                }
            }
            refreshBoxes();
        }

        void refreshBoxes()
        {
            for (int i = 0; i < 7; i++)
            {
                if (startTimes[i].Equals(endTimes[i]))
                {
                    startBoxes[i].Text = "-";
                    endBoxes[i].Text = "-";
                }
                else
                {
                    if (rb24Hr.Checked)
                    {
                        startBoxes[i].Text = string.Format("{0:H:mm}", startTimes[i]);
                        endBoxes[i].Text = string.Format("{0:H:mm}", endTimes[i]);
                    }
                    else
                    {
                        startBoxes[i].Text = string.Format("{0:h:mm tt}", startTimes[i]);
                        endBoxes[i].Text = string.Format("{0:h:mm tt}", endTimes[i]);
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
                        startBoxes[i].Text = "-";
                        endBoxes[i].Text = "-";
                    }
                    else
                    {
                        if (rb24Hr.Checked)
                        {
                            startBoxes[i].Text = string.Format("{0:H:mm}", startTimes[i]);
                            endBoxes[i].Text = string.Format("{0:H:mm}", endTimes[i]);
                        }
                        else
                        {
                            startBoxes[i].Text = string.Format("{0:h:mm tt}", startTimes[i]);
                            endBoxes[i].Text = string.Format("{0:h:mm tt}", endTimes[i]);
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
            if (changesMade)
            {
                if (MessageBox.Show("Changes have been made to this user.\nYou will lose changes if you continue.",
                    "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel) { return; }
            }
            UserSelect selectUser = new UserSelect(stRest, allUsers);
            selectUser.ShowDialog();
            index = selectUser.UserListIndex;
            usernameBox.Text = allUsers[index].user_name;
            loadUserData();
            changesMade = false;
        }

        private void userSettingsForm_Load(object sender, EventArgs e)
        {
            UserSelect selectUser = new UserSelect(stRest, allUsers);

            if (allUsers.Count > 0 && UserID != "")
            {
                for (int i = 0; i < allUsers.Count; i++)
                {
                    if (allUsers[i].user_id == UserID)
                    {
                        index = i;
                        break;
                    }
                }
                UserID = "";
            }

            if (allUsers.Count == 0)
            {
                index = selectUser.CreateNewUser();
                if (index == -1) { this.Close(); return; }
                usernameBox.Text = allUsers[index].user_name;
            }
            else if (UserID == "")
            {
                selectUser.ShowDialog();
                if (selectUser.DialogResult == DialogResult.OK)
                {
                    index = selectUser.UserListIndex;
                    usernameBox.Text = allUsers[index].user_name;
                }
                else { Close(); }
            }

            loadUserData();
        }

        private void usernameBox_Enter(object sender, EventArgs e)
        {
            btnEditUser.Focus();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            UserNameForm renameExisting = new UserNameForm("Rename");
            renameExisting.ShowDialog();
            if (renameExisting.DialogResult == DialogResult.OK)
            {
                changesMade = true;
                UserName = renameExisting.UserName;
                usernameBox.Text = UserName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (changesMade)
            {
                UserResource updateUser = new UserResource();
                updateUser.user_id = UserID;
                updateUser.user_name = UserName;
                List<int> userStartTimes = new List<int>();

                List<int> userEndTimes = new List<int>();
                for (int i = 0; i < 7; i++)
                {
                    if (startTimes[i] != endTimes[i])
                    {
                        TimeSpan holdStartTime = TimeSpan.FromTicks(startTimes[i].Ticks);
                        TimeSpan holdEndTime = TimeSpan.FromTicks(endTimes[i].Ticks);
                        userStartTimes.Add((int)holdStartTime.TotalMinutes);
                        userEndTimes.Add((int)holdEndTime.TotalMinutes);
                    }
                    else
                    {
                        userStartTimes.Add(-1);
                        userEndTimes.Add(-1);
                    }
                }

                updateUser.mon_start = userStartTimes[0]; updateUser.mon_end = userEndTimes[0];
                updateUser.tue_start = userStartTimes[1]; updateUser.tue_end = userEndTimes[1];
                updateUser.wed_start = userStartTimes[2]; updateUser.wed_end = userEndTimes[2];
                updateUser.thr_start = userStartTimes[3]; updateUser.thr_end = userEndTimes[3];
                updateUser.fri_start = userStartTimes[4]; updateUser.fri_end = userEndTimes[4];
                updateUser.sat_start = userStartTimes[5]; updateUser.sat_end = userEndTimes[5];
                updateUser.sun_start = userStartTimes[6]; updateUser.sun_end = userEndTimes[6];

                stRest.UpdateUserInFull(updateUser);
            }
            Close();
        }
    }
}
