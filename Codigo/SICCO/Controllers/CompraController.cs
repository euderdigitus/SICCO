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
    public class CompraController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        // GET: /Compra/
        public ActionResult Index()
        {
            var tb_veiculo = db.tb_veiculo.Include(t => t.tb_bem).Include(t => t.tb_cor).Include(t => t.tb_empresa).Include(t => t.tb_modelo);
            return View(tb_veiculo.ToList());
        }

        // GET: /Compra/Details/5
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

        // GET: /Compra/Create
        public ActionResult Create()
        {
            ViewBag.idCor = new SelectList(db.tb_cor, "id", "cor");
            ViewBag.idModelo = new SelectList(db.tb_modelo, "id", "descricao");
            return View();
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
