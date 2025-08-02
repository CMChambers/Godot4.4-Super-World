using Godot;
using CMC.Tools;
using System;

namespace CMC.Superworld.Dungeon
{

  [Tool]
  [GlobalClass]
  public abstract partial class DungeonFillerRoom : DungeonFiller
  {
    [ExportGroup("Room Filler Settings")]

    [Export] public int roomMinimumSize;
    [Export] public int roomMaximumSize;
    [Export(PropertyHint.Range, "0,1,0.01")] public float roomSquareDeviation;
    [Export(PropertyHint.Range, "0,1,0.01")] protected float roomSquareDeviationChance;
    [Export(PropertyHint.Range, "0,1,0.01")] protected float roomSquareDeviationMaximumPercent;
    protected bool SuccessFindingSpot;
    protected bool FailedFindingSpot;
    protected Area selectedArea;





    public override DungeonData FillDungeon(DungeonData data)
    {
      SetSettings(data);

      while (IsStillFilling(data))
      {
        while (!SuccessFindingSpot && !FailedFindingSpot)
        {
          selectedArea = Find(data);
        }
        if (SuccessFindingSpot)
        {
          Fill(data, selectedArea);
        }
        ResetMethods();
      }
      return data;
    }





    private void ResetMethods()
    {
      FailedFindingSpot = false;
      SuccessFindingSpot = false;
    }
    private void SetSettings(DungeonData data)
    {
      ChooseDensityGoalMethod(data);
      FailedFindingSpot = false;
      SuccessFindingSpot = false;
    }
    private void Fill(DungeonData data, Area selectedArea)
    {
      for (int x = selectedArea.location.X; x < selectedArea.location.X + selectedArea.size.X; x++)
      {
        for (int y = selectedArea.location.Y; y < selectedArea.location.Y + selectedArea.size.Y; y++)
        {
          data.MarkAsUsed(new Vector2I(x, y));
          densityCountCurrentAmount++;

        }
      }
      densityCountCurrentAmount += selectedArea.size.X;
      densityCountCurrentAmount += selectedArea.size.Y;
      densityCountCurrentAmount += 1;
    }

    protected abstract bool IsStillFilling(DungeonData data);
    protected abstract Area Find(DungeonData data);
    // protected abstract void CheckIfAreaAvailable(DungeonData data, Area selectedArea);

    protected virtual bool isDensityGoalReached()
    { return densityCountCurrentAmount >= densityCountCurrentGoal; }
    protected virtual bool isFailureLimitReached()
    { return false; }
    protected virtual bool isDungeonSizeLimitReached(DungeonData data)
    { return false; }
    protected Vector2I GenerateAreaSize(SizeSettingsContainer _settings)
    {

      int sizeX = MathX.RandomOdd(_settings.minimumSize, _settings.maximumSize);
      int sizeY = sizeX;

      // bool shouldDeviate = MathX.RandomFloat() <= _settings.deviationChance;

      if (MathX.RandomBool() && _settings.deviationMaximumPercent > 0)
      {
        int maxDeviation = (int)MathF.Round(sizeX * _settings.deviationMaximumPercent * _settings.squareDeviation);

        bool adjustX = MathX.RandomBool();

        int delta = MathX.RandomRange(-maxDeviation, maxDeviation + 1);
        if (adjustX)
        {
          //adjust size in the x axis
          sizeX = MathX.MakeOddUp(Math.Clamp(sizeX + delta, _settings.minimumSize, _settings.maximumSize));
        }
        else
        {
          //adjust size in the y axis
          sizeY = MathX.MakeOddUp(Math.Clamp(sizeY + delta, _settings.minimumSize, _settings.maximumSize));
        }
      }
      return new Vector2I(sizeX, sizeY);
    }
  }
  public struct Area
  {
    public Vector2I location;
    public Vector2I size;
    public Area() { }
    public Area(Vector2I location, Vector2I size)
    {
      this.location = location;
      this.size = size;
    }

  }
  public struct SizeSettingsContainer
  {
    public int minimumSize;
    public int maximumSize;
    public float squareDeviation;
    public float deviationChance;
    public float deviationMaximumPercent;
    public SizeSettingsContainer(int minimumSize,
                                 int maximumSize,
                                 float squareDeviation,
                                 float deviationChance,
                                 float deviationMaximumPercent)
    {
      this.minimumSize = minimumSize;
      this.maximumSize = maximumSize;
      this.squareDeviation = squareDeviation;
      this.deviationChance = deviationChance;
      this.deviationMaximumPercent = deviationMaximumPercent;
    }
  }
}
