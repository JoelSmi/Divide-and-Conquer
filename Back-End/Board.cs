using Pieces;
using System;
public class Board {
	private Piece[,] board;
	private int dim;
	private EmptySquare e;
	//Default 8x8 chessboard
	public Board()
	{
		e = new EmptySquare();
		board = new Piece[8, 8] {
			{ new Rook(Color.Black), new Knight(Color.Black), new Bishop(Color.Black), new Queen(Color.Black),
			new King(Color.Black), new Bishop(Color.Black), new Knight(Color.Black), new Rook(Color.Black) },
			{ new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black),
			new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black), new Pawn(Color.Black) },
			{ e, e, e, e, e, e, e, e }, {e, e, e, e, e, e, e, e }, { e, e, e, e, e, e, e, e }, {e, e, e, e, e, e, e, e },
			{ new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White),
			new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White), new Pawn(Color.White) },
			{ new Rook(Color.White), new Knight(Color.White), new Bishop(Color.White), new Queen(Color.White),
			new King(Color.White), new Bishop(Color.White), new Knight(Color.White), new Rook(Color.White) }};
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
		b.Move(6, 0, 4, 0);
		b.Move(1, 5, 2, 5);
		b.Print();
	}
}