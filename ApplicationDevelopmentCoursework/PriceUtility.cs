using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApplicationDevelopmentCoursework
{
    class PriceUtility
    {
        public static string _filepath = "price.txt";

        public static string WriteToText(string data)
        {
            if (File.Exists(_filepath))
            {
                using (File.Create(_filepath)) ;
            }

            using (StreamWriter outputfile = new StreamWriter(_filepath))
            {
                outputfile.WriteLine(data);
            }
            return "success";
        }
        public static string ReadFromFile()
        {
            if (File.Exists(_filepath))
            {
                string data = File.ReadAllText(_filepath);
                return data;
            }
            return "file does not exist";
        }
    }
}
