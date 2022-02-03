namespace snake;

internal class Snake
{
    private Movements _previousMove = Movements.Right;

    public List<(int, int)> ListOfCoord { get; } =
        new List<(int, int)>((Settings.FieldWidth - 2) * (Settings.FieldHeight - 2))
        {
            (2, Settings.FieldHeight / 2),
            (1, Settings.FieldHeight / 2)
        };
    
    public void Move()
    {
        UpdateHeadByDefault();
        UpdateTail();
    }

    private void UpdateHeadByDefault()
    {
        (int headX, int headY) = ListOfCoord.First();

        switch (_previousMove)
        {
            case Movements.Up:
                headY--;
                break;
            case Movements.Down:
                headY++;
                break;
            case Movements.Left:
                headX--;
                break;
            case Movements.Right:
                headX++;
                break;
        }

        ListOfCoord.Insert(0, (headX, headY));
    }

    private void UpdateTail()
    {
        ListOfCoord.Remove(ListOfCoord.Last());
    }

    public void MoveByInput()
    {
        ConsoleKey GetKey()
        {
            Console.SetCursorPosition(0, Settings.FieldHeight + 1);
            ConsoleKey inputKey = Console.ReadKey().Key;
            Console.SetCursorPosition(0, Settings.FieldHeight + 1);
            Console.Write(' ');
            return inputKey;
        }

        while (true)
        {
            int newHeadX = 0, newHeadY = 0;
            bool moveDone = true;

            if (_previousMove != Movements.Up && _previousMove != Movements.Down)
            {
                switch (GetKey())
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        (newHeadX, newHeadY) = ListOfCoord.First();
                        newHeadY--;
                        _previousMove = Movements.Up;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        (newHeadX, newHeadY) = ListOfCoord.First();
                        newHeadY++;
                        _previousMove = Movements.Down;
                        break;
                    default:
                        moveDone = false;
                        break;
                }
            }

            else if (_previousMove != Movements.Left && _previousMove != Movements.Right)
            {
                switch (GetKey())
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        (newHeadX, newHeadY) = ListOfCoord.First();
                        newHeadX--;
                        _previousMove = Movements.Left;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        (newHeadX, newHeadY) = ListOfCoord.First();
                        newHeadX++;
                        _previousMove = Movements.Right;
                        break;
                    default:
                        moveDone = false;
                        break;
                }
            }

            if (moveDone)
            {
                ListOfCoord.Insert(0, (newHeadX, newHeadY));
                UpdateTail();
            }

            Thread.Sleep(350);
        }
    }

    public void EatFruit(Fruit fruit)
    {
        foreach ((int, int) coordinates in ListOfCoord)
        {
            if (coordinates == fruit.FruitCoordinates)
            {
                fruit.FruitGenerated = false;
                ListOfCoord.Insert(1, coordinates);
                return;
            }
        }
    }
}