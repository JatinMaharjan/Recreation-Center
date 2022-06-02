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
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Tic = VisitorsUtility.ReadFromFile();
            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = JsonConvert.DeserializeObject<List<Customer>>(Tic);
            try
            {
                var Data = lstCustomer.Where(X => X.ID == (int.Parse(ID.Text)))
                    .GroupBy(X => new
                    {
                        X.FirstName, X.LastName, X.Age, X.Group, X.InTime, X.OutTime, X.Price, X.TotalPrice, X.Date
                    }
                    ).Select(
                        Y => new
                        {
                            Id = int.Parse(ID.Text),
                            FristName = Y.Key.FirstName,
                            LastName = Y.Key.LastName,
                            Age = Y.Key.Age,
                            Group = Y.Key.Group,
                            InTime = Y.Key.InTime,
                            OutTime = Y.Key.OutTime,
                            Price = Y.Key.Price,
                            TotalPrice = Y.Key.TotalPrice,
                            Date = Y.Key.Date
                        }
                    ).ToList();
                dataGridView1.DataSource = Data;
            }
            catch (Exception)
            {
                MessageBox.Show("Tickets Not Found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visitors v = new Visitors();
            v.Show();
            this.Hide();
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ID.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only.", "Invalid Value.", MessageBoxButtons.OK);
                ID.Text = ID.Text.Remove(ID.Text.Length - 1);
            }
        }
    }
}
