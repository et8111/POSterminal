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
            GUI.Menu = GUI.MenuMainLoadOut(GUI.Menu);
            GUI.MainSkeleton();
            houses = houses.OrderBy(a => a.Name).ToList();
            GUI.MainFilling(houses, GUI.Menu);


            while (true)
            {
                int temp = GUI.Selector(GUI.left, GUI.top, GUI.max, GUI.Menu, GUI.index);
                if (temp == 2)
                    GUI.ChangeSort(houses);
            }
        }
    }
}
