using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnUI : BasePiece
{
    
    //overrides the base piece Setup to fit the Pawn's role
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        //checks whether or not the pawn is a black or white piecefor the direction it will go
        mMovement =  mColor == Color.white ?  new Vector3Int(0,1,1) : new Vector3Int(0,-1,-1);

        // loads image for the Pawn
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("pawn_" + spriteName);
        //TagSet(newTeamColor);
    }

    //checks if the state matches the state in the CheckPathing function if so it adds the move possibility to the MhighlightedCells
    private bool MatchesState(int targetX, int targetY, CellState targetState)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoardUI.ValidateCell(targetX, targetY, this);

        if(cellState == targetState)
        {
            mHighlightedCells.Add(mCurrentCell.mBoardUI.mAllCells[targetX, targetY]);
            return true;
        }

        return false;
    }

    // checks the path using the constraints of the pawns movement
    protected override void CheckPathing()
    {
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        MatchesState(currentX - mMovement.z, currentY + mMovement.z, CellState.Free);
        MatchesState(currentX - mMovement.z, currentY + mMovement.z, CellState.Enemy);

        MatchesState(currentX, currentY + mMovement.y, CellState.Free);

        MatchesState(currentX + mMovement.z, currentY + mMovement.z, CellState.Free);
        MatchesState(currentX + mMovement.z, currentY + mMovement.z, CellState.Enemy);

    }

   /* public override void TagSet(Color teamColor)
    {
        string tag;
        if (teamColor == Color.white)
        {
            tag = "p" + mPieceManager.numPieces;
            mPieceManager.mPiecePrefab.tag = tag;
            
        }

    }
   */

}
