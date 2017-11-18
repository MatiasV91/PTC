using PTCData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductosViewModel vm = new ProductosViewModel();
            vm.PedidoMgr();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ProductosViewModel vm)
        {
            vm.EsValido = ModelState.IsValid;
            vm.PedidoMgr();

            if (vm.EsValido)
            {
                ModelState.Clear();
            }
            else
            {
                foreach(KeyValuePair<string,string> error in vm.ErroresValidacion)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
            }
            return View(vm);
        }


    }
}