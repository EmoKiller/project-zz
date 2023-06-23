using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class Item
    {
        protected int id;
        protected int damage;
        protected int magicDamage;
        protected int critical;
        
        protected string type;

        protected bool requiredLevel;

        public int ItemID => id;
        public Item() 
        {
            id = GetHashCode();
            type = GetType().Name;
        }

        public virtual void ShowItem()
        {
            UIManager.Instance.PrintLine(30, "=");
            Console.WriteLine("Item ID: " + id);
            Console.WriteLine("Type: " + type);
            UIManager.Instance.PrintLine(30, "=");
        }


    }
}
