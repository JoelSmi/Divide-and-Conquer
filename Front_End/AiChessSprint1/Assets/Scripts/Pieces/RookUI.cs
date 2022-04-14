using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RookUI : BasePiece
{
    //sets the Rookss movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager, GameManager newGameManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager, newGameManager);

        //// changes RookUI's movement then loads sprite for the RookUI
        mMovement = new Vector3Int(2, 2, 2);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        CreateChildSprite("rook_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
    }

    private bool MatchesState(int targetX, int targetY, CellState targetState, int movecount)
    {
        movecount++;
        CellState cellState = CellState.Free;
        cellState = mCurrentCell.mBoardUI.ValidateCell(targetX, targetY, this);
        if ((cellState == targetState || cellState!= CellState.OutOfBounds) && movecount <= mMovement.x+1)
        {
            if(cellState == targetState)
                mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[targetX, targetY]);

            MatchesState(targetX, targetY + 1, targetState, movecount);
            MatchesState(targetX, targetY - 1, targetState, movecount);

            MatchesState(targetX + 1, targetY, targetState, movecount);
            MatchesState(targetX - 1, targetY, targetState, movecount);

            MatchesState(targetX + 1, targetY + 1, targetState, movecount);
            MatchesState(targetX + 1, targetY - 1, targetState, movecount);
            MatchesState(targetX - 1, targetY + 1, targetState, movecount);
            MatchesState(targetX - 1, targetY - 1, targetState, movecount);


            Debug.Log(movecount);
            return true;
        }
        else { return false; }
    }

    protected override void CheckPathing()
    {
        base.CheckPathing();
        if (mPieceManager.attacking)
        {
            int currentX = mCurrentCell.mBoardPosition.x;
            int currentY = mCurrentCell.mBoardPosition.y;

            MatchesState(currentX, currentY + 1, CellState.Enemy, 0);
            MatchesState(currentX, currentY - 1, CellState.Enemy, 0);

            MatchesState(currentX + 1, currentY, CellState.Enemy, 0);
            MatchesState(currentX - 1, currentY, CellState.Enemy, 0);

            MatchesState(currentX + 1, currentY + 1, CellState.Enemy, 0);
            MatchesState(currentX + 1, currentY - 1, CellState.Enemy, 0);
            MatchesState(currentX - 1, currentY + 1, CellState.Enemy, 0);
            MatchesState(currentX - 1, currentY - 1, CellState.Enemy, 0);
        }
    }
}
