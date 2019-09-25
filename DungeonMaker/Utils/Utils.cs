using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonMaker.Utils
{
  public static class Utils
  {
    //Creates a pretty htmlstring. The first part of the string in italic.
    public static HtmlString PrettyItalicFormat(string str, char separator = ':')
    {
      string ret = "<i>";
      int index = str.IndexOf(separator) + 1;
      ret += str.Insert(index, "</i>");
      return new HtmlString(ret);
    }
  }
}