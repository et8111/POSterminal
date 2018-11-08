using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace POSterminal
{
    public class BounceHouse
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Category { get; set; }
        public List<string> Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public BounceHouse(string name, string second, string cata, string des, double price, int count)
        {
            Name = name;
            SecondName = second;
            Category = cata;
            Description = new List<string>();
            Description.Add(des);
            Price = price;
            Count = count;
        }

        public static void MATH(List<BounceHouse> houses)
        {
            GUI.Quantity = houses.Select(a => a.Count).Sum();
            GUI.Total = houses.Where(b => b.Count > 0).Select(a => (a.Price * 1.06) * a.Count).Sum();
        }

        public static List<BounceHouse> deSerialBounceHouse()
        {
            string fileName = @"C:\Users\jowiesny\source\repos\Midterm\POSterminal\POSterminal\bin\Debug\DATA.txt";
            List<BounceHouse> players = new List<BounceHouse>();
            JsonSerializer js = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (JsonReader jreader = new JsonTextReader(reader))
            {
                players = js.Deserialize<List<BounceHouse>>(jreader);
            }
            return players;
        }
        //strictly for serializing the content to a .txt file not neccessary to run

        //string fileName = @"C:\Users\jowiesny\source\repos\Midterm\POSterminal\POSterminal\bin\Debug\DATA.txt";
        //public static void Serialize(List<BounceHouse> player)
        //{
        //    string fileName = @"C:\Users\jowiesny\source\repos\Midterm\POSterminal\POSterminal\bin\Debug\DATA.txt";
        //    JsonSerializer s = new JsonSerializer();
        //    using (StreamWriter sw = new StreamWriter(fileName))
        //    using (JsonWriter w = new JsonTextWriter(sw))
        //    {
        //        s.Serialize(w, player);
        //    }
        //}
    }
}