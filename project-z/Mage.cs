using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace project_z
{
    public class Mage : Player
    {
        public Mage() : base()
        {
            hp = 100;
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
