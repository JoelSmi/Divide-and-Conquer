using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* creates the different states a cell can be in for movement
 * None: base state will always be changed to another state
 * Friendly: the cell is occupied by a friendly unit
 * Enemy: The cell is occupied by a enemy unit
 * Free: the cell is not occupied by any unit
 * OutOfBounds: the Cell is not within the parameters of the board
*/
public enum CellState
{
    None,
    Friendly,
    Enemy,
    Free,
    OutOfBounds
}
public class Board : MonoBehaviour
{
    //the object which all cells are based of of
    public GameObject mCellPrefab;

    [HideInInspector]
    // Cell matrix that contatins the board 
    //See Cell.cs for more information on Cells
    public Cell[,] mAllCells = new Cell[8, 8];

    // creates the board
    public void Create()
    {
        #region Create
        // nested for loop to instantiate the cells of the board  
        for (int y = 0;  y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                //create Cell
                GameObject newCell = Instantiate(mCellPrefab, transform);

                //Position of new cell
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);

                //setup
                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);

            }
        }
        #endregion

        #region Color
        //goes through Cell matrix and changes base color of prefab to fit alternating pattern
        for (int x = 0; x < 8; x += 2) 
        {
            for (int y = 0; y < 8; y++)
            {
                // checks if the y position of the matrix is even or odd
                //if it is odd it sets a new color for the cell in the next column
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;

                //sets color for the cell
                mAllCells[finalX, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
            }
        }
        #endregion
    }
    
    // validates whether or not a piece can move to a Cell using the CellState Enum defined above
    public CellState ValidateCell(int targetX, int targetY, BasePiece checkingPiece)
    {
        //bounds Check
        if(targetX < 0 || targetX > 7)
        {
            return CellState.OutOfBounds;
        }
        if (targetY < 0 || targetY > 7)
        {
            return CellState.OutOfBounds;
        }

        //Get Cell
        Cell targetCell = mAllCells[targetX, targetY];

        //if the cell has a piece
        if(targetCell.mCurrentPiece != null)
        {
            //if friendly
            if(checkingPiece.mColor == targetCell.mCurrentPiece.mColor)
            {
                return CellState.Friendly;
            }

            if (checkingPiece.mColor != targetCell.mCurrentPiece.mColor)
            {
                return CellState.Enemy;
            }
        }

        return CellState.Free;

    }
}