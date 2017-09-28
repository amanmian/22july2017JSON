using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Web;

namespace _22july2017.cs
{
    class details
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string AddressLine { get; set; }
        public long Home { get; set; }
        public long Mobile { get; set; }
    }
    class Program
    {
        string json = @"C:\Users\Aman Mian\Documents\Visual Studio 2015\Projects\22july2017.cs\22july2017.cs\bin\Debug\22july2017.json";

        static void Main(string[] args)
        {
            var x = ProcessFile(@"22july2017.json");

            var query = x.OrderBy(ca => ca.ID)
                .ThenBy(cs => cs.Email);
            foreach (var y in query.Take(10))
            {
                Console.WriteLine($"{y.ID}: {y.Email}");
            }

        }

        private static List<json> ProcessFile(string json)
        {
            StreamReader sr = new StreamReader(json);
            return File.ReadAllLines(json)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(s => s.Split(new[] { ',' }))
                 .Select(a => new json
                 {
                     ID = Convert.ToInt32(a[0]),
                     Name = a[1],
                     Email = a[2],
                     Age = (a[3]),//Convert.ToInt64
                     AddressLine = (a[4]),
                     Home = Convert.ToInt64(a[5]),
                     Mobile = Convert.ToInt64(a[6]),
                 })
                  .ToList();                                           // return combined.ToList();
        }
    }
}

