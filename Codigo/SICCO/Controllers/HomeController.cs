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
    public class HomeController : Controller
    {
        private SICCO_Entities db = new SICCO_Entities();

        public ActionResult Index()
        {
            var tb_veiculo = db.tb_veiculo.Include(t => t.tb_bem).Include(t => t.tb_cor).Include(t => t.tb_empresa).Include(t => t.tb_modelo);
            ViewBag.idMarca = new SelectList(db.tb_marca, "id", "marca");
            ViewBag.idTipoCompustivel = new SelectList(db.tb_tipocombustivel, "id", "tipoCombustivel");
            return View(tb_veiculo.ToList());
        }

       
    }

}