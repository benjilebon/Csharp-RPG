using System;

namespace RPG
{
    class Item
    {
        /* Types : 
         * 1: Potion
         * 2: Armor
         * 3: Damage
         * 4: HP
         */
        public int id = 0;
        public int golds = 0;
        public int itemType = 0;
        public int value = 0;
        public int level = 0;
        public string name = "";
        public string desc = "";

        public Item(int id, int type, int value, int level, string name, string description, int golds)
        {
            this.id = id;
            itemType = type;
            this.value = value;
            this.level = level;
            this.name = name;
            this.desc = description;
            this.golds = golds;
        }

        public void showItem()
        {
            Console.WriteLine("\n");
            Program.WriteFormattedLine("          "+name+" ({0} G)", Program.colors[14], golds.ToString());
            Console.WriteLine("          "+desc);
            Program.WriteFormattedLine("          {0}", Program.colors[5], negOrPos(value) + value + " " + getItemType());
            Console.WriteLine("          ID: " + id);
            Console.WriteLine("\n");
        }

        private string negOrPos(int value)
        {
            if (value < 0)
            {
                return "-";
            } else
            {
                return "+";
            }
        }

        private string getItemType()
        {
            switch (itemType)
            {
                case 1: return "Soin";
                case 2: return "Armure";
                case 3: return "Dégats d'attaque";
                case 4: return "HP Max";
                default: return "???";
            }
        }
    }
}