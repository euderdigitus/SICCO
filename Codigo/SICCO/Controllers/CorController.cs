using System;
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
    [Authorize(Roles = "master")]
    public class CorController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: /Cor/
        public ActionResult Index()
        {
            return View(db.tb_cor.ToList());
        }

        // GET: /Cor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cor tb_cor = db.tb_cor.Find(id);
            if (tb_cor == null)
            {
                return HttpNotFound();
            }
            return View(tb_cor);
        }

        // GET: /Cor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoCor,cor")] tb_cor tb_cor)
        {
            if (ModelState.IsValid)
            {
                db.tb_cor.Add(tb_cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_cor);
        }

        // GET: /Cor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cor tb_cor = db.tb_cor.Find(id);
            if (tb_cor == null)
            {
                return HttpNotFound();
            }
            return View(tb_cor);
        }

        // POST: /Cor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipoCor,cor")] tb_cor tb_cor)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    db.Entry(tb_cor).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["mensagemCerto"] = "Dados alterados com sucesso!";
                    return RedirectToAction("Edit/" + tb_cor.id);
                }
                return View(tb_cor);
            }
            catch (DataException)
            {
                return RedirectToAction("Edit/" + tb_cor.id);
            }
        }

        // GET: /Cor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cor tb_cor = db.tb_cor.Find(id);
            if (tb_cor == null)
            {
                return HttpNotFound();
            }
            return View(tb_cor);
        }

        // POST: /Cor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tb_cor tb_cor = db.tb_cor.Find(id);
                db.tb_cor.Remove(tb_cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["mensagemErro"] = "Esta COR não pode ser removida, pois está sendo utilizada em algum veículo, altere a COR do veículo para poder remove-la!";
                return RedirectToAction("Delete/" + id);
            }
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
