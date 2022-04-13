using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    // Recursively reference the object?
    public GameObject diceRoll;

    // Stop the animation when the animation is complete
    public void StopAnimation()
    {
        diceRoll.active = false;
    }
}
