using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Net.Http;
namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            ML.Usuario login = new ML.Usuario();
            return View(login);
        }

        public ActionResult IniciarSesion()
        {
            ML.Usuario login = new ML.Usuario();
            return View(login);
        }
        [HttpPost]
        public ActionResult login(ML.Usuario usuario)
        {

            using (var client = new HttpClient())
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URL_API"];
                client.BaseAddress = new Uri(urlAPI);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ML.Usuario>("login/authenticate", usuario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var  usuarioResultAPI = result.Content.ReadAsAsync<ML.Usuario>();
                    usuarioResultAPI.Wait();

                    ML.Usuario usuarioAPI = usuarioResultAPI.Result;
                    //ML.Producto resultItemList = new ML.Producto();
                    //resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                    //result.Object = resultItemList;

                    if (usuarioAPI.Rol.Nombre == "Administrador")
                    {
                        Session["TipoUsuario"] = "Administrador";
                        return RedirectToAction("Index", "Home");
                    }
                    else if (usuarioAPI.Rol.Nombre == "Cliente")
                    {
                        Session["TipoUsuario"] = "Cliente";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["TipoUsuario"] = "Proveedor";
                        return RedirectToAction("IniciarSesion", "Login");
                    }
                }
                else
                {
                    var usuarioResultAPI = result.Content.ReadAsAsync<ML.Result>();
                    usuarioResultAPI.Wait();

                    ML.Result resultAPI = usuarioResultAPI.Result;
                    ViewBag.Error = resultAPI.ErrorMessage;
                    return View(usuario);

                }
            }

            /*EN VARIALE var, llamamos al metodo desde BL.Categoria.CategoriaAddEF(); */
            //var password = usuario.Password;
            //var username = usuario.Username;
            //var result = BL.Usuario.GetByIdEF(usuario.Username);
            //usuario = (ML.Usuario)result.Object;
       

            //if (result.Correct)
            //{
            //    if (usuario.Username == username && usuario.Password == password)
            //    {
            //        if (usuario.Rol.Nombre == "Administrador")
            //        {
            //            Session["TipoUsuario"] = "Administrador";
            //            return RedirectToAction("Index", "Home");
            //        }
            //        else if (usuario.Rol.Nombre == "Cliente")
            //        {
            //            Session["TipoUsuario"] = "Cliente";
            //            return RedirectToAction("Index", "Home");
            //        }
            //        else
            //        {
            //            Session["TipoUsuario"] = "Proveedor";
            //            return RedirectToAction("IniciarSesion", "Login");
            //        }
            //    }
            //    else
            //    {

            //        ViewBag.Message = "el Password es incorrecto";
            //        return PartialView("ValidationModal");
            //    }
                  
            //    //crear secion tipo usuario return view layoy si es sesion adm muestra vistas y si es us muestras otras vistas 

            //}
            //else
            //{


            //    ViewBag.Message = "El usuario no existe en la base de datos";
            //    return PartialView("ValidationModal");
            
            ////    if (usuario.Username == "eduardordl97")
            ////    {

            ////        Session["TipoUsuario"] = "Administrador";
            ////        return RedirectToAction("Index", "Home");

            ////    }
            ////    else
            ////    {
            ////        return RedirectToAction("IniciarSesion");
            ////    }



            //}
        }
    }
}