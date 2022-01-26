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
			{ new Rook(Color.Black, 0), new Knight(Color.Black, 0), new Bishop(Color.Black, 0), new Queen(Color.Black),
			new King(Color.Black), new Bishop(Color.Black, 1), new Knight(Color.Black, 1), new Rook(Color.Black, 1) },
			{ new Pawn(Color.Black, 0), new Pawn(Color.Black, 1), new Pawn(Color.Black, 2), new Pawn(Color.Black, 3),
			new Pawn(Color.Black, 4), new Pawn(Color.Black, 5), new Pawn(Color.Black, 6), new Pawn(Color.Black, 7) },
			{ e, e, e, e, e, e, e, e }, {e, e, e, e, e, e, e, e }, { e, e, e, e, e, e, e, e }, {e, e, e, e, e, e, e, e },
			{ new Pawn(Color.White, 0), new Pawn(Color.White, 1), new Pawn(Color.White, 2), new Pawn(Color.White, 3),
			new Pawn(Color.White, 4), new Pawn(Color.White, 5), new Pawn(Color.White,6 ), new Pawn(Color.White, 7) },
			{ new Rook(Color.White, 0), new Knight(Color.White, 0), new Bishop(Color.White, 0), new Queen(Color.White),
			new King(Color.White), new Bishop(Color.White, 1), new Knight(Color.White, 1), new Rook(Color.White, 1) }};
		dim = 8;
	}
	//Moves a piece at the coordinates [PieceX, PieceY] to the space on the board with the coordinates [DestinationX, DestinationY]
	public void Move(int PieceX, int PieceY, int DestinationX, int DestinationY) {
		board[DestinationX, DestinationY] = board[PieceX, PieceY];
		board[PieceX, PieceY] = e;//Target's previous space is now empty
	}
	public Piece[,] getBoard() {
		return board;
	}
	public int width() {
		return dim;
	}
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
	//Prints the board along with the legal squares (not attacks) for the Piece on a square
	//Each legal empty square a piece can visit is marked as XX
	public void PrintLegalSquares(int[] square) {
		//First print the piece and its legal squares as coordinate pairs
		Piece p = board[square[0], square[1]];
		Console.WriteLine("Legal squares for " + p + ": ");
		foreach (int[] move in p.GetLegalMoves()) {
			Console.WriteLine(move[0] + ", " + move[1]);
		}
		//Printing the board
		HashSet<int[]> legalSquares = p.GetLegalMoves();
		for (int col = 0; col < dim; col++) {
			for (int row = 0; row < dim; row++) {
				if (BoardFunctions.SetContainsSquare(legalSquares, new int[] { col, row })) {
					Console.Write("|XX"); //An empty space this piece can move to
				} else {
					Console.Write("|" + board[col, row]);
				}
			}
			Console.WriteLine("|");
		}
		Console.WriteLine();
	}
	//Tester method
	public static void Main(string[] args) {
		//csc /out:Chess.exe Board.cs Pieces.cs BoardFunctions.cs
		Board b = new Board();
		b.Print();
		BoardFunctions.UpdateLegalMoves(b);
		b.PrintLegalSquares(new int[] { 6, 0 });//p0

		b.Move(6, 0, 4, 0);
		b.Move(1, 5, 2, 5);
		b.Print();
		BoardFunctions.UpdateLegalMoves(b);
		b.PrintLegalSquares(new int[] { 0, 5 });//B1
		b.PrintLegalSquares(new int[] { 0, 6 });//N1

		Console.WriteLine("Minimum roll for Knight to capture Queen:" + Piece.getMinimumRoll(new Knight(Color.White, 0), new Queen(Color.Black)));
		Console.WriteLine("Minimum roll for King to capture Pawn:" + Piece.getMinimumRoll(new King(Color.White), new Pawn(Color.Black, 0)));
		Console.WriteLine("Minimum roll for Pawn to capture Pawn:" + Piece.getMinimumRoll(new Pawn(Color.White, 0), new Pawn(Color.Black, 0)));
	}
}
