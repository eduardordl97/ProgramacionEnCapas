using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Script.Serialization;


namespace SL_WebAPI.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET: api/Departamento
        [Route("api/departamento")]
        [HttpGet]
        public IHttpActionResult Get()
        {
        

            ML.Result result = BL.Departamento.GetAllEF();
           

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET: api/Departamento/5

        [Route("api/departamento/{IdDepartamento}")] //Enviar parámetros ->IdMateria
        [HttpGet]
        public IHttpActionResult GetById(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento);

            //var serializer = new JavaScriptSerializer();
            //var serializedResult = serializer.Serialize(result);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST: api/Departamento
        [Route("api/departamento")] //Enviar parámetros desde el body
        [HttpPost]
        public IHttpActionResult Add(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        // PUT: api/Departamento/5
        [Route("api/departamento")] //Enviar parámetros desde el body
        [HttpPut]
        public IHttpActionResult Update(ML.Departamento departamento)
        {

            ML.Result result = BL.Departamento.UpdateEF(departamento);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE: api/Departamento/5
        [Route("api/departamento/{IdDepartamento}")] //Enviar parámetros ->IdMateria
        [HttpDelete]
        public IHttpActionResult Delete(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.DeleteEF(IdDepartamento);



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
