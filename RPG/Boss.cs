using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Boss
    {
        Player player;
        Dragon dragon;
        private int totalPlayerHp;
        private int totalMonsterHp;

        public Boss(Player player)
        {
            Console.Clear();
            this.player = player;
            this.dragon = new Dragon(player);

            this.totalPlayerHp = player.totalHp;
            this.totalMonsterHp = dragon.hp;

            runCombat();
        }

        private void showCombat()
        {
            Console.Clear();
            Program.WriteFormattedLine("{0}", Program.colors[12], "Vous êtes contre le dragon ancestral ! \n");
            Program.WriteFormattedLine("[{0}] ({1}/{2}) HP // Armor : {3}", Program.colors[10], visualHp(player.hp, totalPlayerHp, 40), player.getHp(), player.getTotalHp(), player.getArmor());
            Program.WriteFormattedLine("[{0}] ({1}/{2}) HP // Armor : {3}", Program.colors[12], visualHp(dragon.hp, totalMonsterHp, 60), dragon.getHp(), totalMonsterHp.ToString(), dragon.getArmor());
            Console.WriteLine("");
        }

        private string visualHp(int hp, int totalHp, int length)
        {
            int barLength = length;
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
            while (player.hp > 0 && dragon.hp > 0)
            {
                showCombat();

                Program.WriteFormattedLine("Appuyez sur {0} pour attaquer !", Program.colors[4], "a");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        player.receiveAttack(dragon);
                        dragon.receiveAttack(player);
                        break;
                    default:
                        break;
                }
            }
            if (dragon.hp <= 0)
                endCombat(true);
            else
                endCombat(false);
        }

        private void endCombat(bool won, int rndSaved = 0, bool loop = false)
        {


            if (won)
            {
                showCombat();
                Console.WriteLine("\n");
                Program.WriteFormattedLine("{0}", Program.colors[2], "======== Vous avez gagné ! ========");


                Program.WriteFormattedLine("{0}", Program.colors[14], "+ " + dragon.goldReward + " G");
                if (!loop) player.golds += dragon.goldReward;


                Program.WriteFormattedLine("{0}", Program.colors[11], "+ " + dragon.xpReward + " XP");
                if (!loop) player.xp += dragon.xpReward;

                player.checkLevelUp();

                Console.WriteLine();
                Program.WriteFormattedLine("Appuyez sur {0} pour recommencer", Program.colors[4], "o");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.O:
                        Console.Clear();
                        Init f = new Init();
                        f.goHome();
                        break;
                    default: endCombat(won, 0, true); break;
                    
                }
            }

            else
            {
                Random rnd = new Random();
                int save = rnd.Next(0, 10);
                if (save > 5 || loop)
                {
                    showCombat();
                    Console.WriteLine("\n");
                    Program.WriteFormattedLine("{0}", Program.colors[4], "=============== Vous avez perdu ! ===============");
                    Program.WriteFormattedLine("{0}", Program.colors[4], "...Mais vous parvenez à vous enfuir de justesse !");

                    Program.WriteFormattedLine("{0}", Program.colors[14], "+ " + dragon.goldReward + " G");
                    if (!loop) player.golds += dragon.goldReward / 2;


                    Program.WriteFormattedLine("{0}", Program.colors[11], "+ " + dragon.xpReward + " XP");
                    if (!loop) player.xp += dragon.xpReward / 2;

                    player.checkLevelUp();

                    player.hp = Convert.ToInt32(player.totalHp * 0.10);

                    Console.WriteLine();
                    Program.WriteFormattedLine("Appuyez sur {0} pour retourner à l'accueil", Program.colors[4], "b");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.B:
                            new Home(player);
                            break;
                        default: endCombat(won, save, true); break;

                    }

                } else
                {
                    Program.gameOver();
                }
            }
        }

        public void goHome()
        {
            new Home(player);
        }
    }
}
