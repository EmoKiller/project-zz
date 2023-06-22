using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Warrior : Player
    {

        public Warrior() : base()
        { 
            hp = 150;
            currentHp = hp;
            damage = 10;
        }
        public override void ShowInFomation()
        {
            Console.WriteLine(hero);
            base.ShowInFomation();
        }
    }
}
