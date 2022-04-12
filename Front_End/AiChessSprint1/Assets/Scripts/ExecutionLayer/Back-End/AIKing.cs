using System;
using System.Collections.Generic;

namespace KingAI1
{
    //Because the king will always exist, we need to make it so that when the king is created, it creates a default board. At the beginning of each kingAI, we will need the actions that the user took from the execution layer
    class AIKing{
        //Any 'global' variables
        private Board b;
        private Piece[] bishop0Subordinates;
        private Piece[] bishop1Subordinates;
        private Piece[] kingSubordinates;
        private Piece[] LiveEnemyPlayers;

        private Piece bishop0Commander;
        private Piece bishop1Commander;
        private Piece kingCommander;

        bool commander0 = true;
        bool commander1 = true;

        private Action[] listOfActions = new Action[6];

        //Constructors for the King
        // Creates the board, creates the list of subordinates and list of enemy pieces for AI to refer to.
        // Will also create the array of actions we will use as moves.
        public AIKing(){
            Board b = new Board();
            Piece[] bishop0Subordinates = {new Knight(Color.Black, 0), new Pawn(Color.Black, 0), 
                new Pawn(Color.Black, 1), new Pawn(Color.Black, 2)};
            Piece[] kingSubordinates = {new Rook(Color.Black, 0), new Bishop(Color.Black, 0), new Queen(Color.Black),
                new Bishop(Color.Black, 1), new Rook(Color.Black, 1), new Pawn(Color.Black, 3), new Pawn(Color.Black, 4)};

            Piece[] bishop1Subordinates = {new Knight(Color.Black, 1), new Pawn(Color.Black, 5), 
                new Pawn(Color.Black, 6), new Pawn(Color.Black, 7)};
            Piece[] LiveEnemyPlayers = {new Pawn(Color.White, 0), new Pawn(Color.White, 1), new Pawn(Color.White, 2), new Pawn(Color.White, 3),
				new Pawn(Color.White, 4), new Pawn(Color.White, 5), new Pawn(Color.White,6 ), new Pawn(Color.White, 7),
				new Rook(Color.White, 0), new Knight(Color.White, 0), new Bishop(Color.White, 0), new Queen(Color.White),
				new King(Color.White), new Bishop(Color.White, 1), new Knight(Color.White, 1), new Rook(Color.White, 1)};
        }

        public AIKing(Board bo){
            this.b = bo;
            bishop0Commander = b.GetBishopCommander("B0");
            if (bishop0Commander.GetType() != typeof(EmptySquare)){
                bishop0Subordinates = b.GetSubordinates(bishop0Commander);
            }
            else{
                commander0 = false;
            }
                
            bishop1Commander = b.GetBishopCommander("B1");
            if (bishop0Commander.GetType() != typeof(EmptySquare)){
                bishop1Subordinates = b.GetSubordinates(bishop1Commander);
            }
            else{
                commander1 = false;
            }
            kingCommander = b.GetBishopCommander("K0");
            kingSubordinates = b.GetSubordinates(kingCommander);
            LiveEnemyPlayers = b.GetEnemyPieces();
        }

       

        // b = kingAI. according to execution layer?


        //This will be the King Immediate Threat Detection  
        public static Action KingImmediateThreatDetection(
            AIKing kingAI, Piece[] LiveEnemyPlayers, Piece king, Board b, bool commentsOn){

            Action outgoingAction = new Action();
            Piece[] dangerPlayers = new Piece[16];

            bool check = false, act = false;
            int counter = 0;
    
            //This forloop is to check every live enemy to see if it is attacking the king.
            foreach (Piece currentEnemyPlayer in LiveEnemyPlayers){
                if (currentEnemyPlayer != null && currentEnemyPlayer.GetType() != typeof(EmptySquare) &&
                    AIBishop.IndividualAttackCheck(king, currentEnemyPlayer, b)){
                    if (commentsOn)
                        Console.WriteLine("King K0 has been found to be in danger");
                    dangerPlayers[counter] = currentEnemyPlayer;
                    check = true;
                }
            }
            if (check)
            {
                //If the King is in danger, the first thing we want to do is to try to attack the piece that
                //is attacking us if that is possible. We will go through the list just in case we want to 
                //a means of prioritization
                foreach(Piece dangerPiece in dangerPlayers){
                    if (dangerPiece != null && dangerPiece.GetType() != typeof(EmptySquare) && 
                        AIBishop.IndividualAttackCheck(dangerPiece, king, b)){
                        if (!act){
                            int[] subordinateSquare = AIBishop.GetLocation(king, b);
                            int[] enemySquare = AIBishop.GetLocation(dangerPiece, b);
                            //If the king can attack the piece, now we want to make sure that that move won't put us
                            //in further danger, future feature*********** For now we will just attack
                            outgoingAction.setAttack(true);
                            outgoingAction.setDestinationCord(enemySquare);
                            outgoingAction.setID(king.GetID());
                            outgoingAction.setOriginalCord(subordinateSquare);
                            outgoingAction.setPieceType(king.GetType());
                            outgoingAction.setIsAct(true);
                            outgoingAction.setCommandingPiece(king);
                            List<int[]> path = king.GetPath(enemySquare[0], enemySquare[1]);
                            outgoingAction.setPath(path);
                            act = true;
                        }      
                    }
                }

                //If the king hasn't attacked, we will now see if any subordinates can attack.
                //We still have the array of danger players, so we don't need to do that again
                //Again, we might need to add a prioritization method, but for now we will just 
                //pick the first piece
                if (!act){
                    foreach(Piece dangerPiece in dangerPlayers){
                        if (!act){
                            Piece[] kingSubordinates = kingAI.GetKingSubordinates();
                            Piece attackingSubordinate = AIBishop.SubordinateAttackCheck(dangerPiece, kingSubordinates, b);
                            //If none were found, it would return e. 
                            //Otherwise, we go ahead and attack.
                            if (attackingSubordinate.GetType() != typeof(EmptySquare)){
                                if (commentsOn){
                                    Console.WriteLine(attackingSubordinate.GetType().ToString() + attackingSubordinate.GetID() + 
                                    " has been found to defend the King.\nAction is being taken");
                                }
                                int[] subordinateSquare = AIBishop.GetLocation(attackingSubordinate, b);
                                int[] enemySquare = AIBishop.GetLocation(dangerPiece, b);
                                //If the king can attack the piece, now we want to make sure that that move won't put us
                                //in further danger, future feature*********** For now we will just attack
                                outgoingAction.setAttack(true);
                                outgoingAction.setDestinationCord(enemySquare);
                                outgoingAction.setID(attackingSubordinate.GetID());
                                outgoingAction.setOriginalCord(subordinateSquare);
                                outgoingAction.setPieceType(attackingSubordinate.GetType());
                                outgoingAction.setIsAct(true);
                                outgoingAction.setCommandingPiece(attackingSubordinate);
                                List<int[]> path = attackingSubordinate.GetPath(enemySquare[0], enemySquare[1]);
                                outgoingAction.setPath(path);
                                act = true;
                            
                            }

                        }
                    }
                }
                //If !act, then neither the king or subordinates could attack the piece endangering him.
                //Now we need to check if there is a square we can move to.
                if(!act){
                    int[] safeSquare = {-1, -1};

                    safeSquare = AIBishop.safeSpot(king, dangerPlayers[0], LiveEnemyPlayers);

                    if (safeSquare[0] != -1 && safeSquare[1] != -1) //If safeSquare != -1, then safespot found something
                    {
                        if (commentsOn){
                            Console.WriteLine("The King will move.\nAction is being taken.");
                        }
                        //*********************
                        //Here we need to code the movement to the safeSquare as the desired move.
                        int[] subordinateSquare = AIBishop.GetLocation(king, b);
                        outgoingAction.setAttack(false);
                        outgoingAction.setDestinationCord(safeSquare);
                        outgoingAction.setID(king.GetID());
                        outgoingAction.setOriginalCord(subordinateSquare);
                        outgoingAction.setPieceType(king.GetType());
                        outgoingAction.setIsAct(true);
                        outgoingAction.setCommandingPiece(king);
                        List<int[]> path = king.GetPath(safeSquare[0], safeSquare[1]);
                        outgoingAction.setPath(path);
                        act = true;
                    }
                    //If there was nowhere to run to and couldn't attack for some reason, we will move on.
                }
                
            }
             return outgoingAction;       
        }

        //This will be the King Subordinate Threat Detection
        public static Action KingSubordinateThreatDetection(
            AIKing kingAI, Piece[] LiveEnemyPlayers, Piece king, Board b, bool commentsOn){

            Piece[] subordinates = kingAI.GetKingSubordinates();
            Piece[] LiveEnemyPieces = kingAI.GetLiveEnemyPlayers();
            Piece[] subordinatesInDanger = new Piece[16];
            Piece[] attackingPieces = new Piece[16];
            Piece attackingPiece = null;
                
            bool danger = false, dangerPiece = false, canAttack = false, dangerFound = false, act = false;
            int counter = 0, attackCounter = 0;
            Action outgoingAction = new Action();


            foreach(Piece p in subordinates){
                foreach(Piece enemy in LiveEnemyPieces){
                    if (p != null && enemy != null)
                    {
                        if (p.GetType() != typeof(EmptySquare) && enemy.GetType() != typeof(EmptySquare))
                        {
                            //Check if the enemy player can attack each of the king subordinates
                            danger = AIBishop.IndividualAttackCheck(p, enemy, b);
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
                }
            }

            //Here we pick the subordinate we will protect and also have a rudimentary form of prioritization
            Piece subordinateWeAreDefending = null;
            foreach(Piece p in subordinatesInDanger){
                if(p != null && p.GetType() != typeof(EmptySquare))
                {
                    if (p.GetType() == typeof(Queen))
                    {
                        subordinateWeAreDefending = p;
                    }
                    else if (p.GetType() == typeof(Rook))
                    {
                        subordinateWeAreDefending = p;
                    }
                    else if (p.GetType() == typeof(Knight))
                    {
                        subordinateWeAreDefending = p;
                    }
                    else if (p.GetType() == typeof(Pawn))
                    {
                        subordinateWeAreDefending = p;
                    }
                }
            }

            //This if counter only if there were subordinatres in danger found.
            //Here we fill the array with pieces that are attacking a subordinate
            if(counter != 0 && subordinatesInDanger[0] != null && subordinatesInDanger[0].GetType() != typeof(EmptySquare)){    
                foreach(Piece currentEnemyPlayer in LiveEnemyPlayers)
                {
                    if (currentEnemyPlayer != null && currentEnemyPlayer.GetType() != typeof(EmptySquare)){
                        dangerPiece = AIBishop.IndividualAttackCheck(subordinateWeAreDefending, currentEnemyPlayer, b);
                        if (dangerPiece == true){
                            //Here we may need to use canAttack to make sure that the attacking piece is one that can be attacked back.
                            if(AIBishop.OddsCheck(currentEnemyPlayer,subordinateWeAreDefending)){
                                attackingPieces[attackCounter] = currentEnemyPlayer;
                                attackCounter++;
                            }
                            dangerFound = true;
                        }
                    }  
                }
            }

            //Now that we have an array of attacking pieces, for now we will just pick the first piece that we can attack back.
            foreach(Piece attacker in attackingPieces){
                if (attacker != null && attacker.GetType() != typeof(EmptySquare))
                {
                    int[] location = AIBishop.GetLocation(attacker,b);
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
                Piece attackingSubordinate = AIBishop.SubordinateAttackCheck(attackingPiece, subordinates, b);
                //If SubordinateAttackCheck returns and empty square, then there isn't a subordinate who can attack the threatening piece
                //This should be somewhat rare.
                if (attackingSubordinate.GetType() != typeof(EmptySquare)){
                    //******Here we code the attackingSubordinate attacking the attackingPiece
                    int[] subordinateSquare = AIBishop.GetLocation(attackingSubordinate, b);
                    int[] enemySquare = AIBishop.GetLocation(attackingPiece, b);
                    //Attack method
                    //b.Attack(subordinateSquare[0], subordinateSquare[1], enemySquare[0], enemySquare[1], )
                    outgoingAction.setAttack(true);
                    outgoingAction.setDestinationCord(enemySquare);
                    outgoingAction.setID(attackingSubordinate.GetID());
                    outgoingAction.setOriginalCord(subordinateSquare);
                    outgoingAction.setPieceType(attackingSubordinate.GetType());
                    outgoingAction.setIsAct(true);
                    outgoingAction.setCommandingPiece(king);
                    List<int[]> path = attackingSubordinate.GetPath(enemySquare[0], enemySquare[1]);
                    outgoingAction.setPath(path);
                    act = true;
                }

                /*If we couldn't find anyone to attack, then we need to move the subordinate. To do this safely,
                we need to find a safe spot for it to move to*/
                else
                {
                    int[] safeBlock = {-1, -1};
                    safeBlock = AIBishop.safeSpot(subordinateWeAreDefending, attackingPiece, LiveEnemyPlayers);
                    if (safeBlock[0] != -1 && safeBlock[1] != -1)
                    {
                        //**********Here we code moving the piece to the squares identified by safeBlock
                        int[] subordinateSquare = AIBishop.GetLocation(subordinateWeAreDefending, b);
                        outgoingAction.setAttack(false);
                        outgoingAction.setDestinationCord(safeBlock);
                        outgoingAction.setID(subordinateWeAreDefending.GetID());
                        outgoingAction.setOriginalCord(subordinateSquare);
                        outgoingAction.setPieceType(subordinateWeAreDefending.GetType());
                        outgoingAction.setIsAct(true);
                        outgoingAction.setCommandingPiece(king);
                        List<int[]> path = subordinateWeAreDefending.GetPath(safeBlock[0], safeBlock[1]);
                        outgoingAction.setPath(path);
                        act = true;
                    }
                    //But if there is no safe spot for it to move to, then we will have to keep moving.
                }
            }
            return outgoingAction;
        }

        //This will be the King Subordinate Offensive Check
        public static Action KingSubordinateOffensiveCheck(
            AIKing kingAI, Piece[] LiveEnemyPlayers, Piece king, Board b, bool commentsOn){
            Piece[] subordinates = kingAI.GetKingSubordinates();
            Piece attackingPiece;

            bool offensiveSub = false, act = false;
            int[] moveToSquares = {-1, -1};

            Action outgoingAction = new Action();

            // First we check if any subordinates can attack an enemy
            foreach (Piece sub in subordinates){
                if(sub != null && sub.GetType() != typeof(EmptySquare) && sub.HasLegalAttack())
                {
                    foreach (int[] move in sub.GetLegalAttacks())
                    {
                        if (move != null && act == false){
                            offensiveSub = true;
                            attackingPiece = sub;
                            //We may need to optimize this eventually to pick the best subordinate to attack
                            //For now it'll be hardcoded so its the first it can find

                            //If there was an offensive subordinate, we can attack. 
                            //There is a separate if statement here just in case we eventualy have the AI pick which subordinate to choose from
                            if (offensiveSub && AIBishop.OddsCheck(attackingPiece, sub))
                            {
                                foreach (int[] attack in sub.GetLegalAttacks()){
                                    moveToSquares[0] = attack[0];
                                    moveToSquares[1] = attack[1];
                                    //Now that we have a move that we want to do, we execute it here, IF that subordinate had a legal attack
                                    int[] subordinateSquare = AIBishop.GetLocation(attackingPiece, b);
                                    outgoingAction.setAttack(false);
                                    outgoingAction.setDestinationCord(moveToSquares);
                                    outgoingAction.setID(attackingPiece.GetID());
                                    outgoingAction.setOriginalCord(subordinateSquare);
                                    outgoingAction.setPieceType(attackingPiece.GetType());
                                    outgoingAction.setIsAct(true);
                                    outgoingAction.setCommandingPiece(king);
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
            int length = subordinates.Length, prob = 0, prob1 = 0, counter = 0;
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
                        prob1 = randomNum.Next(0, p.GetLegalMoves().Count);
                        foreach (int[] moves in p.GetLegalMoves()){
                            if (!act && counter == prob1)
                            {
                                moveToSquares[0] = moves[0];
                                moveToSquares[1] = moves[1];
                                int[] subordinateSquare = AIBishop.GetLocation(p, b);
                                outgoingAction.setAttack(false);
                                outgoingAction.setDestinationCord(moveToSquares);
                                outgoingAction.setID(p.GetID());
                                outgoingAction.setOriginalCord(subordinateSquare);
                                outgoingAction.setPieceType(p.GetType());
                                outgoingAction.setIsAct(true);
                                outgoingAction.setCommandingPiece(king);
                                List<int[]> path = p.GetPath(moveToSquares[0], moveToSquares[1]);
                                outgoingAction.setPath(path);
                                act = true;
                            }
                            else
                            {
                                counter++;
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
                                int[] subordinateSquare = AIBishop.GetLocation(p, b);
                                outgoingAction.setAttack(false);
                                outgoingAction.setDestinationCord(moveToSquares);
                                outgoingAction.setID(p.GetID());
                                outgoingAction.setOriginalCord(subordinateSquare);
                                outgoingAction.setPieceType(p.GetType());
                                outgoingAction.setIsAct(true);
                                outgoingAction.setCommandingPiece(king);
                                List<int[]> path = p.GetPath(moveToSquares[0], moveToSquares[1]);
                                outgoingAction.setPath(path);
                                act = true;
                            }
                        }
                    }
                }
            }
            }
            //If after all this, no move was found, then we move on anyways and the king doesn't move.
            return outgoingAction;
        }

        //We want to make sure each bishop has a pawn and an offense piece
        public static void KingDelegationCheck(AIKing kingAI){
            bool del, offense, defense, knight, rook, pawn, delegated, sub0, sub1, com0, com1;
            int counter = 0;
            del = false;
            offense = false;
            defense = false;
            knight = false;
            pawn = false;
            rook = false;
            delegated = false;
            sub0 = false;
            sub1 = false;
            com0 = false;
            com1 = false;
            Piece[] emptyArray = {};
            Piece[] kingSubordinates;

            if (kingAI.GetCommander0()){
                foreach (Piece sub in kingAI.GetBishop0Subordinates()){
                    if (sub != null){
                        if (sub.GetType() == typeof(Pawn))
                            defense = true;
                        if (sub.GetType() == typeof(Knight) || sub.GetType() == typeof(Rook))
                            offense = true;
                    }
                }

                //First we want to check what pieces the king even has to give away if there is a need
                if (!offense || !defense){
                    foreach (Piece sub in kingAI.GetKingSubordinates()){
                        if (sub.GetType() == typeof(Pawn))
                            pawn = true;
                        if (sub.GetType() == typeof(Knight))
                            knight = true;
                        if (sub.GetType() == typeof(Rook))
                            rook = true;
                    }
                }

                if (!offense){
                    //Delegate a knight to the bishop (if possible)
                    if (knight && !delegated){
                        Console.WriteLine("A Knight has been delegated to Bishop 0");
                        kingAI.DelegateKnight(kingAI.GetBishop0Commander());
                        delegated = true;
                    }
                    //Delegate a rook to the bishop (if possible)
                    else if (rook && !delegated){
                        Console.WriteLine("A Rook has been delegated to Bishop 0");
                        kingAI.DelegateRook(kingAI.GetBishop0Commander());
                        delegated = true;
                    }
                }

                if (!defense){
                    //Delegate a pawn to the bishop
                    if (pawn){
                        Console.WriteLine("A Pawn has been delegated to Bishop 0");
                        kingAI.DelegatePawn(kingAI.GetBishop0Commander());
                        delegated = true;
                    }
                    
                }

            }

            if (kingAI.GetCommander1() && !delegated){
                foreach (Piece sub in kingAI.GetBishop1Subordinates()){
                    if (sub != null){
                        if (sub.GetType() == typeof(Pawn))
                            defense = true;
                        if (sub.GetType() == typeof(Knight) || sub.GetType() == typeof(Rook))
                            offense = true;
                    }
                }

                //First we want to check what pieces the king even has to give away if there is a need
                if (!offense || !defense){
                    foreach (Piece sub in kingAI.GetKingSubordinates()){
                        if (sub != null){
                            if (sub.GetType() == typeof(Pawn))
                                pawn = true;
                            if (sub.GetType() == typeof(Knight))
                                knight = true;
                            if (sub.GetType() == typeof(Rook))
                                rook = true;
                        }
                    }
                }

                if (!offense){
                    //Delegate a knight to the bishop (if possible)
                    if (knight && !delegated){
                        Console.WriteLine("A Knight has been delegated to Bishop 1");
                        kingAI.DelegateKnight(kingAI.GetBishop1Commander());
                        delegated = true;
                    }
                    //Delegate a rook to the bishop (if possible)
                    else if (rook && !delegated){
                        Console.WriteLine("A Rook has been delegated to Bishop 1");
                        kingAI.DelegateRook(kingAI.GetBishop1Commander());
                        delegated = true;
                    }
                }

                if (!defense){
                    //Delegate a pawn to the bishop
                    if (pawn){
                        Console.WriteLine("A Pawn has been delegated to Bishop 1");
                        kingAI.DelegatePawn(kingAI.GetBishop1Commander());
                        delegated = true;
                    }
                    
                }

            }

        }


        public static void KingBoardUpdate(Board newBoard, AIKing kingAI, bool commentsOn){
            bool com0 = false, com1 = false, sub0 = false, sub1 = false, b0 = false, b1 = false, k = false;
            int counter = 0, counter1 = 0, counter2 = 0, enemyCounter = 0;
            Piece[] oldSub0 = kingAI.GetBishop0Subordinates();
            Piece[] oldSub1 = kingAI.GetBishop1Subordinates();
            Piece[] oldKing = kingAI.GetKingSubordinates();
            Piece[] oldEnemy = kingAI.GetLiveEnemyPlayers();
            Piece[] emptyArray = {};
            Piece[] futureSub0 = new Piece[6];
            Piece[] futureSub1 = new Piece[6];
            Piece[] futureKing = new Piece[16];
            Piece[] futureEnemy = new Piece[16];
            Board oldBoard = kingAI.GetKingBoard();

            if (commentsOn){
                Console.WriteLine("Old Bishop 0 Subordinates");
                foreach (Piece p in oldSub0)
                    Console.Write(p + " ");
                Console.Write("\n");

                Console.WriteLine("Old Bishop 1 Subordinates");
                foreach (Piece p in oldSub1)
                    Console.Write(p + " ");
                Console.Write("\n");

                Console.WriteLine("Old King");
                foreach (Piece p in oldKing)
                    Console.Write(p + " ");
                Console.Write("\n");

                Console.WriteLine("Old Live Enemy Players");
                foreach (Piece p in oldEnemy)
                    Console.Write(p + " ");
                Console.Write("\n");
            }
            
            //Here we check if the commander is on the board, and if not, we turn the setting to false
            foreach (Piece p in newBoard.GetBoard()){
                if (p.GetType() == typeof(Bishop) && p.GetID() == 0 && p.GetColor() == Color.Black)
                    com0 = true;
                if (p.GetType() == typeof(Bishop) && p.GetID() == 1 && p.GetColor() == Color.Black)
                    com1 = true;
            }
             
            //If they weren't on the board, then we go ahead and check if the array was empty.
            if (kingAI.GetBishop0Subordinates() == emptyArray)
                sub1 = true;
            if (kingAI.GetBishop1Subordinates() == emptyArray)
                sub1 = true;

            // If the commander isn't on the board and their subordinates list isn't empty, we need to delegate.
            if (!com0 && !sub0)
                kingAI.DelegateCaptured(kingAI.GetBishop0Commander());

            // if (!com0 && !sub0)
            //     Console.WriteLine("DelegateCap for Commander 0");

            if (!com1 && !sub1)
                kingAI.DelegateCaptured(kingAI.GetBishop1Commander());

            // if (!com1 && !sub1)
            //     Console.WriteLine("DelegateCap for Commander 1");

            //At this point, the subordinates have been delegated if a subordinate has been captured.
            //Now we want to update the lists of subordinates themselves. We will go by the list of AI pieces on the newBoard
            //If there is an AI piece on the newboard, we will find where it is in the current list of subordinates and add it to lists we have

            foreach (Piece p in newBoard.GetBoard()){
                if (p.GetColor() == Color.Black){
                    //If the piece is black, we now need to find the piece in the current list of subordinates.
                    
                    foreach (Piece sub in kingAI.GetBishop0Subordinates()){
                        if (sub != null){
                            if (p.GetType() == sub.GetType() && p.GetID() == sub.GetID()){
                                futureSub0[counter] = p;
                                counter++;
                            }
                        }
                    }

                    foreach (Piece sub in kingAI.GetBishop1Subordinates()){
                        if (sub != null){
                            if (p.GetType() == sub.GetType() && p.GetID() == sub.GetID()){
                                futureSub1[counter1] = p;
                                counter1++;
                            }
                        }
                    }

                    foreach (Piece sub in kingAI.GetKingSubordinates()){
                        if (sub != null){
                            if (p.GetType() == sub.GetType() && p.GetID() == sub.GetID()){
                                futureKing[counter2] = p;
                                counter2++;
                            }
                        }
                    }

                }

                //At this point we also go ahead and save all the enemy pieces
                if (p.GetColor() == Color.White){
                    futureEnemy[enemyCounter] = p;
                    enemyCounter++;
                }
            }
            

            //Now that we have the lists ready, we update the lists on the kingAI
            kingAI.bishop0Subordinates = futureSub0;
            kingAI.bishop1Subordinates = futureSub1;
            kingAI.kingSubordinates = futureKing;   
            kingAI.LiveEnemyPlayers = futureEnemy;
            kingAI.commander0 = com0;
            kingAI.commander1 = com1; 
            // kingAI.SetBishop0Subordinates(futureSub0);
            // kingAI.SetBishop1Subordinates(futureSub1);
            // kingAI.SetKingSubordinates(futureKing);   
            // kingAI.SetLiveEnemyPlayers(futureEnemy);
            // kingAI.SetCommander0(com0);
            // kingAI.SetCommander1(com1); 

            // Console.WriteLine("New Bishop 0 Subordinates");
            // foreach (Piece p in futureSub0)
            //     Console.Write(p + " ");
            // Console.Write("\n");

            // Console.WriteLine("New Bishop 1 Subordinates");
            // foreach (Piece p in futureSub1)
            //     Console.Write(p + " ");
            // Console.Write("\n");

            // Console.WriteLine("New King");
            // foreach (Piece p in futureKing)
            //     Console.Write(p + " ");
            // Console.Write("\n");

            // Console.WriteLine("New Live Enemy Players");
            // foreach (Piece p in futureEnemy)
            //     Console.Write(p + " ");
            // Console.Write("\n");

            if (commentsOn){
                Console.WriteLine("New Bishop 0 Subordinates");
                foreach (Piece p in kingAI.GetBishop0Subordinates())
                    Console.Write(p + " ");
                Console.Write("\n");

                Console.WriteLine("New Bishop 1 Subordinates");
                foreach (Piece p in kingAI.GetBishop1Subordinates())
                    Console.Write(p + " ");
                Console.Write("\n");

                Console.WriteLine("New King");
                foreach (Piece p in kingAI.GetKingSubordinates())
                    Console.Write(p + " ");
                Console.Write("\n");

                Console.WriteLine("New Live Enemy Players");
                foreach (Piece p in kingAI.GetKingSubordinates())
                    Console.Write(p + " ");
                Console.Write("\n");
            }

            kingAI.SetKingBoard(newBoard);

        }

        //Here we add the king oversight function, we need to assign kingOversightDefense, if the king has lost a commander, we should be on the defensive. or if we have all three commanders but only 5 subordinates
        public static bool KingOversightFunction(AIKing kingAI){
            int totalSubordinates = 0;
            if (kingAI.GetCommander0() && kingAI.GetCommander1())
                totalSubordinates = kingAI.GetBishop0Subordinates().Length + kingAI.GetBishop1Subordinates().Length + kingAI.GetKingSubordinates().Length;
            else if (kingAI.GetCommander0())
                totalSubordinates = kingAI.GetBishop0Subordinates().Length + kingAI.GetKingSubordinates().Length;
            else if (kingAI.GetCommander1())
                totalSubordinates = kingAI.GetBishop1Subordinates().Length + kingAI.GetKingSubordinates().Length;
            else
                totalSubordinates = kingAI.GetKingSubordinates().Length;
            
            if (totalSubordinates >= 8)
                return true;

            if (!kingAI.GetCommander0())
                return false;
            if (!kingAI.GetCommander1())
                return false;

            return true;
        }

        public static Action[] KingAIFunction(AIKing kingAI){

            /*
                To-do List:
                Fix Subordinate Issue:
                ~~Made it so Bishops aren't kings subordinates (Done)
                ~~For now the king won't care if they are in danger, might need to add that
                Implement Delegation:
                ~~Make it so list of subordinates stay with the king and isn't recalculated each time (Done)
                ~~Make a check within the KingAIFunction (new method) where if the bishops dont have the needed subordinates, we delegate it to em (Done)
                ~~And implement the above ^ (Done)
                Implement Board updating
                ~~As of now, the EL creates a new KingAI object every time it needs a decision (Done)
                ~~We next need to implement a way to update the game board and consequently update Live enemy players, Live subordinates/commanders, and go from there (Done)
                Implement Attack Paths for the knight:
                ~~We need paths for the action class to print out when the knight attacks. (Done)
                Implement Free Action:
                ~~Need to make Bishop return an array of actions, not just one action (Done)
                ~~Need to make it so bishops only use a free action once (Done)
                ~~Need to make it so Kings can use an array of actions from the bishops, not just one action (Done)
                Implement Kings Oversight:
                ~~Need to give bishops a perrogative, either be on defense mode or offense mode. If offense mode, then we do offense play before threat detection.(Done)
                ~~For this, we may need to make the bishopAI into functions like the king, and change the order accordingly. (Done)
                ~~Maybe have an offensive function and a defensive function where we change the order? (Done)
                ~~Have a check before the bishops move, we check how many pieces we have on the board and if we have lost a subordinate (Done)
                ~~If there are less than 8 subordinates total or if we have lost a commander, we will go on defense mode. (Done)
                ~~In defense mode: Bishop Immediate Threat Detection, then Bishop Subordinate Threat Detection, then Bishop Offensive Play (Done)
                ~~In offense mode: Bishop Immediate Threat Detection, then Bishop Offensive Play, then Bishop Subordinate Threat Detection (Done)

                Implement Move-To-Attack:
                - We want to move to the piece next to it (if a knight) (Maybe have a move action?) 
                - We don't want to just move the piece to capture, we want to initialize the capture and still have the correct destination coordinates. 
                Implement Die Roll:
                - If there is an attack, we want to request the die roll (prior to this we will generate a random number)
                - And if successful, then capture the piece
                
                
                

            */
            //Declaration of 'global' variables used here.

            //Before we make moves, we can check that bishops have enough subordinates to work with, so we delegate. 
            //We also need to check if any bishop was captured so that we can delegate the troops back to the king.
            KingDelegationCheck(kingAI);


            Board b = kingAI.GetKingBoard();
            Piece bCommander0 = kingAI.GetBishop0Commander();
            Piece[] c0Subordinates = kingAI.GetBishop0Subordinates();
            Piece bCommander1 = kingAI.GetBishop1Commander();
            Piece[] c1Subordinates = kingAI.GetBishop1Subordinates();
            Piece king = kingAI.GetKingCommander();
            Piece[] kingSubordinates = kingAI.GetKingSubordinates();
            Piece[] LiveEnemyPlayers = kingAI.GetLiveEnemyPlayers();

            Action[] bishop0Actions = new Action[3];
            Action[] bishop1Actions = new Action[3];
            Action kingAction = new Action();

            // b.Print();

            int actionCounter = 0;
            bool commentsOn = false, kingAct = false, kingOversightDefense = false;
        
            //Here we add the king oversight function, we need to assign kingOversightDefense
            kingOversightDefense = KingOversightFunction(kingAI);


            //Here we clear the list of actions we will fill by the end of the AI run.
            kingAI.ClearListOfActions();
        

            Action outgoingAction = new Action();

            //This will be the King Immediate Threat Detection
            outgoingAction = KingImmediateThreatDetection(kingAI, LiveEnemyPlayers, king, b, commentsOn);
            if (outgoingAction.getIsActing()){
                kingAI.AddAnAction(outgoingAction);
                kingAct = true;
            }

            //This will be the Subordinate Threat Detection
            if (!kingAct){
                Action outgoingAction1 = new Action();
                outgoingAction1 = KingSubordinateThreatDetection(kingAI, LiveEnemyPlayers, king, b, commentsOn);
                if (outgoingAction1.getIsActing()){
                    kingAI.AddAnAction(outgoingAction1);
                    kingAct = true;
                }   
            }

            //This will be the Subordinate Offensive Check
            if (!kingAct){
                outgoingAction = KingSubordinateOffensiveCheck(kingAI, LiveEnemyPlayers, king, b, commentsOn);
                if (outgoingAction.getIsActing()){
                    kingAI.AddAnAction(outgoingAction);
                    kingAct = true;
                }   
            }

            Console.WriteLine("King Actions.");

            //We then implement the king's actions
            foreach(Action act in kingAI.GetListOfActions())
            {
                if(act.getIsActing() && !act.getCompleted()){
                    b.Move(act.getOriginalXCord(), act.getOriginalYCord(), 
                        act.getDestinationXCord(), act.getDestinationYCord());
                    //act.printAction();
                    act.printAction();
                    Console.WriteLine("New Board:");
                    b.Print(); 
                    act.setCompleted(true);
                }
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~");

            //If the kingAI has an active commander 0, we get the needed action from it.
            if (kingAI.GetCommander0()){
                bishop0Actions = AIBishop.BishopAI(b, bCommander0, c0Subordinates, LiveEnemyPlayers, kingOversightDefense);
                Console.WriteLine("Bishop 0 Actions.");
                foreach(Action act in bishop0Actions){
                    if(act.getIsActing()){
                        kingAI.AddAnAction(act);
                        act.printAction();
                    }
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~");
            }

            //We go ahead and take first bishops action, and implement them on our board if they are legal actions.
            foreach(Action act in kingAI.GetListOfActions())
            {
                if(act.getIsActing() && !act.getCompleted()){
                    b.Move(act.getOriginalXCord(), act.getOriginalYCord(), 
                        act.getDestinationXCord(), act.getDestinationYCord());
                    Console.WriteLine("New Board:");
                    b.Print(); 
                    act.setCompleted(true);
                }
            }
                
            //If the kingAI has an active commander 1, we get the needed action from it.
            if (kingAI.GetCommander1()){
                bishop1Actions = AIBishop.BishopAI(b, bCommander1, c1Subordinates, LiveEnemyPlayers, kingOversightDefense);
                Console.WriteLine("Bishop 1 Actions.");
                foreach(Action act in bishop1Actions){
                    if(act.getIsActing())
                    {
                        kingAI.AddAnAction(act);
                        act.printAction();
                    }
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~");
            }

            //Then we take last bishop actions, and implement them on our board if they are legal actions.
            foreach(Action act in kingAI.GetListOfActions())
            {
                if(act.getIsActing() && !act.getCompleted()){
                    b.Move(act.getOriginalXCord(), act.getOriginalYCord(), 
                        act.getDestinationXCord(), act.getDestinationYCord());
                    Console.WriteLine("New Board:");
                    b.Print(); 
                    act.setCompleted(true);
                }
            }

            return kingAI.GetListOfActions();

        }

        static void Main(string[] args)
        {
            String[,] boardArray1b = new String [8,8] {
                {"R0","N0","B0","Q0","K0","B1","N1","R1"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"p0","p1","p2","p3","p4","p5","p6","p7"},
                {"r0","n0","b0","q0","k0","b1","n1","r1"}
            }; 

            String[,] boardArray2b = new String [8,8] {
                {"R0","N0","e","Q0","K0","B1","N1","R1"},
                {"e","P1","e","e","P4","P5","P6","P7"},
                {"e","e","e","P2","e","e","e","e"},
                {"p0","e","B0","e","P3","e","e","e"},
                {"P0","e","b0","e","e","e","e","e"},
                {"p1","p2","e","e","e","e","e","e"},
                {"e","e","e","p3","p4","p5","p6","p7"},
                {"r0","n0","e","q0","k0","b1","n1","r1"}
            }; 

            String[,] boardArray2c = new String [8,8] {
                {"R0","N0","e","Q0","K0","B1","e","R1"},
                {"e","e","e","e","P4","P5","P6","P7"},
                {"e","e","e","P2","e","e","e","e"},
                {"p0","e","e","e","P3","e","e","e"},
                {"P0","e","b0","e","e","e","e","e"},
                {"p1","p2","e","e","e","e","e","e"},
                {"e","e","e","p3","p4","p5","p6","p7"},
                {"r0","n0","e","q0","k0","b1","n1","r1"}
            }; 

            String[,] boardArray3b = new String [8,8] {
                {"R0","N0","B0","Q0","K0","B1","e","R1"},
                {"e","P1","P2","e","e","P5","P6","e"},
                {"P0","e","P3","P4","e","e","P7","e"},
                {"e","e","p5","e","e","N1","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"p0","p1","p2","p3","p4","e","p6","p7"},
                {"r0","n0","b0","q0","k0","b1","n1","r1"}
            };

            String[,] boardArray3c = new String [8,8] {
                {"R0","N0","B0","Q0","K0","e","e","R1"},
                {"e","P1","P2","e","e","P5","P6","e"},
                {"P0","e","P3","P4","e","e","P7","e"},
                {"e","e","p5","e","e","N1","e","e"},
                {"e","e","e","e","e","e","e","e"},
                {"e","e","B1","e","e","e","e","e"},
                {"p0","p1","p2","p3","p4","e","p6","p7"},
                {"r0","n0","b0","q0","k0","b1","n1","r1"}
            };



            Board board = new Board(boardArray2b);

            board.Print();

            bool commentsOn = false;

            AIKing kingAI = new AIKing(board);
            Action[] arrayofActions = new Action[3];
            arrayofActions = KingAIFunction(kingAI);

            Console.WriteLine("Final Array of Actions");
            foreach (Action act in kingAI.GetListOfActions()){
                if (act.getIsActing())
                    act.printAction();
            }

            Console.WriteLine("This is the initial phase, now we manually input the next board as if the EL is sending us a board");

            Board board1 = new Board(boardArray2c);
            board1.Print();
            KingBoardUpdate(board1, kingAI, commentsOn);


            Board newBoard = kingAI.GetKingBoard();
            newBoard.Print();
            arrayofActions = KingAIFunction(kingAI);

            Console.WriteLine("Final Array of Actions");
            foreach (Action act in kingAI.GetListOfActions()){
                if (act.getIsActing())
                    act.printAction();
            }

            Console.WriteLine("This is the tertiary phase, now we manually input the next board as if the EL is sending us a board");

            Board board2 = new Board(boardArray3c);
            board2.Print();
            KingBoardUpdate(board2, kingAI, commentsOn);

            Board newBoard1 = kingAI.GetKingBoard();
            newBoard1.Print();
            arrayofActions = KingAIFunction(kingAI);

            Console.WriteLine("Final Array of Actions");
            foreach (Action act in kingAI.GetListOfActions()){
                if (act.getIsActing())
                    act.printAction();
            }
            

            // //Declaration of 'global' variables used here.
            // Board b = kingAI.GetKingBoard();
            // Piece bCommander0 = kingAI.GetBishop0Commander();
            // Piece[] c0Subordinates = kingAI.GetBishop0Subordinates();
            // Piece bCommander1 = kingAI.GetBishop1Commander();
            // Piece[] c1Subordinates = kingAI.GetBishop1Subordinates();
            // Piece king = kingAI.GetKingCommander();
            // Piece[] kingSubordinates = kingAI.GetKingSubordinates();
            // Piece[] LiveEnemyPlayers = kingAI.GetLiveEnemyPlayers();

            // Action bishop0Action = new Action();
            // Action bishop1Action = new Action();
            // Action kingAction = new Action();

            // // b.Print();

            // int actionCounter = 0;
            // bool commentsOn = true, kingAct = false;

            // //First we need to make sure we have a board, we implement the change from the execution layer
            // //This will include updating all of the live enemy players, removing any subordinates who may have been captured
            // //Here we will need to add a check, if a bishop was captured, we need to move its subordinates to the kings subordinates

        
            // //Here we clear the list of actions we will fill by the end of the AI run.
            // kingAI.ClearListOfActions();

            // // Then we need to call BishopAI for the two bishops if they exist. For now they will only return one action
            // //Eventually we want them to be able to make two moves if they need to.
            
            // if (kingAI.GetCommander0()){
            //     bishop0Action = AIBishop.BishopAI(b, bCommander0, c0Subordinates, LiveEnemyPlayers);
            //     if(bishop0Action.getIsActing())
            //         kingAI.AddAnAction(bishop0Action);
            // }
                
            // if (kingAI.GetCommander1()){
            //     bishop1Action = AIBishop.BishopAI(b, bCommander1, c1Subordinates, LiveEnemyPlayers);
            //     if(bishop1Action.getIsActing())
            //         kingAI.AddAnAction(bishop1Action);
            // }

            // //Then we take their actions, and implement them on our board if they are legal actions.
            // foreach(Action act in kingAI.GetListOfActions())
            // {
            //     if(act.getIsActing() && !act.getCompleted()){
            //         b.Move(act.getOriginalXCord(), act.getOriginalYCord(), 
            //             act.getDestinationXCord(), act.getDestinationYCord());
            //         act.printAction();
            //         Console.WriteLine("New Board:");
            //         b.Print(); 
            //         act.setCompleted(true);
            //     }
            // }

            // Action outgoingAction = new Action();
            

            // //This will be the King Immediate Threat Detection
            // outgoingAction = KingImmediateThreatDetection(kingAI, LiveEnemyPlayers, king, b, commentsOn);
            // if (outgoingAction.getIsActing()){
            //     kingAI.AddAnAction(outgoingAction);
            //     kingAct = true;
            // }

            // //This will be the Subordinate Threat Detection
            // if (!kingAct){
            //     Action outgoingAction1 = new Action();
            //     outgoingAction1 = KingSubordinateThreatDetection(kingAI, LiveEnemyPlayers, king, b, commentsOn);
            //     if (outgoingAction1.getIsActing()){
            //         kingAI.AddAnAction(outgoingAction1);
            //         kingAct = true;
            //     }   
            // }

            // //This will be the Subordinate Offensive Check
            // if (!kingAct){
            //     outgoingAction = KingSubordinateOffensiveCheck(kingAI, LiveEnemyPlayers, king, b, commentsOn);
            //     if (outgoingAction.getIsActing()){
            //         kingAI.AddAnAction(outgoingAction);
            //         kingAct = true;
            //     }   
            // }

            // //We then implement the king's actions
            // foreach(Action act in kingAI.GetListOfActions())
            // {
            //     if(act.getIsActing() && !act.getCompleted()){
            //         b.Move(act.getOriginalXCord(), act.getOriginalYCord(), 
            //             act.getDestinationXCord(), act.getDestinationYCord());
            //         act.printAction();
            //         Console.WriteLine("New Board:");
            //         b.Print(); 
            //         act.setCompleted(true);
            //     }
        //     // }

        }

        public Board GetKingBoard(){
            return b;
        }
        public void SetKingBoard(Board b){
            this.b = b;
        }
        public Piece[] GetBishop0Subordinates(){
            return bishop0Subordinates;
        }
        public void SetBishop0Subordinates(Piece[] newsub){
            this.bishop0Subordinates = newsub;
        }
        public Piece[] GetBishop1Subordinates(){
            return bishop1Subordinates;
        }
        public void SetBishop1Subordinates(Piece[] newSub){
            this.bishop0Subordinates = newSub;
        }
        public Piece[] GetKingSubordinates(){
            return kingSubordinates;
        }
        public void SetKingSubordinates(Piece[] newSub){
            this.kingSubordinates = newSub;
        }
        public Piece GetBishop0Commander(){
            return this.bishop0Commander;
        }
        public void SetBishop0Commander(Piece newCO){
            this.bishop0Commander = newCO;
        }
        public Piece GetBishop1Commander(){
            return this.bishop1Commander;
        }
        public void SetBishop1Commander(Piece newCO){
            this.bishop1Commander = newCO;
        }
        public Piece GetKingCommander(){
            return this.kingCommander;
        }
        public void SetKingCommander(Piece newCO){
            this.kingCommander = newCO;
        }
        public Piece[] GetLiveEnemyPlayers(){
            return LiveEnemyPlayers;
        }
        public void SetLiveEnemyPlayers(Piece[] live){
            this.LiveEnemyPlayers = live;
        }
        public bool GetCommander0(){
            return commander0;
        }
        public void SetCommander0(bool newB){
            this.commander0 = newB;
        }
        public bool GetCommander1(){
            return commander1;
        }
        public void SetCommander1(bool newB){
            this.commander1 = newB;
        }

        public Action[] GetListOfActions(){
            return listOfActions;
        }

        public void ClearListOfActions(){
            for(int i = 0; i < listOfActions.Length; i++){
                listOfActions[i] = new Action();
            }
        }

        public void AddAnAction(Action act){
            for(int i = 0; i < listOfActions.Length; i++){
                if (listOfActions[i].getID() == -1){
                    listOfActions[i] = act;
                    return;
                }
            }
        }

        public void DelegateKnight(Piece commander){
            Piece[] kingSub = this.GetKingSubordinates();
            Piece tempPiece;
            int counter = 0;
            int counter1 = 0;
            Piece e;
            bool cont;
            cont = true;
            e = new EmptySquare();
            Piece[] subordinates;
            if (commander.GetID() == 0){
                subordinates = GetBishop0Subordinates();

                foreach (Piece sub in kingSub){
                    if (sub.GetType() == typeof(Knight) && cont){
                        //Here we put the part that actually delegates
                        tempPiece = sub;
                        foreach(Piece sub1 in subordinates){
                            if (sub1.GetType() == typeof(EmptySquare) || sub1 == null){
                                subordinates[counter1] = tempPiece;
                                kingSub[counter] = e;
                                SetBishop0Subordinates(subordinates);
                                SetKingSubordinates(kingSub);
                                cont = false;
                                break;
                            }
                            counter1++;
                        }

                    }
                    counter++;
                }
            }

            if (commander.GetID() == 1){
                subordinates = GetBishop1Subordinates();

                foreach (Piece sub in kingSub){
                    if (sub != null){
                        if (sub.GetType() == typeof(Knight) && cont){
                            //Here we put the part that actually delegates
                            tempPiece = sub;
                            foreach(Piece sub1 in subordinates){
                                if (sub1 == null || sub1.GetType() == typeof(EmptySquare)){
                                    subordinates[counter1] = tempPiece;
                                    kingSub[counter] = e;
                                    SetBishop1Subordinates(subordinates);
                                    SetKingSubordinates(kingSub);
                                    cont = false;
                                    break;
                                }
                                counter1++;
                            }

                        }
                        counter++;
                    }
                }
            }
            
        }

        public void DelegatePawn(Piece commander){
            Piece[] kingSub = this.GetKingSubordinates();
            Piece tempPiece;
            int counter = 0;
            int counter1 = 0;
            Piece e;
            bool cont;
            cont = true;
            e = new EmptySquare();
            Piece[] subordinates;
            if (commander.GetID() == 0){
                subordinates = GetBishop0Subordinates();

                foreach (Piece sub in kingSub){
                    if (sub.GetType() == typeof(Pawn) && cont){
                        //Here we put the part that actually delegates
                        tempPiece = sub;
                        foreach(Piece sub1 in subordinates){
                            if (sub1.GetType() == typeof(EmptySquare)){
                                subordinates[counter1] = tempPiece;
                                kingSub[counter] = e;
                                SetBishop0Subordinates(subordinates);
                                SetKingSubordinates(kingSub);
                                cont = false;
                                break;
                            }
                            counter1++;
                        }

                    }
                    counter++;
                }
            }

            if (commander.GetID() == 1){
                subordinates = GetBishop1Subordinates();

                foreach (Piece sub in kingSub){
                    if (sub.GetType() == typeof(Pawn) && cont){
                        //Here we put the part that actually delegates
                        tempPiece = sub;
                        foreach(Piece sub1 in subordinates){
                            if (sub1.GetType() == typeof(EmptySquare)){
                                subordinates[counter1] = tempPiece;
                                kingSub[counter] = e;
                                SetBishop1Subordinates(subordinates);
                                SetKingSubordinates(kingSub);
                                cont = false;
                                break;
                            }
                            counter1++;
                        }

                    }
                    counter++;
                }
            }
            
        }

        public void DelegateRook(Piece commander){
            
            Piece[] kingSub = this.GetKingSubordinates();
            Piece tempPiece;
            int counter = 0;
            int counter1 = 0;
            Piece e;
            bool cont;
            cont = true;
            e = new EmptySquare();
            Piece[] subordinates;

            if (commander.GetID() == 0){
                subordinates = this.GetBishop0Subordinates();

                foreach (Piece sub in kingSub){
                    if (sub.GetType() == typeof(Rook) && cont){
                        //Here we put the part that actually delegates
                        tempPiece = sub;
                        foreach(Piece sub1 in subordinates){
                            if (sub1.GetType() == typeof(EmptySquare)){
                                subordinates[counter1] = tempPiece;
                                kingSub[counter] = e;
                                SetBishop0Subordinates(subordinates);
                                SetKingSubordinates(kingSub);
                                cont = false;
                                break;
                            }
                            counter1++;
                        }

                    }
                    counter++;
                }
            }

            if (commander.GetID() == 1){
                subordinates = GetBishop1Subordinates();

                foreach (Piece sub in kingSub){
                    if (sub.GetType() == typeof(Rook) && cont){
                        //Here we put the part that actually delegates
                        tempPiece = sub;
                        foreach(Piece sub1 in subordinates){
                            if (sub1.GetType() == typeof(EmptySquare)){
                                subordinates[counter1] = tempPiece;
                                kingSub[counter] = e;
                                SetBishop1Subordinates(subordinates);
                                SetKingSubordinates(kingSub);
                                cont = false;
                                break;
                            }
                            counter1++;
                        }

                    }
                    counter++;
                }
            }
            
        }

        public void DelegateCaptured(Piece missingCommander){
            int counter = 0;
            Piece[] emptyArray = {};
            Piece[] kingSub1;
            Piece[] bishopSub;

            if (missingCommander.GetID() == 0){
                kingSub1 = this.GetKingSubordinates();
                bishopSub = this.GetBishop0Subordinates();
                foreach (Piece kingSub in kingSub1){
                    if (kingSub == null){
                        foreach (Piece sub in bishopSub){
                            kingSub1[counter] = sub;
                            counter++;
                        }
                        this.SetKingSubordinates(kingSub1);
                        this.SetBishop0Subordinates(emptyArray);
                        break;
                    }
                    else{
                        counter++;
                    }
                }
            }

            if (missingCommander.GetID() == 1){
                kingSub1 = this.GetKingSubordinates();
                bishopSub = this.GetBishop1Subordinates();
                foreach (Piece kingSub in kingSub1){
                    if (kingSub == null){
                        foreach (Piece sub in bishopSub){
                            kingSub1[counter] = sub;
                            counter++;
                        }
                        this.SetKingSubordinates(kingSub1);
                        this.SetBishop1Subordinates(emptyArray);
                        break;
                    }
                    else{
                        counter++;
                    }
                }
            }

        }


    }
    



}//End of namespace
