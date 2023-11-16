using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreBookOnline.Models;

namespace StoreBookOnline.Controllers
{
    public class CartController : Controller
    {
        BookStoreDbContext db;
        // GET: Cart
        public ActionResult Index()
        {
            db = new BookStoreDbContext();
            List<GioHang> gh = db.GioHangs.ToList();
            return View(gh);
        }

        public ActionResult Buy(HoaDon hd)
        {
            db = new BookStoreDbContext();
            db.HoaDons.Add(hd);
            db.SaveChanges();
            return Json("Success");
        }

        [HttpPost]
        public ActionResult Delete(GioHang gh)
        {
            db = new BookStoreDbContext();
            GioHang giohang = db.GioHangs.Where(row => row.MaSach == gh.MaSach).FirstOrDefault();
            db.GioHangs.Remove(giohang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}