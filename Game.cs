using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace BattleShips
{
    public class Game
    {
        private World MyWorld;
        private Player Player1;
        private Player2 Player2;

        public int Counter = 0;
        public bool IsEnter;
        public void Start()
        {
            MyWorld = new World(20, 20);
            Player1 = new Player();
            Player2 = new Player2();
            MyWorld.DrawShips();

            RunGameLoop();
        }
        private void DrawFrame()
        {
            
            
            MyWorld.Draw();
            Player1.Draw();
            Player2.Draw();
            

        }

        private void HandlePlayerInputFirstPlayer()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(Player1.X - 1, Player1.Y))
                    {
                        Player1.X -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(Player1.X + 1, Player1.Y))
                    {
                        Player1.X += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(Player1.X, Player1.Y - 1))
                    {
                        Player1.Y -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(Player1.X, Player1.Y + 1))
                    {
                        Player1.Y += 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    if(MyWorld.IsThereAShipOfSecondPlayer(Player1.Y, Player1.X))
                    {
                        MyWorld.Draw();
                    }
                    IsEnter = true;
                    break;

                default:
                    break;
            }

        }
        private void HandlePlayerInputSecondPlayer()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(Player2.X - 1, Player2.Y))
                    {
                        Player2.X -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(Player2.X + 1, Player2.Y))
                    {
                        Player2.X += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(Player2.X, Player2.Y - 1))
                    {
                        Player2.Y -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(Player2.X, Player2.Y + 1))
                    {
                        Player2.Y += 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (MyWorld.IsThereAShipOfFirstPlayer(Player2.Y, Player2.X))
                    {
                        MyWorld.Draw();
                        
                    }
                    IsEnter = true;
                    break;

                default:
                    break;
            }

        }
        private void RunGameLoop()
        {
            
            while (true)
            {
                IsEnter = false;
                if(Counter % 2== 0)
                {
                    while(true)
                    {
                        
                        DrawFrame();
                        HandlePlayerInputFirstPlayer();
                        if(IsEnter)
                        {
                            break;
                        }
                    }
                    
                }
                else
                {
                    while (true)
                    {
                        DrawFrame();
                        HandlePlayerInputSecondPlayer();
                        if (IsEnter)
                        {
                            break;
                        }
                    }
                    
                }
                System.Threading.Thread.Sleep(5);
                Counter++;
                
            }
        }
    }
}
