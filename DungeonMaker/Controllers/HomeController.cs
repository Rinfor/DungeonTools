using System.Web.Mvc;

namespace DungeonMaker.Controllers
{
  public class HomeController : Controller
  {
  // GET: Home
    public ActionResult Index()
    {
      return View();
    }
  }
}