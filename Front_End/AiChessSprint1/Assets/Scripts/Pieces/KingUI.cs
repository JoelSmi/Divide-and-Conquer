using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingUI : BasePiece
{
    //sets the kings movement variable based on the constraints
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // changes king movent then loads sprie for the king
        mMovement = new Vector3Int(3, 3, 3);
        string spriteName = newTeamColor == Color.white ? "red" : "blue";
        GetComponent<Image>().sprite = Resources.Load<Sprite>("base_" + spriteName);

        createChildSprite(spriteName);
    }

    //follows base Kill function and then set the mIsKingAlive object to false to reset the game
    public override void Kill()
    {
        base.Kill();

        mPieceManager.mIsKingAlive = false;
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
        image.sprite = Resources.Load<Sprite>("king_" + spriteName);

        RectTransform rectTransform = childSprite.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(75, 75);
    }
}
