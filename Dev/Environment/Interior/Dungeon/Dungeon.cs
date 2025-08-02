using Godot;
using CMC.Tools;


namespace CMC.Superworld.Dungeon
{
	public partial class Dungeon : Node
	{

		[Export] private Camera3D camera;
		[Export] private NodePath RendererPath;
		[Export] private GenerateMethod generateMethod;
		[Export] private RenderMethod renderMethod;
		[Export] private DungeonSettings settings;
		private DungeonData data;

		private DungeonGenerator generator;
		private DungeonRenderer renderer;

		public override void _Ready()
		{
			// GD.Print($"dungeon size 1:{settings.dungeonSize.X}, {settings.dungeonSize.Y}");
			SetSettings(settings);
			GD.Print($"dungeon size 2:{settings.dungeonSize.X}, {settings.dungeonSize.Y}");
			PositionCamera();
			// GD.Print($"dungeon size 3:{settings.dungeonSize.X}, {settings.dungeonSize.Y}");

			generator = new DungeonGenerator();
			if (generator == null) { GD.PushError("Generator is null!"); }

			renderer = GetNode<DungeonRenderer>(RendererPath);
			if (renderer == null) { GD.PushError("Renderer is null!"); }

			if (data == null) { GD.PushError("Data is null before generate"); }

			switch (generateMethod)
			{
				case GenerateMethod.Debug:
					data = generator.DebugGenerate(settings);
					break;
				case GenerateMethod.Real:
					data = generator.Generate(settings);
					break;
			}
			if (data == null) { GD.PushError($"Data is {data} after generate"); }
			GD.Print("data generated");


			switch (renderMethod)
			{
				case RenderMethod.Text:
					renderer.RenderText(data);
					break;
				case RenderMethod.Debug:
					renderer.RenderDebug(data);
					break;
				case RenderMethod.Real:
					renderer.RenderReal(data);
					break;
				case RenderMethod.DebugMesh:
					renderer.RenderDebugMesh(data);
					break;
			}
			if (data == null) { GD.PushError("Data is null after render"); }

			GD.Print("data rendered");


		}
		private void PositionCamera()
		{
			camera.Position = new Vector3(settings.dungeonSize.X / 2, settings.dungeonSize.Y, settings.dungeonSize.Y / 2);
			camera.RotationDegrees = new Vector3(-90, 0, 0);
		}
		private void SetSettings(DungeonSettings settings)
		{
			settings.dungeonSize = new Vector2I(MathX.MakeOddUp(settings.dungeonSize.X), MathX.MakeOddUp(settings.dungeonSize.Y));
		}
	}
	public enum GenerateMethod { Debug, Real }
	public enum RenderMethod { Text, Debug, DebugMesh, Real }
	public enum FillDensityMethod { Original, Remaining }
}
