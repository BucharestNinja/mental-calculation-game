using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("1: ENDLESS MODE");//好きなだけ暗算の練習が出来るモード
            Console.WriteLine("2: TIME ATTACK MODE");//暗算のタイムを競うモード
            Console.WriteLine("CHOOSE 1 OR 2");
            string choise = Console.ReadLine();
            
                switch (choise)
                {
                    case "1":
                        ENDLESS();
                        break;

                    case "2":
                        TIMEATTACK();
                        break;

                    default://1または2が入力されなかった場合もう一度メニューを表示する
                        Main();
                        break;
                }
            }


        static void ENDLESS()
        {
            Console.WriteLine("PRESS Z TO MENU\n");
            while (true)
            {
                Random random = new Random();
                int number1 = random.Next(100, 1000);
                int number2 = random.Next(100, 1000);
                int correct = number1 + number2;
                Console.WriteLine(number1 + "+" + number2 + "= ?");

                try
                {
                    string answer = Console.ReadLine();
                    if(answer=="z"){ break; }//Zを押すとループから脱出する
                    int answerint = int.Parse(answer);
                    if (answerint == correct)
                    {
                        Console.WriteLine("YOU ARE A GENIUS!!!");
                    }
                    else
                    {
                        Console.WriteLine("YOU ARE A IDIOT!!!");
                    }
                
                }
                catch (FormatException)
                {
                    Console.WriteLine("ENTER A NUMBER");

                }
            }
            Console.WriteLine("\n");//Zキーを押した際にこちらの処理に移りメニュー画面に戻る
            Main();
        }


        static void TIMEATTACK()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();//時間を計測する
            int i;
            for (i = 0; i < 10; i++)//10回計算に正解するとループから抜け出すようにする
            {
                Random random = new Random();
                int number1 = random.Next(100, 1000);
                int number2 = random.Next(100, 1000);
                int correct = number1 + number2;
                Console.WriteLine("\n"+ number1 + "+" + number2 + "= ?");

                for(; ; )//正解するまで入力を無限ループさせる
                {
                    try
                    {
                        string answer = Console.ReadLine();
                        int answerint = int.Parse(answer);
                        if (answerint == correct)
                        {
                            Console.WriteLine("YOU ARE A GENIUS!!!");
                            break;//正解した場合はここで入力のループから抜け出し次の問題に進む
                        }
                        else
                        {
                            Console.WriteLine("YOU ARE AN IDIOT!!!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ENTER A NUMBER");
                    }
                }
            }
            TimeSpan ts = stopwatch.Elapsed;//10回計算に成功したらタイムを表示する
            Console.WriteLine($"{ts}\n");
            Main();//メニュー画面に戻る
        }
    }
}
