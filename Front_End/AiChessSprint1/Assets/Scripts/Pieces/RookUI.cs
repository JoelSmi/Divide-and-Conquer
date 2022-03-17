using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RookUI : BasePiece
{
    //sets the Rookss movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        //// changes RookUI's movement then loads sprite for the RookUI
        mMovement = new Vector3Int(2, 2, 2);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        CreateChildSprite("rook_" + spriteName, 0);
        CreateChildSprite("corp_" + spriteName + "_" + corps, 1);
        CreateChildSprite("comm_" + spriteName + "_" + corps, 2);
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
        if (mPieceManager.attacking)
        {
            int currentX = mCurrentCell.mBoardPosition.x;
            int currentY = mCurrentCell.mBoardPosition.y;
            
            for (int i = 0; i<4; i++)
            {
                for (int j = 0; j<4; j++)
                {
                    MatchesState(currentX - i, currentY - j, CellState.Enemy);
                    MatchesState(currentX - i, currentY + j, CellState.Enemy);

                    MatchesState(currentX + i, currentY - j, CellState.Enemy);
                    MatchesState(currentX + i, currentY + j, CellState.Enemy);
                }
            }
            
            
            

            
        }
    }

}
