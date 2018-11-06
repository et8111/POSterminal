using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSterminal
{
    class GUI
    {
        public static double Total { get; set; }
        public static int Quantity { get; set; }
        public List<string> Menu { get; set; }
        public static string Sorter { get; set; }

        public static void MainSkeleton()
        {
            char fill = (char)247;
            Console.WriteLine("                 ~Jump Around! - Jumbo Bounce House Emporium~");
            Console.CursorTop = 1;
            Console.WriteLine(fill.ToString().PadLeft(83, fill));
            for(int i = 0; i < 16; i++)
                Console.WriteLine($"{fill,-20}{fill,-62}{fill}");
            Console.WriteLine(fill.ToString().PadLeft(83, fill));
            for (int i = 0; i < 6; i++)
                Console.WriteLine($"{fill,-82}{fill}");
            Console.WriteLine(fill.ToString().PadLeft(83, fill));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("MENU:");
            Console.SetCursorPosition(2, 3);
            Console.Write("-".PadLeft(17, '-'));
            Console.SetCursorPosition(22, 2);
            Console.WriteLine($"{"#)",-3}{"ITEMS:", -30}{"CATEGORY:",-15}{"PRICE:",10}");
            Console.SetCursorPosition(22, 3);
            Console.Write("-".PadLeft(58, '-'));
            Console.SetCursorPosition(22,17);
            Console.Write($"{"QUANTITY: 99",-41}{"TOTAL: $99,999.99"}");
            Console.SetCursorPosition(0, 26);
        }
        public static void MainFilling(List<BounceHouse> list, List<string> menu)//MENU(1,4) | ListName(22,4) | listCate(50,4) | ListPrice(66,4) | Quantity(32,17) | Total(46,17)
        {
            Console.SetCursorPosition(2, 4);
            ;
            for (int i = 0; i < menu.Count; i++)
            {
                if (menu[i] == "SORT:")
                    Console.WriteLine(menu[i] + " " + Sorter);
                else
                    Console.WriteLine(menu[i]);
                Console.CursorLeft = 2;
            }

            Console.SetCursorPosition(22, 4);
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].Count+")",-3}{list[i].Name.PadRight(30, '.')}{list[i].Category.PadLeft(11,'.')}{list[i].Price.ToString("C2").PadLeft(14,' ')}");
                Console.CursorLeft = 22;
            }

            Console.SetCursorPosition(0, 26);
        }

        public static List<BounceHouse> ChangeSort(List<BounceHouse> houses)
        {
            switch (Sorter)
            {
                case "NAME    ":
                    Sorter = "CATEGORY";
                    return houses.OrderBy(a => a.Category).ToList();
                case "CATEGORY":
                    Sorter = "PRICE   ";
                    return houses.OrderBy(a => a.Price).ToList();
                case "PRICE   ":
                    Sorter = "COUNT   ";
                    return houses.OrderBy(a => a.Count).ToList();
                case "COUNT   ":
                    Sorter = "NAME    ";
                    return houses.OrderBy(a => a.Name).ToList();
            }
            return houses;
        }

        public static List<string> MenuMainLoadOut(List<string> Menu)
        {
            Menu.Clear();
            Menu.Add("ADD");
            Menu.Add("REMOVE");
            Menu.Add("SORT:");
            Menu.Add("CART");
            return Menu;
        }
        public static List<string> MenuCartLoadOut(List<string> Menu)
        {
            Menu.Clear();
            Menu.Add("ADD");
            Menu.Add("REMOVE");
            Menu.Add("SORT:");
            Menu.Add("CHECKOUT");
            return Menu;
        }
    }
}
