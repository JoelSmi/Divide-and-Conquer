using System;
using System.Collections.Generic;

namespace KingAI1
{
    public class Heuristic{
        //MUST UPDATE THIS WITH THE TOTAL NUMBER OF HEURISTICS
        public int totalHeuristics = 1;

        public Action[] chosenActions;

        public Heuristic(){
            Random rand = new Random();
            HeuristicChoice(rand.Next(0,totalHeuristics));
        }

        public Heuristic(int i){
            if (i < totalHeuristics){
                HeuristicChoice(i);
            }
            else{
                HeuristicChoice(0);
            }
        }

        public void HeuristicChoice(int i){
            if (i == 0){
                this.chosenActions = heuristic0();
            }
        }

        public Action[] heuristic0(){
            //This is the first testing heuristic, we want to move P0, P3, and P7.
            //Here we make the commander piece
            //Here we define all neccessary variables for action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,0};
            int[] dest1 = {2,0};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,3};
            int[] dest2 = {2,3};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,6};
            int[] dest3 = {2,6};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic0 = {action1, action2, action3}; 
            return heuristic0;
        }
        
        /*
        * The starting command structure
        * B0: P0 P1 P2 N0
        * B1: P5 P6 P7 N1
        * K0: P3 P4 R0 R1 Q0 
        */
        
        /*
        P0, P3, P7
        __| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
        0 | R0 | N0 | B0 | Q0 | K0 | B1 | N1 | R1 | 
        1 |    | P1 | P2 |    | P4 | P5 | P6 |    | 
        2 | P0 | e  | e  | e  | P3 | e  | P7 | e  | 
        3 | e  | e  | e  | e  | e  | e  | e  | e  | 
        4 | e  | e  | e  | e  | e  | e  | e  | e  | 
        5 | e  | e  | e  | e  | e  | e  | e  | e  | 
        6 | p0 | p1 | p2 | p3 | p4 | p5 | p6 | p7 | 
        7 | r0 | n0 | b0 | q0 | k0 | b1 | n1 | r1 | 
        */
        public Action[] heuristic1(){
            //Action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,0};
            int[] dest1 = {2,0};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,3};
            int[] dest2 = {2,4};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,7};
            int[] dest3 = {2,6};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic1 = {action1, action2, action3}; 
            return heuristic1;
        } 
        
        /*
        P1, P3, P7
        __| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
        0 | R0 | N0 | B0 | Q0 | K0 | B1 | N1 | R1 | 
        1 | P0 |    | P2 |    | P4 | P5 | P6 |    | 
        2 | e  | P1 | e  | e  | P3 | e  | P7 | e  | 
        3 | e  | e  | e  | e  | e  | e  | e  | e  | 
        4 | e  | e  | e  | e  | e  | e  | e  | e  | 
        5 | e  | e  | e  | e  | e  | e  | e  | e  | 
        6 | p0 | p1 | p2 | p3 | p4 | p5 | p6 | p7 | 
        7 | r0 | n0 | b0 | q0 | k0 | b1 | n1 | r1 | 
        */
        public Action[] heuristic2(){
            //Action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,1};
            int[] dest1 = {2,1};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,3};
            int[] dest2 = {2,4};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,7};
            int[] dest3 = {2,6};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic2 = {action1, action2, action3}; 
            return heuristic2;
        } 
        
        /*
        P2, P3, P7
        __| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
        0 | R0 | N0 | B0 | Q0 | K0 | B1 | N1 | R1 | 
        1 | P0 | P1 |    |    | P4 | P5 | P6 |    | 
        2 | e  | e  | P2 | e  | P3 | e  | P7 | e  | 
        3 | e  | e  | e  | e  | e  | e  | e  | e  | 
        4 | e  | e  | e  | e  | e  | e  | e  | e  | 
        5 | e  | e  | e  | e  | e  | e  | e  | e  | 
        6 | p0 | p1 | p2 | p3 | p4 | p5 | p6 | p7 | 
        7 | r0 | n0 | b0 | q0 | k0 | b1 | n1 | r1 | 
        */
        public Action[] heuristic3(){
            //Action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,2};
            int[] dest1 = {2,2};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,3};
            int[] dest2 = {2,4};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,7};
            int[] dest3 = {2,6};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic3 = {action1, action2, action3}; 
            return heuristic3;
        } 
        
        /*
        P1, P4, P6
        __| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
        0 | R0 | N0 | B0 | Q0 | K0 | B1 | N1 | R1 | 
        1 | P0 |    | P2 | P3 |    | P5 |    | P7 | 
        2 | e  |    | P1 | e  | P4 | P6 | e  | e  | 
        3 | e  | e  | e  | e  | e  | e  | e  | e  | 
        4 | e  | e  | e  | e  | e  | e  | e  | e  | 
        5 | e  | e  | e  | e  | e  | e  | e  | e  | 
        6 | p0 | p1 | p2 | p3 | p4 | p5 | p6 | p7 | 
        7 | r0 | n0 | b0 | q0 | k0 | b1 | n1 | r1 | 
        */
        public Action[] heuristic4(){
            //Action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,1};
            int[] dest1 = {2,2};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,4};
            int[] dest2 = {2,4};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,6};
            int[] dest3 = {2,5};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic4 = {action1, action2, action3}; 
            return heuristic4;
        } 
        
        /*
        P2, P4, P6
        __| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
        0 | R0 | N0 | B0 | Q0 | K0 | B1 | N1 | R1 | 
        1 | P0 | P1 |    | P3 |    | P5 |    | P7 | 
        2 | e  | e  | e  | P2 | P4 | P6 | e  | e  | 
        3 | e  | e  | e  | e  | e  | e  | e  | e  | 
        4 | e  | e  | e  | e  | e  | e  | e  | e  | 
        5 | e  | e  | e  | e  | e  | e  | e  | e  | 
        6 | p0 | p1 | p2 | p3 | p4 | p5 | p6 | p7 | 
        7 | r0 | n0 | b0 | q0 | k0 | b1 | n1 | r1 | 
        */
        public Action[] heuristic5(){
            //Action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,2};
            int[] dest1 = {2,3};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,4};
            int[] dest2 = {2,4};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,6};
            int[] dest3 = {2,5};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic4 = {action1, action2, action3}; 
            return heuristic5;
        }
        
        /*
        P1, P6
        __| 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
        0 | R0 | N0 | B0 | Q0 | K0 | B1 | N1 | R1 | 
        1 | P0 |    | P2 | P3 | P4 | P5 |    | P7 | 
        2 | e  | P1 | e  | e  | e  | e  | P6 | e  | 
        3 | e  | e  | e  | e  | e  | e  | e  | e  | 
        4 | e  | e  | e  | e  | e  | e  | e  | e  | 
        5 | e  | e  | e  | e  | e  | e  | e  | e  | 
        6 | p0 | p1 | p2 | p3 | p4 | p5 | p6 | p7 | 
        7 | r0 | n0 | b0 | q0 | k0 | b1 | n1 | r1 | 
        */
        public Action[] heuristic6(){
            //Action 1
            Piece hCommander1 = new Bishop(Color.Black, 0);
            int[] orig1 = {1,1};
            int[] dest1 = {2,1};
            List<int[]> path1 = new List<int[]>();
            path1.Add(dest1);
            
            //Action 2
            Piece hCommander2 = new King(Color.Black);
            int[] orig2 = {1,1};
            int[] dest2 = {1,1};
            List<int[]> path2 = new List<int[]>();
            path2.Add(dest2);
            
            //Action 3
            Piece hCommander3 = new Bishop(Color.Black, 1);
            int[] orig3 = {1,6};
            int[] dest3 = {2,6};
            List<int[]> path3 = new List<int[]>();
            path3.Add(dest3);
            
            //Create and list actions
            Action action1 = new Action(dest1, orig1, 0, typeof(Pawn), hCommander1, path1);
            Action action2 = new Action(dest2, orig2, 0, typeof(Pawn), hCommander2, path2);
            Action action3 = new Action(dest3, orig3, 0, typeof(Pawn), hCommander3, path3);
            Action[] heuristic6 = {action1, action2, action3}; 
            return heuristic6;
        } 
    }
}
