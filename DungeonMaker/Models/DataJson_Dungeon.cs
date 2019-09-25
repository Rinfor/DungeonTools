using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonMaker.Models
{
  public class DataJson_Dungeon
  {
    public DungeonSize DungeonSize { get; set; }
    public CorridorSize CorridorSize { get; set; }
    public RoomSize RoomSize { get; set; }
    public ChanceOfRoom ChanceOfRoom { get; set; }
  }

  public class DungeonSize
  {
    public int ShortWidth { get; set; }
    public int ShortHeight { get; set; }
    public int MediumWidth { get; set; }
    public int MediumHeight { get; set; }
    public int LargeWidth { get; set; }
    public int LargeHeight { get; set; }
  }

  public class CorridorSize
  {
    public int ShortMin { get; set; }
    public int ShortMax { get; set; }
    public int MediumMin { get; set; }
    public int MediumMax { get; set; }
    public int LargeMin { get; set; }
    public int LargeMax { get; set; }
  }

  public class RoomSize
  {
    public int MinRoomWidth { get; set; }
    public int MinRoomHeight { get; set; }
    public int ShortWidth { get; set; }
    public int ShortHeight { get; set; }
    public int MediumWidth { get; set; }
    public int MediumHeight { get; set; }
    public int LargeWidth { get; set; }
    public int LargeHeight { get; set; }
  }

  public class ChanceOfRoom
  {
    public int Low { get; set;}
    public int Normal { get; set; }
    public int High { get; set; }
  }
}