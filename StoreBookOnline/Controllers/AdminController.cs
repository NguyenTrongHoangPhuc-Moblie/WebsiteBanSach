using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreBookOnline.Models;

namespace StoreBookOnline.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            BookStoreDbContext db = new BookStoreDbContext();
            //List<Sach> sach = db.Saches.ToList();
            List<Sach> s = db.Saches.ToList();
            ViewBag.Cate = db.TheLoaiSaches.ToList();
            ViewBag.Detail = db.Saches.Select(row => row.ChiTiet).Distinct().ToList();
            return View(s);
        }

        [HttpPost]
        public ActionResult Add(Sach s)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            db.Saches.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int MaSach)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            Sach s = db.Saches.Where(row => row.MaSach == MaSach).FirstOrDefault();
            ViewBag.Cate = db.TheLoaiSaches.ToList();
            ViewBag.Special = db.Saches.Select(row => row.ChiTiet).Distinct().ToList();
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Sach sach)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            Sach s = db.Saches.Where(row => row.MaSach == sach.MaSach).FirstOrDefault();
            TheLoaiSach tl = db.TheLoaiSaches.Where(row => row.MaLoai == sach.TheLoaiSach_MaLoai).FirstOrDefault();
            //Update
            s.TenSach = sach.TenSach;
            s.Anh = "/Images/"+ tl.TenLoai + "s/" + sach.Anh;
            s.TacGia = sach.TacGia;
            s.SoLuongTon = sach.SoLuongTon;
            s.DonGia = sach.DonGia;
            s.ChiTiet = sach.ChiTiet;
            s.TheLoaiSach_MaLoai = sach.TheLoaiSach_MaLoai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int MaSach)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            Sach sach = db.Saches.Where(row => row.MaSach == MaSach).FirstOrDefault();
            return View(sach);
        }

        [HttpPost]
        public ActionResult Delete(Sach sach)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            Sach s = db.Saches.Where(row => row.MaSach == sach.MaSach).FirstOrDefault();
            db.Saches.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}