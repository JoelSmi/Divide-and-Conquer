using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    // the image used to highlight cells that are available to move to
    public Image mOutlineImage;
    /*
     * mBoardPosition: where on the board the Cell is associated with
     * mBoard: uses the Board that has been setup
     * mRectTransform: gets the rectangle transform position of the cell
     * */
    [HideInInspector]
    public Vector2Int mBoardPosition;
    [HideInInspector]
    public BoardUI mBoardUI = null;
    [HideInInspector]
    public RectTransform mRectTransform = null;
    [HideInInspector]
    public bool isEnemy = false;

    // the current piece in the cell see BasePiece for more information
    [HideInInspector]
    public BasePiece mCurrentPiece = null;

    // sets the cells to use information from the board in their setup
    public void Setup(Vector2Int newBoardPosition, BoardUI newBoard)
    {
        mBoardPosition = newBoardPosition;
        mBoardUI = newBoard;

        mRectTransform = GetComponent<RectTransform>();
    }

    // if a piece is active disables it by calling the kill function see BasePiece
    public void RemovePiece()
    {
        if(mCurrentPiece != null)
        {
            mCurrentPiece.Kill();
        }
    }
}
