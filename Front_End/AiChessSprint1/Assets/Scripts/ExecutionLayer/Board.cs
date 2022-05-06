using System;
using Actions;
using Pieces;
using KingAI1;
using System.Collections.Generic;

namespace GameBoard
{
    public struct waitingAction
    {  
        public Pieces.Piece waitingPiece;
        public int[] currPos;
        public int[] destPos;
        public int Roll;
        public bool isWaiting { get; set; }
        public bool isSuccess { get; set; }
        public List<int []> newPath { get; set; }

        public waitingAction(Pieces.Piece piece, int[] pos, int[] dest, int roll)
        {
            waitingPiece = piece;
            currPos = pos;
            destPos = dest;
            Roll = roll;
            isWaiting = true;
            isSuccess = false;
            newPath = null;
        }

        public void isNotWaiting()
        {
            isWaiting = false;
        }
        public void setSucess(bool val)
        {
            isSuccess = val;
        }

        public void setPath(List<int []> path)
        {
            newPath = path;
        }
    };

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

        #region GameBoard Global Variables
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

        //Action particular variables
        public int[] actionInitial { get; set; } = new int[2];
        public int[] actionDest { get; set; } = new int[2];
        public List<int[]> actionPositions { get; set; }
        public KingAI1.Action[] AIActions { get; set; }
        public int AttackRoll { get; set; }

        public waitingAction waitBuff { get; set; }

        public KingAI1.AIKing KingAI { get; set; }
        private const int MaxTeamActionCount = 20;
        public int ActionCount { get; set; } = 0;
        //bool value to track turn control
        public bool isWhite { get; protected set; } = true;
        public bool hasActed { get; set; } = false;
        #endregion

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

            this.actionPositions = new List<int[]>();

            //Restart match starting with White taking the first turn
            isWhite = true;
        }

        public void resetCount()
        {
            this.ActionCount = 0;
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
            {
                if (char.ToUpper(currPiece.id.ToCharArray()[0]) == 'R')
                {
                    this.GameBoard[dest[0], dest[1]].isCaptured = true;
                    this.GameBoard[dest[0], dest[1]] = this.Blank;
                    return;
                }
                else
                    this.GameBoard[dest[0], dest[1]].isCaptured = true;
            }

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
        public int takeAction(char ActionType, Pieces.Piece currPiece, bool isAI)
        {
            int temp = 0;

            //Attempted applying new path checking functions
            if (isAI) {
                switch (ActionType)
                {
                    case 'M':
                        temp = Actions.Action.moveAction2(this.actionPositions, this.GameBoard, currPiece);
                        if (temp > 0 && this.ActionCount + temp <= MaxTeamActionCount)
                        {
                            this.ActionCount += temp;
                            int[] previous = currPiece.currPos;
                            foreach (int[] dest in this.actionPositions)
                            {
                                if (previous[0] == dest[0] && previous[1] == dest[1])
                                    continue;
                                updateBoard(currPiece, currPiece.currPos, dest);
                            }
                        }
                        break;
                    case 'A':
                        bool hasMoved = false;
                        //Handling the Knight move and attack feature
                        if (char.ToUpper(currPiece.id.ToCharArray()[0]) == 'N' && this.actionPositions.Count > 1) {

                            List<int[]> moveSet = new List<int[]>();
                            foreach (int[] pos in this.actionPositions)
                                moveSet.Add(pos);
                            moveSet.RemoveAt(this.actionPositions.Count - 1);
                            temp = Actions.Action.moveAction2(moveSet, this.GameBoard, currPiece);
                            if (temp > 0 && this.ActionCount + temp <= MaxTeamActionCount)
                            {
                                hasMoved = true;
                                this.ActionCount += temp;
                                int[] previous = currPiece.currPos;
                                foreach (int[] dest in moveSet)
                                {
                                    if (previous[0] == dest[0] && previous[1] == dest[1])
                                        continue;
                                    updateBoard(currPiece, currPiece.currPos, dest);
                                }
                            }
                        }

                        
                        if (hasMoved)
                        {
                            hasMoved = false;
                            this.AttackRoll++;
                        }

                        int tempRoll = this.AttackRoll;

                        temp = Actions.Action.attackAction2(this.actionPositions, this.GameBoard, currPiece, tempRoll);
                        if(temp == 0)
                        {
                            this.actionPositions.RemoveAt(this.actionPositions.Count - 1);

                            ActionCount += temp;
                            int[] previous = currPiece.currPos;

                            this.waitBuff = new waitingAction(currPiece, currPiece.currPos, this.actionPositions[this.actionPositions.Count - 1], tempRoll);
                            this.waitBuff.setSucess(false);
                            if(this.actionPositions != null)
                                    this.waitBuff.setPath(this.actionPositions);
                            break;
                        }

                        if (temp > 0 && ActionCount + temp <= MaxTeamActionCount)
                        {
                            ActionCount += temp;
                            int[] previous = currPiece.currPos;

                            this.waitBuff = new waitingAction(currPiece, currPiece.currPos, this.actionPositions[this.actionPositions.Count - 1], tempRoll);
                            this.waitBuff.setSucess(true);
                            //updateBoard(currPiece, currPiece.currPos, this.actionPositions[this.actionPositions.Count-1]);
                        }
                        break;

                }
            }
            else {

                int ActionCount = 0;

                this.actionInitial = currPiece.currPos;
                if (this.actionPositions.Count > 0 && this.actionPositions[this.actionPositions.Count - 1][0] >= 0 && this.actionPositions[this.actionPositions.Count- 1][0] < 8 && this.actionPositions[this.actionPositions.Count- 1][1] >= 0 && this.actionPositions[this.actionPositions.Count- 1][1] < 8) {
                    this.actionDest = this.actionPositions[this.actionPositions.Count - 1];
                }
                else {
                    this.actionPositions.Clear();
                    return -1; 
                }

                switch (ActionType) {
                    case 'M':
                        temp = Actions.Action.moveAction2(this.actionPositions, this.GameBoard, currPiece);
                        if (temp > 0 && ActionCount + temp <= MaxTeamActionCount)
                        {
                            ActionCount += temp;
                            updateBoard(currPiece, currPiece.currPos, this.actionDest);
                        }
                        break;
                    case 'A':
                        this.AttackRoll = Actions.Action.rollAttack();
                        int tempRoll = this.AttackRoll;


                        temp = Actions.Action.attackAction2(this.actionPositions, this.GameBoard, currPiece, tempRoll);
                        if (temp > 0 && ActionCount + temp <= MaxTeamActionCount)
                        {
                            ActionCount += temp;

                            this.waitBuff = new waitingAction(currPiece, currPiece.currPos, this.actionDest, tempRoll);
                            //updateBoard(currPiece, currPiece.currPos, this.actionDest);
                        }
                        break;
                }
                this.actionPositions.Clear();
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


        #region UI Action
        public string UIAction(int[] pos, int [] dest)
        {
            string TempLogBuff = "";
            //Gianing the character of the action performed from the Execution Layer
            char ActionType = checkActionType(pos, dest);

            //Apply the found action type to the execution layer
            // 'M' indicates movement; 'A' indicates acttacking
            if (ActionType == 'M' || ActionType == 'A')
            {
                this.actionPositions = new List<int[]>();
                this.actionPositions.Add(dest);
                this.takeAction(ActionType, this.GameBoard[pos[0], pos[1]], false);
                TempLogBuff += ("Initial: " + pos[0] + ", " + pos[1] + "\n");
                TempLogBuff += ("Destination: " + dest[0] + ", " + dest[1] + "\n");
            }
            // 'N' indicates No Action
            else if (ActionType == 'N')
            {
                TempLogBuff += ("No Action Detected\n");
            }
            else
            {
                TempLogBuff += ("Error: Invalid Action\n");
            }

            return TempLogBuff;
        }
        #endregion

        #region AI Call
        //Call to create the necessary AI components and take action
        public void getAIAction()
        {
            
            KingAI1.Board b = new KingAI1.Board(ConvertGameBoard());

            KingAI1.AIKing.KingBoardUpdate(b, this.KingAI, false);

            this.AIActions = KingAI1.AIKing.KingAIFunction(this.KingAI);
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
