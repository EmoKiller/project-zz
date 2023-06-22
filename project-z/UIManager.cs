using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class UIManager
    {
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UIManager();
                return _instance;
            }
        }
        private UIManager() { }
        public string Input(string title)
        {
            Console.Write(title);
            return Console.ReadLine();
        }
        public void PrintLine(int total,string symbol)
        {
            for (int i = 0; i < total; i++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
        public void PrintMenu(string title, UIElement[] element)
        {
            Console.WriteLine(title);
            PrintLine(30,"=");
            for (int i = 0; i < 1; i++)
            {
                for (int j = 1; j < element.Length; j++)
                {
                    Console.WriteLine($"{j}: {element[j].name}");
                }
                Console.WriteLine($"{i}: {element[i].name}");
            }
            PrintLine(30, "=");
            UIElement targetElement = null;
            ValidateInput(element, out targetElement);

            if (targetElement.CallBack != null)
                targetElement.CallBack();
        }
        private void ValidateInput(UIElement[] element, out UIElement targetElement)
        {
            while (true)
            {
                Console.Write("Nhap lua chon: ");
                string key = Console.ReadLine();
                targetElement = ContainElementByKey(key, element);
                if (targetElement != null)
                    break;
                else
                {
                    Console.Write("Khong ton tai chuc nang tren, nhan phim bat ky de tiep tuc...");
                    Console.ReadLine();
                }
            }
        }
        private UIElement ContainElementByKey(string key, UIElement[] element)
        {
            foreach (var e in element)
            {
                if (e.key.Equals(key))
                    return e;
            }
            return null;
        }
    }
}
