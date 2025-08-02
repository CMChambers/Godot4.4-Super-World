using Godot;
using CMC.Tools;

namespace CMC.Superworld.Dungeon
{
  [Tool]
  [GlobalClass]
  public partial class DungeonFillerSequencialRoom : DungeonFillerRoom
  {
    [ExportGroup("Sequencial Room Filler Settings")]
    [Export] public SequencialRoomStartLocation startLocation;
    [Export] public SequencialRoomSizeMethod sizeMethod;
    private bool sizeLimitReached = false;
    int locationX = 1;
    int locationY = 1;

    protected override bool IsStillFilling(DungeonData data)
    {
      if (isDungeonSizeLimitReached(data) || isDensityGoalReached())
      {
        // GD.Print($"locationX:{locationX}, locationY:{locationY}, densityCountCurrentAmount:{densityCountCurrentAmount} >= densityCountCurrentGoal:{densityCountCurrentGoal}");
        return false;
      }
      else
      { return true; }
    }
    protected override bool isDungeonSizeLimitReached(DungeonData data)
    {
      if (sizeLimitReached)
      // if (locationX >= data.dungeonSize.X && locationY >= data.dungeonSize.Y)
      { return true; }
      else
      { return false; }
    }
    protected override Area Find(DungeonData data)
    {
      switch (startLocation)
      {
        case SequencialRoomStartLocation.Corner:
          return SearchFromCorner(data);
        case SequencialRoomStartLocation.Middle:
          return new Area();

          // break;
      }
      return new Area();

      Area SearchFromCorner(DungeonData data)
      {
        locationY = MathX.MakeOddUp(locationY);
        locationX = MathX.MakeOddUp(locationX);
        int sizeResult = GetSizeResult();

        for (; locationY <= data.dungeonSize.Y; locationY += 2)
        {
          for (; locationX <= data.dungeonSize.X; locationX += 2)
          {
            if (data.IsUsed(locationX, locationY)) { continue; }

            for (int size = MathX.MakeOddUp(sizeResult); size >= MathX.MakeOddUp(roomMinimumSize); size -= 2)
            {
              if (data.IsAreaAvailable(locationX, locationY, size, size))
              {
                SuccessFindingSpot = true;
                return selectedArea = new Area(new Vector2I(locationX, locationY), new Vector2I(size, size));
              }
            }
          }
          if (locationX >= data.dungeonSize.X && locationY >= data.dungeonSize.Y)
          { sizeLimitReached = true; }
          locationX = 1;
        }
        FailedFindingSpot = true;
        return new Area();
      }
    }

    // protected override void CheckIfAreaAvailable(DungeonData data, Area selectedArea)
    // {
    //   throw new NotImplementedException();
    // }
    int GetSizeResult()
    {
      switch (sizeMethod)
      {
        case SequencialRoomSizeMethod.Sequencial:
          return MathX.MakeOddUp(roomMaximumSize);
        case SequencialRoomSizeMethod.Random:
          return MathX.RandomOdd(roomMinimumSize, roomMaximumSize);
        default:
          return 1;
      }
    }
  }
  public enum SequencialRoomStartLocation { Corner, Middle }
  public enum SequencialRoomSizeMethod { Sequencial, Random }
}