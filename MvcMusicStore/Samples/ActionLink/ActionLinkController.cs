using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class ActionLinkController : Controller
    {
        //
        // GET: /Home/

        MusicStoreDb storeDB = new MusicStoreDb();

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(5);

            return View(albums);
        }

        public ActionResult DailyDeal()
        {
            var album = GetDailyDeal();
            return PartialView("_DailyDeal", album);
        }

		public ActionResult QuickSearch(string term)
		{
			// The JSON for autocomplete widget must return either value property or label property, or both the properties.
			var artists = GetArtists(term).Select(n => new { value = n.Name });
			return Json(artists, JsonRequestBehavior.AllowGet);
		}

		#region Helper methods

		private List<Artist> GetArtists(string searchString)
		{
			return storeDB.Artists
				.Where(a => a.Name.Contains(searchString))
				.ToList();
		}

        private Album GetDailyDeal()
        {
            return storeDB.Albums
                .OrderBy(a => a.Price)
                .First();
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

		#endregion
    }
}