using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bishop : BasePiece
{
    //sets the Bishops's movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes Bishop's movement then loads sprie for the BIshop
        mMovement = new Vector3Int(2, 2, 2);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Bishop");
    }

}
