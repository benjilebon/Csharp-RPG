using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Entity
    {
        public int hp { get; set; }
        public int dp { get; set; }

        public int armor { get; set; }

        public Entity(int hp, int dp, int armor)
        {
            this.hp = hp;
            this.dp = dp;
            this.armor = armor;
        }

        public void receiveAttack(Entity attacker)
        {
            double multiplier = (double) 50 / (50 + armor);
            int test = Convert.ToInt32((double)attacker.dp * multiplier);
            hp -= Convert.ToInt32((double)attacker.dp * multiplier);
            if (this.hp < 0)
                this.hp = 0;
        }
    }
}
