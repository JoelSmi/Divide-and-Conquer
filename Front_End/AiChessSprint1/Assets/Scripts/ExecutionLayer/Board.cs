using System;
using Actions;
using Pieces;
using BishopAI1;
using System.Collections.Generic;

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

        //Commander instantiation
        public Pieces.King WhiteKing { get; set; }
        public Pieces.Bishop[] WhiteBishops { get; set; }

        public Pieces.King BlackKing { get; set; }
        public Pieces.Bishop[] BlackBishops { get; set; }

        public int[] actionInitial { get; set; } = new int[2];
        public int[] actionDest { get; set; } = new int[2];
        public int[,] actionPositions { get; set; } = new int[5,2];

        private const int MaxTeamActionCount = 6;
        //bool value to track turn control
        public bool isWhite { get; protected set; } = true;
        public bool hasActed { get; set; } = false;

        #region Board Initialization
        public Board(Pieces.Piece[,] initialWhite, Pieces.Piece[,] initialBlack)
        { 

            //Passes matrix of the peice order and their individual ids
            this.WhiteBoard = initialWhite;
            this.BlackBoard = initialBlack;
            resetBoard();
        }

        public void resetBoard()
        {
            Pieces.Bishop WB1 = new Pieces.Bishop("b0", "White"), WB2 = new Pieces.Bishop("b1", "White");
            Pieces.Bishop BB1 = new Pieces.Bishop("B0", "Black"), BB2 = new Pieces.Bishop("B1", "Black");
            string[,] KingDelegations = new string[2, 5];
            string[,] BishopDelegations = new string[4, 4];
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

                if (this.BlackBoard[1, i].id.Equals("K0"))
                    this.BlackKing =(Pieces.King) this.BlackBoard[1, i];
                else if (this.BlackBoard[1, i].id.Equals("B0"))
                    BB1 = (Pieces.Bishop) this.BlackBoard[1, i];
                else if (this.BlackBoard[1, i].id.Equals("B1"))
                    BB2 = (Pieces.Bishop) this.BlackBoard[1, i];


                //White piece initialization for game board order for chess
                this.GameBoard[6, i] = this.WhiteBoard[0, i];
                this.WhiteBoard[0, i].currPos = new int[] { 6, i };
                this.GameBoard[7, i] = this.WhiteBoard[1, i];
                this.WhiteBoard[1, i].currPos = new int[] { 7, i };
                
                if (this.WhiteBoard[1, i].id.Equals("k0"))
                    this.WhiteKing =(Pieces.King) this.WhiteBoard[1, i];
                else if (this.BlackBoard[1, i].id.Equals("b0"))
                    WB1 = (Pieces.Bishop) this.WhiteBoard[1, i];
                else if (this.BlackBoard[1, i].id.Equals("b1"))
                    WB2 =(Pieces.Bishop) this.WhiteBoard[1, i];


                if (i < 3)
                {
                    if(i == 1)
                    {
                        BishopDelegations[0, 3] = this.WhiteBoard[1, i].id;
                        BishopDelegations[2, 3] = this.BlackBoard[1, i].id;
                    }
                    BishopDelegations[0, i] = this.WhiteBoard[0, i].id;
                    BishopDelegations[2, i] = this.BlackBoard[0, i].id;
                }
                else if (i > 4)
                {
                    if(i == 6)
                    {
                        BishopDelegations[1, 3] = this.WhiteBoard[1, i].id;
                        BishopDelegations[3, 3] = this.BlackBoard[1, i].id;
                    }
                    BishopDelegations[1, i-5] = this.WhiteBoard[0, i].id;
                    BishopDelegations[3, i-5] = this.BlackBoard[0, i].id;
                }
                else
                {
                    KingDelegations[0, i-3] = this.WhiteBoard[0, i].id;
                    KingDelegations[1, i-3] = this.BlackBoard[0, i].id;
                }

                if(i == 3)
                {
                    KingDelegations[0, i-1] = this.WhiteBoard[1, i].id;
                    KingDelegations[1, i-1] = this.BlackBoard[1, i].id;
                    KingDelegations[0, i] = this.WhiteBoard[1, i-3].id;
                    KingDelegations[1, i] = this.BlackBoard[1, i-3].id;
                    KingDelegations[0, i+1] = this.WhiteBoard[1, i+4].id;
                    KingDelegations[1, i+1] = this.BlackBoard[1, i+4].id;
                }
            }

            //Creating the Piece delegations in the peice class for the Kings
            this.WhiteKing.getDelegates(this.WhiteBoard, GetRow(KingDelegations, 0));
            this.BlackKing.getDelegates(this.BlackBoard, GetRow(KingDelegations, 1));
            //Creating the Piece delegations in the peice class for the Bishops
            WB1.getDelegates(this.WhiteBoard, GetRow(BishopDelegations, 0));
            WB2.getDelegates(this.WhiteBoard, GetRow(BishopDelegations, 1));
            BB1.getDelegates(this.BlackBoard, GetRow(BishopDelegations, 2));
            BB2.getDelegates(this.BlackBoard, GetRow(BishopDelegations, 3));
            
            this.WhiteBishops =new Pieces.Bishop[]{WB1, WB2};
            
            //this.WhiteBishops[1].getDelegates(this.WhiteBoard, GetRow(BishopDelegations, 1));
            
            this.BlackBishops = new Pieces.Bishop[] {BB1, BB2};
            //this.BlackBishops[1].getDelegates(this.BlackBoard, GetRow(BishopDelegations, 3));

            //Restart match starting with White taking the first turn
            isWhite = true;
        }
        #endregion

        #region GameBoard Checks
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
        #endregion

        #region Apply Action
        //Update the GameBoard based upon the current Piece, current position, and the targeted destination
        public void updateBoard(Pieces.Piece currPiece, int[] currPos, int[] dest)
        {
            if (this.GameBoard[dest[0], dest[1]] != Blank)
                this.GameBoard[dest[0], dest[1]].isCaptured = true;
            this.GameBoard[dest[0], dest[1]] = currPiece;
            this.GameBoard[currPos[0], currPos[1]] = this.Blank;
            currPiece.currPos = dest;
        }
        #endregion

        #region Action Checks
        //given the current position and the destination, check the current position and destination to determine the type of action then return a char to indicate the action type
        public char checkActionType(int[] currPos, int[] dest)
        {
            if (currPos[0] == dest[0] && currPos[1] == dest[1])
                return 'N';
            else if (this.GameBoard[dest[0], dest[1]] == Blank)
                return 'M';
            else if (!this.GameBoard[currPos[0], currPos[1]].color.Equals(this.GameBoard[dest[0], dest[1]].color))
                return 'A';
            //Include delegation condition
            else if (true)
                return 'D';
            else
                return 'I';
        }

        //Function call is made to the Action class to check if the action type is valid or not
        public int takeAction(char ActionType, Pieces.Piece currPiece, int[] dest)
        {
            this.hasActed = true;
            int temp = 0;
            int ActionCount = 0;
            
            this.actionInitial = currPiece.currPos;
            this.actionDest = dest;

            //Update for three command authority Actions
            switch (ActionType) {
                case 'M':
                    temp = Actions.Action.moveAction(this.GameBoard, currPiece, currPiece.currPos, dest);
                    if (temp > 0 && ActionCount + temp <= MaxTeamActionCount)
                    {
                        ActionCount += temp;
                        updateBoard(currPiece, currPiece.currPos, dest);
                    }
                    break;
                case 'A':
                    temp = Actions.Action.attackAction(this.GameBoard, currPiece, currPiece.currPos, dest);
                    if (temp > 0 && ActionCount + temp <= MaxTeamActionCount)
                    {
                        ActionCount += temp;
                        updateBoard(currPiece, currPiece.currPos, dest);
                    }
                    break;
                    
            }
            return ActionCount;
        }

        //overloaded meothod to perform the delegate action
        public int takeAction(char ActionType, int TurnActions, Pieces.Piece currPiece, string Curr, string Next)
        {
            int temp = 0, ActionCount = TurnActions;
            Commander CurrCommander = null;
            Commander NextCommander = null;

            char type = Curr[0];
            switch (type)
            {
                case 'K':
                    CurrCommander = BlackKing;
                    if (Next.Equals("B0"))
                        NextCommander = this.BlackBishops[0];
                    else if (Next.Equals("B1"))
                        NextCommander = this.BlackBishops[1];
                    break;
                case 'k':
                    CurrCommander = this.WhiteKing;
                    if (Next.Equals("b0"))
                        NextCommander = this.WhiteBishops[0];
                    else if (Next.Equals("b1"))
                        NextCommander = this.WhiteBishops[1];
                    break;
            }

            //Update for three command authority Actions
            switch (ActionType) { 
                case 'D':
                    
                    temp = Actions.Action.Delegate(currPiece, CurrCommander, NextCommander);
                    if (temp > 0 && ActionCount + temp <= MaxTeamActionCount)
                    {
                        ActionCount += temp;
                    }
                    break;
            }
            return ActionCount;
        }
        #endregion

        #region AI Call
        //Call to create the necessary AI components and take action
        public void getAIAction()
        {
            //bool act = false, BishopTurn = true;
            //Here we will need to be able to input the board from the middle layer, for now we will create a temp board.
            //BishopAI1.Board b = new BishopAI1.Board(ConvertGameBoard());
            BishopAI1.Board b = new BishopAI1.Board(ConvertGameBoard());


            //Creating object perameters for the BishopAI function call
            BishopAI1.Piece currentCommander = b.GetBishopCommander();

            BishopAI1.Piece[] subordinates = b.GetSubordinates(currentCommander);
            BishopAI1.Piece[] LiveEnemyPlayers = b.GetEnemyPieces();

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
                    if (ActionType == 'A' && Math.Abs(tempDest[0] - tempPos[0]) > 1 && Math.Abs(tempDest[1] - tempPos[1]) > 1)
                    {
                        //takeAction('M', )
                    }

                }

                takeAction(ActionType, this.GameBoard[tempPos[0], tempPos[1]], tempDest);

            }

            endTurn();

        }
        #endregion

        #region End Turn
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
        #endregion

        #region Board Access/Display
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
        public string[] GetRow(string[,] Matrix, int row)
        {
            string[] tempRow = new string[Matrix.GetLength(0)];
            for(int i = 0; i < Matrix.GetLength(0); i++)
            {
                tempRow[i] = Matrix[row, i];
            }
            return tempRow;
        }
    }
    #endregion
}
