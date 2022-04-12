using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueenUI : BasePiece
{
    //sets the queen'ss movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes Queen's movement then loads sprie for the queen
        mMovement = new Vector3Int(3, 3, 3);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        CreateChildSprite("queen_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
    }
    //checks if the state matches the state in the CheckPathing function if so it adds the move possibility to the MhighlightedCells
    private bool MatchesState(int targetX, int targetY, CellState targetState, int movecount)
    {
        movecount++;
        CellState cellState = CellState.Free;
        cellState = mCurrentCell.mBoardUI.ValidateCell(targetX, targetY, this);
        if (cellState == targetState && movecount <= mMovement.x)
        {


            mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[targetX, targetY]);
            MatchesState(targetX, targetY + 1, targetState, movecount);
            MatchesState(targetX, targetY - 1, targetState, movecount);

            MatchesState(targetX + 1, targetY, targetState, movecount);
            MatchesState(targetX - 1, targetY, targetState, movecount);

            MatchesState(targetX + 1, targetY + 1, targetState, movecount);
            MatchesState(targetX + 1, targetY - 1, targetState, movecount);
            MatchesState(targetX - 1, targetY + 1, targetState, movecount);
            MatchesState(targetX - 1, targetY - 1, targetState, movecount);


            return true;
        }
        else { return false; }
    }

    protected override void CheckPathing()
    {
        
        if (!mPieceManager.attacking && mPieceManager.CommandAuthority)
        {
            base.CheckPathing();
            int currentX = mCurrentCell.mBoardPosition.x;
            int currentY = mCurrentCell.mBoardPosition.y;

            MatchesState(currentX, currentY + 1, CellState.Free, 0);
            MatchesState(currentX, currentY - 1, CellState.Free, 0);

            MatchesState(currentX + 1, currentY, CellState.Free, 0);
            MatchesState(currentX - 1, currentY, CellState.Free, 0);

            MatchesState(currentX + 1, currentY + 1, CellState.Free, 0);
            MatchesState(currentX + 1, currentY - 1, CellState.Free, 0);
            MatchesState(currentX - 1, currentY + 1, CellState.Free, 0);
            MatchesState(currentX - 1, currentY - 1, CellState.Free, 0);
        }
    }
}
