using System;

namespace Snake;

internal class Program
{
    /// <summary>
    /// 程序入口点，运行贪吃蛇游戏主循环
    /// </summary>
    /// <param name="args">命令行参数</param>
    public static void Main(string[] args)
    {
        // 游戏主循环
        while (true)
        {
            Console.WriteLine("--------------------Snake Game--------------------");
            Console.WriteLine("Use arrow keys to move the snake.");
            Console.WriteLine("Press Q to quit.");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();
            Game game = new Game();
            game.GameStart();
            // 询问是否再次游戏的循环
            while (true)
            {
                Console.WriteLine("Do you want to play again? (Y/N)");
                string input = Console.ReadLine();
                if (input == "Y" || input == "y")
                {
                    Console.Clear();
                    break;
                }
                if (input == "N" || input == "n")
                {
                    Console.WriteLine("Thank you for playing!");
                    Environment.Exit(0);
                }
                Console.Clear();
            }
        }
    }
}
