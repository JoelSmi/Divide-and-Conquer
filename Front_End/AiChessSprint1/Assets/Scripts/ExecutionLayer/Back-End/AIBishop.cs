using System;
using System.Collections.Generic;

namespace KingAI1
{
    class AIBishop
	{
        //Returns the X co-ordinate and Y co-ordinate on the board
        public static int[] GetLocation(Piece p, Board b)
        {
            if (p != null){
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
            else    {
                int[] nothing = new int[] {-1,-1};
                return nothing;
            }
                
        }

        /*This method will be used to check if a single enemy player can attack a single friendly player.
            The first argument will be the piece who is defending, i.e. the one who may be attacked.
            The second argument will be the the player that may want to attack.
            This will return a boolean value, True: if it can attack, False: if it cannot attack.*/
        public static bool IndividualAttackCheck(Piece defender, Piece attacker, Board b)
        {
            if (defender != null && attacker != null) {
                int[] square = GetLocation(defender,b);
                HashSet<int[]> test = attacker.GetLegalAttacks();
                if (attacker.GetLegalAttacks() == null)
                    return false;
                //if (test == null)
                  //  return false;

                foreach (int[] move in attacker.GetLegalAttacks())
                {
                    if (square[0] == move[0] && square[1] == move[1])
                    {
                        return true;
                    }
                }
                return false;
            }
            else
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
        public static Piece SubordinateAttackCheck(Piece enemyWeWantToAttack, Piece[] subordinates, Board b)
        {
            Piece attackingSubordinate = new EmptySquare();
            if (enemyWeWantToAttack != null)
            {
                int[] square = GetLocation(enemyWeWantToAttack,b);
                foreach (Piece p in subordinates)
                {
                    if (p != null && p.GetType() != typeof(EmptySquare))
                    {
                        foreach (int[] move in p.GetLegalAttacks())
                        {
                            if (square[0] == move[0] && square[1] == move[1])
                            {
                                if (p.GetType() == typeof(Queen))
                                {
                                    attackingSubordinate = p;
                                   
                                }
                                else if (p.GetType() == typeof(Rook))
                                {
                                    attackingSubordinate = p;
                                
                                }
                                else if (p.GetType() == typeof(Bishop))
                                {
                                    attackingSubordinate = p;
                                
                                }
                                else if (p.GetType() == typeof(Knight))
                                {
                                    attackingSubordinate = p;
                                   
                                }
                                else if (p.GetType() == typeof(Pawn))
                                {
                                    attackingSubordinate = p;
                                    
                                }
                                if (OddsCheck(enemyWeWantToAttack, p)){
                                    return attackingSubordinate;
                                }
                            }
                        }
                    }
                    
                }
            }
            return attackingSubordinate;
        }
        
        /*This method will be used when the AI wants to consider the probability a certain piece has of capturing
            another certain piece.
            The first argument is the piece that will be attacked, i.e. the defender
        The second argument is the piece that is attacking, i.e. the attacker
        This function will return a boolean value, True: if the odds are greater than or equal to 50%, False: if the
            odds are less than 50%. (We could make it so the AI will automatically know the number the roll will end up
            being, but this seems a bit unfair)*/
        public static bool OddsCheck(Piece defender, Piece attacker)
        {
            if (defender != null && attacker != null){
                int minimumRoll = Piece.getMinimumRoll(attacker, defender);
                if (minimumRoll >= 3)
                    return true;
                else
                    return false;
            }
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
            if (defender != null && attacker != null){
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
                            if (enemy != null && enemy.GetType() != typeof(EmptySquare)){
                                foreach(int[] enemyAttack in enemy.GetLegalAttacks()){
                                    if (enemyAttack == move){
                                        spotFound = false;
                                    }
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
            
            int[] nothing = new int[] {-1,-1};
            return nothing;
        }
        
        public static void TestingFunctions1(Board b, Piece currentCommander, Piece[] subordinates, Piece[] LiveEnemyPlayers)
        {
            Console.WriteLine("Current Commander Piece Details");
            currentCommander.PrintPiece();
            Console.WriteLine("The subordinates for the commander:");
            foreach (Piece p in subordinates)  
            {
                p.PrintPiece();
            }
            //End of Board Initialization testing code

            //This will check to make sure all of the live enemy players are correct.
            Console.WriteLine("All live enemy pieces");
            foreach (Piece enemy in LiveEnemyPlayers)
            {
                enemy.PrintPiece();
            }

            //This will find the commander and display its coordinates on the screen to test the GetLocation Function
            int[] commanderSquare = {-1,-1};
            commanderSquare = GetLocation(currentCommander,b);
            Console.Write("The current location of the commander is ");
            foreach (int i in commanderSquare){
                Console.Write(i + " ");
            }
            Console.WriteLine(" which is also known as " + Board.GetNotation(commanderSquare[0],commanderSquare[1]));

        }
		//static void Main(string[] args)
        public static Action BishopAI(Board b, Piece currentCommander, Piece[] subordinates, Piece[] LiveEnemyPlayers)
		{
            //At first we will always use the left bishop.
            //Declaration of variables we will need
            bool act = false, BishopTurn = true, commentsOn = true;
            Action outgoingAction = new Action();

            //TestingFunctions1(b, currentCommander, subordinates, LiveEnemyPlayers);

			while(BishopTurn)
			{
                //This will be the bishop immediate threat detection:
                if (!act)
                {
                    //This for loop is so that we can check every single enemy to see if it attacking the commander
                    foreach (Piece currentEnemyPlayer in LiveEnemyPlayers)
                    {
                        //This is the if statement that is actually checking if it is in danger or not
                        if (currentEnemyPlayer != null && currentEnemyPlayer.GetType() != typeof(EmptySquare) && 
                            IndividualAttackCheck(currentCommander, currentEnemyPlayer, b))
                        //reminder: IndividualAttackCheck checks if a single enemy can attack a single ally piece,
                        //returning true or false
                        {
                            if (commentsOn){
                                Console.WriteLine("Commander " + currentCommander.GetType().ToString() + currentCommander.GetID() + " has been found to be in danger");
                            }
                            //If it is true, we need to see which subordinate(s) can attack the dangerous enemy piece.
                            Piece attackingPiece = SubordinateAttackCheck(currentEnemyPlayer, subordinates, b);
                            /*If one is found, SubordinateAttackCheck should have already considered
                            possibilities and accounted for them. SubordinateAttackCheck will find any subordinates who
                            can attack the threat and if there are any, it will return the designation for that piece.

                            In the case we did find a good subordinate to attack with, we can go ahead and call that the
                            attacking piece. We can play around with this option vs. using the bishop offensively first
                            in Sprint3*/
                            if (attackingPiece.GetType().Name != "EmptySquare")
                            {
                                if (commentsOn){
                                Console.WriteLine(attackingPiece.GetType().ToString() + attackingPiece.GetID() + 
                                " has been found to defend the commander.\nAction is being taken");
                                }
                                //***************************************************** Double check with Madison about future use of attack
                                //function, the rolling won't happen in this layer so we can only tell the execution layer that we want to attack
                                //not that if it was successful or not.
                                int[] subordinateSquare = GetLocation(attackingPiece, b);
                                int[] enemySquare = GetLocation(currentEnemyPlayer, b);
                                //Attack method
                                //b.Attack(subordinateSquare[0], subordinateSquare[1], enemySquare[0], enemySquare[1], )
                                outgoingAction.setAttack(true);
                                outgoingAction.setDestinationCord(enemySquare);
                                outgoingAction.setID(attackingPiece.GetID());
                                outgoingAction.setOriginalCord(subordinateSquare);
                                outgoingAction.setPieceType(attackingPiece.GetType());
                                outgoingAction.setIsAct(true);
                                outgoingAction.setCommandingPiece(currentCommander);
                                List<int[]> path = attackingPiece.GetPath(enemySquare[0], enemySquare[1]);
                                outgoingAction.setPath(path);
                                act = true;
                            }

                            //If no attacking piece is found, the bishop will have to be considered.
                            if (attackingPiece.GetType() == typeof(EmptySquare) && currentEnemyPlayer != null && currentEnemyPlayer.GetType() != typeof(EmptySquare))
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
                                        if (commentsOn){
                                            Console.WriteLine("Commander " + currentCommander.GetType().ToString() + currentCommander.GetID() + 
                                            " will defend itself.\nAction is being taken");
                                        }
                                        //********Again, get with madison about coding attacking, but here the commander will
                                        //attack the currentEnemyPlayer
                                        int[] subordinateSquare = GetLocation(currentCommander, b);
                                        int[] enemySquare = GetLocation(currentEnemyPlayer, b);
                                        //Attack method
                                        //b.Attack(subordinateSquare[0], subordinateSquare[1], enemySquare[0], enemySquare[1], )
                                        outgoingAction.setAttack(true);
                                        outgoingAction.setDestinationCord(enemySquare);
                                        outgoingAction.setID(currentCommander.GetID());
                                        outgoingAction.setOriginalCord(subordinateSquare);
                                        outgoingAction.setPieceType(currentCommander.GetType());
                                        outgoingAction.setIsAct(true);
                                        outgoingAction.setCommandingPiece(currentCommander);
                                        List<int[]> path = currentCommander.GetPath(enemySquare[0], enemySquare[1]);
                                        outgoingAction.setPath(path);
                                        act = true;
                                    }
                                    //If the odds weren't in our favor, we could check if the bishop could
                                    //move out of the way
                                    
                                    safeSquare = safeSpot(currentCommander, currentEnemyPlayer, LiveEnemyPlayers);
                                    if (safeSquare[0] != -1 && safeSquare[1] != -1) //If safeSquare != -1, then safespot found something
                                    {
                                        if (commentsOn){
                                            Console.WriteLine("Commander " + currentCommander.GetType().ToString() + currentCommander.GetID() + 
                                            " will move.\nAction is being taken.");
                                        }
                                        //*********************
                                        //Here we need to code the movement to the safeSquare as the desired move.
                                        int[] subordinateSquare = GetLocation(currentCommander, b);
                                        outgoingAction.setAttack(false);
                                        outgoingAction.setDestinationCord(safeSquare);
                                        outgoingAction.setID(currentCommander.GetID());
                                        outgoingAction.setOriginalCord(subordinateSquare);
                                        outgoingAction.setPieceType(currentCommander.GetType());
                                        outgoingAction.setIsAct(true);
                                        outgoingAction.setCommandingPiece(currentCommander);
                                        List<int[]> path = currentCommander.GetPath(safeSquare[0], safeSquare[1]);
                                        outgoingAction.setPath(path);
                                        act = true;
                                    }
                                    else //The bishop will attack if the enemy piece is in range and there is no other option
                                    {
                                        //*********************
                                        //Code in attack from bishop to threat
                                        //********Again, get with madison about coding attacking
                                        int[] subordinateSquare = GetLocation(currentCommander, b);
                                        int[] enemySquare = GetLocation(currentEnemyPlayer, b);
                                        //Attack method
                                        //b.Attack(subordinateSquare[0], subordinateSquare[1], enemySquare[0], enemySquare[1], )
                                        outgoingAction.setAttack(true);
                                        outgoingAction.setDestinationCord(enemySquare);
                                        outgoingAction.setID(currentCommander.GetID());
                                        outgoingAction.setOriginalCord(subordinateSquare);
                                        outgoingAction.setPieceType(currentCommander.GetType());
                                        outgoingAction.setIsAct(true);
                                        outgoingAction.setCommandingPiece(currentCommander);
                                        List<int[]> path = currentCommander.GetPath(enemySquare[0], enemySquare[1]);
                                        outgoingAction.setPath(path);
                                        act = true;
                                    }

                                }
                                //If the bishop cannot attack the threat, it will have to move.
                                safeSquare = safeSpot(currentCommander, currentEnemyPlayer, LiveEnemyPlayers);
                                if (safeSquare[0] != -1 && safeSquare[1] != -1) //If safeSquare != -1, then safespot found something
                                {
                                    if (commentsOn){
                                        Console.WriteLine("Commander " + currentCommander.GetType().ToString() + currentCommander.GetID() + 
                                        " will move.\nAction is being taken.");
                                    }
                                    //If there is a safe spot, we will move there.
                                    //*******Code the movement to the safespot
                                    int[] subordinateSquare = GetLocation(currentCommander, b);
                                    outgoingAction.setAttack(false);
                                    outgoingAction.setDestinationCord(safeSquare);
                                    outgoingAction.setID(currentCommander.GetID());
                                    outgoingAction.setOriginalCord(subordinateSquare);
                                    outgoingAction.setPieceType(currentCommander.GetType());
                                    outgoingAction.setIsAct(true);
                                    outgoingAction.setCommandingPiece(currentCommander);
                                    List<int[]> path = currentCommander.GetPath(safeSquare[0], safeSquare[1]);
                                    outgoingAction.setPath(path);
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
                    Piece[] subordinatesInDanger = new Piece[8], attackingPieces = new Piece[16];
                    Piece subordinateWeAreDefending = null, attackingPiece = null;
                    int counter = 0, counter1 = 0;
                    //BishopSubordinateScan()
                    foreach(Piece p in subordinates)
                    {
                        foreach(Piece enemy in LiveEnemyPlayers)
                        {
                            if (p != null && enemy != null)
                            {
                                if (p.GetType() != typeof(EmptySquare) && enemy.GetType() != typeof(EmptySquare))
                                {
                                    //Check if the enemy player can attack each of the bishops subordinates
                                    danger = IndividualAttackCheck(p, enemy, b);
                                    if (danger)
                                    {
                                        if (commentsOn){
                                            Console.WriteLine("Piece " + p.GetType().ToString() + p.GetID() + " is in danger");
                                        }
                                        //add this subordinate to the list of subordinates in danger
                                        subordinatesInDanger[counter] = p;
                                        counter++;
                                        //~~~~~~~~~~~~Need to make sure we don't add the same piece over and over
                                    }
                                }
                            }
                            
                        } //This is the end of the loop checking each enemy player
                    }//This is the end of the loop checking for each ally piece
                    if (counter != 0 && subordinatesInDanger[0] != null && subordinatesInDanger[0].GetType() != typeof(EmptySquare))
                    {
                        bool dangerPiece = false, dangerFound = false, canAttack = false, dangerPicked = false;
                        //This code was to prioritize knight protection, but this will be implemented later and we will just defend the first piece found
                        // //eventually we can prioritize attacking enemy pieces that could attack more than one piece at a time
                        // //but for now, it will just check if the piece is a knight and will move to defend that.
                        // foreach (Piece subordinate in subordinatesInDanger)
                        // {
                        //     if (subordinate != null && subordinate.GetType() == typeof(Knight)) //Here we check if any of the subordinatesInDanger are knights
                        //     {
                        //         subordinateWeAreDefending = subordinate;
                        //         knightCheck = true;
                        //     }
                        // }//This is the end of the for loop checking each subordinate in danger
                        //if there are no knights to defend, we will take the first pawn
                        subordinateWeAreDefending = subordinatesInDanger[0];

                        //Now that we have selected the piece we're protecting, we need to check exactly which enemy pieces are attacking
                        //for (int i = 0; i < sizeof(LiveEnemyPlayers); i++)
                        
                        foreach(Piece currentEnemyPlayer in LiveEnemyPlayers)
                        {
                            if (currentEnemyPlayer != null && currentEnemyPlayer.GetType() != typeof(EmptySquare)){
                                dangerPiece = IndividualAttackCheck(subordinateWeAreDefending, currentEnemyPlayer, b);
                                if (dangerPiece == true){
                                    //Here we may need to use canAttack to make sure that the attacking piece is one that can be attacked back.
                                    if(OddsCheck(currentEnemyPlayer,subordinateWeAreDefending)){
                                        attackingPieces[counter1] = currentEnemyPlayer;
                                        counter1++;
                                    }
                                    dangerFound = true;
                                }
                            }
                            
                        }
                    /*
                        //If there was at least one attacking enemy found but the odds weren't in our favor, this code will eventually pick 
                        //to move on that enemy. For now this will be commented out and saved for a future sprint.
                        if (dangerFound == true && dangerPicked == false)
                        {
                            foreach (Piece currentEnemyPlayer1 in LiveEnemyPlayers){
                                dangerPiece = IndividualAttackCheck(subordinateWeAreDefending, currentEnemyPlayer1, b);
                                if (dangerPiece == true){
                                    attackingPiece = currentEnemyPlayer1;
                                }
                            }
                         }
                    */

                        //Now that we have an array of attacking pieces, for now we will just pick the first piece that we can attack back.
                        foreach(Piece attacker in attackingPieces){
                            if (attacker != null && attacker.GetType() != typeof(EmptySquare))
                            {
                                int[] location = GetLocation(attacker,b);
                                foreach(int[] move in subordinateWeAreDefending.GetLegalAttacks()){
                                    if (move[0] == location[0] && move[1] == location[1]){
                                        attackingPiece = attacker;
                                    }
                                }
                            }
                        }


                        if (dangerFound && attackingPiece != null && attackingPiece.GetType() != typeof(EmptySquare))
                        {
                            //Now that we know which piece is attacking our subordinate, we use subordinate attack check to see who can attack it
                            Piece attackingSubordinate = SubordinateAttackCheck(attackingPiece, subordinates, b);
                            //If SubordinateAttackCheck returns and empty square, then there isn't a subordinate who can attack the threatening piece
                            //This should be somewhat rare.
                            if (attackingSubordinate.GetType() != typeof(EmptySquare)){
                                //******Here we code the attackingSubordinate attacking the attackingPiece
                                int[] subordinateSquare = GetLocation(attackingSubordinate, b);
                                int[] enemySquare = GetLocation(attackingPiece, b);
                                //Attack method
                                //b.Attack(subordinateSquare[0], subordinateSquare[1], enemySquare[0], enemySquare[1], )
                                outgoingAction.setAttack(true);
                                outgoingAction.setDestinationCord(enemySquare);
                                outgoingAction.setID(attackingSubordinate.GetID());
                                outgoingAction.setOriginalCord(subordinateSquare);
                                outgoingAction.setPieceType(attackingSubordinate.GetType());
                                outgoingAction.setIsAct(true);
                                outgoingAction.setCommandingPiece(currentCommander);
                                List<int[]> path = attackingSubordinate.GetPath(enemySquare[0], enemySquare[1]);
                                outgoingAction.setPath(path);
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
                                int[] subordinateSquare = GetLocation(subordinateWeAreDefending, b);
                                outgoingAction.setAttack(false);
                                outgoingAction.setDestinationCord(safeBlock);
                                outgoingAction.setID(subordinateWeAreDefending.GetID());
                                outgoingAction.setOriginalCord(subordinateSquare);
                                outgoingAction.setPieceType(subordinateWeAreDefending.GetType());
                                outgoingAction.setIsAct(true);
                                outgoingAction.setCommandingPiece(currentCommander);
                                List<int[]> path = subordinateWeAreDefending.GetPath(safeBlock[0], safeBlock[1]);
                                outgoingAction.setPath(path);
                                act = true;
                            }
                            //But if there is no safe spot for it to move to, then we will have to keep moving.
                        }
                    } //If we do not have a subordinate to defend, we can move on to offensive play.
                } //End of Bishop Subordinate Threat Detection

                //This marks the beginning of Bishop Offensive Play Detection
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                if (!act)
                {
                    bool offensiveSub = false;
                    Piece attackingPiece;
                    int[] moveToSquares = {-1, -1};
                    //First we will check if any subordinates can attack an enemy.
                    foreach (Piece sub in subordinates){
                        if(sub != null && sub.GetType() != typeof(EmptySquare) && sub.HasLegalAttack())
                        {
                            foreach (int[] move in sub.GetLegalAttacks())
                            {
                                if (move != null && act == false){
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
                                            //Now that we have a move that we want to do, we execute it here, IF that subordinate had a legal attack
                                            int[] subordinateSquare = GetLocation(attackingPiece, b);
                                            outgoingAction.setAttack(false);
                                            outgoingAction.setDestinationCord(moveToSquares);
                                            outgoingAction.setID(attackingPiece.GetID());
                                            outgoingAction.setOriginalCord(subordinateSquare);
                                            outgoingAction.setPieceType(attackingPiece.GetType());
                                            outgoingAction.setIsAct(true);
                                            outgoingAction.setCommandingPiece(currentCommander);
                                            List<int[]> path = attackingPiece.GetPath(moveToSquares[0], moveToSquares[1]);
                                            outgoingAction.setPath(path);
                                            
                                            act = true;
                                            
                                        }
                                        //We use a foreach just to easily access the hashset.
                                    }

                                }
                            }
                        }
                    }             

                    Random randomNum = new Random();
                    int length = subordinates.Length, prob = 0;
                    bool hasMove = false, pieceFound = false, piecePicked = false;
                    //If after checking all the subordinates, there's nothing that can immediately attack, we need to move.
                    //First we need to check if even one subordinate can move. If even one can move, that's fine.
                    //If there's even one subordinate that can move, we will pick a random number per subordinate, if they can't move, we roll again.
                    foreach (Piece p in subordinates){
                        if (p != null && p.GetType() != typeof(EmptySquare) && p.HasLegalMove())
                        {
                            pieceFound = true;
                            prob = randomNum.Next(0,2);
                            if (prob == 0 && act != true){
                                foreach (int[] moves in p.GetLegalMoves()){
                                    if (!act)
                                    {
                                        moveToSquares[0] = moves[0];
                                        moveToSquares[1] = moves[1];
                                        int[] subordinateSquare = GetLocation(p, b);
                                        outgoingAction.setAttack(false);
                                        outgoingAction.setDestinationCord(moveToSquares);
                                        outgoingAction.setID(p.GetID());
                                        outgoingAction.setOriginalCord(subordinateSquare);
                                        outgoingAction.setPieceType(p.GetType());
                                        outgoingAction.setIsAct(true);
                                        outgoingAction.setCommandingPiece(currentCommander);
                                        List<int[]> path = p.GetPath(moveToSquares[0], moveToSquares[1]);
                                        outgoingAction.setPath(path);
                                        act = true;
                                    }
                                }
                            }
                        }
                    }
                    //If there were some pieces that could move, but didn't then we'll just make the first move availible.
                    if (pieceFound && !act){
                        foreach (Piece p in subordinates){
                        if (p != null && p.GetType() != typeof(EmptySquare) && p.HasLegalMove())
                        {
                            pieceFound = true;
                            if (act != true){
                                foreach (int[] moves in p.GetLegalMoves()){
                                    if (!act)
                                    {
                                        moveToSquares[0] = moves[0];
                                        moveToSquares[1] = moves[1];
                                        int[] subordinateSquare = GetLocation(p, b);
                                        outgoingAction.setAttack(false);
                                        outgoingAction.setDestinationCord(moveToSquares);
                                        outgoingAction.setID(p.GetID());
                                        outgoingAction.setOriginalCord(subordinateSquare);
                                        outgoingAction.setPieceType(p.GetType());
                                        outgoingAction.setIsAct(true);
                                        outgoingAction.setCommandingPiece(currentCommander);
                                        List<int[]> path = p.GetPath(moveToSquares[0], moveToSquares[1]);
                                        outgoingAction.setPath(path);
                                        act = true;
                                    }
                                }
                            }
                        }
                    }
                    }
                    //If after all this, no move was found, then we move on anyways and the bishop doesn't move.
                }
                BishopTurn = false;
                return outgoingAction;
			}//End of Bishops turn
            return outgoingAction;
        }//End of Main
    }//End of class
}//End of namespace
