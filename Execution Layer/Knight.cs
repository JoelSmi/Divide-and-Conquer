using Pieces;

namespace Knights {
    public class Knight : Piece
    {
        public Knight(string id)
        {
            this.movement = 4;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 3, 2, 2, 3, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.id = id;
        }
    }
}
