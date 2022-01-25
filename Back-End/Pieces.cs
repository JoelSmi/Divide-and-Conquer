namespace Pieces {
	public enum Color {
		White, Black, Empty
	}
	public abstract class Piece {
		protected Color c;
		//Returns if the piece is controlled by White or Black
		public Color GetColor() {
			return c;
		}
		//Returns whether the piece is actually an empty square
		public bool IsEmpty() {
			return c == Color.Empty;
		}
		//Returns the movement range of the piece
		public abstract int GetMovement();
		public abstract override string ToString();

	}
	public class Pawn : Piece {
		public Pawn(Color c) {
			this.c = c;
		}
		public override int GetMovement() {
			return 1;
		}
		public override string ToString() {
			if (c ==  Color.White) {
				return "p";
			} else {
				return "P";
			}
		}
	}
	public class Bishop : Piece {
		public Bishop(Color c) {
			this.c = c;
		}
		public override int GetMovement() {
			return 2;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "b";
			} else {
				return "B";
			}
		}
	}
	public class Knight : Piece {
		public Knight(Color c) {
			this.c = c;
		}
		public override int GetMovement() {
			return 4;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "n";
			} else {
				return "N";
			}
		}
	}
	public class Rook : Piece {
		public Rook(Color c) {
			this.c = c;
		}
		public override int GetMovement() {
			return 2;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "r";
			} else {
				return "R";
			}
		}
	}
	public class Queen : Piece {
		public Queen(Color c) {
			this.c = c;
		}
		public override int GetMovement() {
			return 3;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "q";
			} else {
				return "Q";
			}
		}
	}
	public class King : Piece {
		public King(Color c) {
			this.c = c;
		}
		public override int GetMovement() {
			return 3;
		}
		public override string ToString() {
			if (c == Color.White) {
				return "k";
			} else {
				return "K";
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
			return "-";
		}
	}
}