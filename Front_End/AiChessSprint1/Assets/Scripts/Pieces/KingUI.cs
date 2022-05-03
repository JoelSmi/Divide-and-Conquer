using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingUI : BasePiece
{
    //sets the kings movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager, GameManager newGameManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager, newGameManager);

        // changes king movent then loads sprie for the king
        mMovement = new Vector3Int(3, 3, 3);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        // Commander status
        isCommander = true;
        king = true;

        CreateChildSprite("king_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
    }
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
        int movement = mMovement.x;
        base.CheckPathing();
        if (!mPieceManager.attacking)
        {
            if (!mPieceManager.CommandAuthority)
                mMovement.x = 1;
            if (!mPieceManager.CommandAuthority && mPieceManager.CMoveCount > 0)
                mMovement.x = 0;
            if (mPieceManager.CommandAuthority && mPieceManager.CommanderMoved)
                mMovement.x = movement - 1;
            if (mPieceManager.CMoveCount < 2 || mPieceManager.CommandAuthority)//|| (mPieceManager.CommanderMoved && mPieceManager.CommandAuthority))
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
            mMovement.x = movement;
        }
    }

    //follows base Kill function and then set the mIsKingAlive object to false to reset the game
    public override void Kill(BoardUI boardUI)
    {
        base.Kill(boardUI);

        mPieceManager.mIsKingAlive = false;
    }
}
