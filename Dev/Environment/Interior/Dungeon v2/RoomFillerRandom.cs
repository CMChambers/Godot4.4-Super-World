// using Godot;

// public enum SizeSelectMethod { Random, Sequencial }

// namespace CMC.Superworld.Dungeon.v1
// {
// 	[GlobalClass]
// 	public partial class RoomFillerRandom : RoomFiller
// 	{
// 		[Export] private SizeSelectMethod sizeSelectMethod;
// 		// private int xToTry, yToTry, sizeToTry;

// 		protected override void FindASpot()
// 		{
// 			if (OutOfTries()) { return; }

// 			SetSpotSettings();
// 			switch (sizeSelectMethod)
// 			{
// 				case SizeSelectMethod.Random:
// 					{

// 						FindRandomSpot();
// 						FindRandomSize();
// 						break;
// 					}
// 				case SizeSelectMethod.Sequencial:
// 					{
// 						FindRandomSpot();
// 						FindSequencialSize();
// 						break;
// 					}
// 				default:
// 					break;
// 			}
// 		}

// 		void SetSpotSettings()
// 		{
// 			spotX = 0;
// 			spotY = 0;
// 			spotSizeX = 0;
// 			spotSizeY = 0;
// 			// SuccessFindingSpot = false;
// 			// FailedToFindSpot = false;
// 			triesUsed++;
// 		}
// 		void FindRandomSpot()
// 		{
// 			spotX = GD.RandRange(0, dungeonSize);
// 			spotY = GD.RandRange(0, dungeonSize);
// 			//! need Tools.MakeOdd stuff
// 		}
// 		void FindRandomSize()
// 		{
// 			//! need Tools.MakeOdd stuff
// 			//! need SquareDeviation stuff
// 			spotSizeX = GD.RandRange(sizeMinimum, sizeMaximum);
// 			spotSizeY = GD.RandRange(sizeMinimum, sizeMaximum);
// 			if (IsSpotAvailable(spotX, spotY, spotSizeX, spotSizeY))
// 			{
// 				Render(spotX, spotY, spotSizeX, spotSizeY);
// 				triesUsed = 0;
// 				return;
// 			}
// 		}
// 		void FindSequencialSize()
// 		{
// 			for (int currentSize = sizeMaximum; currentSize >= sizeMinimum; currentSize--)
// 			{
// 				//! need Tools.MakeOdd stuff
// 				//! need SquareDeviation stuff
// 				//! add in option for overlapping
// 				spotSizeX = currentSize;
// 				spotSizeY = currentSize;
// 				if (IsSpotAvailable(spotX, spotY, spotSizeX, spotSizeY))
// 				{
// 					Render(spotX, spotY, spotSizeX, spotSizeY);
// 					triesUsed = 0;
// 					// cellsUsed += (spotSizeX + 1) * (spotSizeY + 1);
					

// 					return;
// 				}
// 			}
// 		}
// 	}
// }
