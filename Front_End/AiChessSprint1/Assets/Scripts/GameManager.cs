using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using GameBoard;
using Actions;
using Pieces;

public class GameManager : MonoBehaviour
{
    // instantiate Class Board, Class PieceManger objects  
    public BoardUI mBoardUI;
    public PieceManager mPieceManager;
    public TextMeshProUGUI txt;
    public Button nxtTrnBtn;
    public Button attckButton;
    public GameObject diceRoll;
    public GameObject marginTable;

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

    //UI variables and control structures
    protected List<int> uiCurrentCellX = new List<int>();
    protected List<int> uiCurrentCellY = new List<int>();
    protected List<int> uiTargetCellX = new List<int>();
    protected List<int> uiTargetCellY = new List<int>();
    private int moveCount = 0;
    // Updates to animations, etc.
    public bool uiUpdating = false;
    private const float UI_WAIT_TIME = 1.0f; // One second
    public float uiScheduler = 0.0f;
    public bool dieIsRolling = false;

    //AI variables and control structrues
    private int AIMoveCount = 0;
    private int AIMoveMax = 0;
    private const int AIActionMax = 6;
    private int AIActionCount = 0;
    private bool isAttacking = false;

    //Action Log
    protected string ActionLog = "ActionLog.txt";
    private object WriteLock = new object();

    // Start is called before the first frame update
    void Start()
    {
        StreamWriter file = new(ActionLog, append: false);
        file.Flush();
        file.Close();
        //initiates and creates the Game board
        mBoardUI.Create();

        // sets pieces onto the created
        mPieceManager.Setup(mBoardUI, this);

        ExecutionBoard = new Board(WhitePieces, BlackPieces);

        KingAI1.Board b = new KingAI1.Board(ExecutionBoard.ConvertGameBoard());
        ExecutionBoard.KingAI = new KingAI1.AIKing(b);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dieIsRolling)
        {
            if (!mPieceManager.mIsKingAlive)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            // Time difference between each update call incremented
            uiScheduler += Time.deltaTime;

            #region UI > EL Call
            if (mPieceManager.actionTaken && mPieceManager.mIsKingAlive)
            {
                CellRelay();
                moveCount++;
                mPieceManager.actionTaken = false;

            }

            string TempLogBuff = "";

            if (mPieceManager.GetTurnCount() == 4)
            {

                TempLogBuff += "User Moves:\n";
                for (int i = 0; i <= moveCount - 1; i++)
                {
                    int[] currPos = { (7 - uiCurrentCellY[i]), uiCurrentCellX[i] };
                    int[] dest = { (7 - uiTargetCellY[i]), uiTargetCellX[i] };


                    TempLogBuff += ExecutionBoard.UIAction(currPos, dest);
                }

                TempLogBuff += ExecutionBoard.printGameBoard();
                PrintLog(TempLogBuff);
                TempLogBuff = "";

                mPieceManager.actionTaken = false;
                mPieceManager.SwitchSides(Color.black);
                mPieceManager.Delegation = false;
                mPieceManager.IncreaseTurnCnt();
                ExecutionBoard.endTurn();
                EndTurn();
            }
            #endregion

            if (mPieceManager.GetTurnCount() == 5)
            {
                #region EL > AI Call
                //Updated AI update calls
                nxtTrnBtn.enabled = false;
                if (!ExecutionBoard.isWhite && mPieceManager.mIsKingAlive)
                {
                    //Initial call to gather all action information from the AI
                    if (this.AIMoveMax == 0 && this.AIActionCount == 0)
                    {
                        ExecutionBoard.getAIAction();
                    }

                    // There will be a delay between each action instead of
                    // between each animation, as some actions consist of multiple
                    // animations (Knights/Royalty moving more than one space)
                    if (uiScheduler > UI_WAIT_TIME)
                    {
                        if (this.AIActionCount < AIActionMax && this.AIMoveMax == 0)
                        {
                            getAIActionSet(this.AIActionCount);

                            if (ExecutionBoard.AIActions[this.AIActionCount].getIsActing())
                            {
                                TempLogBuff += "\nAI Action #" + this.AIActionCount + ":\n";
                                TempLogBuff += ExecutionBoard.AIActions[this.AIActionCount].stringAction();
                                if (ExecutionBoard.AIActions[this.AIActionCount].getIsAttack())
                                    PrintLog("Roll for Attack: " + ExecutionBoard.AIActions[this.AIActionCount].getRoll());
                            }

                            this.AIActionCount++;
                        }
                    }

                    //Should be run for all movement steps in a function to
                    //update the UI for every processing the action being taken
                    if (this.AIMoveCount < this.AIMoveMax && !dieIsRolling)
                    {
                        // UI is not already updating with an action and time between last UI update is greater than the wait time
                        if (!uiUpdating)
                        {
                            uiUpdating = true;
                            ApplyAIMove(this.AIMoveCount);

                            if (this.AIMoveCount == this.AIMoveMax - 1 && ExecutionBoard.AIActions[this.AIActionCount - 1].getIsAttack())
                            {
                                rollTheDice(ExecutionBoard.AttackRoll);

                            }

                            if (!dieIsRolling)
                                this.AIMoveCount++;
                        }
                    }

                    //Incrementing the global AIAction count and resetting variables for the next action from the AI
                    if (ExecutionBoard.hasActed)
                    {
                        TempLogBuff += "Action Count: " + this.AIActionCount + "\n" + "Max Move Count: " + this.AIMoveMax + "\n" + "Move Count: " + this.AIMoveCount + "\n";
                        this.AIMoveMax = 0;
                        this.AIMoveCount = 0;
                        ExecutionBoard.hasActed = false;
                        uiScheduler = 0.0f; // Reset UI wait timer
                    }

                    //Once all actions have been processed, print the board and end the AI's turn
                    if (this.AIActionCount == AIActionMax)
                    {
                        endAIActions();
                        mPieceManager.ResetTurnCount();
                        nxtTrnBtn.enabled = true;
                        TempLogBuff += ExecutionBoard.printGameBoard();
                    }
                }
                #endregion
            }

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
            ShowCorps(turnCount);

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
                nxtTrnBtn.GetComponent<Image>().color = new Color(1f, 1f, 1.0f);
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
    }

    public void PrintLog(string TempLogBuff) {
        lock (this.WriteLock) {
            StreamWriter file = new(ActionLog, append: true);
            file.WriteLine(TempLogBuff);
            file.Close();
        }
    }

    #region Execution Layer > UI

    public void UpdateUI(int[] initial, int[] dest)
    {
        //Making sure there is indeed a piece to be moved, might be a redundant/useless check
        if (mBoardUI.mAllCells[initial[1], 7 - initial[0]].mCurrentPiece != null)
        {
            //PrintLog("Starting; \nRow: " + initial[0] + "; Col: " + initial[1]);
            //PrintLog("Destination; \nRow: " + dest[0] + "; Col: " + dest[1]);
            BasePiece tempPiece = mBoardUI.mAllCells[initial[1], 7 - initial[0]].mCurrentPiece;
            tempPiece.mTargetCell = mBoardUI.mAllCells[dest[1], 7 - dest[0]];
            tempPiece.MoveAIPiece();
        }
    }

    #endregion

    //Helper function to gather the necessary information and set the variables for action traversal
    public void getAIActionSet(int idx)
    {
        //getting the AI Actions set in Execution Layer
        if (ExecutionBoard.AIActions[idx].getIsActing() == false)
            return;
        ExecutionBoard.actionPositions = ExecutionBoard.AIActions[idx].getPath();
        ExecutionBoard.actionInitial = ExecutionBoard.AIActions[idx].getOriginalCords();
        ExecutionBoard.actionDest = ExecutionBoard.AIActions[idx].getDestinationCords();
        
        if ((ExecutionBoard.GameBoard[ExecutionBoard.actionInitial[0], ExecutionBoard.actionInitial[1]].color.Equals("Black")))
        {
            if (ExecutionBoard.AIActions[idx].getIsAttack())
            {
                ExecutionBoard.AttackRoll = ExecutionBoard.AIActions[idx].getRoll();
                ExecutionBoard.ActionCount += ExecutionBoard.takeAction('A', ExecutionBoard.GameBoard[ExecutionBoard.actionInitial[0], ExecutionBoard.actionInitial[1]], true);
            }
            else
            {
                ExecutionBoard.ActionCount += ExecutionBoard.takeAction('M', ExecutionBoard.GameBoard[ExecutionBoard.actionInitial[0], ExecutionBoard.actionInitial[1]], true);
            }
        }

        this.AIMoveMax = ExecutionBoard.actionPositions.Count;
        this.AIMoveCount = 0;
    }

    public void ApplyAIMove(int count)
    {
        int[] tempPos = ExecutionBoard.actionInitial;
        int[] destPos = ExecutionBoard.actionPositions[count];

        if(count != 0)
        {
            tempPos = ExecutionBoard.actionPositions[count-1];
        }

        if (count == this.AIMoveMax - 1) {
            ExecutionBoard.hasActed = true;
        }

        UpdateUI(tempPos, destPos);
    }

    public void endAIActions()
    {
        this.AIMoveCount = 0;
        this.AIMoveMax = 0;
        this.AIActionCount = 0;

        ExecutionBoard.actionPositions.Clear();
        ExecutionBoard.resetCount();
        ExecutionBoard.endTurn();

        //GameManager end turn function
        EndTurn();
    }

    public void CellRelay()
    {
        uiCurrentCellX.Add(mPieceManager.pmCurrentCellX);
        uiCurrentCellY.Add(mPieceManager.pmCurrentCellY);
        uiTargetCellX.Add(mPieceManager.pmTargetCellX);
        uiTargetCellY.Add(mPieceManager.pmTargetCellY);
        
    }
    public int UIAttackRoll()
    {
        return Actions.Action.rollAttack();
    }
    
    public void EndTurn()
    {
        if (ExecutionBoard.BlackKing.isCaptured == true || ExecutionBoard.WhiteKing.isCaptured == true)
        {
            //mPieceManager.freeze(true);
            mPieceManager.mIsKingAlive = false;
        }
    }

    // switches between moving and attacking using the button on screen
    public void moveOrAttackBttn()
    {
        /* REMOVE */
        //rollTheDice(UnityEngine.Random.Range(1, 7));
        /* ENDREMOVE */

        if (mPieceManager.attacking)
        {
            txt.text = "Moving";
            mPieceManager.attacking = false;
            marginTable.active = false;
        }
        else
        {
            txt.text = "Attacking";
            mPieceManager.attacking = true;
            marginTable.active = true;
        }
    }

    // function attached to the NextTurnButton in scene. manually progresses the phase
    public void NextTurnButton()
    {
        mPieceManager.CommandAuthority = true;
        mPieceManager.CommanderMoved = false;
        mPieceManager.CMoveCount = 0;

        mPieceManager.IncreaseTurnCnt();
        
     }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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

    #region Dice roll animation

    // Plays a dice roll animation based on a predetermined parameter
    public void rollTheDice(int number)
    {
        //uiUpdating = true;
        if (number > 6) // Standardizing knight buffs
            number = 6;
        else if (number < 1) // Should never occur
            number = 1;
        diceRoll.active = true;
        marginTable.active = true;
        diceRoll.GetComponent<Animator>().SetTrigger("" + number);
    }

    public void keepGoing()
    {
        if (ExecutionBoard.waitBuff.isWaiting && ExecutionBoard.waitBuff.isSuccess)
        {
            ExecutionBoard.waitBuff.isNotWaiting();
            ExecutionBoard.updateBoard(ExecutionBoard.waitBuff.waitingPiece, ExecutionBoard.waitBuff.currPos, ExecutionBoard.waitBuff.destPos);
            PrintLog("Attack Successful -- roll: " + ExecutionBoard.AttackRoll);
        }
        else if(ExecutionBoard.waitBuff.isWaiting && !ExecutionBoard.waitBuff.isSuccess)
        {
            ExecutionBoard.waitBuff.isNotWaiting();
            if (ExecutionBoard.waitBuff.newPath != null)
                ExecutionBoard.AIActions[AIMoveCount - 1].setPath(ExecutionBoard.waitBuff.newPath);
            PrintLog("Attack Failed -- roll: " + ExecutionBoard.AttackRoll);
        }

        this.AIMoveCount++;
        dieIsRolling = false;
    }

    #endregion
}
