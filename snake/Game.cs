using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace snake;

internal class Game
{
    public Game(int speed = 4)
    {
        Settings.Speed = speed;
        Console.WindowHeight = Settings.FieldHeight + 2;
        Console.WindowWidth = Settings.FieldOutputWidth + 2;
    }

    private bool IsDefeat(Snake snake)
    {
        if (SnakeOnBorders(snake) || SnakeEatsItself(snake))
        {
            Console.WindowHeight++;
            return true;
        }

        return false;
    }

    private bool SnakeOnBorders(Snake snake)
    {
        (int x, int y) = snake.BodyCoordinates.First();
        return x == 0 || y == 0 || x >= Settings.FieldWidth || y >= Settings.FieldHeight;
    }

    private bool SnakeEatsItself(Snake snake)
    {
        for (int i = 4; i < snake.BodyCoordinates.Count; i++)
        {
            if (snake.BodyCoordinates.First() == snake.BodyCoordinates[i])
            {
                return true;
            }
        }

        return false;
    }

    public void Start()
    {
        Console.CursorVisible = false;
        Snake snake = new Snake();
        Fruit fruit = new Fruit();
        Output output = new Output();
        Thread inputThread = new Thread(new ThreadStart(snake.MoveByInput));

        output.PrintBorders();
        inputThread.Start();

        while (true)
        {
            Thread.Sleep(1000 / Settings.Speed);
            if (!fruit.FruitGenerated) fruit.GenerateFruit(snake);
            snake.EatFruit(fruit);
            snake.Move();
            output.ClearField();
            output.PrintFruit(fruit);
            output.PrintSnake(snake);

            if (IsDefeat(snake))
            {
                output.PrintDefeat();
                break;
            }
        }
    }
}