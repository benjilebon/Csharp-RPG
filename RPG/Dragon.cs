using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Dragon : Entity
    {
        public int xpReward;
        public int goldReward;
        private Player player;

        public Dragon(Player player) : base(0, 0, 0)
        {
            this.player = player;
            this.hp = setHp();
            this.dp = setDp();
            this.goldReward = setGoldReward();
            this.xpReward = setXpReward();
            this.armor = setArmor();
        }

        private int setHp()
        {
            double tempHp = 250 * RandomExtensions.NextDouble(0.70, 0.70) * 5 / 2;

            return Convert.ToInt32(tempHp);
        }
        private int setDp()
        {
            double tempDp = 250 * RandomExtensions.NextDouble(0.10, 0.10) * 5 / 3.5;

            return Convert.ToInt32(tempDp);
        }

        private int setGoldReward()
        {
            double tempReward = 20 * RandomExtensions.NextDouble(0.60, 0.60) * player.level;

            return Convert.ToInt32(tempReward);
        }

        private int setXpReward()
        {
            double tempXp = 500 * RandomExtensions.NextDouble(0.42, 0.42) * player.level / 2;

            return Convert.ToInt32(tempXp);
        }

        private int setArmor()
        {
            double tempArmor = 10 + (5 * RandomExtensions.NextDouble(6.00, 6.00));

            return Convert.ToInt32(tempArmor);
        }

        public string getHp()
        {
            return hp.ToString();
        }

        public string getDp()
        {
            return dp.ToString();
        }

        public string getArmor()
        {
            return armor.ToString();
        }

    }
}
