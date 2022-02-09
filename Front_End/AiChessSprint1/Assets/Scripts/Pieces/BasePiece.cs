using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BasePiece : EventTrigger
{
    // the color will be used to distinguish the teams from each other
    [HideInInspector]
    public Color mColor = Color.clear;

    /*
     * mOriginalCell: the cell that a piece starts in
     * mCurrentCell: the current cell that a piece is in
     * */
    protected Cell mOriginalCell = null;
    protected Cell mCurrentCell = null;

    protected RectTransform mRectTransform = null;
    protected PieceManager mPieceManager;

    //The cell that a piece is attempting to move into
    protected Cell mTargetCell = null;

    //the amount of movement the piece can make and the cells that will be highlighted when moving the piece
    protected Vector3Int mMovement = Vector3Int.one;
    protected List<Cell> mHighlightedCells = new List<Cell>();
    
    // sets up the pieces team, sprite color, and connection to the PieceManager script
    public virtual void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        mPieceManager = newPieceManager;
        mColor = newTeamColor;
        TagSet();
        //GetComponent<Image>().color = newSpriteColor;
        mRectTransform = GetComponent<RectTransform>();
    }

    //Places the piece on the board using newCell that it recieved from PieceManager
    public void Place(Cell newCell)
    {
        //sets the  current and original cells to this cell location, and sets this piece as the current piece of this Cell
        mCurrentCell = newCell;
        mOriginalCell = newCell;
        mCurrentCell.mCurrentPiece = this;

        //sets the position of this piece to the position of the cell it is connected to
        //sets that the piece is active meaning it is visible and interactible.
        transform.position = newCell.transform.position;
        gameObject.SetActive(true);
    }

    // kills the piece and placees it back in its original cell
    public void Reset()
    {
        Kill();

        Place(mOriginalCell);
        
    }
    
    // disables the piece so it cannot be interacted with and is not visible
    public virtual void Kill()
    {
        // sets that there is no longer a piece in the cell it was in
        mCurrentCell.mCurrentPiece = null;

        gameObject.SetActive(false);
    }

    public virtual void TagSet()
    {
        if (mColor == Color.white)
            mPieceManager.mPiecePrefab.tag = "Player";

        else 
            mPieceManager.mPiecePrefab.tag = "AI";

    }

    #region Movement

    // creates the cell path to use for the highlighted cells
    private void CreateCellPath(int xDirection, int yDirection, int movement)
    {
        //the current x, and y coordinates of the piece based on its current cell
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        // a for loop to create the path based of the mMovement 
        for(int i = 1; i<= movement; i++)
        {
            // adds the direction to the current
            currentX += xDirection;
            currentY += yDirection;

            // creates a cellstate for checking possibilities
            //and then checks the state for the currentX, ,andCurrentY
            CellState cellState = CellState.None;
            cellState = mCurrentCell.mBoardUI.ValidateCell(currentX, currentY, this);


            // if the cell contatins something other than an enemy or a free state it breaks the loop
            if (cellState != CellState.Free)
                break;


            mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[currentX, currentY]);
        }
    }

    //checks the pathing options for a piece
    protected virtual void CheckPathing()
    {
        //horizontal
        CreateCellPath(1, 0, mMovement.x);
        CreateCellPath(-1, 0, mMovement.x);
        
        //Vertical
        CreateCellPath(0, 1, mMovement.y);
        CreateCellPath(0, -1, mMovement.y);

        //Upper Diagonal
        CreateCellPath(1, 1, mMovement.z);
        CreateCellPath(-1, 1, mMovement.z);

        //Lower Diagonal
        CreateCellPath(-1, -1, mMovement.z);
        CreateCellPath(1, -1, mMovement.z);

    }

    // shows the outline for the highlighted cells by enabling the outline image
    protected void ShowCells()
    {
        foreach (Cell cell in mHighlightedCells)
            cell.mOutlineImage.enabled = true;

    }

    // clears the cells that are alread highlighted 
    protected void ClearCells()
    {
        foreach (Cell cell in mHighlightedCells)
            cell.mOutlineImage.enabled = false;
        
        mHighlightedCells.Clear();
    }

    // removes the enemy piece on the target cell and moves the piece
    protected virtual void Move()
    {
        //removes Pieece from the board at target cell
        mTargetCell.RemovePiece();

        // removes this piece from its current cell
        mCurrentCell.mCurrentPiece = null;

        //sets the current cell = to the target cell
        //selects this piece as the current piece at the new current cell
        mPieceManager.UIRelay(mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y, mTargetCell.mBoardPosition.x, mTargetCell.mBoardPosition.y);
        mCurrentCell = mTargetCell;
        mCurrentCell.mCurrentPiece = this;

        // snaps the piece to the target cell thenn returns target cell to null
        transform.position = mCurrentCell.transform.position;
        mTargetCell = null;

        
    }
    #endregion

    #region Events

    // when a piece is is picked up use the base on drag function then check for possible paths and then show available cells
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        CheckPathing();

        ShowCells();
    }

    // while a piece is being held use the base for the OnDrag function then  match the  movement to the mouse
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        //matches mouse movement
        transform.position += (Vector3)eventData.delta;
        // the cell the mouse is hovering over inside the list of mHighlightedCells is set to the target cell 
        foreach(Cell cell in mHighlightedCells)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(cell.mRectTransform, Input.mousePosition))
            {
                mTargetCell = cell;
                break;
            }

            //if outside the highligted set target to null
            mTargetCell = null;
        }
    }

    // when the user release the drag follows the base OnEndDrag function
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        //removes the mHighlightedCells 
        ClearCells();

        //if there isnt a target Cell return the piece to its current position
        if (!mTargetCell)
        {
            transform.position = mCurrentCell.gameObject.transform.position;
            return;
        }
        //use the Move function
        Move();

        //switch sides based on color
        mPieceManager.SwitchSides(mColor);
        mPieceManager.actionTaken = true;
    }
    #endregion
}
