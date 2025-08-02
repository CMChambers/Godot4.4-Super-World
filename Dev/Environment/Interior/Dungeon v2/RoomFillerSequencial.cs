// using Godot;
// using System;

// namespace CMC.Superworld.Dungeon.v1
// {
// 	public enum SequencialFillMethod { Center, Corner }
// 	[GlobalClass]
// 	public partial class RoomFillerSequencial : RoomFiller
// 	{
// 		[Export] private SequencialFillMethod sequencialFillMethod;
// 		protected override void FindASpot()
// 		{
// 			SetSpotSettings();
// 			if (OutOfTries()) { return; }
// 			for (int sizeToTry = sizeMaximum; sizeToTry >= sizeMinimum; sizeToTry--)
// 			{
// 				spotSizeX = sizeToTry;
// 				spotSizeY = sizeToTry;

// 				switch (sequencialFillMethod)
// 				{
// 					case SequencialFillMethod.Center:
// 						{
// 							FindSequencialSpotFromCenter();
// 							break;
// 						}
// 					case SequencialFillMethod.Corner:
// 						{
// 							FindSequencialSpotFromCorner();
// 							break;
// 						}
// 					default: break;
// 				}
// 			}
// 			triesUsed = triesAllowed;
// 		}
// 		void SetSpotSettings()
// 		{
// 			spotX = 0;
// 			spotY = 0;
// 			spotSizeX = 0;
// 			spotSizeY = 0;
// 			triesUsed++;
// 		}
// 		void FindSequencialSpotFromCenter()
// 		{
// 			//get center
// 			//get distance
// 			//check top of square
// 			//check right side of square
// 			//check bottom of square
// 			//check left side of square


// 			// spotX = xToTry;
// 			// spotY = yToTry;
// 			if (IsSpotAvailable(spotX, spotY, spotSizeX, spotSizeY))
// 			{
// 				Render(spotX, spotY, spotSizeX, spotSizeY);
// 				triesUsed = 0;
// 				return;
// 			}

// 		}
// 		void FindSequencialSpotFromCorner()
// 		{
// 			for (int xToTry = 0; xToTry <= dungeonSize; xToTry++)
// 			{
// 				for (int yToTry = 0; yToTry < dungeonSize; yToTry++)
// 				{
// 					spotX = xToTry;
// 					spotY = yToTry;
// 					if (IsSpotAvailable(spotX, spotY, spotSizeX, spotSizeY))
// 					{
// 						Render(spotX, spotY, spotSizeX, spotSizeY);
// 						triesUsed = 0;
// 						return;
// 					}
// 				}
// 			}

// 		}
// 	}
// }
