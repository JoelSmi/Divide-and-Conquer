using Pieces;


namespace Actions
{
    public class Action
    {
        static bool actionValid = false;
        static Piece[,] GameBoard;

        #region MoveCall
        public static int moveAction(Piece[,] GB,Piece currPiece, int[] pos, int[] dest)
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
            GameBoard = GB;
            char pieceType = char.ToUpper(currPiece.id.ToCharArray()[0]);

            switch (pieceType)
            {
                case 'K':
                    checkMoveSquare(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                        return 0;
                    //break;

                case 'Q':
                    checkMoveSquare(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
                    //break;

                case 'N':
                    checkMoveKnight(currPiece, pos, dest);


                    if (actionValid == true)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
                    //break;

                case 'B':
                    checkSlide(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                        //break;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }

                case 'P':
                    if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                        actionValid = true;
                    if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                        actionValid = true;
                    if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                        actionValid = true;

                    if (actionValid == true)
                    {
                        return 2;
                        //break;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
                    //break;

                case 'R':
                    checkSlide(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                        //break;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
            }

            return 0;
        }
        #endregion

        #region AttackCall
        public static int attackAction(Piece[,] GB, Piece currPiece, int[] pos, int[] dest)
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
            GameBoard = GB;
            char pieceType = char.ToUpper(currPiece.id.ToCharArray()[0]);

            switch (pieceType)
            {
                case 'K':
                    checkAttackRook(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                        return 0;
                    //break;

                case 'Q':
                    checkAttackRook(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
                    //break;

                case 'N':
                    checkAttackRook(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
                    //break;

                case 'B':
                    checkAttackRook(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                        //break;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }

                case 'P':
                    if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                        actionValid = true;
                    if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                        actionValid = true;
                    if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                        actionValid = true;

                    if (actionValid == true)
                    {
                        return 2;
                        //break;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }

                case 'R':
                    checkAttackRook(currPiece, pos, dest);

                    if (actionValid == true)
                    {
                        return 2;
                        //break;
                    }
                    else
                    {
                        return 0;
                        //break;
                    }
            }

            return 0;
        }
        #endregion

        #region checkSlide
        //For bishop/rook movement
        public static void checkSlide(Piece currPiece, int[] pos, int[] dest)
        {
            //Two Spaces Moved
            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }

            //One space moved
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
        }
        #endregion

        #region checkAttack
        //For archer/rook attack
        public static void checkAttackRook(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;

            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;

            if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
        }
        #endregion

        #region checkAttackSquare
        //For king/queen/knight/bishop attack
        public static void checkAttackSquare(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].color.Equals("Black")))
                actionValid = true;
        }
        #endregion

        #region checkMoveSquare
        //For king/queen movement
        public static void checkMoveSquare(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;

            //For two spaces away
            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                else if (!GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    else if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }

            //For 3 spaces away
            if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1]].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] - 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0], pos[1] + 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0], pos[1] - 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0], pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0], pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")))
                {
                    if ((GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                    if ((GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                    {
                        actionValid = true;
                    }
                }
                if ((GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1]].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
                if ((GameBoard[pos[0] + 1, pos[1]].id.Equals("e")) && (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
            if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if ((GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e")) && (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e")))
                {
                    actionValid = true;
                }
            }
        }
        #endregion

        #region checkMoveKnight
        //For knight movement
        public static void checkMoveKnight(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                actionValid = true;

            //For 2 spaces
            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
            }
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
            {
                if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                {
                    actionValid = true;
                }
                if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }
                if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e") && GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                    {
                        actionValid = true;
                    }
                }

                //For 3 spaces away
                if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }

                //For 4 spaces away
                if (((pos[0] - 4 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && (GameBoard[pos[0] - 3, pos[1]].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 1].id.Equals("e") && (GameBoard[pos[0] - 3, pos[1]].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1]].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 4 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 3, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 3 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 2 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && (GameBoard[pos[0], pos[1] + 3].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] - 1 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && (GameBoard[pos[0], pos[1] - 3].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] - 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] + 2].id.Equals("e") && (GameBoard[pos[0], pos[1] + 3].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 1 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0], pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] - 1, pos[1] - 2].id.Equals("e") && (GameBoard[pos[0], pos[1] - 3].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 2 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] - 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0], pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 1, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 3 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0], pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 1, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 2, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && (GameBoard[pos[0] + 3, pos[1]].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 2].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] + 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1]].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] + 1].id.Equals("e") && (GameBoard[pos[0] + 3, pos[1]].id.Equals("e")))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 2 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1] + 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1]].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 1].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 3 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e"))
                        {
                            if (GameBoard[pos[0] + 3, pos[1] - 3].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                            if (GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                            {
                                actionValid = true;
                            }
                        }
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                    if (GameBoard[pos[0] + 1, pos[1]].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 1].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 2].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
                if (((pos[0] + 4 == dest[0]) && pos[1] - 4 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                {
                    if (GameBoard[pos[0] + 1, pos[1] - 1].id.Equals("e"))
                    {
                        if (GameBoard[pos[0] + 2, pos[1] - 2].id.Equals("e") && GameBoard[pos[0] + 3, pos[1] - 3].id.Equals("e"))
                        {
                            actionValid = true;
                        }
                    }
                }
            }
        }
    }
    #endregion
}


