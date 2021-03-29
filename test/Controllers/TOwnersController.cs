﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test;

namespace test.Controllers
{
    public class TOwnersController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();

        // GET: TOwners
        public ActionResult Index()
        {
            var tOwners = db.TOwners
                .Include(t => t.TState)
                .Include(t => t.TUser)
                .Include(t => t.TGender);
            return View(tOwners.ToList());
        }

        // GET: TOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOwner tOwner = db.TOwners.Find(id);
            if (tOwner == null)
            {
                return HttpNotFound();
            }
            return View(tOwner);
        }

        // GET: TOwners/Create
        public ActionResult Create()
        {
            ViewBag.intStateID = new SelectList(db.TStates, "intStateID", "strStateCode");
            ViewBag.intUserID = new SelectList(db.TUsers, "intUserID", "strUserName");
            ViewBag.intGenderID = new SelectList(db.TGenders, "intGenderID", "strGender");
            return View();
        }

        // POST: TOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intOwnerID,strFirstName,strLastName,intGenderID,strAddress,strCity,intStateID,strZip,strPhoneNumber,strEmail,strOwner2Name,strOwner2PhoneNumber,strOwner2Email,strNotes")] TOwner tOwner) {
            if (ModelState.IsValid) {
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@strFirstName", tOwner.strFirstName),
                    new SqlParameter("@strLastName", tOwner.strLastName),
                    new SqlParameter("@intGenderID", tOwner.intGenderID),
                    new SqlParameter("@strAddress", tOwner.strAddress),
                    new SqlParameter("@strCity", tOwner.strCity),
                    new SqlParameter("@intStateID", tOwner.intStateID),
                    new SqlParameter("@strZip", tOwner.strZip),
                    new SqlParameter("@strPhoneNumber", tOwner.strPhoneNumber),
                    new SqlParameter("@strEmail", tOwner.strEmail),
                    new SqlParameter("@strOwner2Name", tOwner.strOwner2Name),
                    new SqlParameter("@strOwner2PhoneNumber", tOwner.strOwner2PhoneNumber),
                    new SqlParameter("@strOwner2Email", tOwner.strOwner2Email),
                    new SqlParameter("@strNotes", tOwner.strNotes)
                };
                db.uspAddNewUser(tOwner.strEmail, tOwner.strZip, 1);
                var userID = db.TUsers.Max(u => u.intUserID);
                db.TOwners.Add(tOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.intStateID = new SelectList(db.TStates, "intStateID", "strStateCode", tOwner.intStateID);
            return View(tOwner);
        }

        // GET: TOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOwner tOwner = db.TOwners.Find(id);
            if (tOwner == null)
            {
                return HttpNotFound();
            }
            ViewBag.intStateID = new SelectList(db.TStates, "intStateID", "strStateCode", tOwner.intStateID);
            ViewBag.intUserID = new SelectList(db.TUsers, "intUserID", "strUserName", tOwner.intUserID);
            ViewBag.intGenderID = new SelectList(db.TGenders, "intGenderID", "strGender", tOwner.intGenderID);
            return View(tOwner);
        }

        // POST: TOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intOwnerID,strFirstName,strLastName,intGenderID,strAddress,strCity,intStateID,strZip,strPhoneNumber,strEmail,strOwner2Name,strOwner2PhoneNumber,strOwner2Email,strNotes,isActive,intUserID")] TOwner tOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.intStateID = new SelectList(db.TStates, "intStateID", "strStateCode", tOwner.intStateID);
            ViewBag.intUserID = new SelectList(db.TUsers, "intUserID", "strUserName", tOwner.intUserID);
            ViewBag.intGenderID = new SelectList(db.TGenders, "intGenderID", "strGender", tOwner.intGenderID);

            return View(tOwner);
        }

        // GET: TOwners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOwner tOwner = db.TOwners.Find(id);
            if (tOwner == null)
            {
                return HttpNotFound();
            }
            return View(tOwner);
        }

        // POST: TOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOwner tOwner = db.TOwners.Find(id);
            db.TOwners.Remove(tOwner);
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
