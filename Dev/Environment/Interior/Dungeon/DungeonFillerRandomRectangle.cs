using Godot;

namespace CMC.Superworld.Dungeon
{
  [Tool]
  [GlobalClass]
  public partial class DungeonFillerRandomRectangle : DungeonFiller
  {

    public override DungeonData FillDungeon(DungeonData data)
    {
      int randomStartX = GD.RandRange(0, data.dungeonSize.X - 1);
      int randomStartY = GD.RandRange(0, data.dungeonSize.Y - 1);
      int randomStopX = GD.RandRange(randomStartX + 1, data.dungeonSize.X);
      int randomStopY = GD.RandRange(randomStartY + 1, data.dungeonSize.Y);
      GD.Print($"{randomStartX}, {randomStartY}, {randomStopX}, {randomStopY}");

      for (int x = randomStartX; x < randomStopX; x++)
      {
        GD.Print($"in real generator for loop {x}");
        for (int y = randomStartY; y < randomStopY; y++)
        {
          GD.Print($"in real generator for loop {x}, {y}");
          data.MarkAsUsed(new Vector2I(x, y));
        }
      }
      return data;
    }
  }
}