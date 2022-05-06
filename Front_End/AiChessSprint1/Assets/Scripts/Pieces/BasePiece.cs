using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BasePiece : EventTrigger
{
    #region Variables

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
    //The cell that a piece is attempting to move into (public so AI can access)
    public Cell mTargetCell = null;

    //the amount of movement the piece can make and the cells that will be highlighted when moving the piece
    protected Vector3Int mMovement = Vector3Int.one;
    protected List<Cell> mHighlightedCells = new List<Cell>();

    // Stores the original base sprite while a unit is selected
    protected Sprite tempSprite = null;

    // What corp the piece belongs to (1, 2, or 3)
    public int originalcorps = 0;
    public int corps = 0;

    // If the piece is the leader of its corps
    protected bool isRook= false;
    protected bool knight = false;
    protected bool pawn = false;
    protected bool bishop = false;
    protected bool leftCommander = false;
    protected bool rightCommander = false;
    protected bool queen = false;
    protected bool king = false;
    protected bool isCommander = false;
    protected bool IsCommander
    {
        get { return isCommander; }
        set { isCommander = value; }
    }
    

    // Whether or not a piece is still alive and playable
    protected bool isPlayable = true;
    public bool IsPlayable
    {
        get { return isPlayable; }
    }

    // Piece movement
    Vector3 destination, start;
    protected bool isMoving = false;
    protected float speed = 0.5f, t = 0;

    // Colors
    readonly float[,] CORPS_COLORS =
    {
        {0.8f, 0.2f, 0.2f, 1.0f}, // Red
        {1.0f, 0.9f, 0.0f, 1.0f}, // Yellow
        {1.0f, 0.6f, 0.0f, 1.0f}, // Orange
        {0.2f, 0.4f, 0.8f, 1.0f}, // Blue
        {0.2f, 0.8f, 0.2f, 1.0f}, // Green
        {0.2f, 0.8f, 0.8f, 1.0f} // Cyan
    };

    // GameManager access
    protected GameManager gameManager;

    #endregion

    #region Update

    // Only for movement, at the moment, will separate if needed
    void Update()
    {
        if (isMoving)
        {
            t += Time.deltaTime / speed;
            transform.position = Vector3.Lerp(start, destination, t);
            if (t >= 1) // Reached destination
            {
                isMoving = false; // No longer moving
                gameManager.uiUpdating = false; // UI is free to continue updating
            }
        }
        
        if (mPieceManager.CMoveCount >= 2)
            mPieceManager.CommandAuthority = false;
        if (!mPieceManager.CommandAuthority && mPieceManager.Delegation && mPieceManager.CommanderMoved && !mPieceManager.KnightMoved)
        {
            mPieceManager.IncreaseTurnCnt();
            mPieceManager.CommandAuthority = true;
            mPieceManager.CommanderMoved = false;
            mPieceManager.CMoveCount = 0;
        }

        
    }

    #endregion

    #region Miscellaneous

    // disables the piece so it cannot be interacted with and is not visible
    public virtual void Kill(BoardUI boardUI)
    {
        // sets that there is no longer a piece in the cell it was in
        mCurrentCell.mCurrentPiece = null;

        // Scale to the size of the graveyard cells
        mRectTransform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        // Disable interaction
        isPlayable = false;

        // Remove commander status
        isCommander = false;

        // Move to a graveyard
        for (int y = 11; y >= 8; y--) // Decrement because of how the board is set up
        {
            for (int x = 7; x >= 0; x--)
            {
                if (mColor == Color.white && (y == 9 || y == 11)) // Blue graveyard
                {
                    if (boardUI.mAllCells[x, y].mCurrentPiece == null)
                    {
                        mTargetCell = boardUI.mAllCells[x, y];
                        Move(true);
                    }
                }
                else if (mColor == Color.black && (y == 8 || y == 10)) // Red graveyard
                {
                    if (boardUI.mAllCells[x, y].mCurrentPiece == null)
                    {
                        mTargetCell = boardUI.mAllCells[x, y];
                        Move(true);
                    }
                }
            }
        }
        //gameObject.SetActive(false); // disable the gameobject when not using the graveyard
    }
    public void SwitchCorps()
    {
        Debug.Log(this.corps);
        Transform child = this.transform.Find("corps");
        Image image = child.GetComponent<Image>();
        if (this.corps == 1)
        {
            this.corps = 2;
            this.originalcorps = 2;
        }
        if (this.corps == 3)
        {
            this.corps = 2;
            this.originalcorps = 2;

        }
        image.color = new Color(CORPS_COLORS[corps - 1, 0], CORPS_COLORS[corps - 1, 1], CORPS_COLORS[corps - 1, 2], CORPS_COLORS[corps - 1, 3]);
        transform.position = mCurrentCell.gameObject.transform.position;

    }

    #endregion

    #region Initialize

    // sets up the pieces team, sprite color, and connection to the PieceManager script
    public virtual void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager, GameManager newGameManager)
    {
        mPieceManager = newPieceManager;
        gameManager = newGameManager;
        mColor = newTeamColor;
        TagSet();
        mRectTransform = GetComponent<RectTransform>();
        //sets the initial original corps and corps values to the same value origianl corps will be used to return delegations
        originalcorps = CorpsSet();
        corps = originalcorps;
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
    public void Reset(BoardUI boardUI)
    {
        Kill(boardUI);

        // Reset from graveyard's scale
        mRectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Place(mOriginalCell);
    }

    public virtual void TagSet()
    {
        if (mColor == Color.white)
            mPieceManager.mPiecePrefab.tag = "Player";

        else
            mPieceManager.mPiecePrefab.tag = "AI";
    }

    //Determines what corp a piece belongs to, based on their name
    public int CorpsSet()
    {
        string[] tempName = this.name.Split(' ');
        switch (tempName[2])
        {
            case "0": // Pawn
            case "1": // Pawn
            case "2": // Pawn
            case "9": // Knight
            case "10": // Bishop
                return 2; // yellow, green
            case "5": // Pawn
            case "6": // Pawn
            case "7": // Pawn
            case "13": // Bishop
            case "14": // Knight
                return 3; // orange, cyan
            case "3": // Pawn
            case "4": // Pawn
            case "8": // Rook
            case "11": // King
            case "12": // Queen
            case "15": // Rook
                return 1; // red, blue
            default://Error
                return 0;
        }
    }

    // Changing commander status during gameplay
    protected void CommanderSet(bool enable)
    {
        this.isCommander = enable;
        Transform child = this.transform.Find("commander");
        Image image = child.GetComponent<Image>();
        image.enabled = enable;
    }

    #endregion

    #region Movement

    // creates the cell path to use for the highlighted cells
    protected virtual void CreateCellPath(int xDirection, int yDirection, int movement)
    {
        if (mPieceManager.CommandAuthority || (mCurrentCell.mCurrentPiece.isCommander && !mPieceManager.CommanderMoved) ||(mCurrentCell.mCurrentPiece.knight && mPieceManager.KnightMoved))
        {
            if (mCurrentCell.mCurrentPiece.isCommander && !mPieceManager.CommandAuthority)
                movement = 1;
            if (mCurrentCell.mCurrentPiece.isCommander && mPieceManager.CommandAuthority && mPieceManager.CommanderMoved)
                movement = movement - 1;
            //the current x, and y coordinates of the piece based on its current cell
            int currentX = mCurrentCell.mBoardPosition.x;
            int currentY = mCurrentCell.mBoardPosition.y;

            // a for loop to create the path based of the mMovement 
            for (int i = 1; i <= movement; i++)
            {
                // adds the direction to the current
                currentX += xDirection;
                currentY += yDirection;

                // creates a cellstate for checking possibilities
                //and then checks the state for the currentX, ,andCurrentY
                CellState cellState = CellState.None;
                cellState = mCurrentCell.mBoardUI.ValidateCell(currentX, currentY, this);

                // if the cell contatins something other than an enemy or a free state it breaks the loop
                if (mPieceManager.attacking)
                {
                    if (cellState == CellState.Enemy)
                    {
                        if (i == 1)
                        {
                            mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[currentX, currentY]);

                        }
                        else break;
                    }
                    break;
                }
                if (!mPieceManager.attacking)
                {
                    if (cellState != CellState.Free)
                        break;
                }


                mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[currentX, currentY]);
            }
        }
        // selects the delegation tiles if the piece picked up can be delegated back to the king
        if (mCurrentCell.mCurrentPiece.originalcorps == 1 && !mCurrentCell.mCurrentPiece.isCommander && !mPieceManager.Delegation && !mPieceManager.attacking)
        {
            if(mPieceManager.LeftTroops <=6)
                mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[0, 12]);
            if(mPieceManager.RightTroops <= 6)
                mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[5, 12]);

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
        {
            cell.mOutlineImage.enabled = true;
            if (mPieceManager.attacking)
                cell.mOutlineImage.GetComponent<Image>().color = new Color(0.85f, 0.20f, 0.20f, 1.0f);
            else
                cell.mOutlineImage.GetComponent<Image>().color = new Color(0.18f, 0.42f, 0.64f, 1.0f);
        }
    }

    // clears the cells that are alread highlighted 
    protected void ClearCells()
    {
        foreach (Cell cell in mHighlightedCells)
            cell.mOutlineImage.enabled = false;
        
        mHighlightedCells.Clear();
    }

    // removes the enemy piece on the target cell and moves the piece
    protected virtual void Move(bool beingKilled)
    {
        // Initialize movement variables
        start = mCurrentCell.transform.position;
        Cell startCell = mCurrentCell;
        destination = mTargetCell.transform.position;
        t = 0;
        
        if (mPieceManager.attacking && mTargetCell!=null) 
        {
            
            int atckrol = gameManager.UIAttackRoll();
            
            if (!AttackCheck(atckrol, mTargetCell.mCurrentPiece))
            {
                transform.position = mCurrentCell.gameObject.transform.position;
                transform.position = start;
                mTargetCell = null;
                gameManager.moveOrAttackBttn();
                mPieceManager.KnightMoved = false;
                return;
            }
            mPieceManager.KnightMoved = false;
        }
        


        //removes Pieece from the board at target cell
        mTargetCell.RemovePiece();

        // removes this piece from its current cell
        

        //sets the current cell = to the target cell
        //selects this piece as the current piece at the new current cell
        mPieceManager.UIRelay(mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y, mTargetCell.mBoardPosition.x, mTargetCell.mBoardPosition.y);        
        mPieceManager.actionTaken = true;
        if (isRook && mPieceManager.attacking)
        {
            transform.position = start;

            if (beingKilled)
                transform.position = mTargetCell.transform.position;
            mTargetCell = null;
            
            return;
        }
        mCurrentCell.mCurrentPiece = null;
        mCurrentCell = mTargetCell;
        mCurrentCell.mCurrentPiece = this;
        // snaps the piece to the target cell thenn returns target cell to null
        //transform.position = mCurrentCell.transform.position;

        // 
        transform.position = start;

        if (!beingKilled)
            isMoving = true;
        else
            transform.position = mCurrentCell.transform.position;

        mTargetCell = null;
    }

    //Unused for sprint 1 demo
    protected virtual void Attack()
    {
        //removes Piece from the board at target cell
        mTargetCell.RemovePiece();

        //sets the current cell = to the current cell
        //selects this piece as the current piece at the new current cell
        mPieceManager.UIRelay(mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y, mTargetCell.mBoardPosition.x, mTargetCell.mBoardPosition.y);
        mCurrentCell.mCurrentPiece = this;

        // snaps the piece to the target cell thenn returns target cell to null
        transform.position = mCurrentCell.transform.position;
        mTargetCell = null;

    }

    public bool AttackCheck(int roll, BasePiece defender)
    {

        
        if (this.name.Contains("BLUE"))
        {
            return false;
        }
        Debug.Log(roll);
        gameManager.rollTheDice(roll);




        if (this.pawn && roll >= 4)
        {
            if (defender.bishop && roll >= 5)
            {
                return true;
            }
            else if (roll == 6)
                return true;
            else if (defender.pawn)
            {
                return true;
            }
            else
                return false;
        }
        else if (this.isRook && roll >= 4)
        {

            if (defender.king || defender.queen || defender.knight)
            {
                return true;
            }
            else if (roll >= 5)
            {
                return true;
            }
            else { return false; }
        }
        else if (this.bishop && roll >= 3)
        {
            if (defender.pawn)
                return true;
            else if (defender.bishop && roll >= 4)
                return true;
            else if (roll >= 5)
                return true;
            else
                return false;
        }
        else if (this.knight)
        {
            if (mPieceManager.KnightMoved)
            {
                roll++;
                Debug.Log(roll);
            }

            if (defender.pawn & roll>=2 )
                return true;
            else if (roll >= 5)
                return true;
            else return false;
        }
        else if (this.queen && roll >= 2)
        {
            if (defender.pawn)
                return true;
            else if (defender.isRook && roll >= 5)
                return true;
            else if ((defender.king || defender.queen || defender.bishop || defender.knight) && roll >= 4)
                return true;
            else { return false; }
        }
        else if (this.king)
        {
            if (defender.pawn)
                return true;
            else if (defender.isRook && roll >= 5)
                return true;
            else if (roll >= 4)
                return true;
            else { return false; }
        }
        else { return false; }
    }
    #endregion

    #region Events

    // when a piece is is picked up use the base on drag function then check for possible paths and then show available cells
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlayable && mColor == Color.white)
        {
            
            base.OnBeginDrag(eventData);
            if (mPieceManager.GetTurnCount() == corps && mPieceManager.CMoveCount<2)
            {
                if(mCurrentCell.mCurrentPiece.isCommander && mPieceManager.CMoveCount<2) 
                    CheckPathing();

                if (!mCurrentCell.mCurrentPiece.isCommander && mPieceManager.CommandAuthority)
                    CheckPathing();
                if (mCurrentCell.mCurrentPiece.knight && mPieceManager.KnightMoved && mPieceManager.attacking)
                    CheckPathing();
            }
            if (!mPieceManager.Delegation && originalcorps == mPieceManager.GetTurnCount())
            {
                CreateCellPath(0, 0, 0);
            }
            ShowCells();

            //Change to the selected base sprite
            tempSprite = base.GetComponent<Image>().sprite;
            base.GetComponent<Image>().sprite = Resources.Load<Sprite>("base_select");
        }
    }

    // while a piece is being held use the base for the OnDrag function then  match the  movement to the mouse
    public override void OnDrag(PointerEventData eventData)
    {
        if (isPlayable && mColor == Color.white)
        {
            base.OnDrag(eventData);

            // Find the canvas object
            Canvas myCanvas = null;
            GameObject tempObj = GameObject.Find("Parent Canvas");
            if (tempObj != null) // Canvas was found
            {
                myCanvas = tempObj.GetComponent<Canvas>();
            }
            // Convert the position of from screen space to world space
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
            transform.position = myCanvas.transform.TransformPoint(pos);

            // the cell the mouse is hovering over inside the list of mHighlightedCells is set to the target cell 
            foreach (Cell cell in mHighlightedCells)
            {
                // Added the main camera as a parameter, since movement is slightly changed
                if (RectTransformUtility.RectangleContainsScreenPoint(cell.mRectTransform, Input.mousePosition, myCanvas.worldCamera))
                {
                    mTargetCell = cell;
                    break;
                }

                //if outside the highligted set target to null
                mTargetCell = null;
            }
        }
    }

    // when the user release the drag follows the base OnEndDrag function
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (isPlayable && mColor == Color.white)
        {
            base.OnEndDrag(eventData);
            // removes the mHighlightedCells 
            ClearCells();

            // Revert to original base sprite
            base.GetComponent<Image>().sprite = tempSprite;

            //grabs the corps sprite component
            Transform child = mCurrentCell.mCurrentPiece.transform.Find("corps");
            Image image = child.GetComponent<Image>();

            //if there isnt a target Cell return the piece to its current position
            if (!mTargetCell)
            {
                transform.position = mCurrentCell.gameObject.transform.position;
                return;
            }

            // changes the corp and corps sprite component based on what corp and cell the piece was placed in.
            #region Delegation
            if ((mTargetCell.name == "Left Delegation" || mTargetCell.name == "Right Delegation") && mCurrentCell.mCurrentPiece.corps != mCurrentCell.mCurrentPiece.originalcorps && !mPieceManager.Delegation)
            {
                if (mCurrentCell.mCurrentPiece.corps == 1)
                    mPieceManager.LeftTroops--;
                if (mCurrentCell.mCurrentPiece.corps == 3)
                    mPieceManager.RightTroops--;
                mCurrentCell.mCurrentPiece.corps = 1;
                image.color = new Color(CORPS_COLORS[corps - 1, 0], CORPS_COLORS[corps - 1, 1], CORPS_COLORS[corps - 1, 2], CORPS_COLORS[corps - 1, 3]);
                transform.position = mCurrentCell.gameObject.transform.position;
                mPieceManager.Delegation = true;
                return;
            }
            else if (mTargetCell.name == "Left Delegation" && mPieceManager.LeftTroops <= 6)
            {
                
                mCurrentCell.mCurrentPiece.corps = 2;
                image.color = new Color(CORPS_COLORS[corps - 1, 0], CORPS_COLORS[corps - 1, 1], CORPS_COLORS[corps - 1, 2], CORPS_COLORS[corps - 1, 3]);
                transform.position = mCurrentCell.gameObject.transform.position;
                mPieceManager.Delegation = true;
                mPieceManager.LeftTroops++;
                return;
            }
            else if(mTargetCell.name == "Right Delegation" && mPieceManager.RightTroops <= 6)
            {
                mCurrentCell.mCurrentPiece.corps = 3;
                image.color = new Color(CORPS_COLORS[corps - 1, 0], CORPS_COLORS[corps - 1, 1], CORPS_COLORS[corps - 1, 2], CORPS_COLORS[corps - 1, 3]);
                transform.position = mCurrentCell.gameObject.transform.position;
                mPieceManager.Delegation = true;
                mPieceManager.RightTroops++;
                return;
            }
            #endregion

            if (mPieceManager.CommandAuthority && (!mCurrentCell.mCurrentPiece.isCommander))
            {
                mCurrentCell.mOutlineImage.enabled = false;
                mPieceManager.CommandAuthority = false;
                
                
            }
            
            if (mCurrentCell.mCurrentPiece.isCommander)
            {
                mPieceManager.CMoveCount++;
                mCurrentCell.mOutlineImage.enabled = false;
                Cell target = mTargetCell;
                Move(false);
                if ((Math.Abs(mCurrentCell.mBoardPosition.x - target.mBoardPosition.x) < 2) && (Math.Abs(mCurrentCell.mBoardPosition.y - target.mBoardPosition.y) <= 1))
                {
                    
                    mPieceManager.CommanderMoved = true;
                }
                
                if ((Math.Abs(mCurrentCell.mBoardPosition.x - target.mBoardPosition.x) > 1) || (Math.Abs(mCurrentCell.mBoardPosition.y - target.mBoardPosition.y) > 1))
                {
                    mPieceManager.CommandAuthority = false;
                    mPieceManager.CommanderMoved = true;
                }
                return;

            }
            if (mCurrentCell.mCurrentPiece.knight)
            {
                
                mPieceManager.KnightMoved = true;
                mCurrentCell.mOutlineImage.enabled = false;
                
                Move(false);
                return;
            }


            //use the Move function
            mCurrentCell.mOutlineImage.enabled = false;
            Move(false);

        }
    }

    // when mouse hovers over a piece
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!isCommander)
        {
            Transform child = this.transform.Find("corps");
            Image image = child.GetComponent<Image>();
            image.enabled = true;
        }
    }

    // when mouse stops hovering over a piece
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (!isCommander)
        {
            Transform child = this.transform.Find("corps");
            Image image = child.GetComponent<Image>();
            image.enabled = false;
        }
    }
    #endregion

    #region AI movement
    /*
     * Movement for the AI pieces
     */
    public void MoveAIPiece()
    {

        
        // Initialize movement variables
        start = mCurrentCell.transform.position;
        destination = mTargetCell.transform.position;
        // the piece is not moving (a turn is skipped)
        if (destination == start)
            return;

        t = 0;

        //removes Piece from the board at target cell, if it is the enemy
        if (mTargetCell.mCurrentPiece != null && mTargetCell.mCurrentPiece.mColor == Color.white)
            mTargetCell.RemovePiece();

        // removes this piece from its current cell
        mCurrentCell.mCurrentPiece = null;

        //sets the current cell = to the target cell
        //selects this piece as the current piece at the new current cell
        mPieceManager.UIRelay(mCurrentCell.mBoardPosition.x, mCurrentCell.mBoardPosition.y, mTargetCell.mBoardPosition.x, mTargetCell.mBoardPosition.y);
        mCurrentCell = mTargetCell;
        mCurrentCell.mCurrentPiece = this;

        // 
        isMoving = true;

        mTargetCell = null;
        
    }
    #endregion

    #region Sprites
    // Adds the base to the sprite, determined by team color
    protected void CreateChildSprite(string spriteName, int extra)
    {
        GameObject childSprite = new GameObject();
        childSprite.transform.SetParent(transform);
        childSprite.transform.localScale = new Vector3(1, 1, 1);
        childSprite.name = spriteName;

        childSprite.AddComponent<Image>();
        Image image = childSprite.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(spriteName);

        RectTransform rectTransform = childSprite.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(75, 75);

        // Corps sprite
        if (extra == 1)
            image.enabled = false;
        // Commander sprite
        else if (extra == 2)
            image.enabled = isCommander ? true : false;

        // Change to corps color
        if (extra == 1 || extra == 2)
        {
            Color newColor;
            // Red
            if (mColor == Color.white)
                newColor = new Color(CORPS_COLORS[corps - 1, 0], CORPS_COLORS[corps - 1, 1], CORPS_COLORS[corps - 1, 2], CORPS_COLORS[corps - 1, 3]);
            // Blue
            else
                newColor = new Color(CORPS_COLORS[corps + 2, 0], CORPS_COLORS[corps + 2, 1], CORPS_COLORS[corps + 2, 2], CORPS_COLORS[corps + 2, 3]);

            image.color = newColor;
        }
    }
    #endregion
}
