using System;
using Godot;
// using Godot.Collections;
namespace CMC.Superworld.Dungeon
{

[Tool]
[GlobalClass]
public partial class DungeonFillerHallway : DungeonFiller
{
    [Export] public int turnChance;
    [Export] public int deadEndChance;
    [Export] public int forkChance;

    public override DungeonData FillDungeon(DungeonData data)
    {
            return data;
    }

}
}