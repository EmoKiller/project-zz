using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Enemy : Human
    {

        public Enemy(int level) : base()
        {
            hp = 50;
            damage = GameUtilities.GetRandomValue(5, 10);
            exp = GameUtilities.GetRandomValue(2, 5);
            this.level = level;
            AttributeChangeByLevel();
            currentHp = hp;
            attackSpeed = 1;
        }
        public override void ShowInFomation()
        {
            Console.WriteLine("Enemy :"+ ShowDeadAlive());
            base.ShowInFomation();
        }
        private void AttributeChangeByLevel()
        {
            hp *= level;
            damage *= level;
            exp *= level;
        }


    }
}
