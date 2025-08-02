// using Godot;

// namespace CMC.Superworld.Dungeon.v1
// {
// 	[GlobalClass]
// 	public partial class BorderDrawer : DungeonElement
// 	{
// 		public override void Calculate(DungeonSettings dungeonSettings, GridMap gridMap)
// 		{

// 			GD.Print("1");
// 			int size = dungeonSettings.size;
// 			dungeonSettingsRef.size = dungeonSettings.size;
// 			GD.Print("2");

// 			for (int j = -1; j <= 3; j++)
// 			{
// 				GD.Print("first loop");
// 				GD.Print(dungeonSettingsRef.size);

// 				GD.Print(dungeonSettings.size);

// 			}
// 			for (int i = -1; i <= dungeonSettings.size; i++)
// 			{
// 				GD.Print("second loop");

// 				GD.Print("for " + i);
// 				gridMap.SetCellItem(new Vector3I(i, 0, -1), 0);
// 				gridMap.SetCellItem(new Vector3I(i, 0, dungeonSettings.size), 0);
// 				gridMap.SetCellItem(new Vector3I(dungeonSettings.size, 0, i), 0);
// 				gridMap.SetCellItem(new Vector3I(-1, 0, i), 0);

// 			}
// 		}

// 	}
// }