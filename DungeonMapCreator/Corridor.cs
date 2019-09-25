using System;
using System.Drawing;

namespace DungeonMapCreator
{
  public class Corridor : Printable
  {
    public Corridor(Image tileImage)
    {
      if(tileImage != null)
      {
        Brush = new TextureBrush(tileImage);
      }
      else
      {
        Brush = Brushes.White;
      }
      Width = 1;
      Height = 1;
    }
  }
}