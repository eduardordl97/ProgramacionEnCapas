using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using System.Net;  
using System.Threading;  
using System.Web.Http;  
using SL_WebAPI.Models;


namespace SL_WebAPI.Controllers
{
        /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }


        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate([FromBody]ML.Usuario usuario)
        {
            var password = usuario.Password;
            if (usuario == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            //TODO: Validate credentials Correctly, this code is only for demo !!
            ML.Result result = BL.Usuario.GetByIdEF(usuario.Username);

            usuario = (ML.Usuario)result.Object;

            if(result.Correct)
            {
                if (usuario.Password == password)
                {
                    usuario.Token = TokenGenerator.GenerateTokenJwt(usuario.Username);
                    
                    return Ok(usuario);
                }
                else
                {
                    result.ErrorMessage = "el Password es incorrecto";
                    return Content(HttpStatusCode.Unauthorized, result); //401
                }
            }
            else
            {
                result.ErrorMessage = "El usuario no existe en la base de datos";
                return Content(HttpStatusCode.Unauthorized, result); //401
            }
            
        }
    }
}
