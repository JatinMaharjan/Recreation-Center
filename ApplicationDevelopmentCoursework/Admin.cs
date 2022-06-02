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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            AdminGrid();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || One_Five.Text == "" || Five_Ten.Text == "" || Ten_Plus.Text == "" || Weekends.Text == "" || Holidays.Text == "")
            {
                MessageBox.Show("Fields can't be left blank.");
            }
            else
            {
                int FirstChild = int.Parse(textBox1.Text);
                int SecondChild = int.Parse(textBox2.Text);
                int ThirdChild = int.Parse(textBox3.Text);
                int FirstAdult = int.Parse(textBox4.Text);
                int SecondAdult = int.Parse(textBox5.Text);
                int ThirdAdult = int.Parse(textBox6.Text);
                int FirstOld = int.Parse(textBox7.Text);
                int SecondOld = int.Parse(textBox8.Text);
                int ThirdOld = int.Parse(textBox9.Text);
                int FirstGroup = int.Parse(One_Five.Text);
                int SecondGroup = int.Parse(Five_Ten.Text);
                int ThirdGroup = int.Parse(Ten_Plus.Text);
                int Week = int.Parse(Weekends.Text);
                int Hld = int.Parse(Holidays.Text);

                AdminPrice price;
                price = new AdminPrice();
                price.ChildFirst = FirstChild;
                price.ChildSecond = SecondChild;
                price.ChildThird = ThirdChild;
                price.AdultFirst = FirstAdult;
                price.AdultSecond = SecondAdult;
                price.AdultThird = ThirdAdult;
                price.OldFirst = FirstOld;
                price.OldSecond = SecondOld;
                price.OldThird = ThirdOld;
                price.GroupFirst = FirstGroup;
                price.GroupSecond = SecondGroup;
                price.GroupThird = ThirdGroup;
                price.Weekend = Week;
                price.Holiday = Hld;


                price.runPrice();
                List<AdminPrice> lsPrice = new List<AdminPrice>();
                string data = PriceUtility.ReadFromFile();
                if (data != null && data != "")
                {
                    lsPrice = JsonConvert.DeserializeObject<List<AdminPrice>>(data);
                }
                lsPrice.Add(price);

                string str = JsonConvert.SerializeObject(lsPrice);
                PriceUtility.WriteToText(str);
                AdminGrid();
                MessageBox.Show("The Price is Recorded Successfully.");
                Clear();
            }
        }
        public void AdminGrid()
        {
            string datas = PriceUtility.ReadFromFile();
            List<AdminPrice> PriceList = new List<AdminPrice>();
            PriceList = JsonConvert.DeserializeObject<List<AdminPrice>>(datas);
            DataGrid.DataSource = PriceList;
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            One_Five.Text = "";
            Five_Ten.Text = "";
            Ten_Plus.Text = "";
            Weekends.Text = "";
            Holidays.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox8.Text = textBox8.Text.Remove(textBox8.Text.Length - 1);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox9.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                textBox9.Text = textBox9.Text.Remove(textBox9.Text.Length - 1);
            }
        }

        private void One_Five_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(One_Five.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                One_Five.Text = One_Five.Text.Remove(One_Five.Text.Length - 1);
            }
        }

        private void Five_Ten_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Five_Ten.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Five_Ten.Text = Five_Ten.Text.Remove(Five_Ten.Text.Length - 1);
            }
        }

        private void Ten_Plus_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Ten_Plus.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Ten_Plus.Text = Ten_Plus.Text.Remove(Ten_Plus.Text.Length - 1);
            }
        }

        private void Weekends_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Weekends.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Weekends.Text = Weekends.Text.Remove(Weekends.Text.Length - 1);
            }
        }

        private void Holidays_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Holidays.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Numbers Only", "Invalid Value.", MessageBoxButtons.OK);
                Holidays.Text = Holidays.Text.Remove(Holidays.Text.Length - 1);
            }
        }
    }
}
