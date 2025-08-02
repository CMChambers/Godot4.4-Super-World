using Godot;

namespace CMC.Superworld.Dungeon
{
    public partial class DungeonRenderer : Node
    {
        [Export] public PackedScene debugObject;
        // private MeshInstance3D debugMeshInstance3D;


        public void RenderReal(DungeonData data)
        {
            GD.Print("in RenderReal");
        }

        public void RenderDebug(DungeonData data)
        {
            GD.Print("in RenderDebug");
            // var DebugObjectInstance = debugObject.Instantiate();
            GD.Print("after instance created");
            // AddChild(DebugObjectInstance);
            GD.Print("after child added");

        }

        public void RenderDebugMesh(DungeonData data)
        {
            RenderDungeonOutline(data);
            for (int x = 0; x < data.dungeonSize.X; x++)
            {
                for (int y = 0; y < data.dungeonSize.Y; y++)
                {
                    if (data.IsUsed(x, y))
                    {
                        Spawn.DebugBoxMesh(x, y, this);
                    }
                    // GD.Print($" {x}, {y}= {data.IsUsed(x, y)}");
                }
            }
        }

        private void RenderDungeonOutline(DungeonData data)
        {
            for (int x = -1; x < data.dungeonSize.X + 1; x++)
            {
                for (int y = -1; y < data.dungeonSize.Y + 1; y++)
                {
                    if (x == -1 || y == -1 || x == data.dungeonSize.X || y == data.dungeonSize.Y)
                    { Spawn.DebugBoxMesh(x, y, this); }
                }
            }
        }

        public void RenderText(DungeonData data)
        {
            GD.Print("in RenderText");
            for (int x = 0; x < data.dungeonSize.X; x++)
            {
                // GD.Print("in render text for loop " + x);
                for (int y = 0; y < data.dungeonSize.Y; y++)
                {
                    // GD.Print("in render text for loop " + x + " " + y);
                    GD.Print($" {x}, {y}= {data.IsUsed(x, y)}");
                    if (data.IsUsed(x, y))
                        GD.Print($" {x}, {y}= {data.IsUsed(x, y)}");

                }
            }
        }

    }
}