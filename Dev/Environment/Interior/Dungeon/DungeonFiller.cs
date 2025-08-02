// using System;
using Godot;
// using Godot.Collections;
namespace CMC.Superworld.Dungeon
{
    // [Tool]
    [GlobalClass]
    public abstract partial class DungeonFiller : Resource
    {
        [Export] public bool enabled = true;
        [Export(PropertyHint.Range, "0,1,0.01")] public float density = 0.2f;
        [Export] public DungeonFillerDoor doors;
        protected int densityCountCurrentGoal;
        protected int densityCountCurrentAmount;


        public abstract DungeonData FillDungeon(DungeonData data);

        protected void ChooseDensityGoalMethod(DungeonData data)
        {
            densityCountCurrentAmount = 0;
            switch (data.fillDensityMethod)
            {
                case FillDensityMethod.Original:
                    densityCountCurrentGoal = (int)(data.densityTotalAmount * density);
                    break;

                case FillDensityMethod.Remaining:
                    densityCountCurrentGoal = (int)(data.densityTotalAvailable * density);
                    break;
            }

        }
    }
}