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
    [Authorize]
    public class ModeloController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: /Modelo/
        public ActionResult Index()
        {
            var tb_modelo = db.tb_modelo.Include(t => t.tb_marca).Include(t => t.tb_tipocombustivel);
            return View(tb_modelo.ToList());
        }

        // GET: /Modelo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_modelo tb_modelo = db.tb_modelo.Find(id);
            if (tb_modelo == null)
            {
                return HttpNotFound();
            }
            return View(tb_modelo);
        }

        // GET: /Modelo/Create
        public ActionResult Create()
        {
            ViewBag.idMarca = new SelectList(db.tb_marca, "id", "marca");
            ViewBag.idTipoCompustivel = new SelectList(db.tb_tipocombustivel, "id", "tipoCombustivel");
            return View();
        }

        // POST: /Modelo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,categoiaModelo,tipoModelo,combutivel,descricao,anoModelo,idMarca,idTipoCompustivel")] tb_modelo tb_modelo)
        {
            if (ModelState.IsValid)
            {
                db.tb_modelo.Add(tb_modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMarca = new SelectList(db.tb_marca, "id", "marca", tb_modelo.idMarca);
            ViewBag.idTipoCompustivel = new SelectList(db.tb_tipocombustivel, "id", "tipoCombustivel", tb_modelo.idTipoCompustivel);
            return View(tb_modelo);
        }

        // GET: /Modelo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_modelo tb_modelo = db.tb_modelo.Find(id);
            if (tb_modelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMarca = new SelectList(db.tb_marca, "id", "marca", tb_modelo.idMarca);
            ViewBag.idTipoCompustivel = new SelectList(db.tb_tipocombustivel, "id", "tipoCombustivel", tb_modelo.idTipoCompustivel);
            return View(tb_modelo);
        }

        // POST: /Modelo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,categoiaModelo,tipoModelo,combutivel,descricao,anoModelo,idMarca,idTipoCompustivel")] tb_modelo tb_modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tb_modelo).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["mensagemCerto"] = "Dados alterados com sucesso!";
                    return RedirectToAction("Edit/" + tb_modelo.id);
                }
                ViewBag.idMarca = new SelectList(db.tb_marca, "id", "marca", tb_modelo.idMarca);
                ViewBag.idTipoCompustivel = new SelectList(db.tb_tipocombustivel, "id", "tipoCombustivel", tb_modelo.idTipoCompustivel);
                return View(tb_modelo);
            }
            catch(DataException)
            {
                return RedirectToAction("Edit/" + tb_modelo.id);
            }
        }

        // GET: /Modelo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_modelo tb_modelo = db.tb_modelo.Find(id);
            if (tb_modelo == null)
            {
                return HttpNotFound();
            }
            return View(tb_modelo);
        }

        // POST: /Modelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tb_modelo tb_modelo = db.tb_modelo.Find(id);
                db.tb_modelo.Remove(tb_modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["mensagemErro"] = "Este MODELO não pode ser removid, pois está sendo utilizado em algum veículo, altere o MODELO do veíclo para poder remove-lo!";
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
