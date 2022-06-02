using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApplicationDevelopmentCoursework
{
    class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Group { get; set; }
        public int InTime { get; set; }
        public int OutTime { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

        public void RunCustomer()
        {
            Console.WriteLine(ID);
            Console.WriteLine(FirstName);
            Console.WriteLine(LastName);
            Console.WriteLine(Age);
            Console.WriteLine(Group);
            Console.WriteLine(InTime);
            Console.WriteLine(OutTime);
            Console.WriteLine(Date);
            Console.WriteLine(Price);
        }

        public List<Customer> List()
        {
            string d = VisitorsUtility.ReadFromFile();
            if (d != null)
            {
                List<Customer> lst = JsonConvert.DeserializeObject<List<Customer>>(d);
                return lst;
            }
            return null;
        }

        public void Edit(Customer v)
        {
            List<Customer> vis = List();
            Customer visitor = vis.Where(x => x.ID == v.ID).FirstOrDefault();
            vis.Remove(visitor);
            vis.Add(v);
            string data = JsonConvert.SerializeObject(vis, Formatting.None);
            VisitorsUtility.WriteToText(data);
        }

        public void Delete(int ID)
        {
            List<Customer> list = List();
            Customer v = list.Where(x => x.ID == ID).FirstOrDefault();
            list.Remove(v);
            string data = JsonConvert.SerializeObject(list, Formatting.None);
            VisitorsUtility.WriteToText(data);
        }

        public List<Customer> totalNumberofVisitor(List<Customer> list)
        {
            int ID;
            string FirstName;
            string LastName;
            string Age;
            string Group;
            int InTime;
            int OutTime;
            DateTime Date;
            int Price;
            int TotalPrice;

            if (list != null)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].ID.CompareTo(list[j].ID) > 0)
                        {
                            ID = list[i].ID;
                            list[i].ID = list[j].ID;
                            list[j].ID = ID;

                            FirstName = list[i].FirstName;
                            list[i].FirstName = list[j].FirstName;
                            list[j].FirstName = FirstName;

                            LastName = list[i].LastName;
                            list[i].LastName = list[j].LastName;
                            list[j].LastName = LastName;

                            Age = list[i].Age;
                            list[i].Age = list[j].Age;
                            list[j].Age = Age;

                            Group = list[i].Group;
                            list[i].Group = list[j].Group;
                            list[j].Group = Group;

                            InTime = list[i].InTime;
                            list[i].InTime = list[j].InTime;
                            list[j].InTime = InTime;

                            OutTime = list[i].OutTime;
                            list[i].OutTime = list[j].OutTime;
                            list[j].OutTime = OutTime;

                            Date = list[i].Date;
                            list[i].Date = list[j].Date;
                            list[j].Date = Date;

                            Price = list[i].Price;
                            list[i].Price = list[j].Price;
                            list[j].Price = Price;

                            TotalPrice = list[i].TotalPrice;
                            list[i].TotalPrice = list[j].TotalPrice;
                            list[j].TotalPrice = TotalPrice;
                        }
                    }
                }
                return list;
            }
            return null;
        }

        public List<Customer> totalEarningEachDay(List<Customer> list)
        {
            int ID;
            string FirstName;
            string LastName;
            string Age;
            string Group;
            int InTime;
            int OutTime;
            DateTime Date;
            int Price;
            int TotalPrice;

            if (list != null)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].Date.CompareTo(list[j].Date) > 0)
                        {
                            ID = list[i].ID;
                            list[i].ID = list[j].ID;
                            list[j].ID = ID;

                            FirstName = list[i].FirstName;
                            list[i].FirstName = list[j].FirstName;
                            list[j].FirstName = FirstName;

                            LastName = list[i].LastName;
                            list[i].LastName = list[j].LastName;
                            list[j].LastName = LastName;

                            Age = list[i].Age;
                            list[i].Age = list[j].Age;
                            list[j].Age = Age;

                            Group = list[i].Group;
                            list[i].Group = list[j].Group;
                            list[j].Group = Group;

                            InTime = list[i].InTime;
                            list[i].InTime = list[j].InTime;
                            list[j].InTime = InTime;

                            OutTime = list[i].OutTime;
                            list[i].OutTime = list[j].OutTime;
                            list[j].OutTime = OutTime;

                            Date = list[i].Date;
                            list[i].Date = list[j].Date;
                            list[j].Date = Date;

                            Price = list[i].Price;
                            list[i].Price = list[j].Price;
                            list[j].Price = Price;

                            TotalPrice = list[i].TotalPrice;
                            list[i].TotalPrice = list[j].TotalPrice;
                            list[j].TotalPrice = TotalPrice;
                        }
                    }
                }
                return list;
            }
            return null;
        }

        public void GenerateID(Customer visobj)
        {
            Random r = new Random();
            List<Customer> VisitorsList = List();
            visobj.ID = r.Next(1, 9999);
            string data = JsonConvert.SerializeObject(visobj, Formatting.None);
            VisitorsUtility.WriteToText(data);
        }
    }
}
