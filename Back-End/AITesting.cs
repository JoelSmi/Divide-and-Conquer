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

        String[,] boardArray1 = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"e","P1","P2","P3","P4","P5","P6","P7"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"P0","e","e","e","e","e","e","e"},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        };

        String[,] boardArray2 = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"e","e","e","P3","P4","P5","P6","P7"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"P0","e","P1","e","P2","e","e","e"},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        }; 

        String[,] boardArray3 = new String [8,8] {
                               {"R0","N0","e","Q0","K0","B1","N1","R1"},
                               {"e","e","e","P3","P4","P5","P6","P7"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","P2","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"P0","e","P1","e","B0","e","e","e"},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        }; 

        String[,] boardArray4 = new String [8,8] {
                               {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                               {"e","e","e","P3","P4","P5","P6","P7"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","P2","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"P0","e","P1","e","e","e","e","e"},
                               {"p0","p1","p2","p3","p4","p5","p6","p7"},
                               {"r0","n0","b0","q0","k0","b1","n1","r1"}
        }; 

        String[,] boardArray5 = new String [8,8] {
                               {"R0","e","B0","K0","Q0","B1","N1","R1"},
                               {"e","p2","e","P3","P4","P5","P6","P7"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","e","e","e","e","e"},
                               {"e","e","e","k0","q0","e","p6","p7"},
                               {"e","N0","e","e","e","e","n1","r1"}
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
