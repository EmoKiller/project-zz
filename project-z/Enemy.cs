using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Enemy : Human
    {
        public Enemy() : base()
        {
            level = 1;
            hp = 50;
            currentHp = hp;
            damage = GameUtilities.GetRandomValue(5, 10);
            exp = GameUtilities.GetRandomValue(2,5);
            attackSpeed = 1;
        }
        public override void ShowInFomation()
        {
            Console.WriteLine("Enemy :"+ ShowDeadAlive());
            base.ShowInFomation();
        }


    }
}
