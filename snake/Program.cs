using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace snake
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}