using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : BasePiece
{
    //sets the kings movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes king movent then loads sprie for the king
        mMovement = new Vector3Int(3, 3, 3);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_King");
    }

    //follows base Kill function and then set the mIsKingAlive object to false to reset the game
    public override void Kill()
    {
        base.Kill();

        mPieceManager.mIsKingAlive = false;
    }

}
