using DungeonMaker.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace DungeonMaker.Controllers
{
  public class DungeonController : Controller
  {
  // GET: Dungeon

          private MonsterContext db = new MonsterContext();

    public ActionResult Index()
    {
      SelectList sizes = new SelectList(new List<string>() { "Short", "Medium", "Large" });
      ViewBag.sizes = sizes;
      SelectList density = new SelectList(new List<string>() { "Disperse", "Normal", "Dense" });
      ViewBag.density = density;
      return View();
    }

    [HttpPost]
    public ActionResult Create()
    {
      Models.Dungeon dungeon = new Models.Dungeon();
      dungeon.SetDungeonSize(Request.Form["dungeonSize"].ToString());
      dungeon.SetCorridorSize(Request.Form["corridorLong"].ToString());
      dungeon.SetRoomSize(Request.Form["roomSize"].ToString());
      dungeon.SetChanceOfRoom(Request.Form["roomDensity"].ToString());
      dungeon.CreateName();
      dungeon.CreateDungeon();
      dungeon.CreateDungeonTraits();
      List<Monster> monsters = new List<Monster>();
      using (MonsterContext db = new MonsterContext())
      {
        monsters = new List<Monster>(db.Monsters.ToList());
        foreach(Monster monster in monsters)
        {
          monster.MonsterAbilities = db.Abilities.FirstOrDefault(a => a.ID == monster.MonsterID);
        }
      };
      dungeon.CreateErrantMonsters(monsters);
      return View("Details", dungeon);
    }
  }
}