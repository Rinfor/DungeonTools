using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DungeonMaker.Models;

namespace DungeonMaker.Controllers
{
  public class MonsterController : Controller
  {
    private MonsterContext db = new MonsterContext();

    public ActionResult Index()
    {
      List<Monster> monster = db.Monsters.ToList();
      return View(monster);
    }

    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Monster monster = db.Monsters.Find(id);
      if (monster == null)
      {
        return HttpNotFound();
      }
      return View(monster);
    }

    public ActionResult _Details(int? id)
    {
      if (id == null)
      {
        return new EmptyResult();
      }
      Monster monster = db.Monsters.Find(id);
      if (monster == null)
      {
        return new EmptyResult();
      }
      return View(monster);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}