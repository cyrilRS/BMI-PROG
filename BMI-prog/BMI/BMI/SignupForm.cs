using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using static System.Windows.Forms.DataFormats;

namespace BMI
{
    public partial class SignupForm : Form
    {
        public string file_name = "user.json";
        List<dynamic> userData = new List<dynamic>();

        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            var credentials = new
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
            };

            userData.Add(credentials);
            var json = JsonConvert.SerializeObject(userData);
            File.WriteAllText(file_name, json);

            MessageBox.Show("Login successful!");
            this.Hide();
            MainForm form3 = new MainForm();
            form3.ShowDialog();
            this.Close();


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
            ClearUserDataFile();
        }
        private void ClearDataGridView()
        {
            dgvData.DataSource = null;

            dgvData.Rows.Clear();
        }

        private void ClearUserDataFile()
        {
            string jsonFilePath = "users.json";
            if (File.Exists(jsonFilePath))
            {
                File.Delete(jsonFilePath);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var jsons = File.ReadAllText(file_name);
            userData = JsonConvert.DeserializeObject<List<dynamic>>(jsons);

            dgvData.DataSource = userData;
        }

        private void btnlgn_Click(object sender, EventArgs e)
        {
            var jsons = File.ReadAllText(file_name);
            userData = JsonConvert.DeserializeObject<List<dynamic>>(jsons);

            foreach (var credentials in userData)
            {
                string username = credentials["username"];
                string password = credentials["password"];

                if (txtUsername.Text == username && txtPassword.Text == password)
                {
                    this.Hide();
                    Form form1 = new MainForm();
                    form1.Show();
                    return;
                }
                else
                {

                }

            }
            MessageBox.Show("Invalid Username or Password");
        }
    }
}
