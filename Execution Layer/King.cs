using Pieces;

namespace Kings
{
    public class King : Piece
    {
        private string[] Delegates = new string[16];
        protected bool isCaptured = false;
        protected int actionCount;

        public King(string id)
        {
            this.movement = 4;
            this.movementType = 'S';
            this.defenseProb = new short[] { 1, 3, 2, 2, 3, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.actionCount = 6;

            this.id = id;
        }
    }
}
