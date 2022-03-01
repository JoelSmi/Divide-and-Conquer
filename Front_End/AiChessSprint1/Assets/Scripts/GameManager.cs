using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameBoard;
using Pieces;

public class GameManager : MonoBehaviour
{
    // instantiate Class Board, Class PieceManger objects  
    public BoardUI mBoardUI;
    public PieceManager mPieceManager;
    public TextMeshProUGUI txt;
    public Button nxtTrnBtn;
    
    //Execution Layer initialization 
    private GameBoard.Board ExecutionBoard;
    #region Piece Initialization
    private static string whitecol = "White";
    private static Pieces.Piece[,] WhitePieces = new Pieces.Piece[2, 8]{ { new Pawn("p0",whitecol), new Pawn("p1",whitecol),
                    new Pawn("p2",whitecol), new Pawn("p3",whitecol), new Pawn("p4",whitecol),
                    new Pawn("p5",whitecol), new Pawn("p6",whitecol), new Pawn("p7",whitecol)},
                    {new Rook("r0",whitecol), new Knight("n0",whitecol), new Bishop("b0",whitecol),
                    new Queen("q0",whitecol), new King("k0",whitecol), new Bishop("b1",whitecol),
                    new Knight("n1",whitecol),new Rook("r1",whitecol)} };

    private static string blackcol = "Black";
    private static Pieces.Piece[,] BlackPieces = new Pieces.Piece[2, 8] { { new Pawn("P0",blackcol), new Pawn("P1",blackcol),
                    new Pawn("P2",blackcol), new Pawn("P3",blackcol), new Pawn("P4",blackcol),
                    new Pawn("P5",blackcol) , new Pawn("P6",blackcol), new Pawn("P7",blackcol)},
                    {new Rook("R0",blackcol), new Knight("N0",blackcol), new Bishop("B0",blackcol),
                    new Queen("Q0",blackcol), new King("K0",blackcol), new Bishop("B1",blackcol),
                    new Knight("N1",blackcol),new Rook("R1",blackcol)} };
    #endregion

    protected int uiCurrentCellX, uiCurrentCellY, uiTargetCellX, uiTargetCellY;

    //Action Log
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
        
        ExecutionBoard = new Board(WhitePieces, BlackPieces);
    }

    // Update is called once per frame
    void Update()
    {


        #region UI > EL Update
        if (mPieceManager.GetTurnCount() == 4)
        {
            mPieceManager.ResetTurnCount();
            mPieceManager.actionTaken = true;
        }
        string TempLogBuff = "";
        if (mPieceManager.actionTaken && mPieceManager.mIsKingAlive)
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
                TempLogBuff += ("Initial: " + currPos[0] + ", " + currPos[1] + "\n");
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
            
            EndTurn();
            
            mPieceManager.actionTaken = false;
            mPieceManager.SwitchSides(Color.black);            
        }
        #endregion

        #region EL > AI Call
        //update to the UI when the Execution Layer has been updated by the AI 
        if (!ExecutionBoard.isWhite && mPieceManager.mIsKingAlive)
        {

            ExecutionBoard.getAIAction();

            TempLogBuff += "AI Action:\n";
            TempLogBuff += ExecutionBoard.printGameBoard() + "\n";
            
            EndTurn();
        }
        #endregion

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

            //Making sure there is indeed a piece to be moved, might be a redundant/useless check
            if (mBoardUI.mAllCells[initial[0], initial[1]].mCurrentPiece != null)
            {
                BasePiece tempPiece = mBoardUI.mAllCells[initial[0], initial[1]].mCurrentPiece;
                tempPiece.mTargetCell = mBoardUI.mAllCells[dest[0], dest[1]];
                tempPiece.MoveAIPiece();
            }
        }
        #endregion

        #region ActionLog
        if (!TempLogBuff.Equals(""))
        {
            lock(this.WriteLock)
            {
                StreamWriter file = new(ActionLog, append: true);
                file.WriteLine(TempLogBuff);
                file.Close();
            }
            
        }
        #endregion

        if (!mPieceManager.mIsKingAlive)
        {
            ExecutionBoard = new Board(WhitePieces, BlackPieces);
        }

        #region UI Checks
        #endregion
    }


    public void CellRelay()
    {
        uiCurrentCellX = mPieceManager.pmCurrentCellX;
        uiCurrentCellY = mPieceManager.pmCurrentCellY;
        uiTargetCellX = mPieceManager.pmTargetCellX;
        uiTargetCellY = mPieceManager.pmTargetCellY;
    }
    
    public void EndTurn()
    {
        if (ExecutionBoard.BlackKing.isCaptured == true || ExecutionBoard.WhiteKing.isCaptured == true)
        {
            mPieceManager.mIsKingAlive = false;
        }
    }

    //switches between moving and attacking using the button on screen
    public void moveOrAttackBttn()
    {
        if (mPieceManager.attacking)
        {
            txt.text = "Moving";
            mPieceManager.attacking = false;
        }
        else
        {
            txt.text = "Attacking";
            mPieceManager.attacking = true;
        }
    }

    // function attached to the NextTurnButton in scene. manually progresses the phase
    public void NextTurnButton()
    {
        mPieceManager.IncreaseTurnCnt();
        if (mPieceManager.GetTurnCount() == 1)
        {
            nxtTrnBtn.GetComponent<Image>().color = new Color(0.85f, 0.20f, 0.20f);
        }
        else if (mPieceManager.GetTurnCount() == 2)
        {
            nxtTrnBtn.GetComponent<Image>().color = new Color(1f, 0.9f, 0f);
        }
        else if (mPieceManager.GetTurnCount() == 3)
        {
            nxtTrnBtn.GetComponent<Image>().color = new Color(0.9f, 0.5f, 0f);
        }
        else
        {
            nxtTrnBtn.GetComponent<Image>().color = new Color(0.85f, 0.20f, 0.20f);
        }
     }

}
