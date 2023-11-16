using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreBookOnline.Models;

namespace StoreBookOnline
{
    public class AddCart
    {
        public AddCart(GioHang gh)
        {
            BookStoreDbContext db = new BookStoreDbContext();
            Sach sa = db.Saches.Where(row => row.MaSach == gh.MaSach).FirstOrDefault();
            gh.ThanhTien = Convert.ToInt32(gh.SoLuong * sa.DonGia);
        }
    }
}