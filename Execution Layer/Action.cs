using Pieces;
using Kings;
using Knights;
using Bishops;


namespace Actions {
    public class Action
    {
        public static bool moveAction(Piece currPiece, int[] pos, int[] dest)
        {
            /*
                Function to check whether the intended movement action is valid (i.e. if there are no pieces in the path of movement or at the destination)
                If action invalid return 0
                If action is valid and NOT performed by the knight return 2
                If action is valid and IS performed by the knight return 1

                ***NOTE: both pos and dest are arrays with two elements, the x (row) and y (column) coordinates of the respectively
            */
            return false;
        }

        public static bool attackAction(Piece currPiece, int[] pos, int[] dest)
        {
            /*
                Function to check whether the intended attack action is valid
                If action invalid return 0
                If action is valid and NOT performed by the knight return 2
                If action is valid and IS performed by the knight return 1

                ***NOTE: both pos and dest are arrays with two elements, the x (row) and y (column) coordinates of the respectively
            */
            return false;
        }
    }
}


