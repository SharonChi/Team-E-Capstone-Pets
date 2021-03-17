﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test;

namespace test.Controllers
{
    public class TVisitReasonsController : Controller
    {
        private capstoneEntities db = new capstoneEntities();

        // GET: TVisitReasons
        public ActionResult Index()
        {
            return View(db.TVisitReasons.ToList());
        }

        // GET: TVisitReasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVisitReason tVisitReason = db.TVisitReasons.Find(id);
            if (tVisitReason == null)
            {
                return HttpNotFound();
            }
            return View(tVisitReason);
        }

        // GET: TVisitReasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVisitReasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intVisitReasonID,strVisitReason")] TVisitReason tVisitReason)
        {
            if (ModelState.IsValid)
            {
                db.TVisitReasons.Add(tVisitReason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tVisitReason);
        }

        // GET: TVisitReasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVisitReason tVisitReason = db.TVisitReasons.Find(id);
            if (tVisitReason == null)
            {
                return HttpNotFound();
            }
            return View(tVisitReason);
        }

        // POST: TVisitReasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intVisitReasonID,strVisitReason")] TVisitReason tVisitReason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVisitReason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tVisitReason);
        }

        // GET: TVisitReasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVisitReason tVisitReason = db.TVisitReasons.Find(id);
            if (tVisitReason == null)
            {
                return HttpNotFound();
            }
            return View(tVisitReason);
        }

        // POST: TVisitReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVisitReason tVisitReason = db.TVisitReasons.Find(id);
            db.TVisitReasons.Remove(tVisitReason);
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