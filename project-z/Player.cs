using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Player : Human
    {
        public string hero;

        protected int expRequired = 2;
        public Player() : base()
        {
            hero = GetType().Name;
            level = 1;
            exp = 0;
            attackSpeed = 1;
        }

        public override void ShowInFomation()
        {
            base.ShowInFomation();
        }
        public void GainExp(int gainExp)
        {
            exp += gainExp;
            UpLevel(exp);
        }
        public void UpLevel(int exp)
        {
            if (exp == expRequired)
            {
                Console.WriteLine("Level Up");
                level++;
                BonusUpLevel();
                expRequired *= 2;
                damage += 2;
                hp += 2;
                currentHp = hp;
            }
        }
        private static void BonusUpLevel()
        {
            Console.WriteLine("1: Upgrade Damage + 4");
            Console.WriteLine("2: Upgrade Health + 10");
            Console.WriteLine("3: Upgrade ? + 4");
            ConsoleKeyInfo key = Console.ReadKey();
            string strKey = Convert.ToString(key.Key);
            switch (strKey)
            {
                case "1":
                case "NumPad1":
                    Console.WriteLine("Press 1");
                    break;
                case "2":
                case "NumPad2":
                    Console.WriteLine("Press 2");
                    break;
                case "3":
                case "NumPad3":
                    Console.WriteLine("Press 3");
                    break;
            }
        }
    }
}
