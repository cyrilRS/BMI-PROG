using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BMI.Properties;
using Newtonsoft.Json;


namespace BMI
{
    public partial class MainForm : Form
    {
        public string file_name = "user.json";
        List<dynamic> userData = new List<dynamic>();

        double calculateBMI(double height, double weight)
        {
            double bmi = weight / (height * height);
            bmi = Math.Round(bmi, 2);
            return bmi;
        }
        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dgvdeyta.Columns.Add("Name", "Name");
            dgvdeyta.Columns.Add("Height", "Height");
            dgvdeyta.Columns.Add("Weight", "Weight");
            dgvdeyta.Columns.Add("BMI", "BMI");
            dgvdeyta.Columns.Add("Remarks", "Remarks");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                double height = double.Parse(txtHeight.Text);
                double weight = double.Parse(txtWeight.Text);
                double bmi = calculateBMI(height, weight);
                string remarks = GetRemarks(bmi);

                lblBMI.Text = bmi.ToString();

                // Add data to DataGridView
                dgvdeyta.Rows.Add(name, height + " m", weight + " kg", bmi, remarks);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Height or Weight");
            }

        }
        private string GetRemarks(double bmi)
        {
            if (bmi < 18.5)
            {
                lblRemarks.Text = "Underweight";
                pbxBMI.Image = Resources.Underweight;
                return "Underweight";
            }
            else if (bmi >= 18.5 && bmi <= 24.9)
            {
                lblRemarks.Text = "Normal";
                pbxBMI.Image = Resources.normal;
                return "Normal";
            }
            else if (bmi >= 25 && bmi <= 29.5)
            {
                lblRemarks.Text = "Overweight";
                pbxBMI.Image = Resources.overweight;
                return "Overweight";
            }
            else
            {
                lblRemarks.Text = "Obese";
                pbxBMI.Image = Resources.obese;
                return "Obese";
            }
        }
        
    }
}
