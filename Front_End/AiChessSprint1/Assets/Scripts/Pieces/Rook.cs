using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rook : BasePiece
{
    //sets the Rookss movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        //// changes Rook's movement then loads sprite for the Rook
        mMovement = new Vector3Int(2, 2, 2);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Rook");
    }

}
