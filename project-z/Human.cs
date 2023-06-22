using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Human
    {
        protected int level;
        protected int hp;
        protected int currentHp;
        protected int damage;
        protected int attackSpeed = 1;
        protected int exp;
        protected string typeName;

        public bool Alive => currentHp > 0;
        public int Exp => exp;
        public string TypeName => typeName;
        public Human()
        {
            typeName = GetType().Name;
        }
        public virtual void ShowInFomation()
        {
            UIManager.Instance.PrintLine(30, "=");
            Console.WriteLine("Type: " + typeName);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("HP: " + hp);
            Console.WriteLine("current Hp: " + currentHp);
            Console.WriteLine("damage: " + damage);
            Console.WriteLine("Attack Speed: " + attackSpeed);
            UIManager.Instance.PrintLine(30, "=");
        }
        public void Attack(Human target)
        {
            target.TakeDamage(damage);
            Console.WriteLine("Damage: " + damage + " To " + target.typeName);
        }
        public void TakeDamage(int damage)
        {
            currentHp -= damage;
        }
        public string ShowDeadAlive()
        {
            if (Alive == false)
                return "Dead";
            else
                return "Alive";
        }

    }
}
