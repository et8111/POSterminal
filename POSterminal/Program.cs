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
            GUI.Sorter = "SORTER:NAME";
            List<BounceHouse> houses = new List<BounceHouse>();
            houses = BounceHouse.deSerialBounceHouse();
            GUI.Menu = GUI.MenuMainLoadOut(GUI.Menu);
            GUI.MainSkeleton();
            houses = houses.OrderBy(a => a.Name).ToList();
            GUI.MainFilling(houses, GUI.Menu);



            while (true)
            {
                int temp = GUI.Selector(GUI.left, GUI.top, GUI.Menu.Count-1, GUI.Menu, GUI.index);
                if (temp == 0)
                {
                    temp = GUI.Selector(GUI.left = 25, GUI.top = 4, houses.Count - 1, houses.Select(a => a.Name).ToList(), 0);
                    houses[temp].Count++;
                    GUI.MainFilling(houses, GUI.Menu);
                    GUI.left = 2; GUI.top = 4;GUI.index = 0;
                }
                if (temp == 1)
                {
                    temp = GUI.Selector(GUI.left = 25, GUI.top = 4, houses.Count - 1, houses.Select(a => a.Name).ToList(), 0);
                    houses[temp].Count = (houses[temp].Count>0)?houses[temp].Count-1:houses[temp].Count;
                    GUI.MainFilling(houses, GUI.Menu);
                    GUI.left = 2; GUI.top = 4; GUI.index = 0;
                }
                if (temp == 2)
                {
                    GUI.ChangeSort(ref houses);
                }
            }
        }
    }
}
