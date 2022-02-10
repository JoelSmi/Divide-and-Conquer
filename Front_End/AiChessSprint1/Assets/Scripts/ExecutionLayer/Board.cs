using System;
using Actions;
using Pieces;
using BishopAI1;

namespace GameBoard
{
    public class Board
    {
        /*
         * Board On Initialization:
         * (id representation)
         * |R0 N0 B0 Q0 K0 B1 N1 R1|
         * |P0 P1 P2 P3 P4 P5 P6 P7|
         * |e  e  e  e  e  e  e  e |
         * |e  e  e  e  e  e  e  e |
         * |e  e  e  e  e  e  e  e |
         * |e  e  e  e  e  e  e  e |
         * |p0 p1 p2 p3 p4 p5 p6 p7|
         * |r0 n0 b0 q0 k0 b1 n1 r1|
         */

        //Matricies storing the current game board and the white and black pieces being used
        public Pieces.Piece[,] GameBoard { get; private set; } = new Pieces.Piece[8, 8];
        public Pieces.Piece[,] WhiteBoard { get; private set; } = new Pieces.Piece[2, 8];
        public Pieces.Piece[,] BlackBoard { get; private set; } = new Pieces.Piece[2, 8];
        public Pieces.Piece Blank = new Empty("e", "N");

        public int[] actionInitial { get; set; } = new int[2];
        public int[] actionDest { get; set; } = new int[2];

        private const int MaxActionCount = 2;
        //bool value to track turn control
        public bool isWhite { get; protected set; } = true;
        public bool hasActed { get; set; } = false;

        public Board(Pieces.Piece[,] initialWhite, Pieces.Piece[,] initialBlack)
        { 

            //Passes matrix of the peice order and their individual ids
            this.WhiteBoard = initialWhite;
            this.BlackBoard = initialBlack;

            resetBoard();
        }

        public void resetBoard()
        {
            //initial state of game board before peice setup
            this.GameBoard = new Pieces.Piece[,] {
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank},
                {Blank,Blank,Blank,Blank,Blank,Blank,Blank,Blank}
            };

            for (int i = 0; i < this.GameBoard.GetLength(0); i++)
            {
                //Black piece initialization for game board order for chess
                this.GameBoard[0, i] = this.BlackBoard[1, i];
                this.BlackBoard[1, i].currPos = new int[] { 0, i };
                this.GameBoard[1, i] = this.BlackBoard[0, i];
                this.BlackBoard[0, i].currPos = new int[]{ 1,i};

                //White piece initialization for game board order for chess
                this.GameBoard[6, i] = this.WhiteBoard[0, i];
                this.WhiteBoard[0, i].currPos = new int[] { 6, i };
                this.GameBoard[7, i] = this.WhiteBoard[1, i];
                this.WhiteBoard[1, i].currPos = new int[] { 7, i };

            }

            //Restart match starting with White taking the first turn
            isWhite = true;
        }

        //Checking to ensure the current Piece is in the correct position on the Board
        public void checkBoardPos(Pieces.Piece currPiece)
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

        //Update the GameBoard based upon the current Piece, current position, and the targeted destination
        public void updateBoard(Pieces.Piece currPiece, int[] currPos, int[] dest)
        {
            this.GameBoard[dest[0], dest[1]] = currPiece;
            this.GameBoard[currPos[0], currPos[1]] = this.Blank;
            currPiece.currPos = dest;
        }

        //given the current position and the destination, check the current position and destination to determine the type of action then return a char to indicate the action type
        public char checkActionType(int[] currPos, int[] dest)
        {
            if (currPos[0] == dest[0] && currPos[1] == dest[1])
                return 'N';
            else if (this.GameBoard[dest[0], dest[1]] == Blank)
                return 'M';
            else if (!this.GameBoard[currPos[0], currPos[1]].color.Equals(this.GameBoard[dest[0], dest[1]].color))
                return 'A';
            else
                return 'I';
        }

        //Function call is made to the Action class to check if the action type is valid or not
        public void takeAction(char ActionType, Pieces.Piece currPiece, int[] dest)
        {
            this.hasActed = true;
            int temp = 0;
            int ActionCount = 0;
            
            this.actionInitial = currPiece.currPos;
            this.actionDest = dest;

            switch (ActionType) {
                case 'M':
                    temp = Actions.Action.moveAction(this.GameBoard, currPiece, currPiece.currPos, dest);
                    if (temp > 0 && ActionCount + temp <= MaxActionCount)
                    {
                        ActionCount += temp;
                        updateBoard(currPiece, currPiece.currPos, dest);
                    }
                    break;
                case 'A':
                    temp = Actions.Action.attackAction(this.GameBoard, currPiece, currPiece.currPos, dest);
                    if (temp > 0 && ActionCount + temp <= MaxActionCount)
                    {
                        ActionCount += temp;
                        updateBoard(currPiece, currPiece.currPos, dest);
                    }
                    break;
            }
        }

        //Call to create the necessary AI components and take action
        public void getAIAction()
        {
            bool act = false, BishopTurn = true;
            //Here we will need to be able to input the board from the middle layer, for now we will create a temp board.
            //BishopAI1.Board b = new BishopAI1.Board(ConvertGameBoard());
            BishopAI1.Board b = new BishopAI1.Board(ConvertGameBoard());


            //Creating object perameters for the BishopAI function call
            BishopAI1.Piece currentCommander = b.GetPiece(0, 2);
            BishopAI1.Piece[] subordinates = { b.GetPiece(1, 0), b.GetPiece(1, 1), b.GetPiece(1, 2), b.GetPiece(0, 1) };
            BishopAI1.Piece[] LiveEnemyPlayers ={
                b.GetPiece(6, 0), b.GetPiece(6,1), b.GetPiece(6,2), b.GetPiece(6,3),
                b.GetPiece(6, 4), b.GetPiece(6,5), b.GetPiece(6,6), b.GetPiece(6,7),
                b.GetPiece(7, 0), b.GetPiece(7,1), b.GetPiece(7,2), b.GetPiece(7,3),
                b.GetPiece(7, 4), b.GetPiece(7,5), b.GetPiece(7,6), b.GetPiece(7,7),
                };

            //Creation of AIAction object using the BishopAI function
            BishopAI1.Action outgoingAction = BishopAI1.AIBishop.BishopAI(b, currentCommander, subordinates, LiveEnemyPlayers);
            int [] tempPos = outgoingAction.getOriginalCords(), tempDest = outgoingAction.getDestinationCords();
            if (tempDest[0] != tempPos[0] || tempDest[1] != tempPos[1])
            {
                //Performing the move action on the AIBoard
                b.Move(tempPos[0], tempPos[1], tempDest[0], tempDest[1]);

                char ActionType = checkActionType(tempPos, tempDest);

                if (this.GameBoard[tempPos[0], tempPos[1]].id.ToUpper().ToCharArray()[0].Equals("N"))
                {

                }

                takeAction(ActionType, this.GameBoard[tempPos[0], tempPos[1]], tempDest);

            }

            endTurn();

        }

        //Control function for switching which color has control of updating the GameBoard
        public void endTurn()
        {
            if (isWhite)
            {
                this.isWhite = false;
                return;
            }

            this.isWhite = true;
        }

        //Helper function to convert Piece[,] array to string[,] array
        public string[,] ConvertGameBoard()
        {
            string[,] StringBoard = new string[8, 8];
            for (int i = 0; i < this.GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.GameBoard.GetLength(0); j++)
                {
                    StringBoard[i, j] = this.GameBoard[i, j].id; 
                }
            }
            return StringBoard;
        }

        //helper function for printing the current state of the GameBoard
        public string printGameBoard()
        {
            string CurrentState = "";
            for (int x = 0; x < this.GameBoard.GetLength(0); x++)
            {
                if(x > 0)
                    CurrentState += "\n";
                for (int y = 0; y < this.GameBoard.GetLength(0); y++)
                {
                    CurrentState += (this.GameBoard[x, y].id + "\t");
                }
            }
            CurrentState += "\n";
            return CurrentState;
        }
    }
}
