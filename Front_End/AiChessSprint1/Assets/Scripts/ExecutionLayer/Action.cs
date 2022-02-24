using Pieces;
using System;


namespace Actions
{
    public class Action
    {
        private static bool actionValid = false;
        static Piece[,] GameBoard;
        
        public static int rollAttack()
        {
            Random roll = new Random();
            return roll.Next(1,7);

        }
        
                public static int moveAction2(moveSet[,] GB, Piece currPiece)
        {
            //Counter is used to check whether to place the value from the 2d array into x or y,
            //as well as checking to see if the position on the gameboard is empty
            int counter = 0;
            //firstCheck is used to check for the first position in the set of positions
            firstCheck = 0;
            static bool actionValid = true;
            int x, y;
            GameBoard = GB;
            char pieceType = char.ToUpper(currPiece.id.ToCharArray()[0]);

            //Iterates through the first dimension of the array
            for (int i = 0; i < moveSet.GetLength(0); i++)
            {
                if (actionValid == true)
                {
                    //Iterates through the second dimension of the array
                    for (int j = 0; j < moveSet.GetLength(1); j++)
                    {
                        //Checks for the x position in the 2d array and sets x to that value
                        if (counter == 0)
                        {
                            x = moveSet[i, j];
                            counter = 1;
                        }
                        //Checks for the y position in the 2d array and sets y to that value
                        else
                        {
                            y = moveSet[i, j];
                            counter = 0;

                            //Checks if it is the first value in the array. If it is, then it does not need to
                            //check if the space is empty, as the original piece is in that spot
                            if (firstCheck = 0)
                            {
                                firstCheck = 1;
                            }
                            else //If the loop gets to this portion after firstCheck is changed off of 0, then it is no longer the first move
                            {
                                //Checks to see if the position is empty
                                if (GameBoard[x, y].id == 'e')
                                {
                                    actionValid = 1;
                                }
                                else
                                {
                                    actionValid = 0;
                                    break;
                                }
                            }
                        }
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
        }

        public static int attackAction2(moveSet[,] GB, Piece currPiece, int[] dest)
        {
            //Counter is used to check whether to place the value from the 2d array into x or y,
            //as well as checking to see if the position on the gameboard is empty
            int counter = 0;
            //firstCheck is used to check for the first position in the set of positions
            firstCheck = 0;
            static bool actionValid = true;
            int x, y;
            GameBoard = GB;
            char pieceType = char.ToUpper(currPiece.id.ToCharArray()[0]);
            char enemyType = char.ToUpper(GameBoard[dest[0], dest[1]].id.ToCharArray()[0]);
            chanceAttack = rollAttack() - 1;
            //We use a here to set the for loop to search before the last position
            int a = moveSet.GetLength(0) - 1;

            //Iterates through the first dimension of the array
            for (int i = 0; i < a; i++)
            {
                if (actionValid == true)
                {
                    //Iterates through the second dimension of the array
                    for (int j = 0; j < moveSet.GetLength(1); j++)
                    {
                        //Checks for the x position in the 2d array and sets x to that value
                        if (counter == 0)
                        {
                            x = moveSet[i, j];
                            counter = 1;
                        }
                        //Checks for the y position in the 2d array and sets y to that value
                        else
                        {
                            y = moveSet[i, j];
                            counter = 0;

                            //Checks if it is the first value in the array. If it is, then it does not need to
                            //check if the space is empty, as the original piece is in that spot
                            if (firstCheck = 0)
                            {
                                firstCheck = 1;
                            }
                            else //If the loop gets to this portion after firstCheck is changed off of 0, then it is no longer the first move
                            {
                                //Checks to see if the position is empty
                                if (GameBoard[x, y].id == 'e')
                                {
                                    actionValid = 1;
                                }
                                else
                                {
                                    actionValid = 0;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            if (currPiece.color != GameBoard[dest[0], dest[1]].color)
            {
                actionValid = true;
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
            }
        }

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


