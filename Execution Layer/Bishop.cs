using Pieces;

namespace Bishops
{
    public class Bishop : Piece
    {
        private string[] Delegates = new string[6];
        protected bool isCaptured = false;
        protected int actionCount;

        public Bishop(string id)
        {
            this.movement = 2;
            this.movementType = 'S';

            this.defenseProb = new short[] { 2, 2, 3, 2, 2, 3 };

            this.attack = 1;
            this.attackType = 'S';

            this.actionCount = 0;

            this.id = id;
        }
    }
}