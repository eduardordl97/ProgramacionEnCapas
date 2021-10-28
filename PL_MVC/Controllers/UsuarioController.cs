using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Globalization;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
            
          
           
  
            

        }
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
           
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }

        [HttpGet]
        public ActionResult Form(string Username) //Add { Id null } //Update {Id > 0 }
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRoles = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();
            if (resultRoles.Correct)
            {
                usuario.Rol.Roles = resultRoles.Objects;

                if (Username == null)
                {
                    usuario.Action = "Add";
                    return View(usuario);
                }
                else
                {
                    //GetById
                    ML.Result result = BL.Usuario.GetByIdEF(Username);

                    if (result.Correct)
                    {
                        usuario = (ML.Usuario)result.Object;
                        usuario.Rol.Roles = resultRoles.Objects;
                        usuario.Action = "Update";

                        return View(usuario);

                    }


                    else
                    {
                        ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                        return PartialView("ValidationModal");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información " +  resultRoles.ErrorMessage;
                return PartialView("ValidationModal");
            }
           

        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();

            if (ModelState.IsValid)
            {
                if (usuario.Action == "Add")
                {
                    result = BL.Usuario.AddEF(usuario);


                    if (result.Correct)
                    {
                        ViewBag.Message = "Usuario agregado correctamente";
                    }
                }
                if(usuario.Action == "Update")
                {
                    result = BL.Usuario.UpdateEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Usuario actualizado correctamente";
                    }
                }

                if (!result.Correct)
                {
                    ViewBag.Message = "No se pudo agregar correctamente el Usuario " + result.ErrorMessage;
                }

            }
            else
            {
                ML.Result resultRoles = BL.Rol.GetAllEF();
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRoles.Objects;
                return View(usuario);
            }
            
            return PartialView("ValidationModal");

        }

        [HttpGet]
        public ActionResult UpdateStatus(string Username)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetByIdEF(Username);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                usuario.Status = (usuario.Status) ? false : true;
                ML.Result resultUpdate = BL.Usuario.UpdateEF(usuario);
                if (resultUpdate.Correct)
                {
                    ViewBag.Message = "Usuario actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al actualizar al Usuario " + resultUpdate.ErrorMessage;
                }
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información " + result.ErrorMessage;
            }
                               
            return PartialView("ValidationModal");
            
        }

        //[HttpPost]
        //public ActionResult UploadFile(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string _path = Path.Combine(Server.MapPath("../UploadedFiles"), _FileName);
        //            file.SaveAs(_path);

        //            return RedirectToAction("CargaMasiva", "Usuario", new { Path = _path });
        //        }
        //        else{
        //             return PartialView("ValidationModal");
        //        }
                
        //    }
        //    catch
        //    {
        //        return PartialView("ValidationModal");
        //    }
        //}

        public ActionResult CargaMasiva()
        {
            HttpPostedFileBase file = Request.Files["ArchivoTXT"];

            if(file.ContentLength > 0){
                var lines = new List<string>();
                using (StreamReader reader = new StreamReader(file.InputStream))
                {
                    string headerLine = reader.ReadLine();
                    string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                    while ((Line = reader.ReadLine()) != null)
                    {
                        
                        string[] datosUsuario = Line.Split('|');
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Username = datosUsuario[0];
                        usuario.Nombre = datosUsuario[1];
                        usuario.ApellidoPaterno = datosUsuario[2];           
                        usuario.ApellidoMaterno = datosUsuario[3];
                        usuario.FechaNacimiento = DateTime.ParseExact(datosUsuario[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        usuario.Email = datosUsuario[5];

                        usuario.Sexo = "Hombre";
                        usuario.Password = "pass";
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = 1;
                        usuario.Telefono = "5546374667";
                    
                    

                        ML.Result result = BL.Usuario.AddEF(usuario);
                        if (result.Correct)
                        {
                            ViewBag.Message = "Carga Masiva realizada correctamente";
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrió un error al añadir a los usuarios ";
                            var texto = "Hubo un error al añadir al usuario: "+usuario.Username+ " Error: "+result.ErrorMessage;
                            GenerarTXT(texto);
                        }

                        
                    }
                
        
                }
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al cargar el archivo ";
            }

            return PartialView("ValidationModal");
        }

        public ActionResult GenerarTXT(string texto)
        {
            string rutaCompleta = Server.MapPath("~/ErrorLog/Error.txt");
          

            using (StreamWriter mylogs = System.IO.File.AppendText(rutaCompleta))         //se crea el archivo
            {

                mylogs.WriteLine(texto);
                
                mylogs.Close();


            }
            return RedirectToAction("GetAll");

        }

    }
}