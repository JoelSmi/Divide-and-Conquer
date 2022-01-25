using Actions;
using Pieces;

namespace GameBoard
{
    public class Board
    {
        //Matricies storing the current game board and the white and black pieces being used
        private string[][] GameBoard = new string[8][8];
        private string[][] WhiteBoard = new string[2][8];
        private string[][] BlackBoard = new string[2][8];

        //bool value to track turn control
        bool isWhite;

        public Board(string[][] initialWhite, string [][] initialBlack)
        {
            //initial state of game board before peice setup
            this.GameBoard = new string[][] {
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"}
            };

            //Passes matrix of the peice order and their individual ids
            this.WhiteBoard = initialWhite;
            this.BlackBoard = initialBlack;
        }

        public void resetBoard()
        {
            //initial state of game board before peice setup
            this.GameBoard = new string[][] {
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"}
            };

            for(int i = 0; i < GameBoard[0]; i++)
            {
                //Black piece initialization for game board order for chess
                GameBoard[0][i] = this.BlackBoard[1][i];
                GameBoard[1][i] = this.BlackBoard[0][i];

                //White piece initialization for game board order for chess
                GameBoard[6][i] = this.WhiteBoard[0][i];
                GameBoard[7][i] = this.WhiteBoard[1][i];
            }

            //Restart match starting with White taking the first turn
            isWhite = true;
        }


    }
}
