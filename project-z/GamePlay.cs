﻿using System;
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
        private int levelEnemy = 1;
        private int Page = 1;
        private int minOfEnemy = 1;
        private int maxOfEnemy = 1;
        private int countEnemyDead = 0;
        private int totalEnemyDead = 0;
        private bool enemyAllAlive = false;
        private Enemy[] enemies = null;
        private GamePlay() { }
        public void Play()
        {
            ResetGame();
            Console.Clear();
            StartPage();
        }
        
        private void StartPage()
        {
            Console.Clear();
            Console.WriteLine("Game Start");
            while (GameManager.Instance.player.Alive)
            {
                Console.WriteLine($"Page: {Page}");
                PageUpdate();
                CreatedEnemy();
                ShowEnemies();
                Console.WriteLine("Press start Round");
                Console.ReadKey();
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
                TurnPlayer();
                EnemyAttack();
                CheckEnemyDead();
                countTurn++;
                Console.ReadKey();
                Console.Clear();
            }
            Page++;
            countEnemyDead = 0;
        }
        private void TurnPlayer()
        {
            while (GameManager.Instance.player.Alive)
            {
                ChooseEnemy();
                break;
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
                Console.WriteLine(i);
                element[x] = new UIElement(x.ToString(), enemies[i].TypeName + " Level: " + enemies[i].Level + " Hp:" + enemies[i].CurrentHp,
                    () => 
                    {
                        PlayerAttack(enemies[y]);
                    });
                enemies[i].ShowInFomation();
            }
            element[0] = new UIElement("0","Option", Option);
            UIManager.Instance.PrintMenu("turn Player Attack", element);
        }
        public void Option()
        {
            Console.Clear();
            UIElement[] elements = new UIElement[4];
            elements[1] = new UIElement("1", "Show Infomation",
                () =>
                {
                    Console.Clear();
                    GameManager.Instance.player.ShowInFomation();
                    Console.ReadKey();
                    Option();
                });
            elements[2] = new UIElement("2", "Inventory", null);
            elements[3] = new UIElement("3", "Skill", null);
            elements[0] = new UIElement("0", "Back", ChooseEnemy);
            UIManager.Instance.PrintMenu("Player Option", elements);
        }
        private void PlayerAttack(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("Player Attack");
            GameManager.Instance.player.Attack(enemy);
            if (!enemy.Alive)
            {
                //drop items
                Console.WriteLine("Player Gain Exp + " + enemy.Exp);
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
                    totalEnemyDead++;
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
                Enemy enemy = new Enemy(levelEnemy);
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
        }
        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            WinnerLoses();
            Console.ReadKey();
            Scores();
            Console.ReadKey();
            GameManager.Instance.ShowMainMenu();
        }
        private void WinnerLoses()
        {
            if (GameManager.Instance.player.Alive)
            {
                Console.WriteLine("Player Winner");
            }
            else
            {
                Console.WriteLine("Player loses");
            }
        }
        private void Scores()
        {
            Console.Clear();
            Console.WriteLine("==============SCORES=============");
            Console.WriteLine("Total Kill Enemy: " + totalEnemyDead);
        }
        private void PageUpdate()
        {
            if (Page % 2 == 0)
            {
                maxOfEnemy++;
            }
            else if (Page % 5 == 0)
            {
                minOfEnemy++;
                levelEnemy++;
                
            }
        }
        private void ResetGame()
        {
            Page = 1;
            minOfEnemy = 1;
            maxOfEnemy = 1;
            levelEnemy = 1;
        }
    }
}
