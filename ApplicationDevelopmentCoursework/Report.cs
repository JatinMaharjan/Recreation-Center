using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ApplicationDevelopmentCoursework
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            ReportGrid();
        }

        private void ReportGrid()
        {
            string str = VisitorsUtility.ReadFromFile();
            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = JsonConvert.DeserializeObject<List<Customer>>(str);
            try
            {
                var data = lstCustomer.Where(Z => Z.Date == (dateTimePicker1.Value.Date)).
                    GroupBy(Z => new { Z.Age, Z.Group }).Select(
                    y => new
                    {
                        date = dateTimePicker1.Value.Date,
                        Age = y.Key.Age,
                        Group = y.Key.Group,
                        Total_Visitors = y.Count()
                    }
                    ).OrderBy(Z => Z.Group).ToList();

                dataGridView1.DataSource = data;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 200;
            }
            catch (Exception e)
            {
                MessageBox.Show("The Data is Empty to Display.");
            }
        }
        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            ReportGrid();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visitors V = new Visitors();
            V.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
