// using Godot;

// namespace CMC.Superworld.Dungeon.v1
// {
// 	[GlobalClass]
// 	public partial class RoomFiller : DungeonElement
// 	{
// 		#region Properties
// 		// bool KeepGoing;

// 		[Export(PropertyHint.Range, "0,1,")] protected float density;
// 		[Export(PropertyHint.Range, "1,100,")] protected int sizeMaximum;
// 		[Export(PropertyHint.Range, "1,100,")] protected int sizeMinimum;
// 		[Export(PropertyHint.Range, "0,1,")] protected float squareDeviation;
// 		[Export(PropertyHint.Range, "0,1,")] protected float exitFrequency;
// 		[Export(PropertyHint.Range, "0,1,")] protected float doorChance;

// 		protected int spotX;
// 		protected int spotY;
// 		protected int spotSizeX;
// 		protected int spotSizeY;
// 		// protected bool SuccessFindingSpot;
// 		// protected bool FailedToFindSpot;

// 		[Export(PropertyHint.Range, "0,100,")] protected int triesAllowed;
// 		protected int triesUsed;

// 		// protected bool OutOfTries;
// 		protected int cellsUsed;
// 		private int cellsAvailable;
// 		private int cellsNeeded;
// 		protected int dungeonSize;

// 		GridMap gridMapRef;
// 		#endregion
// 		#region MainMethod
// 		public override void Calculate(DungeonSettings dungeonSettings, GridMap gridMap)
// 		{
// 			SetFillerSettings(dungeonSettings, gridMap);
// 			while (!DoneFilling() && !OutOfTries())
// 			{
// 				FindASpot();
// 			}
// 		}
// 		#endregion
// 		#region Methods
// 		void SetFillerSettings(DungeonSettings dungeonSettings, GridMap gridMap)
// 		{
// 			// dungeonSettingsRef = dungeonSettings;
// 			// gridMapRef = gridMap;
// 			// dungeonSize = dungeonSettings.dungeonSize;
// 			// cellsUsed = 0;
// 			// cellsAvailable = dungeonSettings.cellsAvailable;
// 			// cellsNeeded = (int)((dungeonSize - 1) * (dungeonSize - 1) * density);
// 		}
// 		protected bool IsSpotAvailable(int spotX, int spotY, int spotSizeX, int potSizeY)
// 		{
// 			for (int x = 0; x < spotSizeX; x++)
// 			{
// 				for (int y = 0; y < spotSizeY; y++)
// 				{
// 					if (IsCellUsed(x, y))
// 					{
// 						return false;
// 					}
// 				}
// 			}
// 			return true;
// 		}
// 		bool DoneFilling()
// 		{ return (cellsUsed >= cellsNeeded); }
// 		protected bool OutOfTries()
// 		{ return (triesUsed >= triesAllowed); }
// 		bool IsCellUsed(int x, int y)
// 		{
// 			return (gridMapRef.GetCellItem(new Vector3I(x, 0, y)) > 0);
// 			//! this might not work at all
// 		}
// 		protected void Render(int spotX, int spotY, int spotSizeX, int spotSizeY)
// 		{
// 			// for (int x = spotX; x < (spotX + spotSizeX); x++)
// 			// {
// 			// 	for (int z = spotY; z < (spotY + spotSizeY); z++)
// 			// 	{
// 			// 		gridMapRef.SetCellItem(new Vector3I(x, 0, z), 0);
// 			// 	}
// 			// }
// 			// cellsUsed += (spotSizeX + 1) * (spotSizeY + 1);
// 			// dungeonSettingsRef.cellsAvailable -= cellsUsed;
// 		}
// 		protected virtual void FindASpot() { }
// 		#endregion
// 	}
// }
