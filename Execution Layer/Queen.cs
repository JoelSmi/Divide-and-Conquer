using Pieces;

namespace Queens {
    public class Queen : Piece
    {
        public Queen(string id)
        {
            this.movement = 3;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 3, 2, 2, 3, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.id = id;
        }
    }
}

