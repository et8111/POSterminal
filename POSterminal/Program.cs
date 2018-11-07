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
            program(houses, false);
        }

        public static void program(List<BounceHouse> houses, bool flag)
        {
            while (true)
            {
                GUI.MainFilling(houses, GUI.Menu);
                int temp = GUI.Selector(GUI.left, GUI.top, GUI.Menu.Count - 1, GUI.Menu, GUI.index, false, houses);
                if (temp == 0)
                {
                    if (flag)
                        return;
                    temp = GUI.Selector(GUI.left = 25, GUI.top = 4, houses.Count - 1, houses.Select(a => a.Name).ToList(), 0, true, houses);
                    houses[temp].Count++;
                    BounceHouse.MATH(houses.Where(a => a.Name == houses[temp].Name).ToList(), true);
                    GUI.MainFilling(houses, GUI.Menu);
                    GUI.left = 2; GUI.top = 4; GUI.index = 0;
                    continue;
                }
                if (temp == 1)
                {
                    temp = GUI.Selector(GUI.left = 25, GUI.top = 4, houses.Count - 1, houses.Select(a => a.Name).ToList(), 0, true, houses);
                    if (!flag)
                    {
                        BounceHouse.MATH(houses.Where(a => a.Name == houses[temp].Name).ToList(), false);
                        houses[temp].Count = (houses[temp].Count > 0) ? houses[temp].Count - 1 : houses[temp].Count;
                        GUI.MainFilling(houses, GUI.Menu);
                    }
                    GUI.left = 2; GUI.top = 4; GUI.index = 0;
                    continue;
                }
                if (temp == 2)
                {
                    GUI.ChangeSort(ref houses);
                    continue;
                }
                if (temp == 3)
                {
                    if (houses.Where(a => a.Count > 0).Count() > 0)
                    {
                        GUI.MenuCartLoadOut(GUI.Menu);
                        Console.SetCursorPosition(22, 4);
                        for (int i = 0; i < 12; i++)
                        {
                            Console.WriteLine($"{" ",-3}{" ".PadRight(30, '.')}{" ".PadLeft(11, '.')}{" ".PadLeft(14, ' ')}");
                            Console.CursorLeft = 22;
                        }
                        GUI.MainFilling(houses.Where(a => a.Count > 0).ToList(), GUI.Menu);
                        program(houses.Where(a => a.Count > 0).ToList(), true);
                        GUI.MenuMainLoadOut(GUI.Menu);
                    }
                    continue;
                }
            }
        }
    }
}
