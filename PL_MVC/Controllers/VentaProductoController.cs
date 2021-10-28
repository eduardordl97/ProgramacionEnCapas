using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaProductoController : Controller
    {
        // GET: VentaProducto
        public ActionResult GetByIdVenta(int IdVenta)
        {
            ML.VentaProducto ventaProducto = new ML.VentaProducto();
            ML.Result resultVentaProducto = BL.VentaProducto.GetByIdVenta(IdVenta);

            //Instancias
            

            if (resultVentaProducto.Correct)
            {
                ventaProducto.VentaProductos = resultVentaProducto.Objects;
                return View(ventaProducto);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + resultVentaProducto.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }
    }
}