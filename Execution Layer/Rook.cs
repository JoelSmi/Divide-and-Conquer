using Pieces;

namespace Rooks
{
    public class Rook : Piece
    {

        public Rook(string id)
        {
            this.movement = 2;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 2, 2, 2, 2, 2 };

            this.attack = 3;
            this.attackType = 'R';

            this.id = id;
        }
    }
}
