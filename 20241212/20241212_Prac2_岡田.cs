using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241212
{
    internal class _20241212_Prac2_岡田
    {
        public class Character
        {
            public string name{get;set;}
            public int HP { get;set;}
            public int MP {  get;set;}
            public int ATK {  get;set;}
            public int AGL {  get;set;}
            public int DFE {  get;set;}

            // 初期化
            public void Initialize(string Name,Random random)
            {
                name = Name;
                HP = random.Next(1, 100);
                MP = random.Next(1, 50);
                ATK = random.Next(1, 30);
                AGL = random.Next(1, 30);
                DFE = random.Next(1, 30);
            }

            public void takeDamage(int damage)
            {
                HP -= damage;
                Console.WriteLine($"に{damage}ダメージ！");
                if(HP < 0)
                {
                    HP = 0;
                }
            }

            public bool isAlive()
            {
                return HP > 0;
            }
        }

        public class Player : Character
        {
            public int attack()
            {
                int damage;
                damage = ATK * 2;
                return damage;
            }

            public void defend(int damage)
            {
                HP -= (DFE - damage); 
            }
            
        }

        public class Enemy : Character
        {
            public int attack()
            {
                int damage;
                Random random = new Random();
                int select = random.Next(1,100);
                if(select <= 75)
                {
                    damage = ATK;
                }
                else
                {
                    Console.WriteLine("敵は本気を出した！通常の２倍の攻撃！");
                    damage = ATK * 2;
                }
                return damage;
            }
        }

        public class Fight
        {
            public void Fighting()
            {
                Random rand = new Random();
                Player player = new Player();
                Enemy enemy = new Enemy();

                // プレイヤーのステータスの入力
                Console.WriteLine("プレイヤーの名前を入力してください。");
                string PlayerName = Console.ReadLine();
                player.Initialize(PlayerName, rand);

                // エネミーのステータスの入力
                Console.WriteLine("エネミーの名前を入力してください。");
                string EnemyName = Console.ReadLine();
                enemy.Initialize(EnemyName, rand);

                // お互いのステータスの表示
                Console.WriteLine($"{player.name}\nHP：{player.HP} MP：{player.MP}　ATK：{player.ATK}　AGL：{player.AGL}　DFE：{player.DFE}");
                Console.WriteLine($"{enemy.name}\nHP：{enemy.HP} MP：{enemy.MP}　ATK：{enemy.ATK}　AGL：{enemy.AGL}　DFE：{enemy.DFE}");

                // どちらかのHPが0になるまで続ける
                while (player.HP > 0 && enemy.HP > 0)
                {
                    // どちらが先に攻撃するかをAGLを使って決定
                    // プレイヤーの方が速い場合
                    if(player.AGL >= enemy.AGL)
                    {
                        Console.WriteLine("行動を選択してください。\n攻撃：１　防御：２");
                        int Pselect;
                        while(true)
                        {
                            Pselect = int.Parse(Console.ReadLine());
                            if(Pselect < 1 || Pselect > 2)
                            {
                                Console.WriteLine("入力に誤りがあります。再度入力してください。");
                            }
                            else
                            {
                                break;
                            }
                        }
                        // 攻撃を選択した場合
                        if(Pselect == 1)
                        {
                            Console.WriteLine($"{player.name}の攻撃！");
                            Console.Write($"{enemy.name}");
                            enemy.takeDamage(player.attack());
                        }
                        // 防御を選択した場合
                        else
                        {
                            Console.WriteLine($"{player.name}は身を守っている");
                        }

                        // エネミーの攻撃
                        Console.WriteLine($"{enemy.name}の攻撃！");
                        Console.WriteLine($"{player.name}");
                        player.takeDamage(enemy.attack());
                    }

                    // エネミーの方が速い場合
                    else
                    {
                        // エネミーの攻撃
                        Console.WriteLine($"{enemy.name}の攻撃！");
                        Console.Write($"{player.name}");
                        player.takeDamage(enemy.attack());
                        // プレイヤーの選択
                        Console.WriteLine("行動を選択してください。\n攻撃：１　防御：２");
                        int Pselect;
                        while (true)
                        {
                            Pselect = int.Parse(Console.ReadLine());
                            if (Pselect < 1 || Pselect > 2)
                            {
                                Console.WriteLine("入力に誤りがあります。再度入力してください。");
                            }
                            else
                            {
                                break;
                            }
                        }
                        // 攻撃を選択した場合
                        if (Pselect == 1)
                        {
                            Console.WriteLine($"{player.name}の攻撃！");
                            Console.Write($"{enemy.name}");
                            enemy.takeDamage(player.attack());
                        }
                        // 防御を選択した場合
                        else
                        {
                            Console.WriteLine($"{player.name}は身を守っている");
                        }
                    }

                    // 現在の状態を出力
                    Console.WriteLine($"{player.name}　HP：{player.HP}");
                    Console.WriteLine($"{enemy.name}　HP：{enemy.HP}");
                }
                // 結果の出力
                if(player.HP <= 0)
                {
                    Console.WriteLine($"{enemy.name}の勝利！");
                }
                else if(enemy.HP <= 0)
                {
                    Console.WriteLine($"{player.name}の勝利！");
                }
            }
        }
        static void Main(string[] args)
        {
            Fight fight = new Fight();
            fight.Fighting();
        }
    }
}
