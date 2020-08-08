using System;
using System.Threading;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        
        static void printBoard(Game mygame, int boardWidth, int boardHeight)
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    
                    if (mygame.GetCurrentState(i, j) == true)
                    {
                        Console.Write("*");
                    }  
                    else if (mygame.GetCurrentState(i, j) == false)
                    {
                        Console.Write("#");
                    }

                    //Console.Write(mygame.GetCurrentState(i, j).ToString() + '\t');
                    //Console.Write(mygame.GetCurrentState(i, j).ToString());
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int boardWidth = 20;
            int boardHeight = 20;

            Game mygame = new Game (boardWidth, boardHeight);
            //printBoard(mygame,  boardWidth,  boardHeight);
            printBoard(mygame, boardWidth, boardHeight);
            // Thread.Sleep(500);
            Console.Clear();
            for (int x = 0; x < 30; x++)
            {
                mygame.StateUpdate();
                printBoard(mygame, boardWidth, boardHeight);
                // Thread.Sleep(500);
                Console.Clear();
            }
            
        }

       
    }
}
