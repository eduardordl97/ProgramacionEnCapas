using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaController : Controller
    {
        [HttpPost]
        public ActionResult ProductoGetAll(ML.Producto producto)
        {
            
            ML.Result resultDepartamento = BL.Departamento.GetByIdArea(producto.Departamento.Area.IdArea);       
            
            ML.Result resultAreas = BL.Area.GetAllEF();
            
            ML.Result result = BL.Producto.ProductoGetByIdDepartamento(producto.Departamento.IdDepartamento);//ProductoGetByIdDepartamento    
    

            if (result.Correct)
            {
                producto.Departamento.Departamentos = resultDepartamento.Objects;
                producto.Departamento.Area.Areas = resultAreas.Objects;
                producto.Productos = result.Objects;

                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
            
        }
        // GET: Venta
        public ActionResult ProductoGetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();
            ML.Producto producto = new ML.Producto();
            ML.Result resultDepartamento = BL.Departamento.GetAllEF();
            ML.Result resultProveedor = BL.Proveedor.GetAllEF();
            ML.Result resultAreas = BL.Area.GetAllEF();

            //Instancias
            producto.Departamento = new ML.Departamento();
            producto.Proveedor = new ML.Proveedor();
            producto.Departamento.Area = new ML.Area();

            if (result.Correct)
            {
                
                producto.Departamento.Area.Areas = resultAreas.Objects;
                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }

 
        public JsonResult GetDepartamento(int IdArea)
        {
            ML.Departamento depto = new ML.Departamento();
            depto.IdDepartamento = 0;
            depto.Nombre = "Seleccione una opción";

            var result = BL.Departamento.GetByIdArea(IdArea);
            result.Objects.Insert(0, depto);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
   
        
        public ActionResult Carrito(int? IdProducto)
        {
            ML.Result result = new ML.Result();
            ML.Venta venta = new ML.Venta();

            if (IdProducto != null)
            {
                if (Session["Carrito"] == null)
                {

                    ML.VentaProducto ventaProducto = new ML.VentaProducto();

                    ventaProducto.Producto = new ML.Producto();
                    ventaProducto.Producto.IdProducto = IdProducto.Value;
                    ventaProducto.Cantidad = 1;
                    ML.Result resultProducto = BL.Producto.GetByIdEF(ventaProducto.Producto.IdProducto);
                    if (resultProducto.Correct == true)
                    {

                        ventaProducto.Producto.Nombre = ((ML.Producto)resultProducto.Object).Nombre;
                        ventaProducto.Producto.PrecioUnitario = ((ML.Producto)resultProducto.Object).PrecioUnitario;
                        ventaProducto.Producto.Stock = ((ML.Producto)resultProducto.Object).Stock;
                        ventaProducto.Producto.Imagen = ((ML.Producto)resultProducto.Object).Imagen;
                        result.Objects = new List<object>();
                        result.Objects.Add(ventaProducto);

                    }
                    Session["Carrito"] = result.Objects;


                }
                else
                {
                    bool Existe = false;
                    int index = 0;
                    result.Objects = (List<object>)Session["Carrito"];
                    foreach (ML.VentaProducto ventaProducto in result.Objects)
                    {

                        if (ventaProducto.Producto.IdProducto == IdProducto)
                        {
                            Existe = true;
                            index = result.Objects.IndexOf(ventaProducto);
                        }

                    }

                    if (Existe == true)
                    {

                        foreach (ML.VentaProducto ventaProducto in result.Objects)
                        {
                            if (result.Objects.IndexOf(ventaProducto) == index)
                            {
                                ventaProducto.Cantidad += 1;

                            }
                        }

                    }
                    else
                    {

                        ML.VentaProducto ventaproducto = new ML.VentaProducto();
                        ventaproducto.Producto = new ML.Producto();
                        ventaproducto.Producto.IdProducto = IdProducto.Value;
                        ventaproducto.Cantidad = 1;
                        ML.Result resultProducto = BL.Producto.GetByIdEF(ventaproducto.Producto.IdProducto);
                        ventaproducto.Venta = new ML.Venta();
                        ventaproducto.Venta.Total += ((ML.Producto)resultProducto.Object).PrecioUnitario * ventaproducto.Cantidad;
                        if (resultProducto.Correct == true)
                        {
                            ventaproducto.Producto.Nombre = ((ML.Producto)resultProducto.Object).Nombre;
                            ventaproducto.Producto.PrecioUnitario = ((ML.Producto)resultProducto.Object).PrecioUnitario;
                            ventaproducto.Producto.Stock = ((ML.Producto)resultProducto.Object).Stock;
                            ventaproducto.Producto.Imagen = ((ML.Producto)resultProducto.Object).Imagen;
                            result.Objects.Add(ventaproducto);

                        }
                    }

                }
            }
            else
            {
                result.Objects = (List<object>)Session["Carrito"];
            }
            

            Session["Carrito"] = result.Objects;
            return View(result);   
            
        }

        public ActionResult Mas(int? IdProducto)
        {

            ML.Result result = new ML.Result();
            result.Objects = (List<object>)Session["Carrito"];
            foreach (ML.VentaProducto ventaProducto in result.Objects)
            {
                if (ventaProducto.Producto.IdProducto == IdProducto)
                {
                    ventaProducto.Cantidad += 1;


                }
            }

            Session["Carrito"] = result.Objects;
            return View("Carrito", result);

        }

        public ActionResult Menos(int? IdProducto)
        {

            ML.Result result = new ML.Result();
            result.Objects = (List<object>)Session["Carrito"];


            foreach (ML.VentaProducto ventaProducto in result.Objects)
            {
                if (ventaProducto.Producto.IdProducto == IdProducto)
                {
                    ventaProducto.Cantidad -= 1;

                      
                }
            }


            Session["Carrito"] = result.Objects;
            return View("Carrito", result);

        }

        public ActionResult DeleteCarrito(int? IdProducto)
        {


            ML.Result result = new ML.Result();
            result.Objects = (List<object>)Session["Carrito"];
            int index = 0;
            foreach (ML.VentaProducto ventaProducto in result.Objects)
            {
                if (ventaProducto.Producto.IdProducto == IdProducto)
                {
                    index = result.Objects.IndexOf(ventaProducto);

                }
            }
            result.Objects.RemoveAt(index);
            Session["Carrito"] = result.Objects;
            return View("Carrito", result);


        }

        public decimal GetTotal(List<object> objects)
        {
            decimal Total = 0;
            foreach(ML.VentaProducto ventaProducto in objects)
            {
                Total += ventaProducto.Cantidad * ventaProducto.Producto.PrecioUnitario;
            }

            return Total;
        }

        public ActionResult Procesar()
        {


            ML.Result result = new ML.Result();
            result.Objects = (List<object>)Session["Carrito"];
            ML.Venta venta = new ML.Venta();

            venta.Usuario = new ML.Usuario();
            venta.Usuario.Username = "eduardordl97";
            venta.MetodoPago = new ML.MetodoPago();
            venta.MetodoPago.IdMetodoPago = 1;
            venta.Total = GetTotal(result.Objects);

            ML.Result resultVenta = BL.Venta.AddEF(venta, result.Objects);
            venta.IdVenta = ((ML.Venta)resultVenta.Object).IdVenta;


            return RedirectToAction("GetByIdVenta", "VentaProducto", new { IdVenta = venta.IdVenta });

        }

    
    }
}

