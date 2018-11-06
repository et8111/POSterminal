using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSterminal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BounceHouse> houses = new List<BounceHouse>();
            houses = BounceHouse.deSerialBounceHouse();

            GUI.MainSkeleton();
            GUI.MainFilling(houses);
            //Console.ReadLine();
            //houses = houses.OrderBy(a => a.Price).ToList();
            //GUI.MainFilling(houses);

            Console.WriteLine(houses.Max(a => a.Name.Length));
            Console.WriteLine(houses.Max(a => a.Category.Length));
            Console.WriteLine(houses.Max(a => a.Price.ToString().Length));
        }
    }
}
