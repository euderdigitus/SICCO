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
    public class CombustivelController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: /Combustivel/
        public ActionResult Index()
        {
            return View(db.tb_tipocombustivel.ToList());
        }

        // GET: /Combustivel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipocombustivel tb_tipocombustivel = db.tb_tipocombustivel.Find(id);
            if (tb_tipocombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipocombustivel);
        }

        // GET: /Combustivel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Combustivel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,tipoCombustivel")] tb_tipocombustivel tb_tipocombustivel)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipocombustivel.Add(tb_tipocombustivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_tipocombustivel);
        }

        // GET: /Combustivel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipocombustivel tb_tipocombustivel = db.tb_tipocombustivel.Find(id);
            if (tb_tipocombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipocombustivel);
        }

        // POST: /Combustivel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,tipoCombustivel")] tb_tipocombustivel tb_tipocombustivel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensagemCerto"] = "Dados alterados com sucesso! ";        
                    db.Entry(tb_tipocombustivel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit/"+tb_tipocombustivel.id);
                }
                return View(tb_tipocombustivel);
            }
            catch(DataException)
            {
                TempData["mensagemErro"] = "Não foi possível atualizar, tente novamente mais tarde!";        
                return RedirectToAction("Edit/"+tb_tipocombustivel.id);
            }
        }

        // GET: /Combustivel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipocombustivel tb_tipocombustivel = db.tb_tipocombustivel.Find(id);
            if (tb_tipocombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipocombustivel);
        }
        // POST: /Combustivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try{
            tb_tipocombustivel tb_tipocombustivel = db.tb_tipocombustivel.Find(id);
            db.tb_tipocombustivel.Remove(tb_tipocombustivel);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["mensagemErro"] = "Este COMBUSTÍVEL não pode ser removida, pois está sendo utilizada em algum Modelo, altere o COMBUSTÍVEL do Modelo para poder remove-lo!";        
                return RedirectToAction("Delete/"+id);
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
