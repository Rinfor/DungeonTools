using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMapCreator
{
  public class DungeonMap : Printable
  {
    public static Random Random { get; private set; }
    public bool[,] Map { get; private set; }

    //lista de rooms y corridors
    public List<Room> Rooms { get; private set; }
    public List<Corridor> Corridors { get; private set; }

    private List<Tuple<int, int>> coordsForBacktracking = new List<Tuple<int, int>>();
    private BuildParams buildParams;

    public DungeonMap(BuildParams @params)
    {
      Random = new Random();
      Width = @params.DungeonWidth;
      Height = @params.DungeonHeight;
      Rooms = new List<Room>();
      Corridors = new List<Corridor>();
      buildParams = @params;
      if (@params.WallImage != null)
      {
        Brush = new TextureBrush(@params.WallImage);
      }
      else
      {
        Brush = Brushes.Black;
      }
      Map = new bool[Width, Height];
    }

    public void CreateDungeon()
    {
      Room initialRoom = CreateRoom(Width / 2, Height / 2, Orientation.Null,true);
      Rooms.Add(initialRoom);
      int roomIndex = 1;
      PopulateOpenings(initialRoom);
      while (roomIndex < Rooms.Count)
      {
        PopulateOpenings(Rooms[roomIndex]);
        roomIndex++;
      } 
    }

    private Room CreateRoom(int x, int y, Orientation createdFrom ,bool isFirstRoom = false)
    {
      Room room = new Room(buildParams);
      bool roomOk = false;
      if (!isFirstRoom)
      {
        roomOk = room.CreateRoom(x, y, Width, Height,createdFrom);
      }
      else
      {
        roomOk = room.CreateFirstRoom(x, y, Width, Height);
      }
      if (roomOk)
      {
        try
        {
          for (int i = room.X; i < room.X + room.Width; i++)
          {
            for (int j = room.Y; j < room.Y + room.Height; j++)
            {
              Map[i, j] = true;
            }
          }
          return room;
        }
        catch (IndexOutOfRangeException)
        {
          return null;
        }
      }
      else
      {
        return null;
      }
    }

    private void PopulateOpenings(Room room)
    {
      foreach (Opening opening in room.Openings)
      {
        int x = 0;
        int y = 0;
        switch (opening.Orientation)
        {
          case Orientation.East:
            x = opening.X + 1;
            y = opening.Y;
            break;
          case Orientation.West:
            x = opening.X - 1;
            y = opening.Y;
            break;
          case Orientation.North:
            x = opening.X;
            y = opening.Y-1;
            break;
          case Orientation.South:
            x = opening.X;
            y = opening.Y+1;
            break;
        }
        if(x < Width && x >= 0 && y < Height && y >= 0)
        {
          FillOpening(x, y, opening, 0);
        }
      }
    }

    private void FillOpening(int x,int y, Opening opening, int iteration)
    {
      int tiles = Random.Next(buildParams.MinCorridorSize, buildParams.MaxCorridorSize);
      bool bHasToStop = false;
      int i = 0;
      while (!bHasToStop && i < tiles)
      {
        try
        {
          if (x < Width && x >= 0 && y < Height && y >= 0 && !Map[x, y])
          {
            Map[x, y] = true;
            coordsForBacktracking.Add(new Tuple<int, int>(x, y));
            Corridors.Add(new Corridor(buildParams.TileImage) { X = x, Y = y });
            IncrementCoord(ref x, ref y, opening.Orientation);
          }
          else
          {
            bHasToStop = true;
          }
        }
        catch (IndexOutOfRangeException)
        {
          BacktrackingCorridors();
          bHasToStop = true;
        }
        i++;
      }
      if(!bHasToStop)
      {
        AddToCorridor(x, y, opening, iteration);
      }
    }

    private void AddToCorridor(int x, int y, Opening opening, int iteration)
    {
      bool createRoom = Random.Next(100) < buildParams.ChanceOfRoom;
      if (createRoom)
      {
        Room room = CreateRoom(x, y, opening.Orientation);
        if (room != null && !CheckCollisions(room))
        {
          Rooms.Add(room);
        }
        else
        {
          BacktrackingCorridors();
        }
      }
      if (!createRoom)
      {
        Orientation orientation = Orientation.Null;
        do
        {
          orientation = (Orientation)Random.Next(1, 4) + 1;
        } while (opening.IsReverse(orientation));
        Opening newCorridorOpening = new Opening() { X = x, Y = y, Orientation = orientation };
        if (x < Width && x >= 0 && y < Height && y >= 0)
        {
          FillOpening(x, y, newCorridorOpening, iteration + 1);
        }
      }
      if (iteration == 0)
      {
        coordsForBacktracking.Clear();
      }
    }

    private void BacktrackingCorridors()
    {
      foreach(Tuple<int,int> coord in coordsForBacktracking)
      {
        Map[coord.Item1, coord.Item2] = false;
        Corridors.RemoveAll(c => c.X == coord.Item1 && c.Y == coord.Item2);
      }
    }

    private void IncrementCoord(ref int x, ref int y, Orientation orientation)
    {
      switch (orientation)
      {
        case Orientation.East:
          x++;
          break;
        case Orientation.West:
          x--;
          break;
        case Orientation.North:
          y--;
          break;
        case Orientation.South:
          y++;
          break;
      }
    }

    private bool CheckCollisions(Printable printable)
    {
      bool collide = false;
      Rectangle rectangle = new Rectangle(printable.X, printable.Y, printable.Width, printable.Height);
      foreach(Room r in Rooms)
      {
        Rectangle auxRentangle = new Rectangle(r.X, r.Y, r.Width, r.Height);
        if(rectangle.IntersectsWith(auxRentangle))
        {
          collide = true;
          break;
        }
      }
      if(collide)
      {
        return collide;
      }
      foreach (Corridor c in Corridors)
      {
        Rectangle auxRentangle = new Rectangle(c.X, c.Y, c.Width, c.Height);
        if (rectangle.IntersectsWith(auxRentangle))
        {
          collide = true;
          break;
        }
      }
      return collide;
    }
  }
}
