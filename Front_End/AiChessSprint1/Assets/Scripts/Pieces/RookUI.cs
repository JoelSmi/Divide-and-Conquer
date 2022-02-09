using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RookUI : BasePiece
{
    //sets the Rookss movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        //// changes RookUI's movement then loads sprite for the RookUI
        mMovement = new Vector3Int(2, 2, 2);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        createChildSprite(spriteName);
    }

    //Adds the base to the sprite, determined by team color
    protected void createChildSprite(string spriteName)
    {
        GameObject childSprite = new GameObject();
        childSprite.transform.SetParent(transform);
        childSprite.transform.localScale = new Vector3(1, 1, 1);
        childSprite.name = "Piece Sprite";

        childSprite.AddComponent<Image>();
        Image image = childSprite.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("rook_" + spriteName);

        RectTransform rectTransform = childSprite.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(75, 75);
    }

}
