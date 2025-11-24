using System.Collections.Generic;

namespace Snake;

/// <summary>
/// 表示贪吃蛇游戏中的蛇，负责蛇的移动、生长和方向控制
/// </summary>
public class Snake
{
    private static int _length;
    const int Width = 16;
    const int Height = 9;
    private List<(int x, int y)> _snake;
    private static string _direction = "right";
    private int[] _lastPosition = new int[2];

    /// <summary>
    /// 构造函数，初始化蛇的初始位置、长度和方向
    /// </summary>
    public Snake()
    {
        _length = 3;
        _snake = new List<(int x, int y)>
        {
            (0, 2),
            (0, 1),
            (0, 0)
        };
        _direction = "right";
    }

    /// <summary>
    /// 移动蛇的位置
    /// </summary>
    /// <returns>移动成功返回true，撞墙或撞到自己返回false</returns>
    public bool Move()
    {
        switch (_direction)
        {
            case "up":
                // 检查是否撞墙
                if (_snake[0].x - 1 >= Height || _snake[0].x - 1 < 0)
                {
                    return false;
                }

                // 检查是否撞到自己
                if (_snake.Contains((_snake[0].x - 1, _snake[0].y)) && _snake[_snake.Count - 1] != (_snake[0].x - 1, _snake[0].y))
                {
                    return false;
                }

                _snake.Insert(0, (_snake[0].x - 1, _snake[0].y));
                _lastPosition[0] = _snake[_snake.Count - 1].x;
                _lastPosition[1] = _snake[_snake.Count - 1].y;
                _snake.RemoveAt(_snake.Count - 1);
                return true;
            case "down":
                // 检查是否撞墙
                if (_snake[0].x + 1 >= Height || _snake[0].x + 1 < 0)
                {
                    return false;
                }
                
                // 检查是否撞到自己
                if (_snake.Contains((_snake[0].x + 1, _snake[0].y)) && _snake[_snake.Count - 1] != (_snake[0].x + 1, _snake[0].y))
                {
                    return false;
                }

                _snake.Insert(0, (_snake[0].x + 1, _snake[0].y));
                _lastPosition[0] = _snake[_snake.Count - 1].x;
                _lastPosition[1] = _snake[_snake.Count - 1].y;
                _snake.RemoveAt(_snake.Count - 1);
                return true;
            case "left":
                // 检查是否撞墙
                if (_snake[0].y - 1 >= Width || _snake[0].y - 1 < 0)
                {
                    return false;
                }
                
                // 检查是否撞到自己
                if (_snake.Contains((_snake[0].x, _snake[0].y - 1)) && _snake[_snake.Count - 1] != (_snake[0].x, _snake[0].y - 1))
                {
                    return false;
                }

                _snake.Insert(0, (_snake[0].x, _snake[0].y - 1));
                _lastPosition[0] = _snake[_snake.Count - 1].x;
                _lastPosition[1] = _snake[_snake.Count - 1].y;
                _snake.RemoveAt(_snake.Count - 1);
                return true;
            case "right":
                // 检查是否撞墙
                if (_snake[0].y + 1 >= Width || _snake[0].y + 1 < 0)
                {
                    return false;
                }
                
                // 检查是否撞到自己
                if (_snake.Contains((_snake[0].x, _snake[0].y + 1)) && _snake[_snake.Count - 1] != (_snake[0].x, _snake[0].y + 1))
                {
                    return false;
                }

                _snake.Insert(0, (_snake[0].x, _snake[0].y + 1));
                _lastPosition[0] = _snake[_snake.Count - 1].x;
                _lastPosition[1] = _snake[_snake.Count - 1].y;
                _snake.RemoveAt(_snake.Count - 1);
                return true;
            default:
                return true;
        }
    }

    /// <summary>
    /// 改变蛇的移动方向
    /// </summary>
    /// <param name="newDirection">新的移动方向("up", "down", "left", "right")</param>
    public void ChangeDirection(string newDirection)
    {
        // 防止蛇反向移动（不能直接反向掉头）
        if (newDirection == "up" && _direction != "down")
        {
            _direction = "up";
        }
        else if (newDirection == "down" && _direction != "up")
        {
            _direction = "down";
        }
        else if (newDirection == "left" && _direction != "right")
        {
            _direction = "left";
        }
        else if (newDirection == "right" && _direction != "left")
        {
            _direction = "right";
        }
    }

    /// <summary>
    /// 获取蛇身位置列表
    /// </summary>
    /// <returns>包含蛇身所有坐标位置的列表</returns>
    public List<(int x, int y)> GetSnake()
    {
        return _snake;
    }

    /// <summary>
    /// 增加蛇的长度计数
    /// </summary>
    private void AddLength()
    {
        _length++;
    }

    /// <summary>
    /// 获取蛇的当前长度
    /// </summary>
    /// <returns>蛇的长度</returns>
    public int GetLength()
    {
        return _length;
    }

    /// <summary>
    /// 使蛇增长，在蛇尾添加一节身体
    /// </summary>
    public void Grow()
    {
        _snake.Insert(_snake.Count, (_lastPosition[0], _lastPosition[1]));
        AddLength();
    }
}
