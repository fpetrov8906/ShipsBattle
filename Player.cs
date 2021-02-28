using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BattleShips
{
    public class Player
    {
        public int X = 1;
        public int Y = 0;
        private ConsoleColor PlayerColor;
        private string PlayerMarker;
        public Player()
        {
            PlayerMarker = "#";
            PlayerColor = ConsoleColor.Blue;
            
        }

        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(Y, X);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}
