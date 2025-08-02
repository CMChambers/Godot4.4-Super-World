using Godot;
using Godot.Collections;
using System.Collections.Generic;
using CMC.DevelopmentTools;

namespace CMC.Superworld.Dungeon
{
    public class DungeonGenerator
    {
        // [Export] private GenerateMethod generateMethod;
        public DungeonData DebugGenerate(DungeonSettings settings)
        {
            GD.Print("in debug Generate");
            DungeonData result = new DungeonData(settings.dungeonSize);
            if (result == null) { GD.PrintErr("result is null"); }

            for (int x = 1; x <= 4; x++)
            {
                for (int y = 1; y <= 4; y++)
                {
                    GD.Print("in debug generate for loop " + x + " " + y);
                    result.MarkAsUsed(new Vector2I(x, y));
                }
            }
            return result;
        }


        public DungeonData Generate(DungeonSettings settings)
        {
            DungeonData result = new DungeonData(settings.dungeonSize);
            DevTools.NullCheck(result);
            if (result == null) { GD.PrintErr("result is null"); }
            result.fillDensityMethod = settings.fillDensityMethod;
            result.densityTotalAmount = settings.dungeonSize.X * settings.dungeonSize.Y; ;

            if (settings.Fillers == null) { GD.PrintErr("Fillers are null"); }
            foreach (var filler in settings.Fillers)
            {
                GD.Print("for each filler");
                if (filler.enabled)
                { result = filler.FillDungeon(result); }
            }

            return result;
        }
    }
}