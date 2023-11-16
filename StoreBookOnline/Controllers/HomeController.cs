using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreBookOnline.Models;

namespace StoreBookOnline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BookStoreDbContext db = new BookStoreDbContext();
            List<Sach> sa = db.Saches.ToList();
            return View(sa);
        }
    }
}