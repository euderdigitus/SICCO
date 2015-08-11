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
    public class VeiculoController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: Veiculo
        public ActionResult Index()
        {
            var tb_veiculo = db.tb_veiculo.Include(t => t.tb_bem).Include(t => t.tb_cor).Include(t => t.tb_empresa).Include(t => t.tb_modelo);
            return View(tb_veiculo.ToList());
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            if (tb_veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            ViewBag.idBem = new SelectList(db.tb_bem, "id", "id");
            ViewBag.idCor = new SelectList(db.tb_cor, "id", "tipoCor");
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia");
            ViewBag.idModelo = new SelectList(db.tb_modelo, "id", "descricao");
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,placa,chassi,idConcessionaria,idModelo,idCor,idBem,idEmpresa,lote")] tb_veiculo tb_veiculo)
        {
            if (ModelState.IsValid)
            {
                db.tb_veiculo.Add(tb_veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBem = new SelectList(db.tb_bem, "id", "id", tb_veiculo.idBem);
            ViewBag.idCor = new SelectList(db.tb_cor, "id", "tipoCor", tb_veiculo.idCor);
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia", tb_veiculo.idEmpresa);
            ViewBag.idModelo = new SelectList(db.tb_modelo, "id", "tipoModelo", tb_veiculo.idModelo);
            return View(tb_veiculo);
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            if (tb_veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBem = new SelectList(db.tb_bem, "id", "id", tb_veiculo.idBem);
            ViewBag.idCor = new SelectList(db.tb_cor, "id", "tipoCor", tb_veiculo.idCor);
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia", tb_veiculo.idEmpresa);
            ViewBag.idModelo = new SelectList(db.tb_modelo, "id", "tipoModelo", tb_veiculo.idModelo);
            return View(tb_veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,placa,chassi,idConcessionaria,idModelo,idCor,idBem,idEmpresa,lote")] tb_veiculo tb_veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBem = new SelectList(db.tb_bem, "id", "id", tb_veiculo.idBem);
            ViewBag.idCor = new SelectList(db.tb_cor, "id", "tipoCor", tb_veiculo.idCor);
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia", tb_veiculo.idEmpresa);
            ViewBag.idModelo = new SelectList(db.tb_modelo, "id", "tipoModelo", tb_veiculo.idModelo);
            return View(tb_veiculo);
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            if (tb_veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tb_veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_veiculo tb_veiculo = db.tb_veiculo.Find(id);
            db.tb_veiculo.Remove(tb_veiculo);
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
