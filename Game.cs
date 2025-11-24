using System;
using System.Text;
using System.Threading;

namespace Snake;

/// <summary>
/// 贪吃蛇游戏主类，负责游戏逻辑、界面显示和用户交互
/// </summary>
public class Game
{
    private static string[,] _board = new string[Height, Width];
    const int Width = 16;
    const int Height = 9;
    private static Snake _snake = new Snake();
    private static Fruit _fruit = new Fruit(_snake.GetSnake());
    private const string Body = "[■]";
    private const string Head = "[o]";
    private const string Fruit = "[●]";
    private static int _speed;

    /// <summary>
    /// 开始游戏，控制游戏主循环
    /// </summary>
    public void GameStart()
    
    {
        Console.OutputEncoding = Encoding.Unicode;
        ChooseDifficulty();
        InitBoard();
        // 游戏主循环
        while (true)
        {
            Update();
            Thread.Sleep(_speed);
            KeyboardInput();
            // 检查蛇是否撞墙或撞到自己
            if (!_snake.Move())
            {
                GameOverLose();
                break;
            }

            // 检查蛇是否吃到果实
            if (_snake.GetSnake()[0].x == _fruit.GetPosition()[0] && _snake.GetSnake()[0].y == _fruit.GetPosition()[1])
            {
                _snake.Grow();
                _fruit.Eat(_snake.GetSnake());
            }

            // 检查游戏是否胜利（填满整个游戏区域）
            if (_snake.GetLength() == Width * Height)
            {
                GameOverWin();
                break;
            }
        }
    }

    /// <summary>
    /// 初始化游戏棋盘，将所有位置设置为空白
    /// </summary>
    private void InitBoard()
    {
        _board = new string[Height, Width];
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                _board[i, j] = "[ ]";
            }
        }
    }

    /// <summary>
    /// 打印游戏棋盘到控制台
    /// </summary>
    private static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("Score: " + (_snake.GetLength() - 3));
        Console.WriteLine("--------------------------------------------------");
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            Console.Write("|");
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                Console.Write(_board[i, j]);
            }

            Console.Write("|");
            Console.WriteLine();
        }

        Console.WriteLine("--------------------------------------------------");
    }

    /// <summary>
    /// 更新游戏状态并在控制台上显示
    /// </summary>
    private void Update()
    {
        InitBoard();
        // 绘制蛇身
        for (int i = 0; i < _snake.GetSnake().Count; i++)
        {
            if (i == 0)
            {
                _board[_snake.GetSnake()[i].x, _snake.GetSnake()[i].y] = Head;
            }
            else
            {
                _board[_snake.GetSnake()[i].x, _snake.GetSnake()[i].y] = Body;
            }
        }

        // 绘制果实
        _board[_fruit.GetPosition()[0], _fruit.GetPosition()[1]] = Fruit;
        PrintBoard();
    }

    /// <summary>
    /// 处理键盘输入，控制蛇的移动方向
    /// </summary>
    private void KeyboardInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _snake.ChangeDirection("up");
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _snake.ChangeDirection("down");
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _snake.ChangeDirection("left");
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _snake.ChangeDirection("right");
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine("Game Over");
                    Console.WriteLine("Thank you for your Playing.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return;
            }
        }
    }

    /// <summary>
    /// 游戏胜利结束处理
    /// </summary>
    private void GameOverWin()
    {
        Console.WriteLine("You Win!");
        Console.WriteLine("Game Over");
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// 游戏失败结束处理
    /// </summary>
    private void GameOverLose()
    {
        Console.WriteLine("You Lose!");
        Console.WriteLine("Game Over");
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// 选择游戏难度
    /// </summary>
    public static void ChooseDifficulty()
    {
        Console.WriteLine("Choose difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine("4. Impossible");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
        string choice;
        // 输入验证循环
        while (true)
        {
            choice = Console.ReadLine();
            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Invalid choice.");
                Console.Write("Enter your choice: ");
            }
            if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3") && !choice.Equals("4") &&
                !choice.Equals("5"))
            {
                Console.WriteLine("Invalid choice.");
                Console.Write("Enter your choice: ");
            }
            else
            {
                break;
            }
        }
        switch (choice)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("You choose Easy.");
                _speed = 1000;
                Thread.Sleep(1000);
                Console.WriteLine("Are you ready?");
                Thread.Sleep(1000);
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("You choose Medium");
                _speed = 600;
                Thread.Sleep(1000);
                Console.WriteLine("Are you ready?");
                Thread.Sleep(1000);
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("You choose Hard");
                _speed = 300;
                Thread.Sleep(1000);
                Console.WriteLine("Are you ready?");
                Thread.Sleep(1000);
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();
                break;
            case "4":
                Console.Clear();
                Console.WriteLine("You choose Impossible");
                _speed = 100;
                Thread.Sleep(1000);
                Console.WriteLine("Are you ready?");
                Thread.Sleep(1000);
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();
                break;
            case "5":
                Console.Clear();
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Thank you for playing!");
                Environment.Exit(0);
                break;
        }
    }
}
