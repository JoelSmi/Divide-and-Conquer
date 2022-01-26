using System;
using System.Collections.Generic;
using Pieces;

public class BoardFunctions
{
	//Update legal moves and attacks for all pieces on the board b
	public static void UpdateLegalMoves(Board b) {
		for (int i = 0; i < b.width(); i++) {
			for (int j = 0; j < b.width(); j++) {
				UpdateLegalMoves(b, i, j);
			}
		}
	}
	//Update legal moves and attacks for the piece at position (pieceX, pieceY) on the board b
	private static void UpdateLegalMoves(Board b, int row, int col) {
		Piece p = b.getBoard()[row, col];
		if (p.GetType() != typeof(EmptySquare)) {
			//Clear the list of legal attacks and prepare to update in the recursive helper method
			p.SetLegalAttacks(new HashSet<int[]>());
			//Call the recursive helper method to traverse each legal space
			p.SetLegalMoves(GetLegalMoves(b, p, row, col, p.GetMovement(), new HashSet<int[]>()));
		}
	}
	/**Recursive helper function for pathing all legal moves for a piece
	 * TODO: Implement Rook and Knight legal attacks
	 * Precondition: Piece p is not an EmptySquare */
	private static HashSet<int[]> GetLegalMoves(Board b, Piece p, int row, int col, int remainingMov, HashSet<int[]> legalMoves) {
		if (remainingMov <= 0) {
			//Piece has no movement remaining, so return the compiled set of legal moves
			return legalMoves;
		}
		//Create the coordinate pairs of the 8 adjacent squares
		int[] north = { row - 1, col };
		int[] south = { row + 1, col };
		int[] west = { row, col - 1 };
		int[] east = { row, col + 1 };
		int[] northwest = { row - 1, col - 1 };
		int[] northeast = { row - 1, col + 1 };
		int[] southwest = { row + 1, col - 1 };
		int[] southeast = { row + 1, col + 1 };
		//Create combinations of these squares according to the legal movement directions for each piece
		int[][] legalDirections;
		if (p.GetType() == typeof(Pawn)) {
			//Black and White pawns move in opposite directions
			if (p.GetColor() == Color.White) {
				legalDirections = new int[][] { north, northwest, northeast };
			} else {
				legalDirections = new int[][] { south, southwest, southeast };
			}
		} else {//Rook, Knight, Bishop, Queen, King
			legalDirections = new int[][] { north, south, east, west, northwest, northeast, southwest, southeast };
		}
		//Establish the list of squares to recursively check
		List<int[]> squareQueue = new List<int[]>();
		//Filter out spaces that are out of bounds or occupied by an ally piece
		foreach (int[] square in legalDirections) {
			if (IsInBounds(square[0], square[1])) {
				if (b.getBoard()[square[0], square[1]].GetColor() == Color.Empty && !SetContainsSquare(legalMoves, square)) {
					//A legal empty square which we have not yet traversed has been found
					legalMoves.Add(square);
					squareQueue.Add(square);//Recursively traverse this square later
				} else if (b.getBoard()[square[0], square[1]].GetColor() != p.GetColor()
					&& remainingMov == p.GetMovement()) {//Piece is adjacent to an enemy piece
					p.GetLegalAttacks().Add(square);
				}
			}
		}
		foreach (int[] square in squareQueue) {
			//Update the list of legal moves by traversing to each square in the queue and finding the legal moves given that square
			legalMoves = new HashSet<int[]>(GetLegalMoves(b, p, square[0], square[1], remainingMov - 1, legalMoves));
		}
		return legalMoves;
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
	//Returns whether a coordinate pair maps to an existing space on a default board
	public static bool IsInBounds(int row, int col) {
		return row < 8 && row >= 0 && col < 8 && col >= 0;
	}
}