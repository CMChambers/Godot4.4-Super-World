// using System;
// using Godot;
// namespace CMC.Superworld.Dungeon.v2
// {

//     public class DungeonGrid
//     {
//         public int sizeX;
//         public int sizeY;
//         public bool[] used;
//         public Vector2I[] coordinates;

//         public DungeonGrid(int sizeX, int sizeY)
//         {
//             this.sizeX = sizeX;
//             this.sizeY = sizeY;
//             MarkAllUnused();
//             SetCoordinates();
//         }


//         public void MarkAllUnused()
//         {
//             for (int y = 0; y < sizeY; y++)
//             {
//                 for (int x = 0; x < sizeX; x++)
//                 {
//                     MarkUnused(x, y);
//                 }
//             }
//         }

//         public void MarkUsed(int x, int y)
//         {
//             used[Index(x, y)] = true;
//         }

//         public void MarkUnused(int x, int y)
//         {
//             used[Index(x, y)] = false;
//         }
//         int Index(int x, int y)
//         {
//             return (y * sizeX) + x;
//         }

//         public void SetCoordinates()
//         {
//             for (int y = 0; y < sizeY; y++)
//             {
//                 for (int x = 0; x < sizeX; x++)
//                 {
//                     coordinates[Index(x, y)] = new Vector2I(x, y);
//                 }
//             }
//         }

//     }
// }