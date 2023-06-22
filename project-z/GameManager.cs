using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_z
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }
        public Player player;
        private GameManager()
        {
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            UIElement[] element = new UIElement[2];
            element[1] = new UIElement("1","Start Game", SelectHero);
            element[0] = new UIElement("0", "Exit", null);
            UIManager.Instance.PrintMenu("Project-z", element);
        }
        private void SelectHero()
        {
            Console.Clear();
            UIElement[] element = new UIElement[4];
            element[1] = new UIElement("1", "Warrior", () => { player = GameUtilities.SelectWarrior("Warrior"); GamePlay.Instance.Play(); });
            element[2] = new UIElement("2", "Archer", () => { player = GameUtilities.SelectWarrior("Archer"); GamePlay.Instance.Play(); });
            element[3] = new UIElement("3", "Mage", () => { player = GameUtilities.SelectWarrior("Mage"); GamePlay.Instance.Play(); });
            element[0] = new UIElement("0", "Back", ShowMainMenu);
            UIManager.Instance.PrintMenu(" Select Hero ", element);
        }

    }
}
