using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public string Index()
        {
            return "In StoreController.Index();";
        }

        //
        // GET: /Store/Browse?genre=xxxx

        public string Browse(string genre)
        {
            string message = "In StoreController.Browse(); the genre is " + HttpUtility.HtmlEncode(genre);
            return message;
        }

        //
        // GET: /Store/Details

        public string Details()
        {
            return "In StoreController.Details();";
        }
    }
}
