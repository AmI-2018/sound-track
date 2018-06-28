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
    public partial class setTimeForm : Form
    {
        public class SetTimeReturnObj
        {
            public DateTime StartTime { get; }
            public DateTime EndTime { get; }
            public bool[] SetDays { get; } = new bool[7]; //Monday is 0

            public SetTimeReturnObj(DateTime startTime, DateTime endTime, bool[] setDays)
            {
                StartTime = startTime;
                EndTime = endTime;
                SetDays = setDays;
            }
            public SetTimeReturnObj(DateTime startTime, DateTime endTime, bool setMonday, bool setTuesday, 
                bool setWednesday, bool setThursday, bool setFriday, bool setSaturday, bool setSunday)
            {
                StartTime = startTime;
                EndTime = endTime;
                SetDays[0] = setMonday;
                SetDays[1] = setTuesday;
                SetDays[2] = setWednesday;
                SetDays[3] = setThursday;
                SetDays[4] = setFriday;
                SetDays[5] = setSaturday;
                SetDays[6] = setSaturday;
            }
        }

        Action<SetTimeReturnObj> onSet = null;

        DateTime StartTime;
        DateTime EndTime;

        List<CheckBox> cbDays;

        public setTimeForm(Action<SetTimeReturnObj> OnSetTimeEvent, DateTime startTime = new DateTime(), 
            DateTime endTime = new DateTime(), int dayIndex = -1)
        {
            InitializeComponent();

            StartTime = startTime.AddDays(1);
            EndTime = endTime.AddDays(1);

            cbDays = new List<CheckBox>();
            cbDays.Add(cbMon);
            cbDays.Add(cbTue);
            cbDays.Add(cbWed);
            cbDays.Add(cbThur);
            cbDays.Add(cbFri);
            cbDays.Add(cbSat);
            cbDays.Add(cbSun);

            if (dayIndex > -1) { cbDays[dayIndex].Checked = true; }

            onSet = OnSetTimeEvent;

            updateStartBox();
            updateEndBox();

            startBox.Enabled = false;
            endBox.Enabled = false;
            startBox.Enabled = true;
            endBox.Enabled = true;
        }

        public void SetTimesAndDay(DateTime startTime, DateTime endTime, int dayIndex = -1)
        {
            StartTime = startTime;
            EndTime = endTime;
            StartTime = startTime.AddDays(1);
            EndTime = endTime.AddDays(1);

            if (dayIndex > -1) { cbDays[dayIndex].Checked = true; }

            updateEndBox();
            updateStartBox();
        }

        void updateStartBox()
        {
            if (rb24Hr.Checked) { startBox.Text = string.Format("{0:H:mm}", StartTime); }
            else { startBox.Text = string.Format("{0:h:mm tt}", StartTime); }
        }

        void updateEndBox()
        {
            if (rb24Hr.Checked) { endBox.Text = string.Format("{0:H:mm}", EndTime); }
            else { endBox.Text = string.Format("{0:h:mm tt}", EndTime); }
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            Button btnSender;
            try
            {
               btnSender = (Button)sender;
            }
            catch
            {
                return;
            }

            string btnID = (string)btnSender.Tag;
            switch (btnID)
            {
                case "0": //Hour +
                    if (StartTime.Hour != 11) { StartTime = StartTime.AddHours(1); }
                    else { StartTime = StartTime.AddHours(-23); }
                    break;
                case "1": //Minute +
                    if (StartTime.Minute < 55) { StartTime = StartTime.AddMinutes(5); }
                    else { StartTime = StartTime.AddMinutes(-55); }
                    break;
                case "2":  //Hour -
                    if (StartTime.Hour != 12) { StartTime = StartTime.AddHours(-1); }
                    else { StartTime = StartTime.AddHours(23); }
                    break;
                case "3": //Minute -
                    if (StartTime.Minute > 0) { StartTime = StartTime.AddMinutes(-5); }
                    else { StartTime = StartTime.AddMinutes(55); }
                    break;
                default:
                    break;
            }
            updateStartBox();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Button btnSender;
            try
            {
                btnSender = (Button)sender;
            }
            catch
            {
                return;
            }

            string btnID = (string)btnSender.Tag;
            switch (btnID)
            {
                case "0": //Hour +
                    if (EndTime.Hour != 11) { EndTime = EndTime.AddHours(1); }
                    else { EndTime = EndTime.AddHours(-23); }
                    break;
                case "1": //Minute +
                    if (EndTime.Minute < 55) { EndTime = EndTime.AddMinutes(5); }
                    else { EndTime = EndTime.AddMinutes(-55); }
                    break;
                case "2":  //Hour -
                    if (EndTime.Hour != 12) { EndTime = EndTime.AddHours(-1); }
                    else { EndTime = EndTime.AddHours(23); }
                    break;
                case "3": //Minute -
                    if (EndTime.Minute > 0) { EndTime = EndTime.AddMinutes(-5); }
                    else { EndTime = EndTime.AddMinutes(55); }
                    break;
                default:
                    break;
            }
            updateEndBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool anyDayChecked = false;
            for (int i = 0; i < 7; i++)
            {
                if (cbDays[i].Checked)
                {
                    anyDayChecked = true;
                    break;
                }
            }
            if (!anyDayChecked)
            {
                MessageBox.Show("Must select a day to clear.", "No Day Selected", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("You are about to clear the selected days.\nAre you sure you want to proceed?",
                "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool[] days = new bool[7];
                for (int i = 0; i < 7; i++)
                {
                    days[i] = cbDays[i].Checked;
                }
                SetTimeReturnObj data = new SetTimeReturnObj(new DateTime(), new DateTime(), days);
                onSet(data);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (StartTime.CompareTo(EndTime) > -1)
            {
                MessageBox.Show("End Time must be later than Start Time.\n" +
                    "Note: Time after midnight is considered later than before midnight",
                    "Invalid Times", MessageBoxButtons.OK);
                return;
            }

            bool anyDayChecked = false;
            for (int i = 0; i < 7; i++)
            {
                if (cbDays[i].Checked)
                {
                    anyDayChecked = true;
                    break;
                }
            }

            if (!anyDayChecked)
            {
                MessageBox.Show("Must select a day to set.", "No Day Selected", MessageBoxButtons.OK);
                return;
            }

            if (onSet != null)
            {
                bool[] days = new bool[7];
                for (int i = 0; i < 7; i++)
                {
                    days[i] = cbDays[i].Checked;
                }

                SetTimeReturnObj data = new SetTimeReturnObj(StartTime, EndTime, days);
                onSet(data);
            }
        }

        private void rbHourFormat_Click(object sender, EventArgs e)
        {
            if (rb24Hr.Checked)
            {
                startBox.TextAlign = HorizontalAlignment.Center;
                endBox.TextAlign = HorizontalAlignment.Center;
            }
            else
            {
                startBox.TextAlign = HorizontalAlignment.Right;
                endBox.TextAlign = HorizontalAlignment.Right;

            }
            updateStartBox();
            updateEndBox();
        }

        private void TextBox_Focused(object sender, EventArgs e)
        {
            startBox.Enabled = false;
            endBox.Enabled = false;
            startBox.Enabled = true;
            endBox.Enabled = true;
        }
    }
}
