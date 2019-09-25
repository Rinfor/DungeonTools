using System.Drawing;

namespace DungeonMapCreator
{
  public class DungeonPrinter
  {
    public DungeonMap dungeonMap; 

    public DungeonPrinter(BuildParams @params)
    {
      dungeonMap = new DungeonMap(@params);
    }

    public Bitmap PrintDungeon()
    {
      dungeonMap.CreateDungeon();
      ImagePrinter imagePrinter = new ImagePrinter();
      Bitmap dungeon = imagePrinter.Print(dungeonMap);
      foreach (Room r in dungeonMap.Rooms)
      {
        imagePrinter.PrintOnImage(r, dungeon);
      }
      foreach (Corridor c in dungeonMap.Corridors)
      {
        imagePrinter.PrintOnImage(c, dungeon);
      }
      return dungeon;
    }
  }
}
