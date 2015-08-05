﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SICCO.Database;

namespace SICCO.Controllers
{
    public class MarcaController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: /Marca/
        public ActionResult Index()
        {
            return View(db.tb_marca.ToList());
        }

        // GET: /Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = db.tb_marca.Find(id);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // GET: /Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Marca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,marca,tipo")] tb_marca tb_marca)
        {
            if (ModelState.IsValid)
            {
                db.tb_marca.Add(tb_marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_marca);
        }

        // GET: /Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = db.tb_marca.Find(id);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // POST: /Marca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,marca")] tb_marca tb_marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_marca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_marca);
        }

        // GET: /Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = db.tb_marca.Find(id);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // POST: /Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_marca tb_marca = db.tb_marca.Find(id);
            db.tb_marca.Remove(tb_marca);
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
