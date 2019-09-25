using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMapCreator
{
  public abstract class Printable
  {
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public int X { get;  set; }
    public int Y { get;  set; }
    public int PxSize { get; private set; } = 16;

    public Brush Brush { get; set; }
  }
}
