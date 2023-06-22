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
        
        protected string type;
        protected bool requiredLevel;

        public int ItemID => id;
        public Item() 
        {
            id = GetHashCode();
        }

        public void ShowItem()
        {

        }


    }
}
