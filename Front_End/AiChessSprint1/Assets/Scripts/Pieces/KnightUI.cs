using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightUI : BasePiece
{
    //sets the Knight's movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes Knight's movement then loads sprite for the Knight
        mMovement = new Vector3Int(4, 4, 4);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        CreateChildSprite("knight_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
    }

    private bool MatchesState(int targetX, int targetY, CellState targetState)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoardUI.ValidateCell(targetX, targetY, this);
        if (cellState == targetState)
        {
            mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[targetX, targetY]);
            return true;
        }

        return false;
    }

    protected override void CheckPathing()
    {
        base.CheckPathing();
        if (!mPieceManager.attacking)
        {
            int currentX = mCurrentCell.mBoardPosition.x;
            int currentY = mCurrentCell.mBoardPosition.y;
            if (MatchesState(currentX, currentY + 1, CellState.Free) || MatchesState(currentX, currentY + 1, CellState.Free))
            {
                MatchesState(currentX - 1, currentY + 2, CellState.Free);
                MatchesState(currentX + 1, currentY + 2, CellState.Free);

                MatchesState(currentX - 1, currentY - 2, CellState.Free);
                MatchesState(currentX + 1, currentY - 2, CellState.Free);

                MatchesState(currentX - 1, currentY + 3, CellState.Free);
                MatchesState(currentX + 1, currentY + 3, CellState.Free);

                MatchesState(currentX - 1, currentY - 3, CellState.Free);
                MatchesState(currentX + 1, currentY - 3, CellState.Free);
            }
            if (MatchesState(currentX - 1, currentY, CellState.Free) || MatchesState(currentX + 1, currentY, CellState.Free))
            {
                MatchesState(currentX - 2, currentY + 1, CellState.Free);
                MatchesState(currentX - 2, currentY - 1, CellState.Free);
                MatchesState(currentX + 2, currentY + 1, CellState.Free);
                MatchesState(currentX + 2, currentY - 1, CellState.Free);

                MatchesState(currentX + 3, currentY + 1, CellState.Free);
                MatchesState(currentX + 3, currentY - 1, CellState.Free);
                MatchesState(currentX - 3, currentY + 1, CellState.Free);
                MatchesState(currentX - 3, currentY - 1, CellState.Free);
            }
        }
    }
}
