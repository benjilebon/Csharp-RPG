using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Combat
    {
        Player player;
        Monster monster;
        private int totalPlayerHp;
        private int totalMonsterHp;

        public Combat(Player player)
        {
            Console.Clear();
            this.player = player;
            monster = new Monster(player);

            this.totalPlayerHp = player.totalHp;
            this.totalMonsterHp = monster.hp;

            runCombat();
        }

        private void showCombat()
        {
            Console.Clear();
            Program.WriteFormattedLine("{0}", Program.colors[12], "Vous êtes en combat ! \n");
            Program.WriteFormattedLine("[{0}] ({1}/{2}) HP // Armor : {3}", Program.colors[10], visualHp(player.hp, totalPlayerHp), player.getHp(), player.getTotalHp(), player.getArmor());
            Program.WriteFormattedLine("[{0}] {1} HP // Armor : {2}", Program.colors[12], visualHp(monster.hp, totalMonsterHp), monster.getHp(), monster.getArmor());
            Console.WriteLine("");
        }

        private string visualHp(int hp, int totalHp)
        {
            int barLength = 40;
            double percentHp = (double) hp / totalHp * barLength;
            int playerHp = Convert.ToInt32(percentHp);
            string bar = "";

            for (int i = 0; i < playerHp; i++)
            {
                bar += '#';
            }

            int currlen = bar.Length;
            int needed = barLength == currlen ? 0 : (barLength - currlen);

            return needed == 0 ? bar :
                (needed > 0 ? bar + new string(' ', needed) :
                    new string(new string(bar.ToCharArray().Reverse().ToArray()).
                        Substring(needed * -1, bar.Length - (needed * -1)).ToCharArray().Reverse().ToArray()));
        }

        private void runCombat()
        {
            while (player.hp > 0 && monster.hp > 0)
            {
                showCombat();

                Program.WriteFormattedLine("Appuyez sur {0} pour attaquer !", Program.colors[4], "a");
                switch (Console.ReadLine())
                {
                    case "a":
                        player.receiveAttack(monster);
                        monster.receiveAttack(player);
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer un choix valide");
                        break;
                }
            }
            if (monster.hp <= 0)
                endCombat(true);
            else
                endCombat(false);
        }

        private void endCombat(bool won, bool loop = false)
        {


            if (won)
            {
                showCombat();
                Console.WriteLine("\n");
                Program.WriteFormattedLine("{0}", Program.colors[2], "======== Vous avez gagné ! ========");


                Program.WriteFormattedLine("{0}", Program.colors[14], "+ " + monster.goldReward + " G");
                if (!loop) player.golds += monster.goldReward;


                Program.WriteFormattedLine("{0}", Program.colors[11], "+ " + monster.xpReward + " XP");
                if (!loop) player.xp += monster.xpReward;

                player.checkLevelUp();

                Console.WriteLine();
                Program.WriteFormattedLine("Appuyez sur {0} pour retourner à l'accueil", Program.colors[4], "b");

                switch (Console.ReadLine())
                {
                    case "b": goHome(); break;
                    default: endCombat(won, true); break;
                    
                }
            }
        }

        public void goHome()
        {
            new Home(player);
        }
    }
}
