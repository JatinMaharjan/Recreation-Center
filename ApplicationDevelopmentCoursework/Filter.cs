using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDevelopmentCoursework
{
    public partial class Filter : Form
    {
        public Filter()
        {
            InitializeComponent();
        }

        private void button2_Click(object    sender, EventArgs e)
        {
            Customer v = new Customer();
            List<Customer> CustomerList = v.List();
            List<Customer> list = v.totalEarningEachDay(CustomerList);
            DataTable DT = VisitorsUtility.ConvertToDataTable(list);
            dataGridView1.DataSource = DT;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime Date_Start = dateTimePicker1.Value.Date;
            DateTime Date_End = Date_Start.AddDays(7);
            Customer V = new Customer();
            List<Customer> CustomerList = V.List();
            try
            {
                var Data_Of_A_Week = CustomerList
                    .Where(Z => Z.Date >= Date_Start && Z.Date <= Date_End)
                    .GroupBy(T => T.Date)
                    .Select(N => new
                    {
                        Date = N.First().Date,
                        TotalVisitors = N.Count().ToString()
                    }
                    ).ToList();
                DataTable DT = VisitorsUtility.ConvertToDataTable(Data_Of_A_Week);
                dataGridView1.DataSource = DT;
                foreach (DataGridViewColumn C in dataGridView1.Columns)
                {
                    C.DefaultCellStyle.Font = new Font("Arial", 18F, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 200;
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visitors v = new Visitors();
            v.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
