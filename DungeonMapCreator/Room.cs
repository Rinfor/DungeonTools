using System.Collections.Generic;
using System.Drawing;

namespace DungeonMapCreator
{
  public class Room : Printable
  {
    public List<Opening> Openings { get; private set; }
    private BuildParams buildParams;

    public Room(BuildParams @params)
    {
      Openings = new List<Opening>();
      if(@params.TileImage != null)
      {
        Brush = new TextureBrush(@params.TileImage);
      }
      else
      {
        Brush = Brushes.White;
      }
      buildParams = @params;
    }

    public bool CreateFirstRoom(int x, int y, int dungeonWidth, int dungeonHeight)
    {
      Width = DungeonMap.Random.Next(buildParams.MinRoomWidth, buildParams.MaxRoomWidth);
      Height = DungeonMap.Random.Next(buildParams.MinRoomHeight, buildParams.MaxRoomHeight);
      X = x;
      Y = y;
      if (X + Width >= dungeonWidth || Y + Height >= dungeonHeight)
      {
        return AdjustRoom(dungeonWidth, dungeonHeight);
      }
      AddOpening(X + Width - 1, Y + DungeonMap.Random.Next(Height), Orientation.East, true);
      AddOpening(X + DungeonMap.Random.Next(Width), Y + Height - 1, Orientation.South, true);
      AddOpening(X, Y + DungeonMap.Random.Next(Height), Orientation.West, true);
      AddOpening(X + DungeonMap.Random.Next(Width), Y, Orientation.North, true);
      return true;
    }

    public bool CreateRoom(int x, int y, int dungeonWidth, int dungeonHeight, Orientation fromCreated)
    {
      Width = DungeonMap.Random.Next(buildParams.MinRoomWidth, buildParams.MaxRoomWidth);
      Height = DungeonMap.Random.Next(buildParams.MinRoomHeight, buildParams.MaxRoomHeight);
      X = x;
      Y = y;
      if (fromCreated == Orientation.West)
      {
        X = x - Width + 1;
      }
      else if (fromCreated == Orientation.North)
      {
        Y = y - Height + 1;
      }
      if (X + buildParams.MinRoomWidth >= dungeonWidth || Y + buildParams.MinRoomHeight >= dungeonHeight || X < 1 || Y < 1)
      {
        return false;
      }
      if (fromCreated == Orientation.South || fromCreated == Orientation.North)
      {
        X = DungeonMap.Random.Next(X - Width + 1, X);
      }
      else if (fromCreated == Orientation.West || fromCreated == Orientation.East)
      {
        Y = DungeonMap.Random.Next(Y - Height + 1, Y);
      }
      if (X + Width >= dungeonWidth || Y + Height >= dungeonHeight)
      {
        return AdjustRoom(dungeonWidth, dungeonHeight);
      }
      AddOpenings(dungeonWidth, dungeonHeight);
      return true;
    }

    private bool AdjustRoom(int dungeonWidth, int dungeonHeight)
    {
      Width /= 2;
      Height /= 2;
      X += X;
      Y += Y;
      if (Width < buildParams.MinRoomWidth || Height < buildParams.MinRoomHeight)
      {
        return false;
      }
      if (X + Width >= dungeonWidth || Y + Height >= dungeonHeight)
      {
        return AdjustRoom(dungeonWidth, dungeonHeight);
      }
      return true;
    }

    private void AddOpenings(int dungeonWidth, int dungeonHeight)
    {
      if (Width > 2)
      {
        if (X - buildParams.MinCorridorSize > 1)
        {
          AddOpening(X + DungeonMap.Random.Next(Width), Y, Orientation.North);
        }
        if (X + buildParams.MinCorridorSize < dungeonHeight + 1)
        {
          AddOpening(X + DungeonMap.Random.Next(Width), Y + Height - 1, Orientation.South);
        }
      }
      if (Height > 2)
      {
        if (Y - buildParams.MinCorridorSize > 1)
        {
          AddOpening(X, Y + DungeonMap.Random.Next(Height), Orientation.West);
        }
        if (Y + buildParams.MinCorridorSize < dungeonWidth + 1)
        {
          AddOpening(X + Width - 1, Y + DungeonMap.Random.Next(Height), Orientation.East);
        }
      }
    }

    private void AddOpening(int x, int y, Orientation orientation, bool createAlways = false)
    {
      bool create = DungeonMap.Random.Next(2) == 1;
      if (create || createAlways)
      {
        Openings.Add(new Opening() { X = x, Y = y, Orientation = orientation });
      }
    }
  }
}
