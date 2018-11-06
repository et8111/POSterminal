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
        public static void MainSkeleton()
        {
            char fill = (char)247;
            Console.WriteLine("                 ~Jump Around! - Jumbo Bounce House Emporium~");
            Console.CursorTop = 1;
            Console.WriteLine(fill.ToString().PadLeft(80, fill));
            for(int i = 0; i < 16; i++)
                Console.WriteLine($"{fill,-20}{fill,-59}{fill}");
            Console.WriteLine(fill.ToString().PadLeft(80, fill));
            for (int i = 0; i < 6; i++)
                Console.WriteLine($"{fill,-79}{fill}");
            Console.WriteLine(fill.ToString().PadLeft(80, fill));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("MENU:");
            Console.SetCursorPosition(2, 3);
            Console.Write("-".PadLeft(17, '-'));
            Console.SetCursorPosition(22, 2);
            Console.WriteLine($"{"ITEMS:", -30}{"CATEGORY:",-15}{"PRICE:",10}");
            Console.SetCursorPosition(22, 3);
            Console.Write("-".PadLeft(55, '-'));
            Console.SetCursorPosition(22,17);
            Console.Write($"{"QUANTITY: 99",-38}{"TOTAL: $99,999,99"}");
            Console.SetCursorPosition(0, 26);
        }
        public static void MainFilling(List<BounceHouse> list)//MENU(1,4) | ListName(22,4) | listCate(50,4) | ListPrice(66,4) | Quantity(32,17) | Total(46,17)
        {
            Console.SetCursorPosition(22, 4);
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i].Name.PadRight(30, '.')}{list[i].Category.PadLeft(11,'.')}{list[i].Price.ToString("C2").PadLeft(14,' ')}");
                Console.CursorTop++;
                Console.CursorLeft = 22;
            }

            Console.SetCursorPosition(0, 26);
        }
    }
}
