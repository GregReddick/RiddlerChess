// --------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Xoc Software">
// Copyright © 2021 Xoc Software
// </copyright>
// --------------------------------------------------------------------------------------------------

namespace RiddlerChess
{
	using System;
	using System.Collections.Generic;

	/// <summary>A program.</summary>
	internal class Program
	{
		/// <summary>Values that represent chess pieces.</summary>
		private enum ChessPiece
		{
			/// <summary>An enum constant representing the visited option.</summary>
			Visited,

			/// <summary>An enum constant representing the black option.</summary>
			Black,

			/// <summary>An enum constant representing the pawn option.</summary>
			Pawn,

			/// <summary>An enum constant representing the knight option.</summary>
			Knight,

			/// <summary>An enum constant representing the bishop option.</summary>
			Bishop,

			/// <summary>An enum constant representing the rook option.</summary>
			Rook,

			/// <summary>An enum constant representing the queen option.</summary>
			Queen,

			/// <summary>An enum constant representing the king option.</summary>
			King,
		}

		/// <summary>Main entry-point for this application.</summary>
		private static void Main()
		{
			ChessPiece[,] board = new ChessPiece[8, 8]
			{
				{ ChessPiece.King, ChessPiece.Black, ChessPiece.Bishop, ChessPiece.Black, ChessPiece.King, ChessPiece.Rook, ChessPiece.Bishop, ChessPiece.Rook },
				{ ChessPiece.Knight, ChessPiece.Rook, ChessPiece.Knight, ChessPiece.Knight, ChessPiece.Pawn, ChessPiece.Knight, ChessPiece.King, ChessPiece.Bishop },
				{ ChessPiece.Rook, ChessPiece.Black, ChessPiece.Knight, ChessPiece.Black, ChessPiece.Pawn, ChessPiece.Rook, ChessPiece.Pawn, ChessPiece.Rook },
				{ ChessPiece.Black, ChessPiece.Black, ChessPiece.Pawn, ChessPiece.Rook, ChessPiece.Black, ChessPiece.Knight, ChessPiece.Black, ChessPiece.Black },
				{ ChessPiece.Knight, ChessPiece.Knight, ChessPiece.Knight, ChessPiece.Bishop, ChessPiece.Black, ChessPiece.Bishop, ChessPiece.Rook, ChessPiece.Bishop },
				{ ChessPiece.Queen, ChessPiece.Rook, ChessPiece.Knight, ChessPiece.Pawn, ChessPiece.Black, ChessPiece.Knight, ChessPiece.Rook, ChessPiece.Queen },
				{ ChessPiece.Black, ChessPiece.Black, ChessPiece.Rook, ChessPiece.Pawn, ChessPiece.Bishop, ChessPiece.Pawn, ChessPiece.Bishop, ChessPiece.Queen },
				{ ChessPiece.King, ChessPiece.Bishop, ChessPiece.Queen, ChessPiece.Knight, ChessPiece.Pawn, ChessPiece.Rook, ChessPiece.Knight, ChessPiece.Knight },
			};

			Location location = new Location(6, 4);
			List<Location> moves = new();

			Move(board, location, moves);
		}

		/// <summary>Moves.</summary>
		/// <param name="board">The board.</param>
		/// <param name="location">The location.</param>
		/// <param name="moves">The moves.</param>
		/// <returns>True if it succeeds, false if it fails.</returns>
		private static bool Move(ChessPiece[,] board, Location location, IList<Location> moves)
		{
			bool result = false;
			if (location.Rank >= 0 && location.Rank <= 7 && location.File >= 0 && location.File <= 7)
			{
				ChessPiece chessPiece = board[location.Rank, location.File];

				ChessPiece[,] boardMove = (ChessPiece[,])board.Clone();
				IList<Location> movesMove = moves.Clone();
				movesMove.Add(location);
				boardMove[location.Rank, location.File] = ChessPiece.Visited;

				switch (chessPiece)
				{
					case ChessPiece.Visited:
						break;

					case ChessPiece.Black:
						break;

					case ChessPiece.Pawn:
						result = Move(boardMove, new Location(location.Rank - 1, location.File - 1), movesMove);
						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 1, location.File + 1), movesMove);
						}

						break;

					case ChessPiece.Knight:
						result = Move(boardMove, new Location(location.Rank - 2, location.File - 1), movesMove);
						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 2, location.File + 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 1, location.File - 2), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 1, location.File + 2), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File - 2), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File + 2), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 2, location.File - 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 2, location.File + 1), movesMove);
						}

						break;

					case ChessPiece.Bishop:
						result = Move(boardMove, new Location(location.Rank - 1, location.File - 1), movesMove);
						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 1, location.File + 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File - 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File + 1), movesMove);
						}

						break;

					case ChessPiece.Rook:
						result = Move(boardMove, new Location(location.Rank - 1, location.File), movesMove);
						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank, location.File - 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank, location.File + 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File), movesMove);
						}

						break;

					case ChessPiece.Queen:
						result = Move(boardMove, new Location(location.Rank - 1, location.File - 1), movesMove);
						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 1, location.File + 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File - 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File + 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank - 1, location.File), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank, location.File - 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank, location.File + 1), movesMove);
						}

						if (!result)
						{
							result = Move(boardMove, new Location(location.Rank + 1, location.File), movesMove);
						}

						break;

					case ChessPiece.King:
						foreach (Location locationSolution in movesMove)
						{
							Console.Write(locationSolution.ToString() + " ");
						}

						Console.WriteLine();

						result = false;
						break;
				}
			}

			return result;
		}

		/// <summary>A location.</summary>
		/// <seealso cref="T:System.ICloneable"/>
		private class Location : ICloneable
		{
			/// <summary>The file.</summary>
			private int file;

			/// <summary>The rank.</summary>
			private int rank;

			/// <summary>Initializes a new instance of the <see cref="Location"/> class.</summary>
			/// <param name="rank">The rank.</param>
			/// <param name="file">The file.</param>
			public Location(int rank, int file)
			{
				this.rank = rank;
				this.file = file;
			}

			/// <summary>Gets the rank.</summary>
			/// <value>The rank.</value>
			public int Rank
			{
				get
				{
					return this.rank;
				}
			}

			/// <summary>Gets the file.</summary>
			/// <value>The file.</value>
			public int File
			{
				get
				{
					return this.file;
				}
			}

			/// <summary>Returns a string that represents the current object.</summary>
			/// <returns>A string that represents the current object.</returns>
			/// <seealso cref="M:System.Object.ToString()"/>
			public override string ToString()
			{
				return Convert.ToChar(65 + this.file).ToString() + (8 - this.rank).ToString();
			}

			/// <summary>Creates a new object that is a copy of the current instance.</summary>
			/// <returns>A new object that is a copy of this instance.</returns>
			/// <seealso cref="M:System.ICloneable.Clone()"/>
			public object Clone()
			{
				return new Location(this.rank, this.file);
			}
		}
	}
}