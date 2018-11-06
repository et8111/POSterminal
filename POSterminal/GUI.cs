using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSterminal
{
    static class GUI
    {
        public static double Total { get; set; }
        public static int Quantity { get; set; }
        public static List<string> Menu { get; set; } = new List<string>();
        public static string Sorter { get; set; }
        public static int left { get; set; } = 2;
        public static int top { get; set; } = 4;
        public static int max { get; set; } = 3;
        public static int index { get; set; } = 0;

        public static void Adder(List<BounceHouse> houses)
        {

        }

        public static int Selector(int left, int top, int max, List<string> Menu, int index)
        {
            ConsoleColor current = Console.ForegroundColor;
            ConsoleColor yellow = ConsoleColor.Yellow;
            ConsoleColor back = Console.BackgroundColor;
            ConsoleKeyInfo k; 

            while (true)
                {
                Console.SetCursorPosition(left, top);
                Console.ForegroundColor = back;
                Console.BackgroundColor = yellow;
                Console.Write(Menu[index]);
                //Cursor.
                k = Console.ReadKey(true);
                Console.SetCursorPosition(left, top);
                if (k.Key == ConsoleKey.Enter)
                    break;
                else if ((k.Key == ConsoleKey.UpArrow && index != 0) || (k.Key == ConsoleKey.DownArrow && index != max))
                {
                    Console.ForegroundColor = current;
                    Console.BackgroundColor = back;
                    Console.Write(Menu[index]);
                    top = (k.Key == ConsoleKey.DownArrow) ? top + 1 : top - 1; ;
                    index = (k.Key == ConsoleKey.DownArrow)?index+1: index-1;
                }
            }
            Console.ForegroundColor = current;
            Console.BackgroundColor = back;
            GUI.left = left;
            GUI.top = top;
            GUI.index = index;
            GUI.max = max;
            return index;
        }

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
            Console.Write($"{"QUANTITY:  0",-41}{"TOTAL: $0.00"}");
            Console.SetCursorPosition(0, 26);
        }
        public static void MainFilling(List<BounceHouse> list, List<string> menu)//MENU(2,4) | ListName(25,4) | listCate(50,4) | ListPrice(66,4) | Quantity(32,17) | Total(46,17)
        {
            Console.SetCursorPosition(2, 4);
            Menu[2] = Sorter;
            for (int i = 0; i < menu.Count; i++)
            {
                Console.Write("                ");
                Console.CursorLeft = 2;
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

        public static void ChangeSort(ref List<BounceHouse> houses)
        {
            switch (Sorter)
            {
                case "SORTER:NAME":
                    Sorter = "SORTER:CATEGORY";
                    houses =  houses.OrderBy(a => a.Category).ToList();
                    break;
                case "SORTER:CATEGORY":
                    Sorter = "SORTER:PRICE";
                    houses =  houses.OrderBy(a => a.Price).ToList();
                    break;
                case "SORTER:PRICE":
                    Sorter = "SORTER:COUNT";
                    houses =  houses.OrderByDescending(a => a.Count.ToString()).ToList();
                    break;
                case "SORTER:COUNT":
                    Sorter = "SORTER:NAME";
                    houses = houses.OrderBy(a => a.Name).ToList();
                    break;
            }
            MainFilling(houses, Menu);
        }

        public static List<string> MenuMainLoadOut(List<string> Menu)
        {
            Menu.Clear();
            Menu.Add("ADD");
            Menu.Add("REMOVE");
            Menu.Add(Sorter);
            Menu.Add("CART");
            return Menu;
        }
        public static List<string> MenuCartLoadOut(List<string> Menu)
        {
            Menu.Clear();
            Menu.Add("ADD");
            Menu.Add("REMOVE");
            Menu.Add(Sorter);
            Menu.Add("CHECKOUT");
            return Menu;
        }
    }
}
