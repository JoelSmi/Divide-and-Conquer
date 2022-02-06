using Pieces;
using Kings;
using Knights;
using Bishops;


namespace Actions {
    public class Action
    {
        bool actionValid = false;

        public static int moveAction(Piece currPiece, int[] pos, int[] dest)
        {
            /*
                Function to check whether the intended movement action is valid (i.e. if there are no pieces in the path of movement or at the destination)
                If action invalid return 0
                If action is valid and NOT performed by the knight return 2
                If action is valid and IS performed by the knight return 1

                ***NOTE: both pos and dest are arrays with two elements, the x (row) and y (column) coordinates of the respectively
            */

            //If the destination is off of the board, then it is an invalid action
            if (dest[0] < 0 || dest[1] < 0)
                actionValid = false;

            if (dest[0] > 8 || dest[1] > 8)
                actionValid = false;

            switch (pieceType)
            {
                case "King":
                    checkMoveSquare(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                    }
                    else
                        return 0;
                    break;

                case "Queen":
                    checkMoveSquare(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                    break;

                case "Knight":
                    checkMoveKnight(Piece currPiece, int[] pos, int[] dest);


                    if (actionValid = true)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                    break;
 
                case "Bishop":
                    checkSlide(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                        break;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                            
                case "Pawn":
                    if ((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                        actionValid = true;
                    if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                        actionValid = true;
                    if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                        actionValid = true;

                    if (actionValid = true)
                    {
                        return 2;
                        break;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                    break;

                case "Rook":
                    checkSlide(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                        break;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
            }

            return false;
        }

        public static int attackAction(Piece currPiece, int[] pos, int[] dest)
        {
            /*
                Function to check whether the intended attack action is valid
                If action invalid return 0
                If action is valid and NOT performed by the knight return 2
                If action is valid and IS performed by the knight return 1

                ***NOTE: both pos and dest are arrays with two elements, the x (row) and y (column) coordinates of the respectively
            */
            if (dest[0] < 0 || dest[1] < 0)
                actionValid = false;

            if (dest[0] > 8 || dest[1] > 8)
                actionValid = false;

            switch (pieceType)
            {
                case "King":
                    checkAttackRook(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                    }
                    else
                        return 0;
                    break;

                case "Queen":
                    checkAttackRook(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                    break;

                case "Knight":
                    checkAttackRook(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
                    break;

                case "Bishop":
                    checkAttackRook(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                        break;
                    }
                    else
                    {
                        return 0;
                        break;
                    }

                case "Pawn":
                    if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                        actionValid = true;
                    if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                        actionValid = true;
                    if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                        actionValid = true;

                    if (actionValid = true)
                    {
                        return 2;
                        break;
                    }
                    else
                    {
                        return 0;
                        break;
                    }

                case "Rook":
                    checkAttackRook(Piece currPiece, int[] pos, int[] dest);

                    if (actionValid = true)
                    {
                        return 2;
                        break;
                    }
                    else
                    {
                        return 0;
                        break;
                    }
            }

            return false;
        }

        //For bishop/rook movement
        public static void checkSlide(Piece currPiece, int[] pos, int[] dest)
        {
            //Two Spaces Moved
            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
            }

            //One space moved
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
        }

        //For archer/rook attack
        public static void checkAttackRook(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;

            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;

            if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
        }

        //For king/queen/knight/bishop attack
        public static void checkAttackSquare(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]].IndexOf('b') > 0))
        }

        //For king/queen movement
        public static void checkMoveSquare(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;

            //For two spaces away
            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                else if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] != "e")
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }

            //For 3 spaces away
            if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e"))
                {
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
                if ((GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e") && (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if ((GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e") && (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e"))
                {
                    actionValid = true;
                }
            }
        }

        //For knight movement
        public static void checkMoveKnight(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                actionValid = true;

            //For 2 spaces
            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0]- 3, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
            {
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                {
                    actionValid = true;
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                    {
                        actionValid = true;
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                    {
                        actionValid = true;
                    }
                }

                //For 3 spaces away
                if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 3])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 3])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 3])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 3])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]])
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }

                //For 4 spaces away
                if (((pos[0] - 4 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] - 4 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] - 4 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] - 1 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] - 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] + 1 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] + 2 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] - 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0], currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] + 4 == dest[0]) && pos[1] == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1]] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] + 2] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] + 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                    actionValid = true;
                if (((pos[0] + 4 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] + 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1]] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 1] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e")
                        {
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 3] == "e")
                            {
                                actionValid = true;
                            }
                            if (GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1]] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 1] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 2] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[currPiece.dest[0], currPiece.dest[1]] == "e"))
                {
                    if (GameBoard[currPiece.pos[0] + 1, currPiece.pos[1] - 1] == "e")
                    {
                        if (GameBoard[currPiece.pos[0] + 2, currPiece.pos[1] - 2] == "e" && GameBoard[currPiece.pos[0] + 3, currPiece.pos[1] - 3] == "e")
                        {
                            actionValid = true;
                        }
                    }
                }
            }
        }
    }
}
