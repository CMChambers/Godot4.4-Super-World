using System;
using Godot;
// using Godot.Collections;
namespace CMC.Superworld.Dungeon
{

  [Tool]
  [GlobalClass]
  public partial class DungeonFillerCave : DungeonFiller
  {
    [Export] public int minSize;
    [Export] public int maxSize;
    [Export] public int squareDeviation;

    public override DungeonData FillDungeon(DungeonData data)
    {
      return data;
    }

  }
}