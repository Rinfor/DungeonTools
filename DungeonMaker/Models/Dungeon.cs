using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Hosting;

namespace DungeonMaker.Models
{
  public class Dungeon
  {
    public string Name { get; private set; }
    public string Climate { get; private set; }
    public string Light { get; private set; }
    public string Wall { get; private set; }
    public int DungeonWidth { get; set; }
    public int DungeonHeight { get; set; }
    public int MinCorridorSize { get; set; }
    public int MaxCorridorSize { get; set; }
    public int MinRoomWidth { get; set; }
    public int MinRoomHeight { get; set; }
    public int MaxRoomWidth { get; set; }
    public int MaxRoomHeight { get; set; }
    public int ChanceOfRoom { get; set; }
    public List<Monster> ErrantMonster { get; private set; }

    public byte[] ImageBuffer { get; set; }

    private Random random;

    public Dungeon()
    {
      random = new Random();
      ErrantMonster = new List<Monster>();
    }

    public void CreateDungeon()
    {
      DungeonMapCreator.BuildParams bp = new DungeonMapCreator.BuildParams()
      {
        DungeonWidth = this.DungeonWidth,
        DungeonHeight = this.DungeonHeight,
        MinCorridorSize = this.MinCorridorSize,
        MaxCorridorSize = this.MaxCorridorSize,
        MinRoomWidth = this.MinRoomWidth,
        MinRoomHeight = this.MinRoomHeight,
        MaxRoomWidth = this.MaxRoomWidth,
        MaxRoomHeight = this.MaxRoomHeight,
        TileImage = Image.FromFile(HostingEnvironment.MapPath(@"~/Content/Images/tile.jpg")),
        ChanceOfRoom = this.ChanceOfRoom
      };
      DungeonMapCreator.DungeonPrinter dungeonImage = new DungeonMapCreator.DungeonPrinter(bp);
      ImageConverter converter = new ImageConverter();
      ImageBuffer = (byte[])converter.ConvertTo(dungeonImage.PrintDungeon(), typeof(byte[]));
    }

    public void SetDungeonSize(string dungeonSize)
    {
      switch (dungeonSize)
      {
        case "Short":
          DungeonHeight = MvcApplication.DungeonJsonData.DungeonSize.ShortHeight;
          DungeonWidth = MvcApplication.DungeonJsonData.DungeonSize.ShortWidth;
          break;
        case "Medium":
        default:
          DungeonHeight = MvcApplication.DungeonJsonData.DungeonSize.MediumHeight;
          DungeonWidth = MvcApplication.DungeonJsonData.DungeonSize.MediumWidth;
          break;
        case "Large":
          DungeonHeight = MvcApplication.DungeonJsonData.DungeonSize.LargeHeight;
          DungeonWidth = MvcApplication.DungeonJsonData.DungeonSize.LargeWidth;
          break;
      }
    }

    public void SetCorridorSize(string corridorLong)
    {
      switch (corridorLong)
      {
        case "Short":
          MinCorridorSize = MvcApplication.DungeonJsonData.CorridorSize.ShortMin;
          MaxCorridorSize = MvcApplication.DungeonJsonData.CorridorSize.ShortMax;
          break;
        case "Medium":
        default:
          MinCorridorSize = MvcApplication.DungeonJsonData.CorridorSize.MediumMin;
          MaxCorridorSize = MvcApplication.DungeonJsonData.CorridorSize.MediumMax;
          break;
        case "Large":
          MinCorridorSize = MvcApplication.DungeonJsonData.CorridorSize.LargeMin;
          MaxCorridorSize = MvcApplication.DungeonJsonData.CorridorSize.LargeMax;
          break;
      }
    }

    public void SetRoomSize(string roomSize)
    {
      MinRoomWidth = MvcApplication.DungeonJsonData.RoomSize.MinRoomWidth;
      MinRoomHeight = MvcApplication.DungeonJsonData.RoomSize.MinRoomHeight;
      switch (roomSize)
      {
        case "Short":
          MaxRoomWidth = MvcApplication.DungeonJsonData.RoomSize.ShortWidth;
          MaxRoomHeight = MvcApplication.DungeonJsonData.RoomSize.ShortHeight;
          break;
        case "Medium":
        default:
          MaxRoomWidth = MvcApplication.DungeonJsonData.RoomSize.MediumWidth;
          MaxRoomHeight = MvcApplication.DungeonJsonData.RoomSize.MediumHeight;
          break;
        case "Large":
          MaxRoomWidth = MvcApplication.DungeonJsonData.RoomSize.LargeWidth;
          MaxRoomHeight = MvcApplication.DungeonJsonData.RoomSize.LargeHeight;
          break;
      }
    }

    public void SetChanceOfRoom(string roomDensity)
    {
      switch (roomDensity)
      {
        case "Disperse":
          ChanceOfRoom = MvcApplication.DungeonJsonData.ChanceOfRoom.Low;
          break;
        case "Normal":
        default:
          ChanceOfRoom = MvcApplication.DungeonJsonData.ChanceOfRoom.Normal;
          break;
        case "Dense":
          ChanceOfRoom = MvcApplication.DungeonJsonData.ChanceOfRoom.High;
          break;
      }
    }

    public void CreateName()
    {
      string dungeonNamesFile = System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/Content/Files/Names.json"));
      DataJson_Names names = Newtonsoft.Json.JsonConvert.DeserializeObject<DataJson_Names>(dungeonNamesFile);
      Name = names.Adjetives[random.Next(names.Adjetives.Length)];
      Name += names.Subjects[random.Next(names.Subjects.Length)];
      Name += names.Complements[random.Next(names.Complements.Length)];
    }

    public void CreateDungeonTraits()
    {
      string dungeonTraitsFile = System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/Content/Files/DungeonTraits.json"));
      DataJson_Traits traitsJson = Newtonsoft.Json.JsonConvert.DeserializeObject<DataJson_Traits>(dungeonTraitsFile);
      Climate = SelectRandomTrait(traitsJson.Climates);
      Light = SelectRandomTrait(traitsJson.Lightning);
      Wall = SelectRandomTrait(traitsJson.Walls);
    }

    public void CreateErrantMonsters(List<Monster> monsters)
    {
      ErrantMonster.Clear();
      int monsterLen = monsters.Count;
      for (int i = 0; i<4; i++)
      {
        int rnd = random.Next(0, monsterLen);
        ErrantMonster.Add(monsters[rnd]);
      }
    }

    private string SelectRandomTrait(DungeonTrait[] traits)
    {
      int rnd = random.Next(0, 100);
      int accChance = 0;
      bool selected = false;
      string trait = "";
      int len = traits.Length;
      int i = 0;
      while(!selected && i < len)
      {
        if(rnd <= traits[i].Chance + accChance)
        {
          trait = traits[i].Value;
          selected = true;
        }
        else
        {
          accChance += traits[i].Chance;
        }
        i++;
      }
      return trait;
    }
  }
}