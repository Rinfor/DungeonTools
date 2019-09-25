namespace DungeonMapCreator
{
  public class Opening
  {
    public int X { get; set; }
    public int Y { get; set; }
    public Orientation Orientation { get; set; }

    public Opening()
    {
      
    }

    public Opening(Opening opening)
    {
      X = opening.X;
      Y = opening.Y;
      Orientation = opening.Orientation;
    }

    public void ReverseOrientation()
    {
      switch (Orientation)
      {
        case Orientation.North:
          Orientation = Orientation.South;
          break;
        case Orientation.South:
          Orientation = Orientation.North;
          break;
        case Orientation.East:
          Orientation = Orientation.West;
          break;
        case Orientation.West:
          Orientation = Orientation.East;
          break;
        default:
          break;
      }
    }

    public bool IsReverse(Orientation orientation)
    {
      switch (orientation)
      {
        case Orientation.North:
          return Orientation == Orientation.South;
        case Orientation.South:
          return Orientation == Orientation.North;
        case Orientation.East:
          return Orientation == Orientation.West;
        case Orientation.West:
          return Orientation == Orientation.East;
        default:
          return false;
      }
    }
  }
}