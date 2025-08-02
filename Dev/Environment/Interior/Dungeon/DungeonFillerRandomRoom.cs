using Godot;
using CMC.Tools;

namespace CMC.Superworld.Dungeon
{
  [Tool]
  [GlobalClass]
  public partial class DungeonFillerRandomRoom : DungeonFillerRoom
  {
    [ExportGroup("Debug")]
    private int failedAttemptsMade;
    [Export] private int failedAttemptsAllowed = 100;


    protected override Area Find(DungeonData data)
    {
      SizeSettingsContainer sizeSettingsContainer = new SizeSettingsContainer(
                                                                roomMinimumSize,
                                                                roomMaximumSize,
                                                                roomSquareDeviation,
                                                                roomSquareDeviationChance,
                                                                roomSquareDeviationMaximumPercent);
      selectedArea = new Area();
      selectedArea.location.X = MathX.RandomOdd(0, data.dungeonSize.X - 2);
      selectedArea.location.Y = MathX.RandomOdd(0, data.dungeonSize.Y - 2);
      selectedArea.size = GenerateAreaSize(sizeSettingsContainer);
      // selectedArea.size.X = Math.RandomOdd(roomMinimumSize, roomMaximumSize);
      // selectedArea.size.Y = selectedArea.size.X;
      CheckIfAreaAvailable(data, selectedArea);
      return selectedArea;
    }
    void CheckIfAreaAvailable(DungeonData data, Area selectedArea)
    {
      if (AreaIsAvailable(selectedArea, data))
      {
        SuccessFindingSpot = true;
      }
      else
      {
        failedAttemptsMade++;
        if (failedAttemptsMade >= failedAttemptsAllowed)
        {
          FailedFindingSpot = true;
        }
      }
      bool AreaIsAvailable(Area area, DungeonData data) => data.IsAreaAvailable(area.location, area.size);
    }
    void SetSettings(DungeonData data)
    {
      ChooseDensityGoalMethod(data);
      FailedFindingSpot = false;
      SuccessFindingSpot = false;
    }
    protected override bool IsStillFilling(DungeonData data)
    {
      if (isDensityGoalReached() || isFailureLimitReached())
      {
        failedAttemptsMade = 0;
        return false;
      }
      else
      {
        return true;
      }

    }
    protected override bool isFailureLimitReached()
    { return failedAttemptsMade >= failedAttemptsAllowed; }
  }
}
