using System;

namespace RPG
{
    class Shop
    {
        Player player;
 
        public Shop(Player player)
        {
            this.player = player;
            Console.Clear();
            Console.WriteLine("Boutique: "+ player.name + "\n");
            Console.WriteLine();
            Program.WriteFormattedLine("Vous avez {0} HP", Program.colors[10], player.getHp());
            Program.WriteFormattedLine("Vous avez {0} Armure", Program.colors[10], player.getArmor());
            Program.WriteFormattedLine("Vous avez {0} Dégats d'attaque", Program.colors[10], player.getDp());
            Program.WriteFormattedLine("Vous avez {0} golds", Program.colors[14], player.getGolds());
            Console.WriteLine("\n \n");

            Console.WriteLine("\n ============================== \n");

            foreach (Item item in ItemsData.addItemsToShop(player.level))
            {
                item.showItem();
            }

            Console.WriteLine("\n ============================== \n");

            Program.WriteFormattedLine("Appuyez sur {0} pour retourner à l'accueil", Program.colors[4], "b");
            switch (Console.ReadLine())
            {
                case "c": new Combat(player); break;
                case "i": new Shop(player); break;
                default: new Home(player); break;
            }
        }
    }
}