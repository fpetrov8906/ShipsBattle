using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BattleShips
{
    public class Player2
    {
        public int X = 1;
        public int Y = 1;
        private ConsoleColor PlayerColor;
        private string PlayerMarker;
        public Player2()
        {
            PlayerMarker = "#";
            PlayerColor = ConsoleColor.Red;
            
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
