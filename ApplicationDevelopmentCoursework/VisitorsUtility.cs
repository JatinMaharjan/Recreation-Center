using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Data;

namespace ApplicationDevelopmentCoursework
{
    class VisitorsUtility
    {
        public static string _filepath = "Visitor.txt";

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

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            if (data != null)
            {
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
            }
            return table;
        }

    }
}
