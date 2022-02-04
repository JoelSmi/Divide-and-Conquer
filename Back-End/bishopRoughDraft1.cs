using System;

namespace BishopAI1
{
	/*Instead of having these classes here, we will most likely have another file that will have all these classes,
	in addition to all of the methods we will use here (get/sets) and eventually we may be able to optimize this
	using other methods*/

	/*For the purposes of this rough draft, I will just make names for methods and list them
	below this comment as I need to use them. I've also just said pieces will be represented as Char, but we can talk
	about the best way of representing pieces

	*/
    

    class bishopRoughDraft1
	{
        //Returns the X co-ordinate and Y co-ordinate on the board
	    // Maybe change from foreach to for
        public static int[] GetLocation(Piece p, Board b)
        {
            int x = 0, y = 0, counter = 0;
            int[] square = {-1,-1};

            foreach (Piece p1 in b.GetBoard()){
                if(p1.GetType() == p.GetType()){
                    if(p1.GetColor() == p.GetColor()){
                        if(p1.GetID() == p.GetID()){
                            square[0] = y;
                            square[1] = x;
                            return square;
                        }
                    }
                }
                if (x<=6){
                    x++;
                    counter++;
                }
                else if (x == 7){
                    y++;
                    x = 0;
                    counter++;
                }
            }
            return square;
        }

        /*1 enemy attack 1 friendly
          Argument 1 - friendly
	  Argument 2 - enemy
	  Return 1 - True, enemy can attack
	  Return 2 - False, enemy cannot attack*/
        public static bool IndividualAttackCheck(Piece defender, Piece attacker, Board b)
        {
            int[] square = GetLocation(defender,b);
            foreach (int[] move in attacker.GetLegalAttacks())
            {
                if (square[0] == move[0] && square[1] == move[1])
                {
                    return true;
                }
            }
            return false;
        }
        
        /*This method will be used when we want to find a subordinate who can attack a particular enemy. This will be used
		when we have a commander that is in danger and we want to find a subordinate who can attack the attacking piece.
		In the event there are multiple subordinates that can attack the defending commander, we will find the one that
		has the highest probability of capture upon attacking.
		This function will not just be able to stop at the first subordinate it finds, we want to find the best
	subordinate we can use (Knight > Pawn).
		The first argument is the enemy we want to kill.
		The second argument is the array of pieces that are the subordinates of the commander.
		This function will return the piece that is recommended to attack with.*/
        private static Piece SubordinateAttackCheck(Piece enemyWeWantToAttack, Piece[] subordinates, Board b)
        {
            int[] square = GetLocation(enemyWeWantToAttack,b);
            foreach (Piece p in subordinates)
            {
                foreach (int[] move in p.GetLegalAttacks())
                {
                    if (square[0] == move[0] && square[1] == move[1])
                    {
                        Piece attackingSubordinate;
                        if (p.GetType() == typeof(Knight))
                        {
                            attackingSubordinate = p;
                            return attackingSubordinate;
                        }
                        else if (p.GetType() == typeof(Pawn))
                        {
                            attackingSubordinate = p;
                            return attackingSubordinate;
                        }
                    }
                }
            }
            
            Piece empty = new EmptySquare();
            return empty;
        }
        
        /*This method will be used when the AI wants to consider the probability a certain piece has of capturing
            another certain piece.
            The first argument is the piece that will be attacked, i.e. the defender
        The second argument is the piece that is attacking, i.e. the attacker
        This function will return a boolean value, True: if the odds are greater than or equal to 50%, False: if the
            odds are less than 50%. (We could make it so the AI will automatically know the number the roll will end up
            being, but this seems a bit unfair)*/
        static bool OddsCheck(Piece defender, Piece attacker)
        {
            int minimumRoll = Piece.getMinimumRoll(attacker, defender);
            if (minimumRoll >= 4)
                return true;
            else
                return false;
        }
        
        /*This method will be used if a commander (or piece) is in danger and the commander cannot take out the threat.
        If this is the case, we need to find a square the piece can move to where it will be out of danger. This method
        will have to
        1) If the defending piece is a commander, we need to account for the fact it can move more than one square.
        2) Check which blocks around it are either in danger, or occupied by a friendly. We can do this with hashsets
        The first argument is the piece that is currently in danger, i.e. the defender
        The second argument is the piece that is attacking, i.e. the attacker
        This function will return an int[] which will be the space to move to.*/
        public static int[] safeSpot(Piece defender, Piece attacker, Piece[] LiveEnemyPlayers){
            bool spotFound = true;
            int[] safeSquare = {-1,-1};
            //First we need to find a square away from the primary attacker
            //For now we will just use the first square that isn't being attacked by the main attacker
            foreach(int[] move in defender.GetLegalMoves()){
                foreach(int[] attackSpot in attacker.GetLegalAttacks()){
                    if (move == attackSpot)
                    {
                        spotFound = false;
                    }
                }
                //If a spot was found we need to make sure it isn't being attacked by anyone else
                //This if function will go through every single enemy and check all of their legal attacks
                //**************************
                //Madison: Legal attacks hash will store all the blocks they can attack right? regardless of if there is an enemy or not?
                if (spotFound)
                {
                    foreach(Piece enemy in LiveEnemyPlayers){
                        foreach(int[] enemyAttack in enemy.GetLegalAttacks()){
                            if (enemyAttack == move){
                                spotFound = false;
                            }
                        }
                    }
                    //If spotFound is still true, this is the block we need to move to.
                    if (spotFound)
                    {
                        safeSquare[0] = move[0];
                        safeSquare[1] = move[1];
                        return safeSquare;
                    }
                    //If spot found is false now, we need to continue the loop and find another space.
                }
            }
            //If we went through all of the defenders viable moves and they're all being threatened
            //Then we return unmodified safeSquare which is [-1,-1]
            return safeSquare;
        }
        
	static void Main(string[] args)
	{
            //At first we will always use the left bishop.
            
            bool act = false, BishopTurn = true; //Declaration of variables we will need

            
            //Here we will need to be able to input the board from the middle layer, for now we will create a temp board.

            Board b = new Board();
            Console.WriteLine("Board Initialized");
            b.Print();
            
	    // Hardcode pieces
            Piece currentCommander = b.GetPiece(0,2); //commander
            Piece[] subordinates = {b.GetPiece(1, 0), b.GetPiece(1, 1), b.GetPiece(1, 2), b.GetPiece(0, 1)}; //subordinates
            
            //This segment will be testing code in order to make sure the commander and subordinates are correct, will 
            //normally stay commented out
	    /*
            Console.WriteLine("Current Commander Piece Details");
            currentCommander.PrintPiece();
            Console.WriteLine("The subordinates for the commander:");
            foreach (Piece p in subordinates)  
            {
                p.PrintPiece();
            }
	    */
            //End of Board Initialization testing code
            
            //Here we will hardcode the live enemy players
            Piece[] LiveEnemyPlayers =
            {
                b.GetPiece(6, 0), b.GetPiece(6,1), b.GetPiece(6,2), b.GetPiece(6,3),
                b.GetPiece(6, 4), b.GetPiece(6,5), b.GetPiece(6,6), b.GetPiece(6,7),
                b.GetPiece(7, 0), b.GetPiece(7,1), b.GetPiece(7,2), b.GetPiece(7,3),
                b.GetPiece(7, 4), b.GetPiece(7,5), b.GetPiece(7,6), b.GetPiece(7,7),
            };
            //This will check to make sure all of the live enemy players are correct.
            /*
            Console.WriteLine("All live enemy pieces");
            foreach (Piece enemy in LiveEnemyPlayers)
            {
                enemy.PrintPiece();
            }*/

            //This will find the commander and display its coordinates on the screen to test the GetLocation Function
            int[] commanderSquare = {-1,-1};
            commanderSquare = GetLocation(currentCommander,b);
            Console.Write("The current location of the commander is ");
            foreach (int i in commanderSquare){
                Console.Write(i + " ");
            }
            Console.Write(" which is also known as " + Board.GetNotation(commanderSquare[0],commanderSquare[1]));

	    while(BishopTurn)
	    {
                //This will be the bishop immediate threat detection:
                if (!act)
                {
                    //This for loop is so that we can check every single enemy to see if it attacking the commander
                    foreach (Piece currentEnemyPlayer in LiveEnemyPlayers)
                    {                        
                        if (IndividualAttackCheck(currentCommander, currentEnemyPlayer, b)) //check commander(defending) vs enemy (attacking)
                        {
                            //Enemy can attack, now get a friendly to attack enemy
                            Piece attackingPiece = SubordinateAttackCheck(currentEnemyPlayer, subordinates, b);
                            /*If one is found, SubordinateAttackCheck should have already considered
                            possibilities and accounted for them. SubordinateAttackCheck will find any subordinates who
                            can attack the threat and if there are any, it will return the designation for that piece.

                            In the case we did find a good subordinate to attack with, we can go ahead and call that the
                            attacking piece. We can play around with this option vs. using the bishop offensively first
                            in Sprint3*/
                            if (attackingPiece.GetType().Name != "EmptySquare")
                            {
                                //***************************************************** Double check with madison that there are
                                // no attacking methods, and then we need to make one. But here the subordinate that returned
                                //into attacking piece will attack the currentEnemyPlayer
                                int[] subordinateSquare = new int[2];
                                int[] enemySquare = new int[2];
                                //Attack method
                                act = true;
                            }
                            //If no attacking piece is found, the bishop will have to be considered.
                            if (attackingPiece.GetType().Name == "EmptySquare")
                            {
                                int[] safeSquare = {-1,-1};
                                bool individualAttackCheckBool = IndividualAttackCheck(currentEnemyPlayer, currentCommander,b);
                                //We need to check if the bishop itself can attack the threat
                                if (individualAttackCheckBool)
                                {
                                    //If it can attack, we need to make sure the odds are in our favor
                                    bool oddsCheckBool = OddsCheck(currentEnemyPlayer, currentCommander);
                                    if (oddsCheckBool)
                                    {
                                        //********Again, get with madison about coding attacking, but here the commander will
                                        //attack the currentEnemyPlayer

                                        act = true;
                                    }
                                    //If the odds weren't in our favor, we could check if the bishop could
                                    //move out of the way
                                    
                                    safeSquare = safeSpot(currentCommander, currentEnemyPlayer, LiveEnemyPlayers);
                                    if (safeSquare[0] != -1 && safeSquare[1] != -1) //If safeSquare != -1, then safespot found something
                                    {
                                        //*********************
                                        //Here we need to code the movement to the safeSquare as the desired move.
                                        act = true;
                                    }
                                    else //The bishop will attack if the enemy piece is in range and there is no other option
                                    {
                                        //*********************
                                        //Code in attack from bishop to threat
                                        act = true;
                                    }

                                }
                                //If the bishop cannot attack the threat, it will have to move.
                                safeSquare = safeSpot(currentCommander, currentEnemyPlayer, LiveEnemyPlayers);
                                if (safeSquare[0] != -1 && safeSquare[1] != -1) //If safeSquare != -1, then safespot found something
                                {
                                    //If there is a safe spot, we will move there.
                                    //*******Code the movement to the safespot
                                    act = true;
                                }
                                //If there is no safeSpot for the bishop, it will have no choice but to hope for the king to
                                //save it. In this case, we will let the bishop move as normally.
                            }
                        }
                    }
                }
				//This marks the end of the Bishop Immediate Threat Detection

                //This marks the beginning of Bishop Subordinate Threat Detection
                //This will only go through if there is no action being taken from the Bishop immediate treat detection
                if (!act)
                {
                    bool danger = false, knightCheck = false;
                    Piece[] subordinatesInDanger = new Piece[8];
                    Piece subordinateWeAreDefending = null, attackingPiece = null;
                    int counter = 0;
                    //BishopSubordinateScan()
                    foreach(Piece p in subordinates)
                    {
                        foreach(Piece enemy in LiveEnemyPlayers)
                        {
                        //Check if the enemy player can attack each of the bishops subordinates
                            danger = IndividualAttackCheck(p, enemy, b);
                            if (danger)
                            {
                                //add this subordinate to the list of subordinates in danger
                                subordinatesInDanger[counter] = p;
                                counter++;
                            }
                        } //This is the end of the loop checking each enemy player
                    }//This is the end of the loop checking for each ally piece
                    if (counter != 0 && subordinateWeAreDefending != null)
                    {
                    //eventually we can prioritize attacking enemy pieces that could attack more than one piece at a time
                        //but for now, it will just check if the piece is a knight and will move to defend that.
                        foreach (Piece subordinate in subordinatesInDanger)
                        {
                        if (subordinate.GetType() == typeof(Knight)) //Here we check if any of the subordinatesInDanger are knights
                        {
                            subordinateWeAreDefending = subordinate;
                            knightCheck = true;
                        }
                        }//This is the end of the for loop checking each subordinate in danger
                        //if there are no knights to defend, we will take the first pawn
                        if (!knightCheck && counter != 0)
                        {
                        subordinateWeAreDefending = subordinates[0];
                        }
                        //Here we move on if there is a subordinate to defend, if not we need to continue with the loop
                    
                        //We now have the subordinate that we are acting to protect
                        //Now that we have selected the piece we're protecting, we need to check exactly which enemy pieces are attacking
                        //for (int i = 0; i < sizeof(LiveEnemyPlayers); i++)
                        bool dangerPiece = false;
                        foreach(Piece currentEnemyPlayer in LiveEnemyPlayers)
                        {
                            dangerPiece = IndividualAttackCheck(subordinateWeAreDefending, currentEnemyPlayer, b);
                            if (dangerPiece == true){
                                if(OddsCheck(currentEnemyPlayer,subordinateWeAreDefending)){
                                    attackingPiece = currentEnemyPlayer;
                                }
                            }
                        }

                        if (dangerPiece == true)
                        {
                            //Now that we know which piece is attacking our subordinate, we use subordinate attack check to see who can attack it
                            Piece attackingSubordinate = SubordinateAttackCheck(attackingPiece, subordinates, b);
                            if (attackingSubordinate.GetType() != typeof(EmptySquare)){
                                //******Here we code the attackingSubordinate attacking the attackingPiece


                                act = true;
                            }
                        }
                        /*If we couldn't find anyone to attack, then we need to move the subordinate. To do this safely,
                        we need to find a safe spot for it to move to*/
                        else
                        {
                            int[] safeBlock = {-1, -1};
                            safeBlock = safeSpot(subordinateWeAreDefending, attackingPiece, LiveEnemyPlayers);
                            if (safeBlock[0] != -1 && safeBlock[1] != -1)
                            {
                                //**********Here we code moving the piece to the squares identified by safeBlock
                                act = true;
                            }
                            //But if there is no safe spot for it to move to, then we will have to keep moving.
                        }
                    } //If we do not have a subordinate to defend, we can move on to offensive play.
                } //End of Bishop Subordinate Threat Detection

                //This marks the beginning of Bishop Offensive Play Detection
                if (!act)
                {
                    bool offensiveSub = false;
                    Piece attackingPiece, movingPiece;
                    int[] moveToSquares = {-1, -1};
                    //First we will check if any subordinates can attack an enemy.
                    foreach (Piece sub in subordinates){
                        foreach (int[] move in sub.GetLegalAttacks())
                        {
                            if (move != null){
                                offensiveSub = true;
                                attackingPiece = sub;
                                //We may need to optimize this eventually to pick the best subordinate to attack, 
                                //if there are multiple

                                //If there was an offensive subordinate, we can attack. 
                                //There is a separate if statement here just in case we eventualy have the AI pick which subordinate to choose from
                                if (offensiveSub && OddsCheck(attackingPiece, sub))
                                {
                                    foreach (int[] attack in sub.GetLegalAttacks()){
                                        moveToSquares[0] = attack[0];
                                        moveToSquares[1] = attack[1];
                                    }
                                    //We use a foreach just to easily access the hashset.
                                }

                            }
                        }
                    }

                    Random randomNum = new Random();
                    int length = subordinates.Length, prob = 0;
                    bool hasMove = false;
                    //If after checking all the subordinates, there's nothing that can immediately attack, we need to move.
                    //First we need to check if even one subordinate can move. If even one can move, that's fine.
                    //If there's even one subordinate that can move, we will pick a random number per subordinate, if they can't move, we roll again.
                    foreach (Piece p in subordinates){
                        if (p.HasLegalMoves())
                        {
                            prob = randomNum.Next(0,2);
                            if (prob == 0){
                                foreach (int[] moves in p.GetLegalMoves()){
                                    moveToSquares[0] = moves[0];
                                    moveToSquares[1] = moves[1];
                                }
                                movingPiece = p;
                                hasMove = true;
                            }
                        }
                    }

                    //If we were able to find a move, we will go ahead and execute
                    if(hasMove){
                        //Move the movingPiece ordinate to the squares in moveToSquares
                    }

                    //If after all this, no move was found, then we move on anyways and the bishop doesn't move.

                }

                BishopTurn = false;
			}//End of Bishops turn
            
        }//End of Main

    }//End of class
}//End of namespace

