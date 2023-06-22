using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class UIElement
    {
        public string key = "";
        public string name = "";
        public Action CallBack = null;

        public UIElement(string key,string name, Action CallBack) 
        { 
            this.key = key;
            this.name = name;
            this.CallBack = CallBack;
        }
    }
}
