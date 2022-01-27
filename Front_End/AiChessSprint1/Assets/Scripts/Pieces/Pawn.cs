using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : BasePiece
{
    //overrides the base piece Setup to fit the Pawn's role
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        //checks whether or not the pawn is a black or white piecefor the direction it will go
        mMovement =  mColor == Color.white ?  new Vector3Int(0,1,1) : new Vector3Int(0,-1,-1);

        // loads image for the Pawn
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Pawn");
    }

    //checks if the state matches the state in the CheckPathing function if so it adds the move possibility to the MhighlightedCells
    private bool MatchesState(int targetX, int targetY, CellState targetState)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        if(cellState == targetState)
        {
            mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
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

}
