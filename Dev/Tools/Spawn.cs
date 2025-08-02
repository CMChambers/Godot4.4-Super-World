using Godot;

namespace CMC.Superworld
{
    public partial class Spawn : Node
    {
        public static void DebugBoxMesh(int x, int y, Node parent)
        {
            MeshInstance3D debugMeshInstance3D = new MeshInstance3D();

            var boxMesh = new BoxMesh
            {
                Size = new Vector3(1, 1, 1)
            };
            debugMeshInstance3D.Mesh = boxMesh;
            debugMeshInstance3D.Position = new Vector3(x + (x * 0.1f), 0, y + (y * 0.1f));

            parent.AddChild(debugMeshInstance3D);
        }
    }
}