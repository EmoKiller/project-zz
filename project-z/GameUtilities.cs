using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public static class GameUtilities
    {
        public static int GetRandomValue(int min,int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
        public static Player SelectWarrior(string heroSelect)
        {
            if (heroSelect == "Warrior")
                return new Warrior();
            else if (heroSelect == "Archer")
                return new Archer();
            else if (heroSelect == "Mage")
                return new Mage();
            else
                return null;
        }
    }
}
