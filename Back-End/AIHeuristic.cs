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
            Piece hCommander3 = new Bishop(Color.Black, 0);
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

        
    }
}
