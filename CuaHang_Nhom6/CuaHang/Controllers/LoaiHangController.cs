using CuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHang.Controllers
{
    public class LoaiHangController : Controller
    {
        // GET: LoaiHang
        CuaHangEntities1 db = new CuaHangEntities1();
        public ActionResult Index(string txtSearch = "")
        {
            return View(db.LoaiHangs.Where(hh => hh.TenLH.Contains(txtSearch)));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiHang LoaiHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHangs.Add(LoaiHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(LoaiHang);
        }
        public ActionResult Details(int id)
        {
            return View(db.LoaiHangs.Find(id));
        }
        public ActionResult Edit(int id)
        {
            return View(db.LoaiHangs.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(LoaiHang LoaiHang)
        {
            if (ModelState.IsValid)
            {
                LoaiHang hh = db.LoaiHangs.Find(LoaiHang.MaLH);
                hh.TenLH = LoaiHang.TenLH;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(LoaiHang);
        }
        public ActionResult Delete(int id)
        {
            return View(db.LoaiHangs.Find(id));
        }
        public ActionResult ConfirmDelete(int id)
        {
            HangHoa hangHoa = db.HangHoas.FirstOrDefault(hh => hh.MaLH == id);
            if (hangHoa == null)
            {
                LoaiHang LoaiHang = db.LoaiHangs.Find(id);
                db.LoaiHangs.Remove(LoaiHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Có hàng hoá đang tham chiếu";
            return RedirectToAction("Delete", "LoaiHang", new { id = id });
        }
    }
}