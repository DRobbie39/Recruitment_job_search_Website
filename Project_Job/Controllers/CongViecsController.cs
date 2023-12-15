using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project_Job.Models;

namespace Project_Job.Controllers
{
    public class CongViecsController : Controller
    {
        private QL_TuyenDung_TVLEntities db = new QL_TuyenDung_TVLEntities();

        // GET: CongViecs
        public ActionResult Index( int? page)
        {
            if (page == null) page = 1;
            // Check xem page đã được gán giá trị hay chưa

            var congViecs = db.CongViecs.Include(c => c.LoaiViec).OrderBy (c => c.MaCongViec);
            int pageSize = 1;
            // số item có trong 1 trang

            int pageNumber = (page ?? 1);
            return View(congViecs.ToPagedList(pageNumber,pageSize));
        }

        // GET: CongViecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongViec congViec = db.CongViecs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            return View(congViec);
        }

        // GET: CongViecs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiViec = new SelectList(db.LoaiViecs, "MaLoaiViec", "TenLoaiViec");
            return View();
        }

        // POST: CongViecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCongViec,TenCongViec,MucLuong,MoTa,MaLoaiViec")] CongViec congViec)
        {
            if (ModelState.IsValid)
            {
                db.CongViecs.Add(congViec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiViec = new SelectList(db.LoaiViecs, "MaLoaiViec", "TenLoaiViec", congViec.MaLoaiViec);
            return View(congViec);
        }

        // GET: CongViecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongViec congViec = db.CongViecs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiViec = new SelectList(db.LoaiViecs, "MaLoaiViec", "TenLoaiViec", congViec.MaLoaiViec);
            return View(congViec);
        }

        // POST: CongViecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCongViec,TenCongViec,MucLuong,MoTa,MaLoaiViec")] CongViec congViec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congViec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiViec = new SelectList(db.LoaiViecs, "MaLoaiViec", "TenLoaiViec", congViec.MaLoaiViec);
            return View(congViec);
        }

        // GET: CongViecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongViec congViec = db.CongViecs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            return View(congViec);
        }

        // POST: CongViecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CongViec congViec = db.CongViecs.Find(id);
            db.CongViecs.Remove(congViec);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
