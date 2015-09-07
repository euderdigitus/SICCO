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
    public class ConcessionariaController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: /Concessionaria/
        public ActionResult Index()
        {
            return View(db.tb_empresa.ToList());
        }

        // GET: /Concessionaria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        // GET: /Concessionaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Concessionaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nomeFantasia,cnpj,status")] tb_empresa tb_empresa)
        {
            if (ModelState.IsValid)
            {
                tb_empresa.status = "Ativo";
                db.tb_empresa.Add(tb_empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_empresa);
        }

        // GET: /Concessionaria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        // POST: /Concessionaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nomeFantasia,cnpj,status")] tb_empresa tb_empresa)
        {
            try
            {
            if (ModelState.IsValid)
            {
                TempData["mensagemCerto"] = "Dados alterados com sucesso! ";   
                db.Entry(tb_empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/"+tb_empresa.id);
            }
            return View(tb_empresa);
             }
            catch(DataException)
            {
                TempData["mensagemErro"] = "Não foi possível atualizar, tente novamente mais tarde!";        
                return RedirectToAction("Edit/"+tb_empresa.id);
            }
        }

        // GET: /Concessionaria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empresa tb_empresa = db.tb_empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        // POST: /Concessionaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tb_empresa tb_empresa = db.tb_empresa.Find(id);
                db.tb_empresa.Remove(tb_empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["mensagemErro"] = "Esta CONCESSIONÁRIA não pode ser removida, pois já possui varios vinculos, deixe-a Inativa!";
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
