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
            GUI.Sorter = "NAME    ";
            List<BounceHouse> houses = new List<BounceHouse>();
            houses = BounceHouse.deSerialBounceHouse();
            GUI g = new GUI();
            g.Menu = new List<string>();
            g.Menu = GUI.MenuMainLoadOut(g.Menu);
            GUI.MainSkeleton();
            houses = houses.OrderBy(a => a.Name).ToList();

            while (true)
            {
                GUI.MainFilling(houses, g.Menu);
                houses = GUI.ChangeSort(houses);
                Console.ReadLine();
            }
        }
    }
}
