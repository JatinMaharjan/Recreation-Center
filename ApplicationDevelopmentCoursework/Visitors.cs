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
    public partial class Visitors : Form
    {
        public Visitors()
        {
            InitializeComponent();
            AdminGrid();
        }

        private void Clear()
        {
            ID.Text = "";
            First_Name.Text = "";
            Last_Name.Text = "";
            Age.SelectedIndex = 0;
            Group.Checked = false;
            In_Time.Text = "";
            Out_Time.Text = "";
            Price.Text = "";
            Total_Price.Text = "";
        }


        private void Visitors_Load(object sender, EventArgs e)
        {

        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            int VisitorsID = int.Parse(ID.Text);
            string VisitorsFirstName = First_Name.Text;
            string VisitorsLastName = Last_Name.Text;
            string VisitorsAge = Age.SelectedItem.ToString();
            String VisitorsGroup;
            if (Group.Checked)
            {
                VisitorsGroup = "It is in a Group";
            }
            else
            {
                VisitorsGroup = "It is not in a Group";
            }
            DateTime VisitorsDate = dateTimePicker1.Value.Date;
            int VisitorsInTime = int.Parse(In_Time.Text);
            int VisitorsOutTime = int.Parse(Out_Time.Text);
            int VisitorsTotalPrice = int.Parse(Total_Price.Text);
            int VisitorsPrice = int.Parse(Price.Text);
            Customer vis = new Customer();
            vis.ID = VisitorsID;

            vis.FirstName = VisitorsFirstName;
            vis.LastName = VisitorsLastName;
            vis.Age = VisitorsAge;
            vis.Group = VisitorsGroup;
            vis.Date = VisitorsDate;
            vis.InTime = VisitorsInTime;
            vis.OutTime = VisitorsOutTime;
            vis.Price = VisitorsPrice;
            vis.TotalPrice = VisitorsTotalPrice;
            vis.RunCustomer();
            List<Customer> lstVisitors = new List<Customer>();
            string data = VisitorsUtility.ReadFromFile();
            if (data != null && data != "")
            {
                lstVisitors = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
            lstVisitors.Add(vis);
            string str = JsonConvert.SerializeObject(lstVisitors);
            VisitorsUtility.WriteToText(str);
            AdminGrid();
            MessageBox.Show("The Ticekt is Record Successfully.");
            Clear();

        }

        private void AdminGrid()
        {
            string datas = VisitorsUtility.ReadFromFile();
            List<Customer> Customer = new List<Customer>();
            Customer = JsonConvert.DeserializeObject<List<Customer>>(datas);
            dataGridView1.DataSource = Customer;
            TotaVisitors_Chart(Customer);
            TotalPriceOf_VisitorsChar(Customer);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string CustomersGroup;
            if (Group.Checked)
            {
                CustomersGroup = "It is in a Group";
            }
            else
            {
                CustomersGroup = "It is not in a Group";
            }
            Customer V = new Customer();
            V.ID = int.Parse(ID.Text);
            V.FirstName = First_Name.Text;
            V.LastName = Last_Name.Text;
            V.Age = Age.SelectedItem.ToString();
            V.Group = CustomersGroup;
            V.InTime = int.Parse(In_Time.Text);
            V.OutTime = int.Parse(Out_Time.Text);
            V.Date = dateTimePicker1.Value.Date;
            V.Price = int.Parse(Price.Text);
            V.TotalPrice = int.Parse(Total_Price.Text);
            V.Edit(V);
            AdminGrid();
            MessageBox.Show("Date is Successfully Updated.");
            Clear();
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            Login logout = new Login();
            logout.Show();
            this.Hide();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filter F = new Filter();
            F.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Customer CustomerObj = new Customer();
            if (e.ColumnIndex == 0)
            {
                string IDValue = dataGridView1[2, e.RowIndex].Value.ToString();
                string InTimeValue = dataGridView1[7, e.RowIndex].Value.ToString();
                string OutTimeValue = dataGridView1[8, e.RowIndex].Value.ToString();
                string PriceValue = dataGridView1[10, e.RowIndex].Value.ToString();
                string TotalPriceValue = dataGridView1[11, e.RowIndex].Value.ToString();
                int id = 0;
                int InTime = 0;
                int OutTime = 0;
                float price = 0;
                float Total_price = 0;
                if (String.IsNullOrEmpty(IDValue))
                {
                    MessageBox.Show("The Data is Invalid");
                }
                else
                {
                    id = int.Parse(IDValue);
                    InTime = int.Parse(InTimeValue);
                    OutTime = int.Parse(OutTimeValue);
                    price = float.Parse(PriceValue);
                    Customer v = CustomerObj.List().Where(x => x.ID == id).FirstOrDefault();
                    ID.Text = v.ID.ToString();
                    First_Name.Text = v.FirstName;
                    Last_Name.Text = v.LastName;
                    Age.SelectedItem = v.Age;
                    In_Time.Text = v.InTime.ToString();
                    Out_Time.Text = v.OutTime.ToString();
                    Price.Text = v.Price.ToString();
                    Total_Price.Text = v.TotalPrice.ToString();
                }
            }
            else if (e.ColumnIndex == 1)
            {
                string Message = "Do You Want To Remove this Record?";
                string Title = "Record Removed Conformed.";
                MessageBoxButtons Buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(Message, Title, Buttons);
                if (result == DialogResult.OK)
                {
                    string Value = dataGridView1[2, e.RowIndex].Value.ToString();
                    CustomerObj.Delete(int.Parse(Value));
                    AdminGrid();
                }
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            
        }
        private void TotaVisitors_Chart(List<Customer>CustomersList)
        {
            if (CustomersList != null)
            {
                var CustomersResult = CustomersList
                    .GroupBy(X => X.Date)
                    .Select(Y => new
                    {
                        date = Y.First().Date,
                        numberOfCustomers = Y.Count().ToString()
                    }
                    ).ToList();
                DataTable DT = VisitorsUtility.ConvertToDataTable(CustomersResult);
                chart2.DataSource = DT;
                chart2.Name = "Date";
                chart2.Series["Series1"].XValueMember = "Date";
                chart2.Series["Series1"].YValueMembers = "numberOfCustomers";
                this.chart2.Titles.Remove(this.chart2.Titles.FirstOrDefault());
                this.chart2.Titles.Add("Total Customers Weekly Chart");
                chart2.Series["Series1"].IsValueShownAsLabel = true;
            }
        }

        private void TotalPriceOf_VisitorsChar(List<Customer> CustomersList)
        {
            if (CustomersList != null)
            {
                var CustomerResult = CustomersList
                    .GroupBy(X => X.Date)
                    .Select(Y => new
                    {
                        date = Y.First().Date,
                        Total_Price = Y.Sum(Z => Z.TotalPrice)
                    }
                    ).ToList();
                DataTable DT = VisitorsUtility.ConvertToDataTable(CustomerResult);
                chart1.DataSource = DT;
                chart1.Name = "Date";
                chart1.Series["Series1"].XValueMember = "Date";
                chart1.Series["Series1"].YValueMembers = "Total_Price";
                this.chart1.Titles.Remove(this.chart1.Titles.FirstOrDefault());
                this.chart1.Titles.Add("Total Price of Weekly in a Chart");
                chart1.Series["Series1"].IsValueShownAsLabel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ticket F = new Ticket();
            F.Show();
            this.Hide();
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ID.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                ID.Text = ID.Text.Remove(ID.Text.Length - 1);
            }
        }

        private void First_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Last_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void In_Time_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(In_Time.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                In_Time.Text = In_Time.Text.Remove(In_Time.Text.Length - 1);
            }
        }

        private void Out_Time_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Out_Time.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Out_Time.Text = Out_Time.Text.Remove(Out_Time.Text.Length - 1);
            }
        }

        private void Price_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Price.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Price.Text = Price.Text.Remove(Price.Text.Length - 1);
            }
        }

        private void Total_Price_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Total_Price.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Total_Price.Text = Total_Price.Text.Remove(Total_Price.Text.Length - 1);
            }
        }
    }
}
