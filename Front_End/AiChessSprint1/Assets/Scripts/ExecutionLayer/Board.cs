using System;
using Actions;
using Pieces;

namespace GameBoard
{
    public class Board
    {
        //Matricies storing the current game board and the white and black pieces being used
        public string[,] GameBoard { get; private set; } = new string[8, 8];
        public Piece[,] WhiteBoard { get; private set; } = new Piece[2, 8];
        public Piece[,] BlackBoard { get; private set; } = new Piece[2, 8];

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
                this.GameBoard[0, i] = this.BlackBoard[1, i].id;
                this.BlackBoard[1, i].currPos = new int[] { 0, i };
                this.GameBoard[1, i] = this.BlackBoard[0, i].id;
                this.BlackBoard[0, i].currPos = new int[]{ 1,i};

                //White piece initialization for game board order for chess
                this.GameBoard[6, i] = this.WhiteBoard[0, i].id;
                this.WhiteBoard[0, i].currPos = new int[] { 6, i };
                this.GameBoard[7, i] = this.WhiteBoard[1, i].id;
                this.WhiteBoard[1, i].currPos = new int[] { 7, i };
            }

            //Restart match starting with White taking the first turn
            isWhite = true;
        }

        public void checkBoardPos(Piece currPiece)
        {
            int[] Position = new int[2];

            if (!this.GameBoard[currPiece.currPos[0], currPiece.currPos[1]].Equals(currPiece.id))
            {
                for (int x = 0; x < this.GameBoard.GetLength(0); x++)
                {
                    for (int y = 0; y < this.GameBoard.GetLength(1); y++)
                    {
                        if (this.GameBoard[x, y].Equals(currPiece.id))
                        {
                            Position = new int[] { x, y };
                            currPiece.currPos = Position; 
                        }
                    }
                }
            }
        }
        
        public void updateBoard(int[] currPosition, int[] dest, Piece currPiece)
        {
            this.GameBoard[currPosition[0], currPosition[1]] = "e";
            this.GameBoard[dest[0], dest[1]] = currPiece.id;
            currPiece.currPos = dest;
        }
        
        public void takeAction(char ActionType, Piece currPiece, int[] dest)
        {
            
            ///checkBoardPos(Piece);
            ///if(ActionType == 'M'){
            ///     Action.moveAction(currPiece, dest)
            ///     
            /// }elif(ActionType == 'A'){
            ///     Action.attackAction(currPiece, dest)
            ///     
            /// }
            
            //Call Action.cs file for checking validity of action
            //Once confirmed call update to perform action save
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
