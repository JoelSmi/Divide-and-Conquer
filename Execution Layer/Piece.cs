
namespace Pieces
{
    public abstract class Piece
    {
        /*
            Movemnt stores the number of spaces the current piece type has to be able to move, 1 means only adjacent spaces
            Movement type denoted by a single character defines how the peice moves/in what direction it can move
                (i.e. F means forward in the derection of opposing side, S means Square centered at the current position of the piece)
        */
        protected short movement = 0;
        protected char movementType = 'N';

        /*
            * DefenseProb stores the number of ways to succeed against the current piece (i.e. 2 means that only 5 and 6 
            * are the only numbers that the attacker can roll for success against the Bishop) the array positions for the attacker identity
            * follows: {Pawn, Rook, Bishop, Knight, Queen, King}
        */
        protected short[] defenseProb = new short[6];

        /*
            Attack stores the number of spaces the current piece type has to be able to attack, 1 means only adjacent spaces
            Attack type denoted by a single character defines how the peice attacks/in what direction it can attack
                (i.e. F means forward in the derection of opposing side, S means Square centered at the current position of the piece, R means ranged)
        */
        protected short attack = 0;
        protected char attackType = 'N';

        protected string id = "";

        public short getMovement()
        {
            return this.movement;
        }

        public char getMovementType()
        {
            return this.movementType;
        }

        public short[] getDefenseProb()
        {
            return this.defenseProb;
        }

        public short getAttack()
        {
            return this.attack;
        }

        public char getAttackType()
        {
            return this.attackType;
        }

        public string getId()
        {
            return this.id;
        }
    }
}