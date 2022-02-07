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

    protected List<string> ActionLog = new List<String>();

    // Start is called before the first frame update
    void Start()
    {
        //initiates and creates the Game board
        mBoardUI.Create();

        // sets pieces onto the created
        mPieceManager.Setup(mBoardUI);

        //Initialize Execution Layer Board Object
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
        if (mPieceManager.actionTaken)
        {
            CellRelay();

            int[] currPos = { uiCurrentCellX, uiCurrentCellY };
            int[] dest = { uiTargetCellX, uiTargetCellY };
            //Gianing the character of the action performed
            char ActionType = ExecutionBoard.checkActionType(currPos, dest);

            if (ActionType == 'M' || ActionType == 'A')
            {
                
                ExecutionBoard.takeAction(ActionType, ExecutionBoard.GameBoard[currPos[0],currPos[1]], dest );
                ActionLog.Add("Current Position: " + currPos[0] + ", " + currPos[1]);
            }
            else if (ActionType == 'N')
            {
                ActionLog.Add("No Action Detected");
            }
            else
            {
                ActionLog.Add("Error: Invalid Action");
            }

            mPieceManager.actionTaken = false;
        }

        if (ExecutionBoard.hasActed)
        {
            ExecutionBoard.hasActed = false;
        }
    }

    public void EndTurn()
    {
        mPieceManager.SwitchSides(Color.white);
    }

    public void CellRelay()
    {
        uiCurrentCellX = mPieceManager.pmCurrentCellX;
        uiCurrentCellY = mPieceManager.pmCurrentCellY;
        uiTargetCellX = mPieceManager.pmTargetCellX;
        uiTargetCellY = mPieceManager.pmTargetCellY;
    }

   
}
