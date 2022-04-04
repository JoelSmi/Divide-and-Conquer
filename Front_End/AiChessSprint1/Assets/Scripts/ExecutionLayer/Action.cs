using Pieces;
using System;
using System.Collections.Generic;


namespace Actions
{
    public class Action
    {
        private static bool actionValid = false;
        static Piece[,] GameBoard;

        public static int rollAttack()
        {
            Random roll = new Random();
            int output = roll.Next(1, 7);
            return output;

        }

        #region Move
        public static int moveAction2(List<int[]> moveSet, Piece[,] GB, Piece currPiece)
        {
            //Counter is used to check whether to place the value from the 2d array into x or y,
            //as well as checking to see if the position on the gameboard is empty
            int counter = 0;
            //firstCheck is used to check for the first position in the set of positions
            int firstCheck = 0;
            bool actionValid = true;
            int x = -1, y = -1;
            GameBoard = GB;
            char pieceType = char.ToUpper(currPiece.id.ToCharArray()[0]);
            int[] previous = currPiece.currPos;
            //Iterates through the first dimension of the array
            if(moveSet.Count < 1)
            {
                return -1;
            }

            foreach (int[] dest in moveSet)
            {
                if (previous[0] == dest[0] && previous[1] == dest[1])
                    continue;
                if (actionValid == true)
                {
                    //Checks to see if the position is empty
                    if (GameBoard[dest[0], dest[1]].id.Equals("e"))
                    {
                        actionValid = true;
                        previous = dest;
                    }
                    else
                    {
                        actionValid = false;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            switch (pieceType)
            {
                case 'K':
                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                        return 0;

                case 'Q':
                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }

                case 'N':
                    if (actionValid == true)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                case 'B':
                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }

                case 'P':
                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }

                case 'R':
                    if (actionValid == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
            }
            return -1;
        }
        #endregion

        #region Attack
        public static int attackAction2(List<int[]> moveSet, Piece[,] GB, Piece currPiece)
        {
            //Counter is used to check whether to place the value from the 2d array into x or y,
            bool actionValid = true;
            GameBoard = GB;
            int[] initial = currPiece.currPos;
            if (moveSet.Count < 1)
            {
                return -1;
            }
            int[] dest = moveSet[moveSet.Count - 1];
            char pieceType = char.ToUpper(currPiece.id.ToCharArray()[0]);
            char enemyType = char.ToUpper(GameBoard[dest[0], dest[1]].id.ToCharArray()[0]);
            int chanceAttack = rollAttack();
                              
            //Checks to see if the position is empty
            if (!GameBoard[dest[0], dest[1]].id.Equals("e") && (!currPiece.color.Equals(GameBoard[dest[0], dest[1]].color)))
            {
                if ((Math.Abs(dest[0] - initial[0]) < currPiece.attack) && (Math.Abs(dest[1] - initial[1]) < currPiece.attack))
                    actionValid = true;
                else
                    actionValid = false;
            }
            else
            {
                actionValid = false;
            }

            switch (pieceType)
            {
                case 'K':
                    if (actionValid == true)
                    {
                        if (enemyType == 'K' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'Q' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'N' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'B' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'R' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'P')
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    break;

                case 'Q':
                    if (actionValid == true)
                    {
                        if (enemyType == 'K' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'Q' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'N' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'B' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'R' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'P' && chanceAttack < 5)
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    break;

                case 'N':
                    if (actionValid == true)
                    {
                        if (enemyType == 'K' && chanceAttack < 2)
                        {
                            return 1;
                        }
                        if (enemyType == 'Q' && chanceAttack < 2)
                        {
                            return 1;
                        }
                        if (enemyType == 'N' && chanceAttack < 2)
                        {
                            return 1;
                        }
                        if (enemyType == 'B' && chanceAttack < 2)
                        {
                            return 1;
                        }
                        if (enemyType == 'R' && chanceAttack < 2)
                        {
                            return 1;
                        }
                        if (enemyType == 'P' && chanceAttack < 5)
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    break;

                case 'B':
                    if (actionValid == true)
                    {
                        if (enemyType == 'K' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'Q' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'N' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'B' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'R' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'P' && chanceAttack < 4)
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    break;

                case 'R':
                    if (actionValid == true)
                    {
                        if (enemyType == 'K' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'Q' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'N' && chanceAttack < 3)
                        {
                            return 2;
                        }
                        if (enemyType == 'B' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'R' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'P' && chanceAttack < 2)
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    break;

                case 'P':
                    if (actionValid == true)
                    {
                        if (enemyType == 'K' && chanceAttack < 1)
                        {
                            return 2;
                        }
                        if (enemyType == 'Q' && chanceAttack < 1)
                        {
                            return 2;
                        }
                        if (enemyType == 'N' && chanceAttack < 1)
                        {
                            return 2;
                        }
                        if (enemyType == 'B' && chanceAttack < 2)
                        {
                            return 2;
                        }
                        if (enemyType == 'R' && chanceAttack < 1)
                        {
                            return 2;
                        }
                        if (enemyType == 'P' && chanceAttack < 3)
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    break;
            }
            return -1;
        }
        #endregion

        #region Delegate
        public static int Delegate(Piece CurrPiece, Commander CurrCommander, Commander NextCommander)
        {
            //check to ensure the NextDelegation has room for the peice
            if (NextCommander.Delegation.delegates.Count == NextCommander.Delegation.delegates.Capacity)
                return -1;

            //Check to ensure the current peice is apart of the delegation
            if (CurrCommander.Delegation.delegates.IndexOf(CurrPiece) !> 0)
                return -1;

            if ((NextCommander.Delegation.update(CurrPiece, 'A')) == 2)
            {
                CurrCommander.Delegation.update(CurrPiece, 'R');
                return 2;
            }

            return -1;
        }
        #endregion


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
                    if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
                        actionValid = true;
                    if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (GameBoard[dest[0], dest[1]].id.Equals("e")))
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
                    if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                        actionValid = true;
                    if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                        actionValid = true;
                    if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
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
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;

            if (((pos[0] - 2 == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;

            if (((pos[0] - 3 == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 3 == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 2 == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 2 == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 2 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 3 == dest[0]) && pos[1] - 3 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
        }
        #endregion

        #region checkAttackSquare
        //For king/queen/knight/bishop attack
        public static void checkAttackSquare(Piece currPiece, int[] pos, int[] dest)
        {
            if (((pos[0] - 1 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] - 1 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] + 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
                actionValid = true;
            if (((pos[0] + 1 == dest[0]) && pos[1] - 1 == dest[1]) && (currPiece.color != GameBoard[dest[0], dest[1]].color))
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


