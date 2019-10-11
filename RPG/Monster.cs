using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Monster : Entity
    {
        public int xpReward;
        public int goldReward;
        private Player player;

        public Monster(Player player) : base(0, 0, 0)
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
            double tempHp = player.totalHp * RandomExtensions.NextDouble(0.45, 0.60)  * player.level / 2;

            return Convert.ToInt32(tempHp);
        }
        private int setDp()
        {
            double tempDp = 120 * RandomExtensions.NextDouble(0.06, 0.10) * player.level / 2;

            return Convert.ToInt32(tempDp);
        }

        private int setGoldReward()
        {
            double tempReward = 12 * RandomExtensions.NextDouble(0.50, 0.85) * player.level;

            return Convert.ToInt32(tempReward);
        }

        private int setXpReward()
        {
            double tempXp = 300 * RandomExtensions.NextDouble(0.35, 0.60) * player.level / 2;

            return Convert.ToInt32(tempXp);
        }

        private int setArmor()
        {
            double tempArmor = 15 + (player.level * RandomExtensions.NextDouble(4.00, 5.50));

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
