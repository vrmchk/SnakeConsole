using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace snake;

internal class Output
{
    private (int, int) ConvertToOutputCoordinate((int, int) coordinate)
    {
        (int x, int y) = coordinate;
        return (x * 2, y);
    }

    public void PrintBorders()
    {
        void PrintHorizontal(int topCursorPosition)
        {
            Console.SetCursorPosition(0, topCursorPosition);
            for (int i = 0; i <= Settings.FieldOutputWidth; i++)
            {
                Console.Write("-");
            }
        }

        void PrintVertical(int leftCursorPosition)
        {
            for (int i = 0; i <= Settings.FieldHeight; i++)
            {
                Console.SetCursorPosition(leftCursorPosition, i);
                Console.Write('|');
            }
        }

        PrintHorizontal(0);
        PrintHorizontal(Settings.FieldHeight);
        PrintVertical(0);
        PrintVertical(Settings.FieldOutputWidth);
    }

    public void PrintSnake(Snake snake)
    {
        foreach ((int, int) coordinate in snake.BodyCoordinates)
        {
            (int consoleX, int consoleY) = ConvertToOutputCoordinate(coordinate);
            Console.SetCursorPosition(consoleX, consoleY);
            Console.Write(coordinate == snake.BodyCoordinates.First() ? Settings.HeadSkin : Settings.SnakeSkin);
        }

        Console.SetCursorPosition(0, Settings.FieldHeight + 1);
    }

    public void PrintFruit(Fruit fruit)
    {
        (int, int) coordinate = fruit.FruitCoordinate;
        (int consoleX, int consoleY) = ConvertToOutputCoordinate(coordinate);
        Console.SetCursorPosition(consoleX, consoleY);
        Console.Write(Settings.FruitSkin);
    }

    public void ClearField()
    {
        for (int i = 1; i < Settings.FieldHeight; i++)
        {
            Console.SetCursorPosition(1, i);
            for (int j = 0; j < Settings.FieldOutputWidth - 1; j++)
            {
                Console.Write(' ');
            }
        }
    }

    public void PrintDefeat()
    {
        Console.SetCursorPosition(0, Settings.FieldHeight + 1);
        Console.WriteLine("You lost!!!");
        Environment.Exit(0);
    }
}