using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Game
    {
        public Game(int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            board = new Cell[boardHeight, boardWidth];

            for (int i = 0; i < _boardHeight; i++)
            {
                for (int j = 0; j < _boardWidth; j++)
                {
                    this.board[i, j] = new Cell();
                }
            }

            InitializeState();


        }
        
        private void InitializeState()
        {
            Random random = new Random();
            /*
            for (int i = 0; i < _boardHeight*_boardWidth*0.2; i++)
            {
                int rn = random.Next(0, 1000);
                board[rn % _boardHeight, rn % _boardWidth].CurrentState = true;
            }*/

            board[1, 1].CurrentState = true;
            board[2, 2].CurrentState = true;
            board[3, 2].CurrentState = true;
            board[3, 1].CurrentState = true;
            board[3, 0].CurrentState = true;
            //StateUpdate();
        }
        
        public void StateUpdate()
        {
            FutureState();
            for (int i = 0; i < _boardHeight; i++)
            {
                for (int j = 0; j < _boardWidth; j++)
                {
                    board[i, j].CurrentState = board[i, j].FutureState;
                }
            }
        }

        public bool GetCurrentState(int i, int j)
        {
            return board[i, j].CurrentState;
        }

        private void FutureState()
        {
            for(int i = 0; i < _boardHeight; i++)
            {
                for (int j = 0; j < _boardWidth; j++)
                {
                    
                    if (IsAlive(i,j) == true)
                    {
                        if (CountNeighbours(i,j) == 2 || CountNeighbours(i, j) == 3)
                        {
                            board[i, j].FutureState = true;
                        }else
                        {
                            board[i, j].FutureState = false;
                        }
                    }
                    else if (IsAlive(i, j) == false && CountNeighbours(i, j) == 3)
                    {
                        board[i, j].FutureState = true;
                    }
                    else
                    {
                        board[i, j].FutureState = false;
                    }
                }
            }

          

        }

        private int CountNeighbours(int i, int j)
        {
            int sum = 0;

            if (i == 0 && j == 0)
            {
                //Top left 
                sum = sum + AliveCount(i + 1, j) + AliveCount(i, j + 1) + AliveCount(i + 1, j + 1);  
            }else if(i == 0 && j == _boardWidth - 1)
            {
                //Top right
                sum = sum + AliveCount(i , j - 1) + AliveCount(i + 1, j) + AliveCount(i + 1, j - 1);
            }else if(i == _boardHeight - 1 && j == 0)
            {
                //Bottom Left
                sum = sum + AliveCount(i - 1, j) + AliveCount(i, j + 1) + AliveCount(i - 1, j + 1);
            }else if(i == _boardHeight -1 && j == _boardWidth -1)
            {
                //Bottom Right
                sum = sum + AliveCount(i, j - 1) + AliveCount(i - 1, j) + AliveCount(i - 1, j - 1);
            }else if( (i%(_boardHeight - 1)) > 0  && j == 0)
            {
                //Left Wall
                sum = sum + AliveCount(i - 1, j) + AliveCount(i + 1, j) + AliveCount(i, j + 1);
                sum = sum + AliveCount(i - 1, j + 1) + AliveCount(i + 1, j + 1);
            }
            else if((i % (_boardHeight - 1)) > 0 && j == _boardWidth - 1)
            {
                //Right Wall
                sum = sum + AliveCount(i - 1, j) + AliveCount(i + 1, j) + AliveCount(i, j - 1);
                sum = sum + AliveCount(i -1 , j - 1) + AliveCount(i + 1, j - 1);
            }
            else if(i == 0 && (j%(_boardWidth - 1)) > 0)
            {
                //Top wall
                sum = sum + AliveCount(i, j - 1) + AliveCount(i, j + 1) + AliveCount(i + 1, j);
                sum = sum + AliveCount(i + 1, j - 1) + AliveCount(i + 1,j + 1 );
            } else if(i == _boardHeight - 1 && (j % (_boardWidth - 1)) > 0)
            {
                //Bottom wall
                sum = sum + AliveCount(i, j - 1) + AliveCount(i, j + 1) + AliveCount(i - 1, j);
                sum = sum + AliveCount(i - 1, j - 1) + AliveCount(i - 1, j + 1);
            }else
            {
                sum = sum + AliveCount(i + 1, j) + AliveCount(i - 1, j) 
                    + AliveCount(i, j -1) + AliveCount(i, j + 1);
                sum = sum + AliveCount(i + 1, j + 1) + AliveCount(i + 1, j - 1) 
                    + AliveCount(i - 1, j + 1) + AliveCount(i - 1, j - 1);
            }

            return sum;
        }

      

        

        private bool IsAlive(int i, int j)
        {
            if (board[i, j].CurrentState)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int AliveCount(int i, int j)
        {

            if (board[i , j].CurrentState)
            {
                return 1;
            }else
            {
                return 0;
            }
        }
        

        private Cell[,] board;
        int _boardWidth;
        int _boardHeight;
    }

}
