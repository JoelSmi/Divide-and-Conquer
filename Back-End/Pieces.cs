namespace Pieces {
	public enum Color {
		White, Black, Empty
	}
	public abstract class Piece {
		protected Color c;
		protected int id;
		//Returns if the piece is controlled by White or Black
		public Color GetColor() {
			return c;
		}
		//Returns whether the piece is actually an empty square
		public bool IsEmpty() {
			return c == Color.Empty;
		}
		//Returns the piece ID
		public int getID() {
			return id;
		}
		//Returns the movement range of the piece
		public abstract int GetMovement();
		public abstract override string ToString();
	}
	public class Pawn : Piece {
		public Pawn(Color c, int id) {
			this.c = c;
			this.id = id;
		}
		public override int GetMovement() {
			return 1;
		}
		public override string ToString() {
			if (c ==  Color.White) {
				return "p" + id;
			} else {
				return "P" + id;
			}
		}
	}
	public class Bishop : Piece {
		public Bishop(Color c, int id) {
			this.c = c;
			this.id = id;
		}
		public override int GetMovement() {
			return 2;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "b" + id;
			} else {
				return "B" + id;
			}
		}
	}
	public class Knight : Piece {
		public Knight(Color c, int id) {
			this.c = c;
			this.id = id;
		}
		public override int GetMovement() {
			return 4;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "n" + id;
			} else {
				return "N" + id;
			}
		}
	}
	public class Rook : Piece {
		public Rook(Color c, int id) {
			this.c = c;
			this.id = id;
		}
		public override int GetMovement() {
			return 2;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "r" + id;
			} else {
				return "R" + id;
			}
		}
	}
	public class Queen : Piece {
		public Queen(Color c) {
			this.c = c;
			id = 0;//only 1 Queen
		}
		public override int GetMovement() {
			return 3;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "q" + id;
			} else {
				return "Q" + id;
			}
		}
	}
	public class King : Piece {
		public King(Color c) {
			this.c = c;
			id = 0;//only 1 King
		}
		public override int GetMovement() {
			return 3;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "k" + id;
			} else {
				return "K" + id;
			}
		}
	}
	public class EmptySquare : Piece {
		public EmptySquare() {
			this.c = Color.Empty;
		}
		public override int GetMovement() {
			return 0;
		}
		public override string ToString() {
			return "--";
		}
	}
}
