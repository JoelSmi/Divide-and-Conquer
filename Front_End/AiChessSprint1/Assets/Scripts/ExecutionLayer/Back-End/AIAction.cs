//namespace BishopAI1;

//using AIPieces;
//using AIBoard;
//using AIBishop;
using System;

namespace BishopAI1
{
	public class Action {
		
		private Type pieceType;
		private int id = -1;
		private int originalXCord = -1;
		private int originalYCord = -1;
		private int[] originalCords = {-1, -1};
		private int destinationXCord = -1;
		private int destinationYCord = -1;
		private int[] destinationCords = {-1, -1};
		private bool isAttack = false;
		private String printedReference;

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
			Console.WriteLine("The outgoing action returned is:");
			Console.WriteLine("The " + pieceType.ToString() + " with an id of " + id 
			+ " will move from " + GetNotation(originalCords[0], originalCords[1]) + " to " 
			+ GetNotation(destinationCords[0], destinationCords[1]));
			Console.WriteLine("[" + getOriginalXCord() + "," + getOriginalYCord() 
			+ "] to [" + getDestinationXCord() + "," + getDestinationYCord() + "]");
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
	}
}
