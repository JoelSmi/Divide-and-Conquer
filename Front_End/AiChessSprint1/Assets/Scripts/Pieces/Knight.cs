using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : BasePiece
{
    //sets the Knight's movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes Knight's movement then loads sprite for the Knight
        mMovement = new Vector3Int(4, 4, 4);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Knight");
    }

}