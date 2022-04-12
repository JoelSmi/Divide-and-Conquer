using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollTransparent : MonoBehaviour
{
    // Parent object
    public GameObject diceAnimation;

    // Start is called before the first frame update
    void Start()
    {
        // Get the current screen dimensions
        int height = Screen.height;
        int width = Screen.width;

        // Scale the single transparent pixel to the size of the screen
        this.transform.localScale = new Vector3(width, height, 1);
    }
}
