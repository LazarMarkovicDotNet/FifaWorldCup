﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FifaWorldCup.Models;

namespace FifaWorldCup.Controllers
{
    public class StadiumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stadium
        public ActionResult Index()
        {
            return View(db.Stadiums.ToList());
        }

        // GET: Stadium/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stadium stadium = db.Stadiums.Find(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View(stadium);
        }

        // GET: Stadium/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stadium/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Capacity,StadiumName")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                db.Stadiums.Add(stadium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stadium);
        }

        // GET: Stadium/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stadium stadium = db.Stadiums.Find(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View(stadium);
        }

        // POST: Stadium/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Capacity,StadiumName")] Stadium stadium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stadium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stadium);
        }

        // GET: Stadium/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stadium stadium = db.Stadiums.Find(id);
            if (stadium == null)
            {
                return HttpNotFound();
            }
            return View(stadium);
        }

        // POST: Stadium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stadium stadium = db.Stadiums.Find(id);
            db.Stadiums.Remove(stadium);
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
