using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Queen : BasePiece
{
    //sets the queen'ss movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes Queen's movement then loads sprie for the queen
        mMovement = new Vector3Int(3, 3, 3);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Queen");
    }

}
