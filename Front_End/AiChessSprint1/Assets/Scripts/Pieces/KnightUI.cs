using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightUI : BasePiece
{
    //sets the Knight's movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager, GameManager newGameManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager, newGameManager);
        knight = true;
        // changes Knight's movement then loads sprite for the Knight
        mMovement = new Vector3Int(4, 4, 4);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        CreateChildSprite("knight_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
    }

    private bool MatchesState(int targetX, int targetY, CellState targetState, int movecount)
    {
        movecount++;
        CellState cellState = CellState.Free;
        cellState = mCurrentCell.mBoardUI.ValidateCell(targetX, targetY, this);
        if (cellState == targetState && movecount<= mMovement.x)
        {
            

            mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[targetX, targetY]);
            MatchesState(targetX , targetY + 1, targetState, movecount);
            MatchesState(targetX, targetY - 1, targetState, movecount);
            
            MatchesState(targetX + 1, targetY, targetState, movecount);
            MatchesState(targetX - 1, targetY, targetState, movecount);
            
            MatchesState(targetX + 1, targetY + 1, targetState, movecount);
            MatchesState(targetX + 1, targetY - 1, targetState, movecount);
            MatchesState(targetX - 1, targetY + 1, targetState, movecount);
            MatchesState(targetX - 1, targetY - 1, targetState, movecount);


            return true;
        }
        else{ return false; }
    }

    protected override void CheckPathing()
    {
        base.CheckPathing();
        if (!mPieceManager.attacking)
        {
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
