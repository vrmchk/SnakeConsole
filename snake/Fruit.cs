using System;

namespace snake;

internal class Fruit
{
    public bool FruitGenerated { get; set; }
    public (int, int) FruitCoordinate { get; private set; }

    public void GenerateFruit(Snake snake)
    {
        Random random = new Random();
        int x, y;
        while (true)
        {
            x = random.Next(1, Settings.FieldWidth);
            y = random.Next(1, Settings.FieldHeight);
            if (!snake.BodyCoordinates.Contains((x, y)))
            {
                FruitGenerated = true;
                break;
            }
        }

        FruitCoordinate = (x, y);
    }
}