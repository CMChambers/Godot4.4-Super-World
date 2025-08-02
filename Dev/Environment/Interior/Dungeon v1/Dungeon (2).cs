// using Godot;

// namespace CMC.Superworld.Dungeon.v1
// {
// 	// [Tool]
// 	public partial class Dungeon : Node3D
// 	{
// 		#region Properties
// 		[Export] private DungeonSettings dungeonSettings;

// 		// [Export] private int size = 50;
// 		[Export] private DungeonElement[] dungeonElements;
// 		GridMap gridMap;
// 		#endregion

// 		public override void _Ready()
// 		{
// 			gridMap = GetNode<GridMap>("GridMap");
// 			Generate();
// 		}

// 		void Generate()
// 		{
// 			GD.Print("generate");
// 			// ClearOldMap();
// 			CalculateMap();

// 		}
// 		void ClearOldMap() { gridMap.Clear(); }
// 		void CalculateMap()
// 		{
// 			GD.Print("calculate");

// 			// DrawBorder();
// 			// SetDungeonSettings();
// 			foreach (var item in dungeonElements)
// 			{
// 				GD.Print("dungeon calculate map for each");

// 				item.Calculate(dungeonSettings, gridMap);
// 				UpdateDungeonSettings();
// 			}
// 		}
// 		// void SetDungeonSettings()
// 		// {
// 		// 	// dungeonSettings.cellsAvailable = (dungeonSettings.size - 1) * (dungeonSettings.size - 1);
// 		// 	// dungeonSettings = new DungeonSettings();
// 		// 	// dungeonSettings.size = size;
// 		// }
// 		void UpdateDungeonSettings() { }
// 		void DrawBorder()
// 		{
// 			int size = dungeonSettings.size;
// 			for (int i = -1; i <= size; i++)
// 			{
// 				gridMap.SetCellItem(new Vector3I(i, 0, -1), 0);
// 				gridMap.SetCellItem(new Vector3I(i, 0, size), 0);
// 				gridMap.SetCellItem(new Vector3I(size, 0, i), 0);
// 				gridMap.SetCellItem(new Vector3I(-1, 0, i), 0);
// 			}
// 		}
// 	}
// }
