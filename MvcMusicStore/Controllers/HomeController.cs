﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index(string UserName)
		{
			ViewBag.UserName = UserName;

			return View();
		}

        public ActionResult About()
        {
            return View();
        }
    }
}
