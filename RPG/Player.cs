using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Player : Entity
    {
        public string name;
        public int level = 0;
        public int golds = 0;
        public int totalHp = 0;
        public int xp = 0;
        public int xpNeeded = 0;

        public Player(string name) : base(100, 10, 10)
        {
            this.name = name;
            this.level = 1;
            this.totalHp = hp;
            this.xpNeeded = setNeededXp();
        }

        //  GETTERS

        public string getHp()
        {
            return hp.ToString();
        }

        public string getGolds()
        {
            return golds.ToString();
        }

        public string getDp()
        {
            return dp.ToString();
        }

        public string getLevel()
        {
            return level.ToString();
        }

        public string getXp()
        {
            return xp.ToString();
        }

        public string getNeededXp()
        {
            return xpNeeded.ToString();
        }

        public string getArmor()
        {
            return armor.ToString();
        }

        // FUNCTIONS

        public string showXp(int xp, int totalXp)
        {
            int barLength = 80;
            double percentXp = (double)xp / totalXp * barLength;
            int playerXp = Convert.ToInt32(percentXp);
            string bar = "";

            for (int i = 0; i < playerXp; i++)
            {
                bar += '#';
            }

            int currlen = bar.Length;
            int needed = barLength == currlen ? 0 : (barLength - currlen);

            return needed == 0 ? bar :
                (needed > 0 ? bar + new string('-', needed) :
                    new string(new string(bar.ToCharArray().Reverse().ToArray()).
                        Substring(needed * -1, bar.Length - (needed * -1)).ToCharArray().Reverse().ToArray()));
        }

        public void checkLevelUp()
        {
            if (xp > xpNeeded)
            {
                level++;
                Program.WriteFormattedLine("{0}", Program.colors[9], "//////////--- LEVEL UP ! >>> "+ getLevel() +"---\\\\\\\\\\");
                xp = 0;
                xpNeeded = setNeededXp();

                hp = Convert.ToInt32(hp * 1.15);
            }
        }

        private int setNeededXp()
        {
            double tempXp = 500 * Math.Exp((double) (level - 1) / 3);

            return Convert.ToInt32(tempXp);
        }


    }
}
