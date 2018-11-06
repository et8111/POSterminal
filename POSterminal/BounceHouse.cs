using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace POSterminal
{
    class BounceHouse
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Category { get; set; }
        public List<string> Description { get; set; }
        public double Price { get; set; }

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

/////////////////////////////////////
///In the Event of file Corruption///
/////////////////////////////////////


//List<BounceHouse> houses = new List<BounceHouse>();
//houses.Add(new BounceHouse());
//houses[0].Name = "Pirates of the Bouncy Sea";
//houses[0].SecondName = "Mega Jumbo Bounce House";
//houses[0].Category = "Family Ent.";
//houses[0].Description = new List<string>();
//houses[0].Description.Add("20 x 34 Pirate ship equiped with rockwall,");
//houses[0].Description.Add("lookout post, sustain 800lbs. Includes");
//houses[0].Description.Add("equipable plank walking ball pit.");
//houses[0].Description.Add("Moderate bouncing.");
//houses[0].Price = 6995;

//houses.Add(new BounceHouse());
//houses[1].Name = "Jimmy Jr. Jr.";
//houses[1].SecondName = "Jumbo Bounce House";
//houses[1].Category = "Family Ent.";
//houses[1].Description = new List<string>();
//houses[1].Description.Add("20 x 20 Outdoor float area bouce house,");
//houses[1].Description.Add("traditional trampline style with 8 foot");
//houses[1].Description.Add("ceiling. Childrens unit, Moderate Bouncing");
//houses[1].Price = 1395;

//houses.Add(new BounceHouse());
//houses[2].Name = "Jimm Jr. Sr.";
//houses[2].SecondName = "Jumbo Bounce House";
//houses[2].Description = new List<string>();
//houses[2].Description.Add("20 x 20 no ceiling flat area traditional");
//houses[2].Description.Add("trampline style bounce housee. Manufactured");
//houses[2].Description.Add("to handle adults, mega bounce.");
//houses[2].Category = "Family Ent.";
//houses[2].Price = 3800;

//houses.Add(new BounceHouse());
//houses[3].Name = "Great Rock Wall of China";
//houses[3].SecondName = "Jumbo Tall boy Bounce House";
//houses[3].Category = "Obsticle";
//houses[3].Description = new List<string>();
//houses[3].Description.Add("26 ft in height with 2 climbing sides. Can");
//houses[3].Description.Add("sustain 2 adults and come equiped with");
//houses[3].Description.Add("climbingsupport gear. Moderate bouncing.");
//houses[3].Price = 6795;

//houses.Add(new BounceHouse());
//houses[4].Name = "Billiard Soccer";
//houses[4].SecondName = "Jumbo Bounce House";
//houses[4].Category = "Obsticle";
//houses[4].Description = new List<string>();
//houses[4].Description.Add("17 x 30 flat area bounce house with 3 foot tall");
//houses[4].Description.Add("climbing 2 foot wide walls and 6 collection pockets.");
//houses[4].Description.Add("Equiped with 16 bounce same balls, Minimum bouncing.");
//houses[4].Price = 3395;

//houses.Add(new BounceHouse());
//houses[5].Name = "Mega Maze";
//houses[5].SecondName = "Jumbo Bouce House";
//houses[5].Category = "Family Ent.";
//houses[5].Description = new List<string>();
//houses[5].Description.Add("18 x 34 maze challenge with 2 sides maze extention");
//houses[5].Description.Add("per maze. Moderate bouncing.");
//houses[5].Price = 5995;

//houses.Add(new BounceHouse());
//houses[6].Name = "Ulitmate Bouncing Warrior";
//houses[6].SecondName = "Mega Jumbo Bounce House";
//houses[6].Category = "Obsticle";
//houses[6].Description = new List<string>();
//houses[6].Description.Add("11 X 60 course sustain 4 riders includes walls,");
//houses[6].Description.Add("tunnels, vetical and horizontal pop ups, sides,");
//houses[6].Description.Add("and ball pit. Handles adults, Mega bouncing.");
//houses[6].Price = 7295;

//houses.Add(new BounceHouse());
//houses[7].Name = "sports, Sports, SPORTS!";
//houses[7].SecondName = "Mega Jumbo Bounce House";
//houses[7].Category = "Arena";
//houses[7].Description = new List<string>();
//houses[7].Description.Add("38 x 20 flat area traditional trampoline arena includes");
//houses[7].Description.Add("basketball, football, volleyball, volleyball net,");
//houses[7].Description.Add("dodge ball, sustains 8 riders. Moderate bouncing.");
//houses[7].Price = 6495;

//houses.Add(new BounceHouse());
//houses[8].Name = "Gladiator Arena";
//houses[8].SecondName = "Jumbo Bounce House";
//houses[8].Category = "Arena";
//houses[8].Description = new List<string>();
//houses[8].Description.Add("21 x 21 octygon, step inside the ring. Includes");
//houses[8].Description.Add("jousting, boxing and sumo equipment. Sustains");
//houses[8].Description.Add("2 riders, handles adults, moderate bouncing.");
//houses[8].Price = 3995;

//houses.Add(new BounceHouse());
//houses[9].Name = "Sticky Wall";
//houses[9].SecondName = "Jumbo Bounce House";
//houses[9].Category = "Family Ent.";
//houses[9].Description = new List<string>();
//houses[9].Description.Add("12 x 21 with 13 foot velco wall. Sustains 2 riders");
//houses[9].Description.Add("How high can you stick? sustains adults, mega bouce.");
//houses[9].Price = 3295;

//houses.Add(new BounceHouse());
//houses[10].Name = "Global Warming Waverider";
//houses[10].Category = "Water Slide";
//houses[10].SecondName = "Mega Jumbo Bounce House";
//houses[10].Description = new List<string>();
//houses[10].Description.Add("30 x 95 freaking feet waterslide. Includes slide,");
//houses[10].Description.Add("climbing wall, water not included. Minimal bouce.");
//houses[10].Price = 14595;

//houses.Add(new BounceHouse());
//houses[11].Name = "Dancing Devil";
//houses[11].SecondName = "Tubeman";
//houses[11].Category = "Air Dancer";
//houses[11].Description = new List<string>();
//houses[11].Description.Add("20 foot tall wacky waving inflatable arm-flailing tubeman.");
//houses[11].Description.Add("WACKY WAVING INFLATABLE ARM-FLAILING TUBEMAN.");
//houses[11].Price = 100;