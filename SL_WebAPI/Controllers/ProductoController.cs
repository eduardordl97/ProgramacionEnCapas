using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        [Route("api/producto")]
        [HttpGet]
        public IHttpActionResult Get()
        {

            ML.Result result = BL.Producto.GetAllEF();


            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        //GetbyID

        [Route("api/producto/{IdProducto}")] //Enviar parámetros ->IdProducto
        [HttpGet]
        public IHttpActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetByIdEF(IdProducto);


            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        // Add: api/Producto
        [Route("api/producto")] //Enviar parámetros desde el body
        [HttpPost]
        public IHttpActionResult Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddEF(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

   

        // PUT: api/Producto/5
        [Route("api/Producto")] //Enviar parámetros desde el body
        [HttpPut]
        public IHttpActionResult Update(ML.Producto producto)
        {

            ML.Result result = BL.Producto.UpdateEF(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE: api/Producto/5
        [Route("api/producto/{IdProducto}")] //Enviar parámetros ->IdMateria
        [HttpDelete]
        public IHttpActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteEF(IdProducto);



            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
