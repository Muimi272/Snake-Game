using System;
using System.Collections.Generic;

namespace Snake;

/// <summary>
/// 表示游戏中果实的类，负责果实的位置管理和随机生成
/// </summary>
public class Fruit
{
    private int[] _position = new int[2];
    private List<(int x, int y)> _snake;
    const int Width = 16;
    const int Height = 9;
    
    /// <summary>
    /// 在随机位置生成果实，确保果实不会出现在蛇身上的位置
    /// </summary>
    private void RandomFruit()
    {
        // 持续生成随机位置直到找到一个不与蛇身重叠的位置
        while (true)
        {
            _position[0] = new Random().Next(0, Height);
            _position[1] = new Random().Next(0, Width);
            if (!_snake.Contains((_position[0], _position[1])))
            {
                break;
            }
        }
    }
    
    /// <summary>
    /// 获取果实的当前位置
    /// </summary>
    /// <returns>包含果实坐标的整数数组</returns>
    public int[] GetPosition()
    {
        return _position;
    }
    
    public void Eat(List<(int x, int y)> snake)
    {
        this._snake = snake;
        RandomFruit();
    }
    
    /// <summary>
    /// 构造函数，初始化果实并生成随机位置
    /// </summary>
    /// <param name="snake">当前蛇身位置列表</param>
    public Fruit(List<(int x, int y)> snake)
    {
        this._snake = snake;
        RandomFruit();
    }
}
