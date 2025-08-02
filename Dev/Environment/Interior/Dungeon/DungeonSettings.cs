using Godot;
using Godot.Collections;
using System.Collections.Generic;
// using System.Collections;

namespace CMC.Superworld.Dungeon
{
    [GlobalClass]
    public partial class DungeonSettings : Resource
    {
        [Export] public FillDensityMethod fillDensityMethod;

        [Export] public SeedToUse seedToUse;
        [Export] public string seed = "ransom seed";
        [Export] public Vector2I dungeonSize;
        public int densityTotalAmount;
        [Export] public int cellSize = 1;

        [Export] public DungeonFiller[] Fillers;
        // [Export] public List<DungeonFiller> listFillers = new List<DungeonFiller>();
    }
    public enum SeedToUse { Global, Random, Custom }

}