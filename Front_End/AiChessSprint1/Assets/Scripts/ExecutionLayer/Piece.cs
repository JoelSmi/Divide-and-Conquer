using System.Collections.Generic;

namespace Pieces
{
    public abstract class Piece
    {
        /*
            Movemnt stores the number of spaces the current piece type has to be able to move, 1 means only adjacent spaces
            Movement type denoted by a single character defines how the peice moves/in what direction it can move
                (i.e. F means forward in the derection of opposing side, S means Square centered at the current position of the piece)
        */
        public short movement { get; protected set; } = 0;
        public char movementType { get; protected set; } = 'N';

        /*
            * DefenseProb stores the number of ways to succeed against the current piece (i.e. 2 means that only 5 and 6 
            * are the only numbers that the attacker can roll for success against the Bishop) the array positions for the attacker identity
            * follows: {Pawn, Rook, Bishop, Knight, Queen, King}
        */
        public short[] defenseProb { get; protected set; } = new short[6];

        /*
            Attack stores the number of spaces the current piece type has to be able to attack, 1 means only adjacent spaces
            Attack type denoted by a single character defines how the peice attacks/in what direction it can attack
                (i.e. F means forward in the derection of opposing side, S means Square centered at the current position of the piece, R means ranged)
        */
        public short attack { get; protected set; } = 0;
        public char attackType { get; protected set; } = 'N';

        /*
            The color indicates which team the peice belongs to while the id
            is how the piece is represnted on the board
        */
        public string color { get; protected set; } = "";
        public string id { get; protected set; } = "";

        //boolean value to determine if a peice has been captured or not 
        public bool isCaptured { get; set; } = false;
        //Storage of the current position of the peice in the format of {x,y}, or {row,column}
        public int[] currPos { get; set; } = new int[2];
    }

    //Subclass of Piece to store the commander information
    public abstract class Commander : Piece 
    {
        public Delegations Delegation;
        //Stores the maximum numbe of actions this peice can perform or command
        public int actionCount { get; protected set; } = 0;
        public abstract void getDelegates(Piece[,] TeamBoard, string[] DelIds);
    }


    #region EmptyPiece
    public class Empty : Piece
    {
        public Empty(string id, string Color)
        {
            this.movement = 0;
            this.movementType = 'N';
            this.defenseProb = new short[] { 6, 6, 6, 6, 6, 6 };

            this.attack = 0;
            this.attackType = 'N';

            this.color = Color;
            this.id = id;
        }
    }
    #endregion

    #region Pawn/Rook
    public class Pawn : Piece
    {
        public Pawn(string id, string Color)
        {
            this.movement = 1;
            this.movementType = 'F';
            this.defenseProb = new short[] { 3, 2, 4, 5, 5, 6 };

            this.attack = 1;
            this.attackType = 'F';

            this.color = Color;
            this.id = id;
        }
    }
    

    public class Rook : Piece
    {

        public Rook(string id, string Color)
        {
            this.movement = 2;
            this.movementType = 'L';
            this.defenseProb = new short[] { 1, 2, 2, 2, 2, 2 };

            this.attack = 3;
            this.attackType = 'R';

            this.color = Color;
            this.id = id;
        }
    }
    #endregion

    #region Royalty/Commanders
    public class Knight : Piece
    {
        public Knight(string id, string Color)
        {
            this.movement = 4;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 3, 2, 2, 3, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.color = Color;
            this.id = id;
        }
    }

    public class Queen : Piece
    {
        public Queen(string id, string Color)
        {
            this.movement = 3;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 3, 2, 2, 3, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.color = Color;
            this.id = id;
        }
    }
    #endregion

    #region Commanders
    ///Both the Bishop and King have two addition variables 
    ///called delegates and action count
    public class Bishop : Commander
    {
        public Bishop(string id, string Color)
        {   
            this.actionCount = 2;
            this.movement = 2;
            this.movementType = 'L';

            this.defenseProb = new short[] { 2, 2, 3, 2, 2, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.actionCount = 2;

            this.color = Color;
            this.id = id;
        }

        override
        public void getDelegates(Piece[,] TeamBoard, string[] DelIds)
        {
            this.Delegation = new Delegations(this.id, TeamBoard, DelIds);
        }
    }
    public class King : Commander
    {
        public King(string id, string Color)
        {
            this.actionCount = 2;
            this.movement = 4;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 3, 2, 2, 3, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.actionCount = 2;

            this.color = Color;
            this.id = id;
        }

        override
        public void getDelegates(Piece[,] TeamBoard, string[] DelIds)
        {
            this.Delegation = new Delegations(this.id, TeamBoard, DelIds);
        }
    }
    #endregion

    #region Commander Delegation Class
    public class Delegations 
    {
        public List<Piece> delegates { get; private set; }
        public Delegations(string CommandId, Piece[,] TeamBoard, string[] DelIds)
        {
            if (CommandId.Equals("K0") || CommandId.Equals("k0")) {
                delegates = new List<Piece>();
                delegates.Capacity = 15;
            }
            else {
                delegates= new List<Piece>();
                delegates.Capacity = 6;
            }

            for(int i = 0; i < TeamBoard.GetLength(0); i++)
            {
                for(int j = 0; j < TeamBoard.GetLength(1); j++)
                {
                    foreach(string id in DelIds)
                    {
                        if (id.Equals(TeamBoard[i, j].id)){
                            delegates.Add(TeamBoard[i, j]);
                        }
                    }
                }
            }
        }

        
        public int update(Piece CurrPiece, char updateType)
        {
            switch (updateType)
            {
                case 'A':
                    if (delegates.Count == delegates.Capacity)
                    {
                        break;
                    }
                    else
                    {
                        delegates.Add(CurrPiece);
                        return 2;
                    }
                    break;
                case 'R':
                    delegates.Remove(CurrPiece);
                    return 0;
                    break;
                default:
                    return -1;
            }
            return -1;
        }
    }
    #endregion

}