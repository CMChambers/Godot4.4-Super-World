// using System;
// using Godot;
// namespace CMC.Superworld.Dungeon.v2
// {
//     [Tool]
//     public partial class DungeonGenerator : Node
//     {
//         // [Export] public PackedScene filledSpace;
//         [Export] private PackedScene emptySpace;
//         [Export] public bool useFillers = true;
//         [Export] private DungeonGeneratorSettings settings;
//         // private DungeonGrid grid;

//         public override void _Ready()
//         {
//             GD.Print("in Ready");
//             Generate();
//         }

//         [ExportToolButton("Generate")]
//         public Callable myCallable => Callable.From(Generate);

//         private void Generate()
//         {
//             GD.Print("in Generate");
//             // grid = new DungeonGrid(settings.dungeonSize.X, settings.dungeonSize.Y);

//             // grid = new DungeonGrid(settings.dungeonSize.X, settings.dungeonSize.Y);
//             // if (useFillers)
//             // {
//             //     foreach (var filler in settings.Fillers)
//             //     {
//             //         filler.FillDungeon(grid);
//             //     }
//             // }
//             // GD.Print("in Generate2");

//             //     Render();
//             //     // GD.Print("in Generate3");

//             // }

//             // private void Render()
//             // {
//             //     GD.Print("in Render");
//             foreach (Node child in GetChildren())
//             {
//                 // if (child.Name.StartsWith("EmptySpace_"))
//                 //     child.QueueFree();
//             }
            
//             for (int x = 0; x < 10; x++)
//             {
//                 for (int y = 0; y < 10; y++)
//                 {

//                     var instanceEmpty = (Node3D)emptySpace.Instantiate();
//                     instanceEmpty.Position = new Vector3(x * 2, -1, y * 2);
//                     AddChild(instanceEmpty);

//                     // instanceEmpty.GlobalPosition = new Vector2(x, y);
//                 }
//             }

//             // foreach (var cellIsUsed in grid.used)
//             // {
//             //     if (cellIsUsed == false)
//             //     {
//             //         var instanceEmpty = emptySpace.Instantiate();
//             //         AddChild(instanceEmpty);
//             //         // instanceEmpty.GlobalPosition = new Vector2(0,0);
//             //         // instanceEmpty. = new Vector3(0,0,0);
//             //     }
//             //     else
//             //     {
//             //         var instanceFilled = filledSpace.Instantiate();
//             //         AddChild(instanceFilled);
//             //     }
//             // }
//         }
//     }
// }