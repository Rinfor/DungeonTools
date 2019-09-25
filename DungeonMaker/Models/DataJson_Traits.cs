
namespace DungeonMaker.Models
{
  public class DungeonTrait
  {
    public short Chance { get; set; }
    public string Value { get; set; }
  }

  public class DataJson_Traits
  {
    public DungeonTrait[] Climates { get; set; }
    public DungeonTrait[] Lightning { get; set; }
    public DungeonTrait[] Walls { get; set; }
  }
}