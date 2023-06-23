using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Player : Human
    {
        protected string hero;

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
        private void UpLevel(int exp)
        {
            if (exp >= expRequired)
            {
                Console.WriteLine("Level Up");
                level++;
                BonusUpLevel();
                ExpRequired();
                UpDamage(2);
                UpHealth(2);
                HealthFull();
            }
        }
        private void BonusUpLevel()
        {
            UIElement[] element = new UIElement[3];
            element[0] = new UIElement("1", "Upgrade Damage + 4", () => { UpDamage(4); });
            element[1] = new UIElement("2", "Upgrade Health + 10", () => { UpHealth(4); });
            element[2] = new UIElement("3", "Health full Hp", HealthFull );
            UIManager.Instance.PrintMenu("Choose", element);
        }
        private void UpDamage(int num)
        {
            damage += num;
        }
        private void UpHealth(int num)
        {
            hp += num;
        }
        private void HealthFull()
        {
            currentHp = hp;
        }
        private void ExpRequired()
        {
            expRequired *= 2;
        }
    }
}
