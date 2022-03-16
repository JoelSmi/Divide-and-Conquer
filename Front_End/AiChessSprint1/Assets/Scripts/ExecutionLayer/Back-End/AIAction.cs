//namespace BishopAI1;

//using AIPieces;
//using AIBoard;
//using AIBishop;
using System;
using System.Collections.Generic;

namespace KingAI1
{
	public class Action {
		
		//May want to add a variable to show which piece commanded this action. Our goal is to show an array of actions.
		private Type pieceType;
		private int id = -1;
		private int originalXCord = -1;
		private int originalYCord = -1;
		private int[] originalCords = new int[2];
		private int destinationXCord = -1;
		private int destinationYCord = -1;
		private int[] destinationCords = {-1, -1};
		private bool isAttack = false;
		private String printedReference;
		private bool isActing = false;
		private Piece commandingPiece;
		private bool completed = false;
		private List<int[]> path;

		public Action(){
			pieceType = typeof(EmptySquare);
			printedReference = "null";
		}

		public Action(Type piece, int pieceId, String printRef, int[] original, int[] destination, bool attacking){
			this.pieceType = piece;
			this.id = pieceId;
			this.originalCords = original;
			originalXCord = this.originalCords[0];
			originalYCord = this.originalCords[1];
			this.destinationCords = destination;
			destinationXCord = this.destinationCords[0];
			destinationYCord = this.destinationCords[1];
			this.isAttack = attacking;
			this.printedReference = printRef;
		}

		public static string GetNotation(int squareRow, int squareCol) {
			string row = (8 - squareRow).ToString();
			char column = (char) (65 + squareCol);
			return column + row;
		}

		public void printAction(){
			if (isAttack){
				Console.WriteLine("The outgoing action returned is:");
				Console.WriteLine("The " + pieceType.ToString() + " with an id of " + id 
				+ " will attack from " + GetNotation(originalCords[0], originalCords[1]) + " to " 
				+ GetNotation(destinationCords[0], destinationCords[1]));
				Console.WriteLine("[" + getOriginalXCord() + "," + getOriginalYCord() 
				+ "] to [" + getDestinationXCord() + "," + getDestinationYCord() + "]");
				Console.Write("Path taken:");
				foreach(int[] square in path){
					Console.Write("[" + square[0] + "," + square[1] + "]");
				}
				Console.Write("\n");
			}
			else{
				Console.WriteLine("The outgoing action returned is:");
				Console.WriteLine("The " + pieceType.ToString() + " with an id of " + id 
				+ " will move from " + GetNotation(originalCords[0], originalCords[1]) + " to " 
				+ GetNotation(destinationCords[0], destinationCords[1]));
				Console.WriteLine("[" + getOriginalXCord() + "," + getOriginalYCord() 
				+ "] to [" + getDestinationXCord() + "," + getDestinationYCord() + "]");
				Console.Write("Path taken:");
				foreach(int[] square in path){
					Console.Write("[" + square[0] + "," + square[1] + "]");
				}
				Console.Write("\n");
			}
			
		}

		public void setPieceType(Type piece){
			this.pieceType = piece;
		}

		public Type getPieceType(){
			return pieceType;
		}

		public void setID(int pieceID){
			this.id = pieceID;
		}

		public int getID(){
			return id;
		}

		// public void setPrintedReference(String printedRef){
		// 	this.printedReference = printedRef;
		// }

		// public String getPrintedRefernce(){
		// 	return printedReference;
		// }

		public void setOriginalCord(int[] original){
			this.originalCords = original;
			originalXCord = this.originalCords[0];
			originalYCord = this.originalCords[1];
		}
		
		public int getOriginalXCord(){
			return originalXCord;
		}
		public int getOriginalYCord(){
			return originalYCord; 
		}

		public int[] getOriginalCords(){
			return originalCords;
		}

		public void setDestinationCord(int [] destination){
			this.destinationCords = destination;
			destinationXCord = this.destinationCords[0];
			destinationYCord = this.destinationCords[1];
		}
		
		public int getDestinationXCord(){
			return destinationXCord;
		}
		public int getDestinationYCord(){
			return destinationYCord;
		}

		public int[] getDestinationCords(){
			return destinationCords;
		}

		public void setAttack(bool attacking){
			this.isAttack = attacking;
		}

		public bool getIsAttack(){
			return isAttack;
		}
		public void setIsAct(bool acting){
			this.isActing = acting;
		}

		public bool getIsActing(){
			return isActing;
		}

		public void setCommandingPiece(Piece commandingPiece){
			this.commandingPiece = commandingPiece;
		}

		public Piece getCommandingPiece(){
			return this.commandingPiece;
		}
		public void setCompleted(bool done){
			this.completed = done;
		}

		public bool getCompleted(){
			return this.completed;

		}
		public void setPath(List<int[]> path){
			this.path = path;
		}
		public List<int[]> getPath(){
			return this.path;
		}
	}
}
