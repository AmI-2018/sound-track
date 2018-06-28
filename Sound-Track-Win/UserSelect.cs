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
using System.Net.Http;

namespace Sound_Track_Win
{
    public partial class UserSelect : Form
    {
        public int UserListIndex { get; protected set; }
        public bool UsersAdded { get; protected set; } = false;
        public List<UserResource> Users;
        SoundTrackRestHandler stRest;

        public UserSelect(SoundTrackRestHandler stHandler, List<UserResource> users)
        {
            InitializeComponent();

            stRest = stHandler;
            Users = users;

            for (int i = 0; i < Users.Count; i++)
            {
                listBox1.Items.Insert(i, new ListViewItem(Users[i].user_name));
            }
        }

        public int CreateNewUser()
        {
            UserResource newUser = new UserResource();
            NewUserName newName = new NewUserName();

            newName.ShowDialog();
            if (newName.DialogResult != DialogResult.OK) { return; }

            string name = newName.UserName;
            string id;

            byte[] randomID = new byte[10];
            bool repeatedID = true;
            Random rnd = new Random();

            while (repeatedID)
            {
                repeatedID = false;

                for (int i = 0; i < randomID.Length; i++)
                {
                    randomID[i] = (byte)rnd.Next(48, 109);
                    if (randomID[i] > 57) { randomID[i] += 7; }
                    if (randomID[i] > 90) { randomID[i] += 6; }
                }

                id = Encoding.UTF8.GetString(randomID);

                for (int i = 0; i < Users.Count; i++)
                {
                    if (Users[i].user_id == id)
                    {
                        repeatedID = true;
                        break;
                    }
                }
            }
            id = Encoding.UTF8.GetString(randomID);

            newUser.user_name = name;
            newUser.user_id = id;

            try
            {
                HttpResponseMessage response = stRest.CreateUser(newUser);
                if (response.IsSuccessStatusCode)
                {
                    Task<MessageResource> result = response.Content.ReadAsAsync<MessageResource>();
                    result.Wait();
                    if (result.Result.message == "POST Successful")
                    {
                        Users.Add(newUser);
                        UsersAdded = true;
                        listBox1.Items.Insert(Users.Count - 1, new ListViewItem(name));
                        listBox1.SelectedIndex = Users.Count - 1;
                        return Users.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create new user:\n" + ex.ToString(), "ERROR");
                return -1;
            }
            return -1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            UserListIndex = listBox1.SelectedIndex;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewUser();
        }
    }
}
