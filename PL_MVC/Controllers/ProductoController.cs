using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        //[HttpPost]
        //public ActionResult GetAll(ML.Producto producto)
        //{
        //    ML.Result resultDepartamento = BL.Departamento.GetAllEF();
        //    producto.Departamento.Departamentos = resultDepartamento.Objects;
        //    ML.Result result = BL.Producto.ProductoGetByIdDepartamento(producto.Departamento.IdDepartamento);//ProductoGetByIdDepartamento    
        //    producto.Productos = result.Objects;
        //    producto.Departamento = new ML.Departamento();
            
        //    return View(producto);
        //}
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {

            //// GETALL
            //ML.Result result = BL.Producto.GetAllEF();
            //ML.Producto producto = new ML.Producto();
            //ML.Result resultDepartamento = BL.Departamento.GetAllEF();
            //ML.Result resultProveedor = BL.Proveedor.GetAllEF();
            //ML.Result resultAreas = BL.Area.GetAllEF();

            //producto.Departamento = new ML.Departamento();
            //producto.Proveedor = new ML.Proveedor();
            //producto.Departamento.Area = new ML.Area();

            ML.Result resultProducto = new ML.Result();
            resultProducto.Objects = new List<Object>();
            ML.Producto producto = new ML.Producto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1040/api/");

                var responseTask = client.GetAsync("producto");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());

                        resultProducto.Objects.Add(resultItemList);
                        producto.Productos = resultProducto.Objects;
                    }

                }
            }
            return View(producto);

        }

        [HttpGet]
        public ActionResult Form(int? IdProducto) //Add { Id null } //Update {Id > 0 }
        {
            ML.Producto producto = new ML.Producto();

            ML.Result resultDepartamento = BL.Departamento.GetAllEF();
            ML.Result resultProveedor = BL.Proveedor.GetAllEF();
            ML.Result resultAreas = BL.Area.GetAllEF();
            

            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();
            producto.Proveedor = new ML.Proveedor();
  
            if (resultDepartamento.Correct && resultProveedor.Correct)
            {
                
                producto.Departamento.Area.Areas = resultAreas.Objects;     
                producto.Proveedor.Proveedores = resultProveedor.Objects;
                producto.Departamento.Departamentos = resultDepartamento.Objects; 


                if (IdProducto == null)
                {
                    
                    return View(producto);
                }
                else
                {
                    ////GetById
                    //ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
                    //var resultProducto = client.GetById(IdProducto.Value);
                    ////ML.Result result = BL.Producto.GetByIdEF(IdProducto.Value);
                    //// Cambiar a result

                    ML.Result result = new ML.Result();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:1040/api/");

                        //HTTP DELETE



                        var responseTask = client.GetAsync("producto/" + IdProducto);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Producto resultItemList = new ML.Producto();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;
                        }


                    }

                    if (result.Correct)
                    {

                        producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                        producto.Nombre = ((ML.Producto)result.Object).Nombre;
                        producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                        producto.Stock = ((ML.Producto)result.Object).Stock;
                        producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;                 
                        producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                        if (producto.Departamento.Area.IdArea > 0)
                        {
                            resultDepartamento = BL.Departamento.GetByIdArea(producto.Departamento.Area.IdArea);
                            producto.Departamento.Departamentos = resultDepartamento.Objects; 
                        }
                        else
                        {
                            producto.Departamento.Departamentos = resultDepartamento.Objects;           
                        }
                        //BL.Departamento.GetByIdArea(producto.Departamento.Area.IdArea);
                        producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                        
                        producto.Descripcion = ((ML.Producto)result.Object).Descripcion;
                        producto.Imagen = ((ML.Producto)result.Object).Imagen;

                        return View(producto);
                        /////////////////////////////////////////////////////////////////////77
                    }


                    else
                    {
                        ViewBag.Message = "Ocurrió un error al obtener la información"; //+ result.ErrorMessage;
                        return PartialView("ValidationModal");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información " + resultDepartamento.ErrorMessage +resultProveedor.ErrorMessage;
                return PartialView("ValidationModal");
            }


        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImagenData"];
                if (file.ContentLength > 0)
                {
                    producto.Imagen = ConvertToBytes(file);
                }
                if (producto.IdProducto == 0)
                {
                    //ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
                    //var resultProducto = client.Add(producto);
                    
                    ////result = BL.Producto.AddEF(producto);

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:1040/api/");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Producto>("producto", producto);
                        postTask.Wait();

                        var resultAPI = postTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Producto agregado correctamente";
                            result.Correct = true;
                        }
                    }

                    if (result.Correct)
                    {
                        ViewBag.Message = "Producto agregado correctamente";
                        result.Correct = true;
                    }
                }
                else
                {
                    //result = BL.Producto.UpdateEF(producto);
                    //if (result.Correct)
                    //{
                    //    ViewBag.Message = "Producto actualizado correctamente";
                    //}
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:1040/api/");

                        //HTTP PUT

                        var putTask = client.PutAsJsonAsync<ML.Producto>("producto", producto);
                        putTask.Wait();

                        var resultAPI = putTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Producto actualizado correctamente";
                            result.Correct = true;
                        }
                    }
                }

                if (!result.Correct)
                {
                    ViewBag.Message = "No se pudo agregar correctamente el Producto " + result.ErrorMessage;
                }

            }
            //else
            //{
            //    return RedirectToAction("Form",producto);
            //}
           
            return PartialView("ValidationModal");

        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            ////ML.Producto producto = new ML.Producto();
            ////producto.IdProducto = IdProducto;

            ////ML.Result result = BL.Producto.DeleteEF(IdProducto);


            //ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
            //var resultProducto = client.Delete(IdProducto);

            ML.Result result = new ML.Result();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1040/api/");

                //HTTP DELETE

                var deleteTask = client.DeleteAsync("producto/" + IdProducto);
                deleteTask.Wait();

                var resultAPI = deleteTask.Result;
                if (resultAPI.IsSuccessStatusCode)
                {
                    result.Correct = true;
                }


            }

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al eliminar el producto "; //+ result.ErrorMessage;
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

        //IMAGEN
        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }
     
  

	
    }
}