using System;
using Godot;
// using Godot.Collections;
namespace CMC.Superworld.Dungeon
{
    [Tool]
    [GlobalClass]
    public partial class DungeonFillerDoor : Resource
    {
        [Export] public bool addDoors = true;
        [Export] public float doorwayDensity = 100;
        [Export] public float doorDensity = 100;
    }
}