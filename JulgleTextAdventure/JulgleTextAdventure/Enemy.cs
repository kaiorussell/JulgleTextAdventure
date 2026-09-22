using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulgleTextAdventure
{
    internal class Enemy
    {
        public string name;
        public int maxHP;
        public int currentHP;
        public int attack;
        int attackCounter = 0;

        public Enemy(string Name, int MaxHP, int Attack)
        {
            name = Name;
            maxHP = MaxHP;
            currentHP = maxHP;
            attack = Attack;
        }

        public int DoAttack()
        {
            if (attackCounter == 3)
            {
                attackCounter = 0;
                return BigAttack();
            }
            else
            {
                attackCounter++;
                return SmallAttack();
            }
        }

        int SmallAttack()
        {
            return attack;
        }
        
        int BigAttack()
        {
            return attack * 2;
        }





    }
}
