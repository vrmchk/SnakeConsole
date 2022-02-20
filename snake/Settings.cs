namespace snake;

internal static class Settings
{
    private static int _speed = 8;


    public static int FieldWidth { get; set; } = 10;
    public static int FieldHeight { get; set; } = 8;
    public static int FieldOutputWidth { get; } = FieldWidth * 2;
    public static char SnakeSkin { get; set; } = '=';
    public static char HeadSkin { get; set; } = '+';
    public static char FruitSkin { get; set; } = '@';

    public static int Speed
    {
        get => _speed;
        set
        {
            if (value >= 8) _speed = 8;
            else if (value <= 1) _speed = 1;
            else _speed = value;
        }
    }
}