using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BattleShips
{
    public class World
    {
        private string[,] Matrix;
        private int Rows;
        private int Cols;
        public List<string> ShipsOfFirstPlayer;
        public List<string> ListOfSinkShipFirstPlayer = new List<string>();
        public List<string> ListOfSinkShipSecondPlayer = new List<string>();
        public List<string> ShipsOfSecondPlayer;
        private readonly Random random = new Random();
        public StringBuilder shipsFirstPlayer;
        public int countOfShips;
        public int CounterOfSinkShipFirstPlayer => ListOfSinkShipFirstPlayer.Count;
        public int CounterOfSinkShipSecondPlayer => ListOfSinkShipSecondPlayer.Count;

        public World(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
        }
        public void Draw()
        {
            
            Matrix = new string[Rows, Cols];
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
                {
                    
                        if (IsThereASunkShip(x, y))
                        {
                            Matrix[x, y] = "X";
                            SetCursorPosition(y, x);
                            Console.Write(Matrix[x, y]);
                        }
                        else
                        {
                            Matrix[x, y] = char.ConvertFromUtf32(35);
                            SetCursorPosition(y, x);
                            Console.Write(Matrix[x, y]);
                        }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine($"First Player Sink Ship:{CounterOfSinkShipSecondPlayer}    Second Player Sink Ship:{CounterOfSinkShipFirstPlayer}");

            if(CounterOfSinkShipSecondPlayer == (Rows * Cols) / 2)
            {
                Console.WriteLine("First Player WON!!!");
            }
            if(CounterOfSinkShipFirstPlayer == (Rows * Cols) / 2)
            {
                Console.WriteLine("Second Player WON!!!");
            }
        }

        // Here we insert ships in the both lists.
        public void DrawShips()
        {
            ShipsOfFirstPlayer = new List<string>();
            ShipsOfSecondPlayer = new List<string>();
            countOfShips = (Rows * Cols) / 2;
            
            for (int i = 0; i < countOfShips; i++)
            {
                int rowCordinate = random.Next(0, Rows);
                int colCordinate = random.Next(0, Cols);
                if(i%2 == 0)
                {
                    ShipsOfFirstPlayer.Add($"{rowCordinate}-{colCordinate}");
                }
                else
                {
                    ShipsOfSecondPlayer.Add($"{rowCordinate}-{colCordinate}");
                }
            }
        } 


        public bool IsThereAShipOfFirstPlayer(int y, int x)
        {
            
            for (int i = 0; i < ShipsOfFirstPlayer.Count; i++)
            {
                var currentInfo = ShipsOfFirstPlayer[i];
                
                int currentRow = int.Parse(currentInfo[0].ToString());
                int currentCol = int.Parse(currentInfo[2].ToString());
                if (y == currentCol && x == currentRow)
                {
                    ShipsOfFirstPlayer.Remove($"{currentRow}-{currentCol}");
                    ListOfSinkShipFirstPlayer.Add($"{x}-{y}");
                    
                        return true;
                }
            }
            return false;
        }
        public bool IsThereAShipOfSecondPlayer(int y, int x)
        {

            for (int i = 0; i < ShipsOfSecondPlayer.Count; i++)
            {
                var currentInfo = ShipsOfSecondPlayer[i];
                int currentRow = int.Parse(currentInfo[0].ToString());
                int currentCol = int.Parse(currentInfo[2].ToString());
                if (y == currentCol && x == currentRow)
                {
                    ShipsOfSecondPlayer.Remove($"{currentRow}-{currentCol}");
                    ListOfSinkShipSecondPlayer.Add($"{x}-{y}");

                    return true;
                }
            }
            return false;
        }
        public void DrawSunkShip(int y, int x)
        {
            SetCursorPosition(x, y);
            Write("X");

        }
        public bool IsThereASunkShip(int x, int y)
        {
            for (int i = 0; i < ListOfSinkShipFirstPlayer.Count; i++)
            {
                var currentInfo = ListOfSinkShipFirstPlayer[i];
                int currentRow = int.Parse(currentInfo[0].ToString());
                var currentCol = int.Parse(currentInfo[2].ToString());
                if (x == currentRow && y == currentCol)
                {
                    return true;
                }
            }
            for (int i = 0; i < ListOfSinkShipSecondPlayer.Count; i++)
            {
                var currentInfo = ListOfSinkShipSecondPlayer[i];
                int currentRow = int.Parse(currentInfo[0].ToString());
                var currentCol = int.Parse(currentInfo[2].ToString());
                if (x == currentRow && y == currentCol)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsPositionWalkable(int y, int x)
        {
            if (y < 0 || x < 0 || y >= Cols|| x >= Rows)
            {
                return false;
            }
            return true;
        }
    }
}
