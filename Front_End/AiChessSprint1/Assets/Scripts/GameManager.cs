using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameBoard;
using Pieces;

public class GameManager : MonoBehaviour
{
    // instantiate Class Board, Class PieceManger objects  
    public BoardUI mBoardUI;
    public PieceManager mPieceManager;
    private GameBoard.Board ExecutionBoard;

    protected int uiCurrentCellX, uiCurrentCellY, uiTargetCellX, uiTargetCellY;

    protected string ActionLog = "ActionLog.txt";

    private object WriteLock = new object();

    // Start is called before the first frame update
    void Start()
    {
        StreamWriter file = new (ActionLog, append: false);
        file.Flush();
        file.Close();
        //initiates and creates the Game board
        mBoardUI.Create();

        // sets pieces onto the created
        mPieceManager.Setup(mBoardUI);

        //Initialize Execution Layer Board Object with the White and Black Matricies
        string teamColor = "White";
        Piece[,] White = new Piece[2, 8]{ { new Pawn("p0",teamColor), new Pawn("p1",teamColor),
                    new Pawn("p2",teamColor), new Pawn("p3",teamColor), new Pawn("p4",teamColor),
                    new Pawn("p5",teamColor), new Pawn("p6",teamColor), new Pawn("p7",teamColor)},
                    {new Rook("r0",teamColor), new Knight("n0",teamColor), new Bishop("b0",teamColor),
                    new Queen("q0",teamColor), new King("k0",teamColor), new Bishop("b1",teamColor),
                    new Knight("n1",teamColor),new Rook("r1",teamColor)} };

        teamColor = "Black";
        Piece[,] Black = new Piece[2, 8] { { new Pawn("P0",teamColor), new Pawn("P1",teamColor),
                    new Pawn("P2",teamColor), new Pawn("P3",teamColor), new Pawn("P4",teamColor),
                    new Pawn("P5",teamColor) , new Pawn("P6",teamColor), new Pawn("P7",teamColor)},
                    {new Rook("R0",teamColor), new Knight("N0",teamColor), new Bishop("B0",teamColor),
                    new Queen("Q0",teamColor), new King("K0",teamColor), new Bishop("B1",teamColor),
                    new Knight("N1",teamColor),new Rook("R1",teamColor)} };
        
        ExecutionBoard = new Board(White,Black);
    }

    // Update is called once per frame
    void Update()
    {
        string TempLogBuff = "";
        if (mPieceManager.actionTaken)
        {
            CellRelay();

            int[] currPos = {7 - uiCurrentCellY, uiCurrentCellX};
            int[] dest = {7 - uiTargetCellY, uiTargetCellX};

            //Gianing the character of the action performed from the Execution Layer
            char ActionType = ExecutionBoard.checkActionType(currPos, dest);

            //Apply the found action type to the execution layer
                // 'M' indicates movement; 'A' indicates acttacking
            if (ActionType == 'M' || ActionType == 'A')
            {
                
                ExecutionBoard.takeAction(ActionType, ExecutionBoard.GameBoard[currPos[0],currPos[1]], dest );
                TempLogBuff += ("initial: " + currPos[0] + ", " + currPos[1] + "\n");
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

            TempLogBuff += ExecutionBoard.printGameBoard() + "\n";
            ExecutionBoard.endTurn();
            

            mPieceManager.actionTaken = false;
            mPieceManager.SwitchSides(Color.black);
        }

        //update to the UI when the Execution Layer has been updated by the AI 
        if (!ExecutionBoard.isWhite)
        {

            ExecutionBoard.getAIAction();

            TempLogBuff += "AI Action:\n";
            TempLogBuff += ExecutionBoard.printGameBoard() + "\n";
        }

        #region Execution Layer > UI
        if (ExecutionBoard.hasActed)
        {
            ExecutionBoard.hasActed = false;

            /* 
             * Convert EL coordinates to UI coordinates
             * 
             * todo: completely redo one coordinate system to the other
             * ideally we just want to pass positions freely and not have
             * to calculate positions between each layer
             * 
             * EL/AI seem to share the same coordinate systems
             * but I believe the UI is more user friendly
             * 
             * EL/AI:   (Y,X) from top > bottom
             * UI:      (X,Y) from bottom > top
             */
            int[] initial = { ExecutionBoard.actionInitial[1], 7 - ExecutionBoard.actionInitial[0] };
            int[] dest = { ExecutionBoard.actionDest[1], 7 - ExecutionBoard.actionDest[0] };

            //Debug.Log("Initial(" + initial[0] + "," + initial[1] + ") Dest(" + dest[0] + ", " + dest[1] + ")");

            //Making sure there is indeed a piece to be moved, might be a redundant/useless check
            if (mBoardUI.mAllCells[initial[0], initial[1]].mCurrentPiece != null)
            {
                BasePiece tempPiece = mBoardUI.mAllCells[initial[0], initial[1]].mCurrentPiece;
                tempPiece.mTargetCell = mBoardUI.mAllCells[dest[0], dest[1]];
                tempPiece.MoveAIPiece();
            }
            /*
            //debugging
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    //Debug.Log("Position: " + mBoardUI.mAllCells[x, y].mBoardPosition + ", Piece: " + mBoardUI.mAllCells[x, y].mCurrentPiece);
                }
            }
            */
        }
        #endregion

        if (!TempLogBuff.Equals(""))
        {
            lock(this.WriteLock)
            {
                StreamWriter file = new(ActionLog, append: true);
                file.WriteLine(TempLogBuff);
                file.Close();
            }
            
        }
    }

    public void EndTurn()
    {
        mPieceManager.SwitchSides(Color.white);
        mPieceManager.actionTaken = true;
    }

    public void CellRelay()
    {
        uiCurrentCellX = mPieceManager.pmCurrentCellX;
        uiCurrentCellY = mPieceManager.pmCurrentCellY;
        uiTargetCellX = mPieceManager.pmTargetCellX;
        uiTargetCellY = mPieceManager.pmTargetCellY;
    }

   
}
