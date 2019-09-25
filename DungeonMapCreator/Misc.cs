using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMapCreator
{
  public class BuildParams
  {
    public int DungeonWidth { get; set; } = 64;
    public int DungeonHeight { get; set; } = 64;
    public int MinCorridorSize { get; set; } = 4;
    public int MaxCorridorSize { get; set; } = 8;
    public int MinRoomWidth { get; set; } = 3;
    public int MinRoomHeight { get; set; } = 3;
    public int MaxRoomWidth { get; set; } = 12;
    public int MaxRoomHeight { get; set; } = 12;
    public int ChanceOfRoom { get; set; } = 50;
    public Image WallImage { get; set; } = null;
    public Image TileImage { get; set; } = null;
  }

  public enum Orientation
  {
    Null,
    North,
    South,
    West,
    East
  }
}
