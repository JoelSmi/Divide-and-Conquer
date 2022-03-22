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
    public Button attckButton;
    
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
        string TempLogBuff = "";
        if (mPieceManager.GetTurnCount() == 4)
        {
            mPieceManager.ResetTurnCount();
            mPieceManager.actionTaken = true;
            ExecutionBoard.endTurn();
        }

        #region UI > EL Call
        if (mPieceManager.actionTaken && mPieceManager.mIsKingAlive)
        {
            CellRelay();

            int[] currPos = { 7 - uiCurrentCellY, uiCurrentCellX };
            int[] dest = { 7 - uiTargetCellY, uiTargetCellX };

            
            TempLogBuff += ExecutionBoard.UIAction(currPos, dest);

            ExecutionBoard.endTurn();

            EndTurn();

            mPieceManager.actionTaken = false;
            mPieceManager.SwitchSides(Color.black);
        }
        #endregion

        #region EL > AI Call
        //update to the UI when the Execution Layer has been updated by the AI 
        if (!ExecutionBoard.isWhite &&  mPieceManager.mIsKingAlive)
        {

            ExecutionBoard.getAIAction();
            TempLogBuff += "AI Action:\n";
            TempLogBuff += ExecutionBoard.AIActions[0].stringAction();
            TempLogBuff += ExecutionBoard.AIActions[1].stringAction();
            TempLogBuff += ExecutionBoard.AIActions[2].stringAction();
            ApplyAIActions();

            TempLogBuff += "\n";
            TempLogBuff += ExecutionBoard.printGameBoard() + "\n";
            
            EndTurn();
        }
        #endregion

        #region ActionLog
        if (!TempLogBuff.Equals(""))
        {
            PrintLog(TempLogBuff);            
        }
        #endregion

        if (!mPieceManager.mIsKingAlive)
        {
            ExecutionBoard = new Board(WhitePieces, BlackPieces);
        }

        #region UI Checks

        int turnCount = mPieceManager.GetTurnCount();

        if (turnCount == 1)
        {
            nxtTrnBtn.GetComponent<Image>().color = CorpsColor(turnCount);
            ShowCorps(turnCount);
        }
        else if (turnCount == 2)
        {
            nxtTrnBtn.GetComponent<Image>().color = CorpsColor(turnCount);
            ShowCorps(turnCount);
        }
        else if (turnCount == 3)
        {
            nxtTrnBtn.GetComponent<Image>().color = CorpsColor(turnCount);
            ShowCorps(turnCount);
        }
        else
        {
            nxtTrnBtn.GetComponent<Image>().color = new Color(0.85f, 0.20f, 0.20f);
        }

        if (mPieceManager.attacking)
        {
            attckButton.GetComponent<Image>().color = new Color(0.85f, 0.20f, 0.20f);
        }
        else
        {
            attckButton.GetComponent<Image>().color = new Color(1f, 1f, 1.0f);
        }

        #endregion
    }

    public void PrintLog(string TempLogBuff){
        lock(this.WriteLock){
            StreamWriter file = new(ActionLog, append: true);
            file.WriteLine(TempLogBuff);
            file.Close();
        }
    }

    #region Execution Layer > UI
    public void UpdateUI(int[] initial, int[] dest)
    {
        //Making sure there is indeed a piece to be moved, might be a redundant/useless check
        if (mBoardUI.mAllCells[initial[1], 7- initial[0]].mCurrentPiece != null)
        {
            PrintLog("Starting; \nRow: " + initial[0] + "; Col: " + initial[1]);
            PrintLog("Destination; \nRow: " + dest[0] + "; Col: " + dest[1]);
            BasePiece tempPiece = mBoardUI.mAllCells[initial[1], 7 - initial[0]].mCurrentPiece;
            tempPiece.mTargetCell = mBoardUI.mAllCells[dest[1], 7 -  dest[0] ];
            tempPiece.MoveAIPiece();
        }
    }
    #endregion

    public void ApplyAIActions()
    {
        //Applying Actions to Execution Layer
        for (int idx = 0; idx < ExecutionBoard.AIActions.Length; idx++)
        {
            ExecutionBoard.actionPositions = ExecutionBoard.AIActions[idx].getPath();
            ExecutionBoard.actionInitial = ExecutionBoard.AIActions[idx].getOriginalCords();
            ExecutionBoard.actionDest = ExecutionBoard.AIActions[idx].getDestinationCords();

            if (ExecutionBoard.AIActions[idx].getIsActing() && (ExecutionBoard.GameBoard[ExecutionBoard.actionInitial[0], ExecutionBoard.actionInitial[1]].color.Equals("Black")))
            {
                if (ExecutionBoard.AIActions[idx].getIsAttack()){
                    ExecutionBoard.ActionCount += ExecutionBoard.takeAction('A', ExecutionBoard.GameBoard[ExecutionBoard.actionInitial[0], ExecutionBoard.actionInitial[1]], true);
                }
                else{
                    ExecutionBoard.ActionCount += ExecutionBoard.takeAction('M', ExecutionBoard.GameBoard[ExecutionBoard.actionInitial[0], ExecutionBoard.actionInitial[1]], true);
                }
            }

            int[] tempPos = ExecutionBoard.actionInitial;
            if (ExecutionBoard.ActionCount > -1)
            {
                foreach (int[] dest in ExecutionBoard.actionPositions)
                {
                    if ((tempPos[0] == dest[0]) && (tempPos[1] == dest[1]))
                        continue;
                    UpdateUI(tempPos, dest);
                    tempPos = dest;
                }
            }
            ExecutionBoard.hasActed = true;
        }

        ExecutionBoard.actionPositions.Clear();
        ExecutionBoard.resetCount();
        ExecutionBoard.endTurn();

        ExecutionBoard.hasActed = false;
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

    // switches between moving and attacking using the button on screen
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
        
     }

    #region UI Corps Display

    // Highlights all units in an active corps
    private void ShowCorps(int corps)
    {
        foreach (Cell cell in mBoardUI.mAllCells)
        {
            if (cell.mCurrentPiece != null) // only check cells that have pieces
            {
                if (cell.mCurrentPiece.corps == corps && cell.mCurrentPiece.mColor == Color.white && cell.mCurrentPiece.IsPlayable) // the current piece is the correct corps, and is not in the graveyard
                {
                    cell.mOutlineImage.enabled = true;
                    cell.mOutlineImage.GetComponent<Image>().color = CorpsColor(corps);
                }
                else
                    cell.mOutlineImage.enabled = false;
            }
        }
    }

    // Determines a color based on corps
    private Color CorpsColor(int corps)
    {
        if (mPieceManager.GetTurnCount() < 4)
        {
            switch (corps)
            {
                case 1:
                    return new Color(0.85f, 0.20f, 0.20f, 0.75f); // red
                case 2:
                    return new Color(1f, 0.9f, 0f, 0.75f); // yellow
                case 3:
                    return new Color(0.9f, 0.5f, 0f, 0.75f); // orange
                default:
                    return new Color(0f, 0f, 0f, 0.75f);
            }
        }
        return new Color(1.0f, 1.0f, 1.0f, 0.75f);
    }

    #endregion
}
