using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Cell
    {
        public Cell()
        {
            currentState = false;
            futureState = false;
        }

        public bool CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public bool FutureState
        {
            get { return futureState; }
            set { futureState = value; }
        }

        private bool currentState;
        private bool futureState;
    }

}
