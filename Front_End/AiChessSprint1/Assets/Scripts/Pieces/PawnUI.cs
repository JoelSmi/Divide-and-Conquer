using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnUI : BasePiece
{    
    //overrides the base piece Setup to fit the Pawn's role
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager, GameManager newGameManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager, newGameManager);
        pawn = true;
        //checks whether or not the pawn is a black or white piecefor the direction it will go
        mMovement =  mColor == Color.white ?  new Vector3Int(0,1,1) : new Vector3Int(0,-1,-1);

        // loads image for the Pawn
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);
        //TagSet(newTeamColor);

        CreateChildSprite("pawn_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
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
        
            //Vertical
            CreateCellPath(0, 1, mMovement.y);

            //Upper Diagonal
            CreateCellPath(1, 1, mMovement.z);
            CreateCellPath(-1, 1, mMovement.z);
        
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
