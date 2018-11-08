using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSterminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Media.SoundPlayer();
            bool FinalFlag = false;
            GUI.Sorter = "SORTER:NAME";
            List<BounceHouse> houses = new List<BounceHouse>();
            houses = BounceHouse.deSerialBounceHouse();
            GUI.Menu = GUI.MenuMainLoadOut(GUI.Menu);
            houses = houses.OrderBy(a => a.Name).ToList();
            program(houses, false,ref FinalFlag);
        }
        //exit or restart
        public static void message()
        {
            Console.Clear();
            Console.WriteLine("OUT reciept has been printed!");
            Console.WriteLine("Press enter to restart, or any key to exit...");
            if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                Environment.Exit(0);
            Console.Clear();
            Console.SetCursorPosition(GUI.left = 2, GUI.top = 4);
        }
        //Programs main controller
        public static int program(List<BounceHouse> houses, bool flag,ref bool FinalFlag)
        {
            while (true)
            {
                GUI.MainSkeleton();
                GUI.MainFilling(houses, GUI.Menu, true);
                int temp = GUI.Selector(GUI.left, GUI.top, GUI.Menu.Count - 1, GUI.Menu, GUI.index, false, houses);
                if (temp == 0)
                {
                    if (FinalFlag)
                        return -1;
                    else if (flag)
                        return 0;
                    temp = GUI.Selector(GUI.left = 25, GUI.top = 4, houses.Count - 1, houses.Select(a => a.Name).ToList(), 0, true, houses);
                    houses[temp].Count++;
                    BounceHouse.MATH(houses);
                    GUI.MainFilling(houses, GUI.Menu, true);
                    GUI.left = 2; GUI.top = 4; GUI.index = 0;
                    continue;
                }
                if (temp == 1)
                {
                    temp = GUI.Selector(GUI.left = 25, GUI.top = 4, houses.Count - 1, houses.Select(a => a.Name).ToList(), 0, true, houses);
                    if (!flag)
                    {
                         houses[temp].Count = (houses[temp].Count > 0) ? houses[temp].Count - 1 : houses[temp].Count;
                        BounceHouse.MATH(houses);
                        GUI.MainFilling(houses, GUI.Menu, true);
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
                        GUI.MainFilling(houses.Where(a => a.Count > 0).ToList(), GUI.Menu, true);
                        if (!flag)
                        {
                            temp = program(houses.Where(a => a.Count > 0).ToList(), true, ref FinalFlag);
                            if (temp == -1)
                            return -1;
                        }
                        else
                        {
                            temp = Finalizer(houses, GUI.Menu, new List<string>());
                            return 0;
                        }
                        GUI.MenuMainLoadOut(GUI.Menu);
                    }
                    continue;
                }
            }
        }

        //Payment Controller
        public static int Finalizer(List<BounceHouse> list, List<string> menu, List<string> payment)
        {
            List<string> Options;
            double money = 0;
            GUI.FinalizeSkeleton();
            GUI.MenuFinalizeLoadOut(GUI.Menu);
            GUI.MainFilling(list, menu, false);
            int temp = GUI.Selector(GUI.left = 2, GUI.top = 4, GUI.Menu.Count - 1, GUI.Menu, 0, false, list);
            if (temp == 0)
            {
                GUI.Total = list.Select(a => a.Price + (a.Price * .06)).Sum();
                return temp;
            }
            else if (temp == 1)
            {
                Options = new List<string>();
                Options.Add("CASH: $");
                money = GUI.Selector2(GUI.left = 22, GUI.top = 4, "Cash", Options);
                payment.Add("Cash");
                payment.Add(money.ToString("C2"));
                GUI.left = 2; GUI.top = 4; GUI.index = 0;
                GUI.Total -= money;
            }
            else if (temp == 2)
            {
                Options = new List<string>();
                Options.Add("CARD#: ");
                Options.Add("CVV#: ");
                Options.Add("EXPIRE: ");
                GUI.Selector2(GUI.left = 22, GUI.top = 4, "Card", Options);
                payment.Add("Card");
                payment.Add(GUI.Total.ToString("C2"));
                GUI.left = 2; GUI.top = 4; GUI.index = 0;
                GUI.Total = 0;
            }
            else if (temp == 3)
            {
                Options = new List<string>();
                Options.Add("CHECK #: ");
                GUI.Selector2(GUI.left = 22, GUI.top = 4, "Check", Options);
                payment.Add("Check");
                payment.Add(GUI.Total.ToString("C2"));
                GUI.left = 2; GUI.top = 4; GUI.index = 0;
                GUI.Total = 0;
            }
            if (GUI.Total > 0)
                temp = Finalizer(list, menu, payment);
            else if (GUI.Total <= 0)
            {
                GUI.change = Math.Abs(GUI.Total);
                RECIEPT(list, payment);
                GUI.Total = 0;
                GUI.Quantity = 0;
                for (int i = 0; i < list.Count; i++)
                    list[i].Count = 0;
                message();
            }
            return 1;
        }

        //spit the reciept to OUT.txt in the bin/Debug file
        public static void RECIEPT(List<BounceHouse> list, List<string> payment)
        {
            double final = list.Select(a => (a.Price + (a.Price * .06))*a.Count).Sum();
            using (StreamWriter writetext = new StreamWriter("OUT.txt"))
            {
                writetext.WriteLine("~Jump Around!-Jumbo Bounce House Emporium~");
                writetext.WriteLine("==========================================");
                for (int i = 0; i < list.Count; i++)
                    writetext.WriteLine($"{list[i].Count + ")",-3}{list[i].Name.PadRight(27, '.')}{list[i].Price.ToString("C2").PadLeft(12, '.')}");
                for (int i = 0; i < payment.Count; i+=2)
                    writetext.WriteLine($"{payment[i].PadRight(30, '.')}{payment[i+1].PadLeft(12,'.')}");
                writetext.WriteLine($"{"Tax".PadRight(30, '.')}{list.Select(a => (a.Price * .06)*a.Count).Sum().ToString("C2").PadLeft(12, '.')}");
                writetext.WriteLine($"{"Total".PadRight(30, '.')}{final.ToString("C2").PadLeft(12, '.')}");
                writetext.WriteLine($"{"Paid".PadRight(30, '.')}{(final+GUI.change).ToString("C2").PadLeft(12,'.')}");
                writetext.WriteLine($"{"Change".PadRight(30,'.')}{GUI.change.ToString("C2").PadLeft(12, '.')}");
            }
        }
    }
}
