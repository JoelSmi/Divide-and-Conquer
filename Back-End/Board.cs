using Pieces;
using System;
using System.Collections.Generic;
public class Board {
	private Piece[,] board;
	private int dim;
	private EmptySquare e;
	
	//Default 8x8 chessboard
	public Board()
	{
		e = new EmptySquare();
		board = new Piece[8, 8] {
			// row 0
			{ new Rook(Color.Black, 0), new Knight(Color.Black, 0), new Bishop(Color.Black, 0), new Queen(Color.Black),
			new King(Color.Black), new Bishop(Color.Black, 1), new Knight(Color.Black, 1), new Rook(Color.Black, 1) },
			// row 1
			{ new Pawn(Color.Black, 0), new Pawn(Color.Black, 1), new Pawn(Color.Black, 2), new Pawn(Color.Black, 3),
			new Pawn(Color.Black, 4), new Pawn(Color.Black, 5), new Pawn(Color.Black, 6), new Pawn(Color.Black, 7) },
			// row 2 to row 5
			{ e, e, e, e, e, e, e, e }, {e, e, e, e, e, e, e, e }, { e, e, e, e, e, e, e, e }, {e, e, e, e, e, e, e, e },
			// row 6
			{ new Pawn(Color.White, 0), new Pawn(Color.White, 1), new Pawn(Color.White, 2), new Pawn(Color.White, 3),
			new Pawn(Color.White, 4), new Pawn(Color.White, 5), new Pawn(Color.White,6 ), new Pawn(Color.White, 7) },
			//row 7, last row
			{ new Rook(Color.White, 0), new Knight(Color.White, 0), new Bishop(Color.White, 0), new Queen(Color.White),
			new King(Color.White), new Bishop(Color.White, 1), new Knight(Color.White, 1), new Rook(Color.White, 1) }};
		dim = 8;
		this.UpdateAllLegalMoves();
	}
	
	/**Creates a new chessboard using a given array
	 * Precondition: board is square */
	public Board(Piece[,] board) {
		e = new EmptySquare();
		this.board = board;
		dim = (int) Math.Sqrt(board.Length);
		this.UpdateAllLegalMoves();
	}
	
	/**Moves a piece at the coordinates [pieceRow, pieceCol] to the space on the board with the coordinates [destinationRow, destinationCol]
	 * Precondition: Both coordinate pairs are in bounds for this board and the destination space is a legal move */
	public void Move(int pieceRow, int pieceCol, int destinationRow, int destinationCol) {
		board[destinationRow, destinationCol] = board[pieceRow, pieceCol];
		board[pieceRow, pieceCol] = e; //Target's previous space is now empty
		Console.WriteLine("Moved piece " + board[destinationRow, destinationCol] 
			+ " to " + GetNotation(destinationRow, destinationCol));
		this.UpdateAllLegalMoves();
	}
	
	/** Attack a piece at the coordinates [defenderRow, defenderCol] with the piece on [attackerRow, attackerCol] with the given roll
	 * This method is for pieces that will not move before attacking, knights should use the AttackAndMove() method if they are moving before attacking
	 * Precondition: The attack being made is a legal attack for the attacker */
	
	public void Attack(int attackerRow, int attackerCol, int defenderRow, int defenderCol, int roll) {
		int minRoll = Piece.getMinimumRoll(board[attackerRow, attackerCol], board[defenderRow, defenderCol]);
		if (roll >= minRoll) {
			Piece capturedPiece = board[defenderRow, defenderCol];
			Move(attackerRow, attackerCol, destinationRow, destinationCol)
			Console.WriteLine("Attack succeeded - roll " + roll + " meets the minimum roll " + minRoll + 
				" and " + board[attackerRow, attackerCol] + " captures " + capturedPiece);
		} else {
			Console.WriteLine("Attack failed - roll " + roll + " is lower than the required roll " + minRoll);
		}

	}
	/** Special function for the knight to both move and attack with the given roll, which is incremented by 1
	 * Precondition: Both the move and attack are legal, and the destination square is adjacent to the defender's square*/
	public void AttackAndMove(int attackerRow, int attackerCol, int destinationRow, int destinationCol, int defenderRow, int defenderCol, int roll) {
		Move(attackerRow, attackerCol, destinationRow, destinationCol);
		Attack(destinationRow, destinationCol, defenderRow, defenderCol, roll + 1);
	}
	
	//some getter
	public Piece[,] GetBoard() {
		return board;
	}
	
	//change to getDim instead?
	public int width() {
		return dim;
	}
	
	//Returns a specific piece from the board
	public Piece GetPiece(int x, int y)
	{
		return board[x, y];
	}
	
	//Update legal moves and attacks for all pieces on the board
	public void UpdateAllLegalMoves() {
		for (int col = 0; col < dim; col++) {
			for (int row = 0; row < dim; row++) {
				Piece p = board[row, col];
				if (p.GetType() != typeof(EmptySquare)) {
					//Clear the list of legal attacks and prepare to update in the recursive helper method
					p.SetLegalAttacks(new HashSet<int[]>());
					//Call the recursive helper method to traverse each legal space
					p.UpdateLegalActions(this, row, col);
				}
			}
		}
	}
	
	//Returns whether a coordinate pair maps to an existing space on this board
	public bool IsInBounds(int row, int col) {
		return row < dim && row >= 0 && col < dim && col >= 0;
	}
	
	/* Returns the squares adjacent to the starting square (row, col)
	 * as a map of legal directions and their squares' coordinate pair values */
	public Dictionary<Direction, int[]> GetAdjacentSquares(int row, int col) {
		Dictionary<Direction, int[]> directions = new Dictionary<Direction, int[]>();
		directions[Direction.North] = new int[] { row - 1, col };
		directions[Direction.South] = new int[] { row + 1, col };
		directions[Direction.West] = new int[] { row, col - 1 };
		directions[Direction.East] = new int[] { row, col + 1 };
		directions[Direction.Northwest] = new int[] { row - 1, col - 1 };
		directions[Direction.Northeast] = new int[] { row - 1, col + 1 };
		directions[Direction.Southwest] = new int[] { row + 1, col - 1 };
		directions[Direction.Southeast] = new int[] { row + 1, col + 1 };
		//Filter out squares that are out of bounds
		HashSet<Direction> keys = new HashSet<Direction>(directions.Keys);
		foreach (Direction dir in keys) {
			if (!IsInBounds(directions[dir][0], directions[dir][1])) {
				directions.Remove(dir);
			}
		}
		return directions;
	}
	
	//Returns a set of the squares within [range] squares of the square at (row, col)
	public HashSet<int[]> GetSquaresInRange(int row, int col, int range) {
		HashSet<int[]> squares = new HashSet<int[]>();
		return GetSquaresInRange(row, col, range, squares);
		
	}
	//Recursive helper method
	private HashSet<int[]> GetSquaresInRange(int row, int col, int range, HashSet<int[]> squares) {
		if (range <= 0) {
			return squares;
		}
		HashSet<int[]> adjacentSquares = new HashSet<int[]>(GetAdjacentSquares(row, col).Values);
		foreach (int[] adjacentSquare in adjacentSquares) { 
			if (!SetContainsSquare(squares, adjacentSquare)) {
				squares.Add(adjacentSquare);
			}
		}
		foreach (int[] adjacentSquare in adjacentSquares) {
			squares = new HashSet<int[]>(GetSquaresInRange(adjacentSquare[0], adjacentSquare[1], range - 1, squares));
		}
		return squares;
	}
	
	//Prints the board along with the legal squares (not attacks) for the Piece on a square
	//Each legal empty square a piece can visit is marked as XX
	public void PrintLegalSquares(int[] square) {
		//First print the piece and its legal squares as coordinate pairs
		Piece p = board[square[0], square[1]];
		Console.WriteLine("Legal squares for " + p + ": ");
		/*foreach (int[] move in p.GetLegalMoves()) {
			Console.WriteLine("(" + move[0] + ", " + move[1] + ")");
		}*/
		//Printing the board
		HashSet<int[]> legalSquares = p.GetLegalMoves();
		for (int col = 0; col < dim; col++) {
			for (int row = 0; row < dim; row++) {
				if (SetContainsSquare(legalSquares, new int[] { col, row })) {
					Console.Write("|XX"); //An empty space this piece can move to
				} else {
					Console.Write("|" + board[col, row]);
				}
			}
			Console.WriteLine("|");
		}
		Console.WriteLine();
	}
	
	//Prints the legal attacks for the Piece on a square
	public void PrintLegalAttacks(int[] square) {
		Piece p = board[square[0], square[1]];
		Console.Write("Legal attack targets for " + p + ": ");
		foreach (int[] move in p.GetLegalAttacks()) {
			Console.Write(board[move[0], move[1]] + " ");
		}
		Console.WriteLine();
	}
	
	//Returns whether a set of squares contains a chosen square
	public static bool SetContainsSquare(HashSet<int[]> hs, int[] square) {
		foreach (int[] setSquare in hs) {
			if (setSquare[0] == square[0] && setSquare[1] == square[1]) {
				return true;
			}
		}
		return false;
	}
	
	/** Converts a square coordinate pair to chess notation (e.g. G4)
	 * Precondition: square is in bounds and on a default 8x8 board */
	public static string GetNotation(int squareRow, int squareCol) {
		string row = (8 - squareRow).ToString();
		char column = (char) (65 + squareCol);
		return column + row;
	}

	
		//TODO: Add rank and file labels
	public void Print() {
		/* Visualization of how the default board is arranged:
		char[,] textBoard = new char[8, 8] {
			{ 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' },
			{ 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
			{ '-', '-', '-', '-', '-', '-', '-', '-' },
			{ '-', '-', '-', '-', '-', '-', '-', '-' },
			{ '-', '-', '-', '-', '-', '-', '-', '-' },
			{ '-', '-', '-', '-', '-', '-', '-', '-' },
			{ 'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
			{ 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' } };
		Uppercase pieces are black, lowercase pieces are white
		K = King, Q = Queen, R = Rook, N = Knight, B = Bishop, P = Pawn, - = empty space */
		int col = 0;
		foreach (Piece piece in board) {
			Console.Write("|" + piece);
			col++;
			if (col == dim) {
				Console.WriteLine("|");
				col = 0;
			}
		}
		Console.WriteLine();
	}
	
	//Tester method
	public static void Main(string[] args) {
		//csc /out:Chess.exe Board.cs Pieces.cs
		Board b = new Board();
		b.Print();
		b.PrintLegalSquares(new int[] { 6, 0 });//p0

		b.Move(6, 5, 5, 5);//p5 up 1 to F3
		b.Move(1, 5, 2, 5);//P5 down 1 to F6
		b.Print();

		b.PrintLegalSquares(new int[] { 0, 5 });//B1
		b.PrintLegalSquares(new int[] { 0, 6 });//N1
		b.PrintLegalSquares(new int[] { 7, 5 });//b1
		b.PrintLegalSquares(new int[] { 7, 6 });//n1
		b.PrintLegalAttacks(new int[] { 7, 6 });//n1

		b.Move(0, 6, 4, 7);//N1 to H4
		b.Print();
		b.PrintLegalAttacks(new int[] { 7, 7 });//r1

		Console.WriteLine("Minimum roll for Knight to capture Queen:" + Piece.getMinimumRoll(new Knight(Color.White, 0), new Queen(Color.Black)));
		Console.WriteLine("Minimum roll for King to capture Pawn:" + Piece.getMinimumRoll(new King(Color.White), new Pawn(Color.Black, 0)));
		Console.WriteLine("Minimum roll for Pawn to capture Pawn:" + Piece.getMinimumRoll(new Pawn(Color.White, 0), new Pawn(Color.Black, 0)));

		b.AttackAndMove(4, 7, 4, 5, 5, 5, 6);//N1 attacks p5 from square F4
		b.Print();

		Board b2 = new Board(b.GetBoard());
	}
}
