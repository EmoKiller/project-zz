using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace project_z
{
    public class GamePlay
    {
        private static GamePlay _instance;
        public static GamePlay Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GamePlay();
                return _instance;
            }
        }
        private int round = 1;
        private int minOfEnemy = 1;
        private int maxOfEnemy = 1;
        private int countEnemyDead = 0;
        private bool enemyAllAlive = false;
        private Enemy[] enemies = null;
        private GamePlay() { }
        public void Play()
        {
            ResetGame();
            Console.Clear();
            Console.WriteLine("Game Start");
            while (GameManager.Instance.player.Alive)
            {
                RoundUpdate();
                CreatedEnemy();
                StartRound();
            }
            GameOver();
        }
        private void StartRound()
        {
            Console.Clear();
            int countTurn = 1;
            while (GameManager.Instance.player.Alive && enemyAllAlive)
            {
                Console.WriteLine($"turn {countTurn}");
                ShowEnemies();
                TurnPlayer();
                EnemyAttack();
                CheckEnemyDead();
                countTurn++;
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void TurnPlayer()
        {
            Console.Clear();
            Console.WriteLine($"turn Player Attack");
            while (GameManager.Instance.player.Alive)
            {
                //int x = GameUtilities.GetRandomValue(0, enemies.Length);
                //if (!enemies[x].Alive)
                //{
                //    continue;
                //}
                //else
                //{
                //    GameManager.Instance.player.Attack(enemies[x]);
                //    Console.WriteLine("Player Attack");
                //    if (!enemies[x].Alive)
                //    {
                //        //drop items
                //        GameManager.Instance.player.GainExp(enemies[x].Exp);
                //    }
                //    Console.WriteLine($"End turn Player");
                //    break;
                //}
                ChooseEnemy();
            }
        }
        private void ChooseEnemy()
        {
            Console.Clear();
            UIElement[] element = new UIElement[enemies.Length+1];
            for (int i = 0; i < enemies.Length; i++)
            {
                int x = i + 1;
                int y = i;
                Console.WriteLine("vong lap i hien tai la:" + i);
                element[x] = new UIElement(x.ToString(), enemies[i].TypeName +" "+ i ,() => { PlayerAttack(enemies[i]); });
                enemies[i].ShowInFomation();
            }
            element[0] = new UIElement("0","Back",null);
            UIManager.Instance.PrintMenu("turn Player Attack", element);
        }
        private void PlayerAttack(Enemy enemy)
        {
            GameManager.Instance.player.Attack(enemy);
            Console.WriteLine("Player Attack");
            if (!enemy.Alive)
            {
                //drop items
                GameManager.Instance.player.GainExp(enemy.Exp);
            }
            Console.WriteLine($"End turn Player");
        }
        private void EnemyAttack()
        {
            Console.WriteLine($"turn Enemy Attack");
            foreach (var enemy in enemies)
            {
                if (!enemy.Alive)
                {
                    countEnemyDead++;
                    continue;
                }
                else
                {
                    enemy.Attack(GameManager.Instance.player);
                    Console.WriteLine($"End turn Enemy");
                }
            }

        }
        private void CheckEnemyDead()
        {
            if (countEnemyDead == enemies.Length)
            {
                enemyAllAlive = false;
            }
        }
        private void CreatedEnemy()
        {
            enemies = new Enemy[GameUtilities.GetRandomValue(minOfEnemy,maxOfEnemy)];
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = new Enemy();
                enemies[i] = enemy;
                Thread.Sleep(20);
            }

            enemyAllAlive = true;
        }
        private void ShowEnemies()
        {
            UIManager.Instance.PrintLine(30,"*");
            Console.WriteLine("Total Enemy:" + enemies.Length);
            foreach (Enemy enemy in enemies)
            {
                enemy.ShowInFomation();
            }
            Console.ReadKey();
        }
        private void GameOver()
        {
            Console.WriteLine("Game Over");
            if (GameManager.Instance.player.Alive)
            {
                Console.WriteLine("Player Winner");
            }
            else
            {
                Console.WriteLine("Player loses");
            }
            Console.ReadKey();
            GameManager.Instance.ShowMainMenu();
        }
        private void RoundUpdate()
        {
            if (round % 2 == 0)
            {
                maxOfEnemy++;
            }
            else if (round % 5 == 0)
            {
                minOfEnemy++;
            }
        }
        private void ResetGame()
        {
            round = 1;
            minOfEnemy = 1;
            maxOfEnemy = 1;
        }
    }
}
