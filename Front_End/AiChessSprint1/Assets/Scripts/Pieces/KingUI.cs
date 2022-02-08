using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingUI : BasePiece
{
    //sets the kings movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes king movent then loads sprie for the king
        mMovement = new Vector3Int(3, 3, 3);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_King");
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
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;
        if (MatchesState(currentX, currentY + 1, CellState.Free) || MatchesState(currentX, currentY + 1, CellState.Free))
        {
            MatchesState(currentX - 1, currentY + 2, CellState.Free);
            MatchesState(currentX + 1, currentY + 2, CellState.Free);
            MatchesState(currentX - 1, currentY - 2, CellState.Free);
            MatchesState(currentX + 1, currentY - 2, CellState.Free);
        }
        if (MatchesState(currentX - 1, currentY, CellState.Free) || MatchesState(currentX + 1, currentY, CellState.Free))
        {
            MatchesState(currentX - 2, currentY + 1, CellState.Free);
            MatchesState(currentX - 2, currentY - 1, CellState.Free);
            MatchesState(currentX + 2, currentY + 1, CellState.Free);
            MatchesState(currentX + 2, currentY - 1, CellState.Free);
        }
        
    }

    //follows base Kill function and then set the mIsKingAlive object to false to reset the game
    public override void Kill()
    {
        base.Kill();

        mPieceManager.mIsKingAlive = false;
    }

}
