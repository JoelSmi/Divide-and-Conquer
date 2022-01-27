using System;
using Actions;
using Pieces;

namespace GameBoard
{
    public class Board
    {
        //Matricies storing the current game board and the white and black pieces being used
        private string[,] GameBoard = new string[8, 8];
        private Piece[,] WhiteBoard = new Piece[2, 8];
        private Piece[,] BlackBoard = new Piece[2, 8];

        //bool value to track turn control
        protected bool isWhite;

        public Board(Piece[,] initialWhite, Piece[,] initialBlack)
        { 

            //Passes matrix of the peice order and their individual ids
            this.WhiteBoard = initialWhite;
            this.BlackBoard = initialBlack;

            resetBoard();
        }

        public void resetBoard()
        {
            //initial state of game board before peice setup
            this.GameBoard = new string[,] {
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"}
            };

            for (int i = 0; i < this.GameBoard.GetLength(0); i++)
            {
                //Black piece initialization for game board order for chess
                this.GameBoard[0, i] = this.BlackBoard[1, i].getId();
                this.GameBoard[1, i] = this.BlackBoard[0, i].getId();

                //White piece initialization for game board order for chess
                this.GameBoard[6, i] = this.WhiteBoard[0, i].getId();
                this.GameBoard[7, i] = this.WhiteBoard[1, i].getId();
            }
            
            //Restart match starting with White taking the first turn
            isWhite = true;
        }
        
        public void updateBoard(int[] currPosition, int[] dest, Piece currPiece)
        {
            this.GameBoard[currPosition[0], currPosition[1]] = "e";
            this.GameBoard[dest[0], dest[1]] = currPiece.getId();
        }
        
        public void takeAction()
        {
            
        }

        public void endTurn()
        {
            if (isWhite)
            {
                this.isWhite = false;
                return;
            }

            this.isWhite = true;
        }

        public void printGameBoard()
        {
            for (int x = 0; x < this.GameBoard.GetLength(0); x++)
            {
                Console.WriteLine();
                for (int y = 0; y < this.GameBoard.GetLength(0); y++)
                {
                    Console.Write(this.GameBoard[x, y] + "\t");
                }
            }
        }
    }
}
