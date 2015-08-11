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
    public class PessoaController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: Pessoa
        public ActionResult Index()
        {
            var tb_pessoa = db.tb_pessoa.Include(t => t.tb_tipopessoa);
            return View(tb_pessoa.ToList());
        }

        // GET: Pessoa/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
              if (tb_pessoa.sexo == "M")
            {
                tb_pessoa.sexo = "Masculino";
            }
            else
            {
                tb_pessoa.sexo = "Feminino";
            }
            return View(tb_pessoa);
        }

        // GET: Pessoa/Create
        
        public ActionResult Create()
        {
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia");
            ViewBag.idTipoPessoa = new SelectList(db.tb_tipopessoa, "id", "tipoPessoa");
           // ViewBag.idUsuario = new SelectList(db.tb_usuario, "id", "login");
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nome,sobreNome,cpfCnpj,rg,email,cidade,estado,cep,fone,celular,sexo,nascimento,endereco,idEmpresa,idTipoPessoa")] tb_pessoa tb_pessoa)
        {
            if (ModelState.IsValid)
            {
                tb_pessoa.idEmpresa = 1;
                db.tb_pessoa.Add(tb_pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia", tb_pessoa.idEmpresa);
            ViewBag.idTipoPessoa = new SelectList(db.tb_tipopessoa, "id", "tipoPessoa", tb_pessoa.idTipoPessoa);
            return View(tb_pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia", tb_pessoa.idEmpresa);
            ViewBag.idTipoPessoa = new SelectList(db.tb_tipopessoa, "id", "tipoPessoa", tb_pessoa.idTipoPessoa);
            return View(tb_pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,sobreNome,cpfCnpj,rg,email,cidade,estado,cep,fone,celular,sexo,nascimento,endereco,idUsuario,idEmpresa,idTipoPessoa")] tb_pessoa tb_pessoa)
        {
            try
            {
            if (ModelState.IsValid)
            {
                TempData["mensagemCerto"] = "Dados alterados com sucesso! ";
                tb_pessoa.idEmpresa = 1;
                db.Entry(tb_pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/"+tb_pessoa.id);
            }
            ViewBag.idEmpresa = new SelectList(db.tb_empresa, "id", "nomeFantasia", tb_pessoa.idEmpresa);
            ViewBag.idTipoPessoa = new SelectList(db.tb_tipopessoa, "id", "tipoPessoa", tb_pessoa.idTipoPessoa);
            return View(tb_pessoa);
            }
            catch(DataException)
            {
                TempData["mensagemErro"] = "Não foi possível atualizar, tente novamente mais tarde!";        
                return RedirectToAction("Edit/"+tb_pessoa.id);
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            if (tb_pessoa == null)
            {
                return HttpNotFound();
            }
            if (tb_pessoa.sexo == "M")
            {
                tb_pessoa.sexo = "Masculino";
            }
            else
            {
                tb_pessoa.sexo = "Feminino";
            }
            return View(tb_pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try{
            tb_pessoa tb_pessoa = db.tb_pessoa.Find(id);
            db.tb_pessoa.Remove(tb_pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                TempData["mensagemErro"] = "Esta PESSOA não pode ser removida, pois tem ligação com algum Veículo.";        
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
