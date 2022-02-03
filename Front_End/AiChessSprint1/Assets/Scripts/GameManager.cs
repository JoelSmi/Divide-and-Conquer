using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // instantiate Class Board, Class PieceManger objects  
    public BoardUI mBoardUI;
    public PieceManager mPieceManager;

    protected int uiCurrentCellX, uiCurrentCellY, uiTargetCellX, uiTargetCellY;



    // Start is called before the first frame update
    void Start()
    {
        //initiates and creates the Game board
        mBoardUI.Create();

        // sets pieces onto the created
        mPieceManager.Setup(mBoardUI);
    }

    // Update is called once per frame
    void Update()
    {
        if (mPieceManager.actionTaken)
        {
            CellRelay();

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
