using System;
namespace Pieces {
	public enum Color {
		White, Black, Empty
	}
	public abstract class Piece {
		//Minimum rolls for each piece to capture another piece
		static int[,] attackerTable = {
		{4, 4, 4, 4, 5, 1},
		{4, 4, 4, 4, 5, 2},
		{5, 5, 5, 5, 5, 2},
		{5, 5, 5, 4, 5, 3},
		{4, 4, 4, 5, 5, 5},
		{6, 6, 6, 5, 6, 4} };
		//Order of the pieces (both left to right and top to bottom) in the AttackerTable
		static Type[] pieceOrder = new Type[6] { typeof(King), typeof(Queen), typeof(Knight), typeof(Bishop), typeof(Rook), typeof(Pawn) };

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
		//Returns the minimum roll needed for the attacker piece to defeat the defender piece
		public static int getMinimumRoll(Piece attacker, Piece defender) {
			if (attacker.GetType() == typeof(EmptySquare) || defender.GetType() == typeof(EmptySquare)) {
				return 0;
			} else {
				int attackerIndex = Array.IndexOf(pieceOrder, attacker.GetType());
				int defenderIndex = Array.IndexOf(pieceOrder, defender.GetType());
				return attackerTable[attackerIndex, defenderIndex];
			}
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
