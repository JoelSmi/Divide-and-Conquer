using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    // Recursively reference the object?
    public GameObject diceRoll;
    public GameManager gameManager;
    public GameObject marginTable;

    // Stop the animation when the animation is complete
    public void StopAnimation()
    {
        //gameManager.uiUpdating = false;
        diceRoll.active = false;
        marginTable.active = gameManager.mPieceManager.attacking;
    }
}
