using CuaHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHang.Controllers
{
    public class HangHoaController : Controller
    {
        // GET: HangHoa
        CuaHangEntities1 db = new CuaHangEntities1();
        public ActionResult Index(string txtSearch = "", int? loaiHangId = null)
        {
            ViewBag.LoaiHangList = new SelectList(db.LoaiHangs.ToList(), "MaLH", "TenLH");

            var hangHoas = db.HangHoas.AsQueryable();

            if (!string.IsNullOrEmpty(txtSearch))
            {
                hangHoas = hangHoas.Where(hh => hh.TenHH.Contains(txtSearch));
            }

            if (loaiHangId.HasValue)
            {
                hangHoas = hangHoas.Where(hh => hh.MaLH == loaiHangId);
            }

            return View(hangHoas.ToList());
        }


        public ActionResult ThanhToan()
        {
            Session["GioHang"] = null;
            TempData["Message"] = "Thanh toán thành công";
            return RedirectToAction("Index");
        }


        public ActionResult Mua(int id)
        {
            return View(db.HangHoas.Find(id));
        }

        public ActionResult GioHang(int id)
        {
            List<HangHoa> gioHang = Session["GioHang"] as List<HangHoa> ?? new List<HangHoa>();
            return View(db.HangHoas.Find(id));
        }


        public ActionResult XoaKhoiGioHang(int id)
        {
            List<HangHoa> gioHang = Session["GioHang"] as List<HangHoa> ?? new List<HangHoa>();
            var itemToRemove = gioHang.FirstOrDefault(h => h.MaHH == id);
            if (itemToRemove != null)
            {
                gioHang.Remove(itemToRemove);
            }
            Session["GioHang"] = gioHang;
            return RedirectToAction("GioHang");
        }






        public ActionResult Create()
        {
            ViewBag.MaLH = new SelectList(db.LoaiHangs.ToList(), "MaLH", "TenLH");
            return View();
        }
        [HttpPost]
        public ActionResult Create(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLH = new SelectList(db.LoaiHangs.ToList(), "MaLH", "TenLH", hangHoa.MaLH);
            return View(hangHoa);
        }

        public ActionResult Details(int id)
        {
            return View(db.HangHoas.Find(id));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.MaLH = new SelectList(db.LoaiHangs.ToList(), "MaLH", "TenLH");
            return View(db.HangHoas.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                HangHoa hh = db.HangHoas.Find(hangHoa.MaHH);
                hh.TenHH = hangHoa.TenHH;
                hh.MaLH = hangHoa.MaLH;
                hh.Gia = hangHoa.Gia;
                hh.SLTon = hangHoa.SLTon;
                hh.DonVi = hangHoa.DonVi;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLH = new SelectList(db.LoaiHangs.ToList(), "MaLH", "TenLH", hangHoa.MaLH);
            return View(hangHoa);
        }

        public ActionResult Delete(int id)
        {
            return View(db.HangHoas.Find(id));
        }
        public ActionResult ConfirmDelete(int id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}