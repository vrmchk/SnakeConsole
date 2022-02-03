namespace snake;

internal static class Settings
{
    public static int FieldWidth { get; set; } = 10;
    public static int FieldHeight { get; set; } = 8;
    public static int FieldOutputWidth { get; } = FieldWidth * 2;
    public static char SnakeSkin { get; set; } = '=';
    public static char HeadSkin { get; set; } = '+';
    public static char FruitSkin { get; set; } = '@';
    // static Settings()
    // {
    //     Console.WindowWidth = FieldOutputWidth + 2;
    //     Console.WindowHeight = FieldHeight + 2;
    // }

    
}