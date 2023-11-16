using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreBookOnline.Models;

namespace StoreBookOnline.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(string name = "Release", int page = 1)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            List<Sach> sach;
            //if (name == "")
            //{
            //    List<SACH> trend = db.SACHes.Where(row => row.CHITIET.Contains("Trending")).ToList();
            //    return View(trend);
            //}
            sach = db.Saches.Where(row => row.ChiTiet.Contains(name)).ToList();

            //pages
            var count = sach.Count();
            int pages = 3;
            int recordpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sach.Count) / Convert.ToDouble(pages)));
            int skippage = (page - 1) * pages;
            ViewBag.Page = page;
            ViewBag.Pages = pages;
            ViewBag.Name = name;
            //sach = sach.Skip(skippage).Take(recordpage).ToList();

            ViewBag.Section = count / 3;

            return View(sach);
        }


        public ActionResult Categories(string name = "all", int page = 1)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            List<Sach> sach;
            if (name == "all")
            {
                sach = db.Saches.ToList();
            }
            else
            {
                sach = db.Saches.Where(row => row.TheLoaiSach.TenLoai.Contains(name)).ToList();
            }
            var count = sach.Count();
            int pages = 5;
            int recordpages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sach.Count) / Convert.ToDouble(pages)));
            int pagesSkip = (page - 1) * pages;
            ViewBag.Page = page;
            ViewBag.RecordPage = recordpages;
            ViewBag.Name = name;
            //sach = sach.Skip(pagesSkip).Take(pages).ToList();

            //if (count % 5 == 0)
            //{
                
            //}
            ViewBag.Section = count / 5;

            return View(sach);
        }

        public ActionResult Special()
        {
            BookStoreDbContext db = new BookStoreDbContext();
            List<Sach> special = db.Saches.Where(row => row.ChiTiet.Contains("Special")).ToList();
            return View(special);
        }

        [HttpPost]
        public ActionResult AddCart(GioHang s)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            Sach sa = db.Saches.Where(row => row.MaSach == s.MaSach).FirstOrDefault();
            bool count = db.GioHangs.Select(row => row.MaSach == s.MaSach).FirstOrDefault();
            //List<GioHang> giohang = db.GioHangs.ToList();
            //GioHang giohang;
            if (count == false)
            {
                s.ThanhTien = Convert.ToInt32(s.SoLuong * sa.DonGia);
                var result = new { message = "Success" };
                db.GioHangs.Add(s);
                db.SaveChanges();
                return Json(result);
            }
            else
            {
                var error = new { message = "Error" };
                return Json(error);
            }
            
        }
    }
}
