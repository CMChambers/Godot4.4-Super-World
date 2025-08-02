using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace CMC.Superworld.Dungeon
{
    public partial class DungeonData
    {
        [Export] public Vector2I dungeonSize;
        [Export] public FillDensityMethod fillDensityMethod;
        [Export] public int densityTotalAmount;
        [Export] public int densityTotalAvailable;

        DungeonDataCell[,] dataCells;

        public DungeonData(Vector2I size)
        {
            dungeonSize = size;
            densityTotalAmount = size.X * size.Y;
            densityTotalAvailable = densityTotalAmount;

            dataCells = new DungeonDataCell[size.X, size.Y];

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    dataCells[x, y] = new DungeonDataCell();
                }
            }
        }

        public void MarkAsUsed(Vector2I pos)
        {
            if (dataCells[pos.X, pos.Y] == null)
            { GD.PrintErr($"Cell at {pos.X}, {pos.Y} is null!"); }

            if (pos.X < 0 || pos.X >= dataCells.GetLength(0) || pos.Y < 0 || pos.Y >= dataCells.GetLength(1))
            { System.Diagnostics.Debug.Fail($"Invalid index: ({pos.X}, {pos.Y})"); }

            dataCells[pos.X, pos.Y].isUsed = true;
        }
        public bool IsUsed(Vector2I pos) { return IsUsed(pos.X, pos.Y); }

        public bool IsUsed(int x, int y)
        {
            if (x < 0 || x >= dataCells.GetLength(0) || y < 0 || y >= dataCells.GetLength(1))
            {
                System.Diagnostics.Debug.Fail($"Invalid index: ({x}, {y})");
                return false;
            }

            return dataCells[x, y].isUsed;
        }


        public bool IsAreaAvailable(Vector2I location, Vector2I size)
        {
            return IsAreaAvailable(location.X, location.Y, size.X, size.Y);
        }
        public bool IsAreaAvailable(int locationX, int locationY, int sizeX, int sizeY)
        {
            if (IsAnyPartOutOfBounds(locationX, locationY, sizeX, sizeY)) { return false; }
            if (IsAnyPartUsed(locationX, locationY, sizeX, sizeY)) { return false; }
            return true;
        }


        bool IsAnyPartOutOfBounds(int locationX, int locationY, int sizeX, int sizeY)
        {
            return locationX + sizeX > dungeonSize.X || locationY + sizeY > dungeonSize.Y;
        }

        bool IsAnyPartUsed(int locationX, int locationY, int sizeX, int sizeY)
        {
            for (int x = locationX; x < locationX + sizeX; x++)
                for (int y = locationY; y < locationY + sizeY; y++)
                    if (IsUsed(x, y))
                        return true;
            return false;
        }
    }

    public class DungeonDataCell { public bool isUsed = false; }
}