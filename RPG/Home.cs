using System;

namespace RPG
{
    class Home
    {
        Player player;
 
        public Home(Player player)
        {
            this.player = player;
            Console.Clear();
            Console.WriteLine("Accueil: "+ player.name + "\n");
            Console.WriteLine();
            Program.WriteFormattedLine("[{0}] ({1}/{2})", Program.colors[11], player.showXp(player.xp, player.xpNeeded), player.getXp(), player.getNeededXp());
            Program.WriteFormattedLine("Vous avez {0} HP", Program.colors[10], player.getHp());
            Program.WriteFormattedLine("Vous avez {0} Dégats d'attaque", Program.colors[10], player.getDp());
            Program.WriteFormattedLine("Vous êtes niveau {0}", Program.colors[10], player.getLevel());
            Program.WriteFormattedLine("Vous avez {0} golds", Program.colors[14], player.getGolds());
            Console.WriteLine("\n \n");

            Program.WriteFormattedLine("Appuyez sur {0} pour aller combattre", Program.colors[4], "c");
            Program.WriteFormattedLine("Appuyez sur {0} pour aller dans le shop", Program.colors[4], "i");
            switch (Console.ReadLine())
            {
                case "c": new Combat(player); break;
                case "i": new Shop(player); break;
                default: new Home(player); break;
            }
        }
    }
}