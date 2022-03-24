using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    
    //checks if both kings are still alive
    public bool mIsKingAlive = true;
    public int numPieces;
    // sets up a game object to be used as the base prefab for the game pieces
    public GameObject mPiecePrefab;

    public int pmCurrentCellX, pmCurrentCellY, pmTargetCellX, pmTargetCellY;
    public bool actionTaken = false;
    public bool attacking = false;
    // delegation variable and get set functions will let the basepiece class know if its allowed to delegate again
    private bool delegation = false;
    public bool Delegation
    {
        get { return delegation; }
        set { delegation = value; }
    }

    private bool commandAuthority = true;
    public bool CommandAuthority
    {
        get { return commandAuthority; }
        set { commandAuthority = value; }
    }
    private bool commanderMoved = false;
    public bool CommanderMoved
    {
        get { return commanderMoved; }
        set { commanderMoved = value; }
    }
            
    private int turncount = 1;

    //instantiates objects to hold the pieces
    private List<BasePiece> mWhitePieces = null;
    private List<BasePiece> mBlackPieces = null;

    //orders the pieces in a string matrix
    private string[] mPieceOrder = new string[16]
    {
        "P", "P", "P", "P", "P", "P", "P", "P",
        "R", "KN", "B", "K", "Q", "B", "KN", "R"
    };

    // for access to the entire board, used for moving to graveyards
    private BoardUI boardUI = null;

    //assigns types to the strings inside previous matrix
    private Dictionary<string, Type> mPieceLibrary = new Dictionary<string, Type>()
    {
        {"P", typeof(PawnUI)},
        {"R", typeof(RookUI)},
        {"KN", typeof(KnightUI)},
        {"B", typeof(BishopUI)},
        {"K", typeof(KingUI)},
        {"Q", typeof(QueenUI)},
    };

    // creates the pieces inside on the boardUI
    public void Setup (BoardUI newBoard)
    {
        boardUI = newBoard;
        // creates the white pieces see CreatePieces below for more info
        numPieces = 0;
        mWhitePieces = CreatePieces(Color.white, new Color32(80, 124, 159, 255), boardUI);

        // creates the black pieces see CreatePieces below for more info
        numPieces = 0;
        mBlackPieces = CreatePieces(Color.black, new Color32(210, 95, 64, 255), boardUI);

        //calls PlacePieces so the pieces are moved to their proper orientation 
        PlacePieces(1, 0, mWhitePieces, boardUI);
        PlacePieces(6, 7, mBlackPieces, boardUI);

        //calls SwitchSides
        SwitchSides(Color.black);
    }

    // instantiates the new pieces using a for loop
    private List<BasePiece> CreatePieces (Color teamColor, Color32 spriteColor, BoardUI board)
    {
        //creates a list using the basePiece class
        List<BasePiece> newPieces = new List<BasePiece>();

        //runs through the piece order string
        for (int i = 0;  i< mPieceOrder.Length; i++)
        {
            //instantiates the base prefab for all the pieces 
            GameObject newPieceObject = Instantiate(mPiecePrefab);
            newPieceObject.transform.SetParent(transform);

            // sets the game object in the center of its parent
            newPieceObject.transform.localScale = new Vector3(1, 1, 1);
            newPieceObject.transform.localRotation = Quaternion.identity;

            // finds the dictionary key for the piece then finds the type of that piece
            string key = mPieceOrder[i];
            Type pieceType = mPieceLibrary[key];

            // Naming the object for Unity view
            string colorName = teamColor == Color.white ? "RED" : "BLUE";
            newPieceObject.name = colorName + " " + pieceType + " " + i;

            //creattes a new base piece based on the type of the piece then adds it to the newpiecesvariable
            BasePiece newPiece = (BasePiece)newPieceObject.AddComponent(pieceType);
            newPieces.Add(newPiece);

            //calls to BasePiece class' Setup function
            newPiece.Setup(teamColor, spriteColor, this);
            numPieces++;
        }

        return newPieces;
    }

    //places the pieces in their designated cells on the boardUI
    private void PlacePieces(int pawnRow, int royaltyRow, List<BasePiece> pieces, BoardUI boardUI)
    {
        for (int i = 0; i < 8; i++)
        {
            // see BasePiece for more information on Place
            pieces[i].Place(boardUI.mAllCells[i, pawnRow]);

            pieces[i + 8].Place(boardUI.mAllCells[i, royaltyRow]);
        }
    }

    // sets the pieces on whether or not they can be interacted with
    // RYAN: Might remove this function entirely because this interferes with sprite movement
    private void SetInteractive(List<BasePiece> allPieces, bool value)
    {
        // sets whether or not all the pieces are available on team to be used
        foreach (BasePiece piece in allPieces)
            piece.enabled = value;
    }

    // changes the turn of who can go
    public void SwitchSides(Color color)
    {
        // checks if both kings are alive if they are not reset the game
        if (!mIsKingAlive)
        {
            ResetPieces();

            mIsKingAlive = true;

            color = Color.black;
        }
        //checks if the next turn is Black's
        bool isBlackTurn = color == Color.white ? true : false;

        //if its blacks turn next sets black to interactive otherwise sets white to be interactive
        SetInteractive(mWhitePieces, !isBlackTurn);
        SetInteractive(mBlackPieces, true);
    }

    //returns all pieces to their original state
    private void ResetPieces()
    {
        foreach (BasePiece piece in mWhitePieces)
            piece.Reset(boardUI);
        foreach (BasePiece piece in mBlackPieces)
            piece.Reset(boardUI);
    }

    public void UIRelay(int currentCellX, int currentCellY, int targetCellX, int targetCellY)
    {
        pmCurrentCellX = currentCellX;
        pmCurrentCellY = currentCellY;
        pmTargetCellX = targetCellX;
        pmTargetCellY = targetCellY;
    }
    
    // three functions for manipulating the turncount variable
    public void IncreaseTurnCnt()
    {
        turncount++;
    }
    public int GetTurnCount()
    {
        return turncount;
    }
    public void ResetTurnCount()
    {
        turncount = 1;
    }
}
