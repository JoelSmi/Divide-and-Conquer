using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // instantiate Class Board, Class PieceManger objects  
    public Board mBoard;
    public PieceManager mPieceManager;


    // Start is called before the first frame update
    void Start()
    {
        //initiates and creates the Game board
        mBoard.Create();

        // sets pieces onto the created
        mPieceManager.Setup(mBoard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurn()
    {
        mPieceManager.SwitchSides(Color.white);
    }
}
