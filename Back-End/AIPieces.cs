using System;
using System.Collections;
using System.Collections.Generic;
namespace KingAI1 {
	public enum Color {
		White, Black, Empty
	}
	public enum MovementType {
		Free, Linear, None
	}
	public enum Direction {
		North, Northwest, Northeast, South, Southwest, Southeast, West, East, None
	}
	public abstract class Piece {
		//Minimum rolls for each piece to capture another piece
		protected static int[,] attackerTable = {
		{4, 4, 4, 4, 5, 1},
		{4, 4, 4, 4, 5, 2},
		{5, 5, 5, 5, 5, 2},
		{5, 5, 5, 4, 5, 3},
		{4, 4, 4, 5, 5, 5},
		{6, 6, 6, 5, 6, 4} };
		//Order of the pieces (both left to right and top to bottom) in the AttackerTable
		static Type[] pieceOrder = new Type[6] { typeof(King), typeof(Queen), typeof(Knight), typeof(Bishop), typeof(Rook), typeof(Pawn) };
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
		protected Color color;
		protected int id, movement;
		protected MovementType movementType;
		protected HashSet<int[]> legalMoves, legalAttacks;
		protected HashSet<Direction> omni = new HashSet<Direction>(new Direction[] { Direction.North, Direction.Northwest, Direction.Northeast,
			Direction.South, Direction.Southwest, Direction.Southeast, Direction.West, Direction.East });
		protected HashSet<Direction> legalDirections;
		protected List<List<int[]>> paths;
		//This prints details about a piece
		public void PrintPiece()
		{
			Console.WriteLine("This is the " + this.GetColor() + " " + this.GetType().Name + " with the ID of " + this.GetID());
		}
		//Returns if the piece is controlled by White or Black
		public Color GetColor() {
			return color;
		}
		//Returns whether the piece is actually an empty square
		public bool IsEmpty() {
			return color == Color.Empty;
		}
		//Returns the piece ID
		public int GetID() {
			return id;
		}
		//Returns the movement range of the piece
		public int GetMovement() {
			return movement;
		}
		//Gets the movement type of the piece (whether it can turn during a move or not)
		public MovementType GetMovementType() {
			return movementType;
		}
		//Gets the set of legal spaces for this piece to move to by their coordinate pairs
		public HashSet<int[]> GetLegalMoves() {
			return legalMoves;
		}
		//Gets the set of spaces which contain enemy pieces that this piece is threatening
		public HashSet<int[]> GetLegalAttacks() {
			return legalAttacks;
		}
		//Get the paths to each space that a piece can legally move to
		public List<List<int[]>> GetPaths() {
			return paths;
		}
		//Return a valid path to the square at (row, col) if it is a legal move, or an empty path if it is not
		public List<int[]> GetPath(int row, int col) {
			foreach (List<int[]> path in paths) {
				if (path[path.Count - 1][0] == row && path[path.Count - 1][1] == col) {
					return path;
				}
			}
			return new List<int[]>();
		}
		public bool HasLegalMove() {
			return legalMoves != null && legalMoves.Count > 0;
		}
		public bool HasLegalAttack() {
			return legalAttacks != null && legalAttacks.Count > 0;
		}
		public bool IsCommander() {
			return this.ToString() == "B0" || this.ToString() == "B1";
		}
		//Update the legal moves and attacks for this piece based on the board and its position
		public void UpdateLegalActions(Board b, int row, int col) {
			//Update legal moves and paths using recursive helper method
			paths = new List<List<int[]>>();
			this.legalMoves = UpdateLegalMoves(b, row, col, movement, new List<int[]>(), new HashSet<int[]>(), Direction.None);
			//Update legal attacks
			legalAttacks.Clear();
			if (this.GetType() == typeof(Rook)) {
				//Allow rook to attack any enemy piece within 3 squares
				foreach (int[] square in b.GetSquaresInRange(row, col, 3)) {
					if (b.GetBoard()[square[0], square[1]].GetColor() != Color.Empty
							&& b.GetBoard()[square[0], square[1]].GetColor() != color) {
						legalAttacks.Add(square);
					}
				}
			} else {
				//Add adjacent spaces containing enemy pieces to the list of legal attacks
				foreach (int[] square in b.GetAdjacentSquares(row, col).Values) {
					if (b.GetBoard()[square[0], square[1]].GetColor() != Color.Empty
							&& b.GetBoard()[square[0], square[1]].GetColor() != color
							&& !Board.SetContainsSquare(legalAttacks, square)) {
						legalAttacks.Add(square);
						List<int[]> attackPath = new List<int[]>();
						attackPath.Add(square);
						if (!paths.Contains(attackPath)) {
							paths.Add(attackPath);
						}
					}
				}
				//Allow knight to also attack any piece adjacent to one of its legal squares
				if (this.GetType() == typeof(Knight)) {
					foreach (int[] legalMove in legalMoves) { 
						foreach (int[] square in b.GetAdjacentSquares(legalMove[0], legalMove[1]).Values) {
							if (b.GetBoard()[square[0], square[1]].GetColor() != Color.Empty
									&& b.GetBoard()[square[0], square[1]].GetColor() != color
									&& !Board.SetContainsSquare(legalAttacks, square)) {
								legalAttacks.Add(square);
								List<int[]> attackPath = new List<int[]>(this.GetPath(legalMove[0], legalMove[1]));
								attackPath.Add(square);
								if (!paths.Contains(attackPath)) {
									paths.Add(attackPath);
								}
							}
						}
					}
				}
			}
		}
		public void SetLegalAttacks(HashSet<int[]> legalAttacks) {
			this.legalAttacks = legalAttacks;
		}
		//Gets the set of legal directions this piece can move in
		public HashSet<Direction> GetLegalDirections() {
			return legalDirections;
		}
		/**Recursive helper function for pathing all legal moves (and their paths) for a piece
		* Precondition: Piece p is not an EmptySquare */
		private HashSet<int[]> UpdateLegalMoves(Board b, int row, int col, int remainingMov,
				List<int[]> path, HashSet<int[]> legalMoves, Direction movementDir) {
			if (remainingMov <= 0) {
				//Piece has no movement remaining, so return the compiled set of legal moves
				return legalMoves;
			}
			//Create the coordinate pairs of the 8 adjacent squares
			Dictionary<Direction, int[]> directions = b.GetAdjacentSquares(row, col);
			//Create combinations of these squares according to the legal movement directions for each piece
			if (movementDir != Direction.None && movementType == MovementType.Linear) {
				//Must continue moving in the direction we were moving
				foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
					if (dir != movementDir) {
						directions.Remove(dir);
					}
				}
			} else {
				//Make the list conform to the set of legal directions for this piece
				foreach (Direction dir in Enum.GetValues(typeof(Direction))) {
					if (!legalDirections.Contains(dir)) {
						directions.Remove(dir);
					}
				}
			}
			//Filter out spaces that are out of bounds, occupied by an ally piece, or already explored
			HashSet<Direction> directionKeys = new HashSet<Direction>(directions.Keys);
			foreach (Direction dir in directionKeys) {
				int[] square = directions[dir];
				List<int[]> pathToDir = this.GetPath(square[0], square[1]); //Path to current directional square
				double pathLength = ComputePathLength(pathToDir); //Length of path to current directional square (0 if not found)
				List<int[]> newPath = new List<int[]>(path);
				newPath.Add(new int[] { square[0], square[1] });
				if (!b.IsInBounds(square[0], square[1]) || b.GetBoard()[square[0], square[1]].GetColor() == color
						|| (Board.SetContainsSquare(legalMoves, square) && ComputePathLength(newPath) >= pathLength)) {
					//Out of bounds, occupied by ally piece, or already explored along an equal or shorter path
					directions.Remove(dir);
				} else if (b.GetBoard()[square[0], square[1]].GetColor() != Color.Empty) {
					directions.Remove(dir);
					if (remainingMov == movement) {//Piece is adjacent to an enemy piece
						legalAttacks.Add(square);
					}
				} else {
					//A legal empty square which we have not yet efficiently traversed has been found
					legalMoves.Add(square);
					//Remove the inefficient path already calculated to this square, if one exists
					paths.Remove(pathToDir);
					//Add the path to this square to the list of paths
					paths.Add(newPath);
				}
			}
			foreach (Direction dir in directions.Keys) {
				int[] square = directions[dir];
				//Update the list of legal moves by traversing to each square in the queue and finding the legal moves given that square
				legalMoves = new HashSet<int[]>(UpdateLegalMoves(b, square[0], square[1], remainingMov - 1, 
					this.GetPath(square[0], square[1]), legalMoves, dir));
			}
			return legalMoves;
		}
		//Computes the distance traveled through a given path
		private static double ComputePathLength(List<int[]> path) {
			double length = 0;
			for (int i = 0; i < path.Count - 1; i++) {
				length += Math.Sqrt(Math.Pow(path[i + 1][0] - path[i][0], 2) + Math.Pow(path[i + 1][1] - path[i][1], 2));
			}
			return length;
		}
		public abstract override string ToString();
	}
	public class Pawn : Piece {
		public Pawn(Color c, int id) {
			this.color = c;
			this.id = id;
			movement = 1;
			movementType = MovementType.Linear;
			if (color == Color.White) {
				legalDirections = new HashSet<Direction>(new Direction[] { Direction.North, Direction.Northwest, Direction.Northeast });
			} else if (color == Color.Black) {
				legalDirections = new HashSet<Direction>(new Direction[] { Direction.South, Direction.Southwest, Direction.Southeast });
			} else {//This shouldn't happen
				legalDirections = new HashSet<Direction>();
			}
		}
		public override string ToString() {
			if (color ==  Color.White) {
				return "p" + id;
			} else {
				return "P" + id;
			}
		}
	}
	public class Bishop : Piece {
		public Bishop(Color c, int id) {
			this.color = c;
			this.id = id;
			movement = 2;
			movementType = MovementType.Linear;
			legalDirections = omni;
		}
		public override string ToString() {
			if (color == Color.White) {
				return "b" + id;
			} else {
				return "B" + id;
			}
		}
	}
	public class Knight : Piece {
		public Knight(Color c, int id) {
			this.color = c;
			this.id = id;
			movement = 4;
			movementType = MovementType.Free;
			legalDirections = omni;
		}
		public override string ToString() {
			if (color == Color.White) {
				return "n" + id;
			} else {
				return "N" + id;
			}
		}
	}
	public class Rook : Piece {
		public Rook(Color c, int id) {
			this.color = c;
			this.id = id;
			movement = 2;
			movementType = MovementType.Linear;
			legalDirections = omni;
		}
		public override string ToString() {
			if (color == Color.White) {
				return "r" + id;
			} else {
				return "R" + id;
			}
		}
	}
	public class Queen : Piece {
		public Queen(Color c) {
			this.color = c;
			id = 0;//only 1 Queen
			movement = 3;
			movementType = MovementType.Free;
			legalDirections = omni;
		}
		public override string ToString() {
			if (color == Color.White) {
				return "q" + id;
			} else {
				return "Q" + id;
			}
		}
	}
	public class King : Piece {
		public King(Color c) {
			this.color = c;
			id = 0;//only 1 King
			movement = 3;
			movementType = MovementType.Free;
			legalDirections = omni;
		}
		public override string ToString() {
			if (color == Color.White) {
				return "k" + id;
			} else {
				return "K" + id;
			}
		}
	}
	public class EmptySquare : Piece {
		public EmptySquare() {
			this.color = Color.Empty;
			movement = 0;
			movementType = MovementType.None;
			legalDirections = new HashSet<Direction>();
		}
		public override string ToString() {
			return "  ";
		}
	}
}
