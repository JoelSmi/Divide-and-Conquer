using System;

namespace BishopAI1;

class AITesting
{    
    static void Main(string[] args){

        //At first we will always use the left bishop.
            
        //Declaration of variables we will need
        bool act = false, BishopTurn = true;
        
        //I change "e" to "e." so it is visually easier to looa at the code
        //default board
        String[,] boardArray00 = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"P0","P1","P2","P3","P4","P5","P6","P7"},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        }; 
//---------------------------------------------------------------------------- 
// Ignoring Knight and archer atm
//----------------------------------------------------------------------------
        //----------------------------------------------------------------
        //1 non commander in danger
        String[,] boardArray1a = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"e.","P1","P2","P3","P4","P5","P6","P7"},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"P0","e.","e.","e.","e.","e.","e.","e."},
                               {"p0","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        };
        //1 commander in danger
        String[,] boardArray1b = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"P0","e.","e.","P3","P4","P5","P6","P7"},
                               {"P1","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","P2","e.","e.","e.","e.","e."},
                               {"e.","e.","b0","e.","e.","e.","e.","e."},
                               {"p1","e.","e.","p2","e.","e.","e.","e."},
                               {"p0","e.","e.","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        };
        
        //----------------------------------------------------------------
        //1 commander, 1 non commander in danger
        //both threaten by the same piece
        String[,] boardArray2a = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"P0","P1","e.","P3","e.","P5","P6","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","P7"},
                               {"e.","e.","P2","e.","e.","e.","P4","e."},
                               {"p0","e.","p1","b0","p2","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","p3","p4","p5","p6","p7"},
                               {"r0","n0","e.","q0","k0","b1","n1","r1"}
        };
        //1 commander, 1 non commander in danger
        //threaten by different piece
        String[,] boardArray2b = new String [8,8] {
                               {"R0","N0","e.","Q0","K0","B1","N1","R1"},
                               {"e.","P1","e.","e.","P4","P5","P6","P7"},
                               {"e.","e.","e.","P2","e.","e.","e.","e."},
                               {"p0","e.","B0","e.","P3","e.","e.","e."},
                               {"P0","e.","b0","e.","e.","e.","e.","e."},
                               {"p1","p2","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","p3","p4","p5","p6","p7"},
                               {"r0","n0","e.","q0","k0","b1","n1","r1"}
        }; 
        //----------------------------------------------------------------
        
        String[,] boardArray4 = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"e.","e.","e.","P3","P4","P5","P6","P7"},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","P2","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"P0","e.","P1","e.","e.","e.","e.","e."},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        }; 

        String[,] boardArray5 = new String [8,8] {
                               {"R0","e.","B0","K0","Q0","B1","N1","R1"},
                               {"e.","p2","e.","P3","P4","P5","P6","P7"},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","e.","e.","e.","e.","e."},
                               {"e.","e.","e.","k0","q0","e.","p6","p7"},
                               {"e.","N0","e.","e.","e".,"e.","n1","r1"}
        }; 

        //Here we will need to be able to input the board from the middle layer, for now we will create a temp board.
        //Board b = new Board();
        //Board b = new Board(boardArray);
        Board b = new Board(boardArray5);

        Console.WriteLine("Board Initialized");
        b.Print();

        Piece currentCommander = b.GetBishopCommander();
        Piece[] subordinates = b.GetSubordinates(currentCommander);
        Piece[] LiveEnemyPlayers = b.GetEnemyPieces();

        Action outgoingAction = AIBishop.BishopAI(b, currentCommander, subordinates, LiveEnemyPlayers);
        
        if (outgoingAction.getIsActing())
        {
            outgoingAction.printAction();
            b.Move(outgoingAction.getOriginalXCord(), outgoingAction.getOriginalYCord(), outgoingAction.getDestinationXCord(), outgoingAction.getDestinationYCord());
            Console.WriteLine("New Board:");
            b.Print();    
        }
        else 
        {
            Console.WriteLine("Valid move was not selected");
        }
    }
}
