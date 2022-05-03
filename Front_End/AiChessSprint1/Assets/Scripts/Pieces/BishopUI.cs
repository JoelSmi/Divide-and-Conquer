using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BishopUI : BasePiece
{
    //sets the Bishops's movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager, GameManager newGameManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager, newGameManager);
        bishop = true;
        // changes Bishop's movement then loads sprie for the BIshop
        mMovement = new Vector3Int(2, 2, 2);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        // Commander status
        isCommander = true;
        if (corps == 1)
            rightCommander = true;
        else if (corps == 3)
            leftCommander = true;

        CreateChildSprite("bishop_" + spriteName, 0);
        CreateChildSprite("corps", 1);
        CreateChildSprite("commander", 2);
    }
}
