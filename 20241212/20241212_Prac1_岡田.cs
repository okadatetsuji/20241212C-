using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241212
{
    internal class Program
    {
        public class Pitcher
        {
            public int Select;
            public void SelectBoll()
            {
                int select = 0;
                while (true)
                {
                    select = int.Parse(Console.ReadLine());
                    if(select < 0 || select > 3)
                    {
                        Console.WriteLine("入力に誤りがあります。再度入力してください。");
                    }
                    else
                    {
                        Select = select;
                        break;
                    }
                }
            }
        }

        public class Game
        {
            Pitcher pitcher = new Pitcher();

            // 各カウント
            public int Hit;
            public int Strike;
            public int Boll;
            public int Out;
            public void PlayBoll()
            {
                Random random = new Random();
                int Bselect;
                Console.WriteLine("プレイボール！");

                while(Hit != 4 && Out != 3)
                {
                    Console.WriteLine("\n投げる球種を選択してください。\n０：ストレート　１：カーブ　２：スライダー　３：シンカー");
                    pitcher.SelectBoll();
                    switch (pitcher.Select)
                    {
                        case 0:
                            {
                                Console.WriteLine("あなたはストレートを選択した！");
                                break;
                            }
                            case 1:
                            {
                                Console.WriteLine("あなたはカーブを選択した！");
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("あなたはスライダーを選択した！");
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("あなたはシンカーを選択した！");
                                break;
                            }
                            default:
                            break;
                    }
                    // バッターの選ぶ数値をランダムに入力
                    Bselect = random.Next(0,3);

                    int judge = random.Next(1,100);

                    // 判定
                    // 数字が同じだった場合
                    if(pitcher.Select == Bselect)
                    {
                        Console.WriteLine("バッター打ちました！");
                        if(judge <= 50)
                        {
                            Console.WriteLine("ヒット！");
                            Hit++;
                        }
                        else if(judge > 50 && judge <= 75)
                        {
                            Console.WriteLine("アウト！");
                            Out++;
                            // 初期化
                            Strike = 0;
                            Boll = 0;
                        }
                        else
                        {
                            Console.WriteLine("ファール！");
                            if(Strike != 2)
                            {
                                Strike++;
                            }
                        }
                    }
                    // 数字が違う場合
                    else
                    {
                        if(judge <= 75)
                        {
                            Console.WriteLine("ストライク！");
                            Strike++;
                            if(Strike == 3)
                            {
                                Console.WriteLine("スリーストライク！");
                                Out++;
                                // 初期化
                                Strike = 0;
                                Boll = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("ボール！");
                            Boll++;
                            if(Boll == 4)
                            {
                                Hit++;
                            }
                        }
                    }

                    // 現在の状況を出力
                    Console.WriteLine($"ストライク{Strike}　ボール{Boll}　アウト{Out}　ヒット{Hit}");

                }
                // 結果表示
                if(Hit == 4)
                {
                    Console.WriteLine("バッターが一周！CPUの勝利！");
                }
                else if(Out == 3)
                {
                    Console.WriteLine("3アウト！Playerの勝利！");
                }
            }
        }
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayBoll();
        }
    }
}
