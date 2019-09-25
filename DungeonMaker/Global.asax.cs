using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;


namespace DungeonMaker
{
  public class MvcApplication : System.Web.HttpApplication
  {
    public static Models.DataJson_Dungeon DungeonJsonData { get; set; }
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      string dungeonConfigFile = System.IO.File.ReadAllText(Server.MapPath(@"~/Content/Files/Data.json"));
      DungeonJsonData = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.DataJson_Dungeon>(dungeonConfigFile);
    }
  }
}
