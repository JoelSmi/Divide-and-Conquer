using Pieces;

namespace Pawns
{
    public class Pawn : Piece
    {
        public Pawn(string id)
        {
            this.movement = 1;
            this.movementType = 'F';
            this.defenseProb = new short[] { 3, 2, 4, 5, 5, 6 };

            this.attack = 1;
            this.attackType = 'F';

            this.id = id;
        }
    }
}