using System;

namespace BishopAI1;

class AITesting
{

    
    static void Main(string[] args){

        //At first we will always use the left bishop.
            
        //Declaration of variables we will need
        bool act = false, BishopTurn = true;
        
        String[,] boardArray = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"P0","P1","P2","P3","P4","P5","P6","P7"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        }; 

        //Here we will need to be able to input the board from the middle layer, for now we will create a temp board.
        //Board b = new Board();
        Board b = new Board(boardArray);
        
        Console.WriteLine("Board Initialized");
        b.Print();

        Piece currentCommander = b.GetPiece(0,2);
        Piece[] subordinates = {b.GetPiece(1, 0), b.GetPiece(1, 1), b.GetPiece(1, 2), b.GetPiece(0, 1)};
        Piece[] LiveEnemyPlayers =
        {
            b.GetPiece(6, 0), b.GetPiece(6,1), b.GetPiece(6,2), b.GetPiece(6,3),
            b.GetPiece(6, 4), b.GetPiece(6,5), b.GetPiece(6,6), b.GetPiece(6,7),
            b.GetPiece(7, 0), b.GetPiece(7,1), b.GetPiece(7,2), b.GetPiece(7,3),
            b.GetPiece(7, 4), b.GetPiece(7,5), b.GetPiece(7,6), b.GetPiece(7,7),
        };

        Action outgoingAction = AIBishop.BishopAI(b, currentCommander, subordinates, LiveEnemyPlayers);
        outgoingAction.printAction();
        b.Move(outgoingAction.getOriginalXCord(), outgoingAction.getOriginalYCord(), outgoingAction.getDestinationXCord(), outgoingAction.getDestinationYCord());
        Console.WriteLine("New Board:");
        b.Print();    
    }
}
