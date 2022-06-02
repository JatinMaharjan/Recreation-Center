using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApplicationDevelopmentCoursework
{
    class AdminPrice
    {
        public int ChildFirst { get; set; }
        public int ChildSecond { get; set; }
        public int ChildThird { get; set; }
        public int AdultFirst { get; set; }
        public int AdultSecond { get; set; }
        public int AdultThird { get; set; }
        public int OldFirst { get; set; }
        public int OldSecond { get; set; }
        public int OldThird { get; set; }
        public float GroupFirst { get; set; }
        public float GroupSecond { get; set; }
        public float GroupThird { get; set; }
        public float Weekend { get; set; }
        public float Holiday { get; set; }


        public void runPrice()
        {
            Console.WriteLine(ChildFirst);
            Console.WriteLine(ChildSecond);
            Console.WriteLine(ChildThird);
            Console.WriteLine(AdultFirst);
            Console.WriteLine(AdultSecond);
            Console.WriteLine(AdultThird);
            Console.WriteLine(OldFirst);
            Console.WriteLine(OldSecond);
            Console.WriteLine(OldThird);
            Console.WriteLine(Weekend);
            Console.WriteLine(Holiday);
        }

        public List<AdminPrice> List()
        {
            string d = PriceUtility.ReadFromFile();
            if (d != null)
            {
                List<AdminPrice> X = JsonConvert.DeserializeObject<List<AdminPrice>>(d);
                return X;
            }
            return null;
        }
    }
}
