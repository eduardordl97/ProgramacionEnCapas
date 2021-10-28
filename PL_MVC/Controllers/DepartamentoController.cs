using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http; //

namespace PL_MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        [HttpGet]
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Departamento.GetAllEF();
            //ML.Departamento departamento = new ML.Departamento();
            //ML.Result resultArea = BL.Area.GetAllEF();

            //departamento.Area = new ML.Area();
            


            //if (result.Correct)
            //{
            //    departamento.Area.Areas = resultArea.Objects;
            //    departamento.Departamentos = result.Objects;
            //    return View(departamento);
            //}
            //else
            //{
            //    ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
            //    return PartialView("ValidationModal");
            //}

            
            ML.Result resultDepartamento = new ML.Result();
            resultDepartamento.Objects = new List<Object>();
            ML.Departamento departamento = new ML.Departamento();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1040/api/");

                var responseTask = client.GetAsync("departamento");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Departamento resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(resultItem.ToString());
         
                        resultDepartamento.Objects.Add(resultItemList);
                        departamento.Departamentos = resultDepartamento.Objects;
                    }
                  
                }
            }
            return View(departamento);
        }

        [HttpGet]
        public ActionResult Form(int? IdDepartamento) //Add { Id null } //Update {Id > 0 }
        {
            ML.Departamento departamento = new ML.Departamento();

            ML.Result resultArea = BL.Area.GetAllEF();

            if (resultArea.Correct)
            {
                departamento.Area = new ML.Area();
                departamento.Area.Areas = resultArea.Objects;
               
                if (IdDepartamento == null)
                {
                    return View(departamento);
                }
                else
                {
                    ////GetById
                    //ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
                    //var resultDepartamento = client.GetById(IdDepartamento.Value);
                    ////ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento.Value);

                    ML.Result result = new ML.Result();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:1040/api/");

                        //HTTP DELETE
                        


                        var responseTask = client.GetAsync("departamento/" + IdDepartamento);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Departamento resultItemList = new ML.Departamento();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;
                        }

                      
                    }

                    //Cambiar a result
                    if (result.Correct)
                    {
                        departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
                        departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
                       
                        departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;


                        return View(departamento);

                    }
                    //////

                    else
                    {
                        ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                        return PartialView("ValidationModal");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información de Area" + resultArea.ErrorMessage;
                return PartialView("ValidationModal");
            }


        }

        [HttpPost]
        public ActionResult Form(ML.Departamento departamento) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();

            if (departamento.IdDepartamento == 0)
            {
                //ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
                //var resultDepartamento = client.Add(departamento);
                ////result = BL.Departamento.AddEF(departamento);

                //if (resultDepartamento.Correct)
                //{
                //    ViewBag.Message = "Departamento agregado correctamente";
                //    result.Correct = true;
                //}


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1040/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Departamento>("departamento", departamento);
                    postTask.Wait();

                    var resultAPI = postTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Departamento agregado correctamente";
                        result.Correct = true;
                    }
                }

               
            }
            else
            {

                //result = BL.Departamento.UpdateEF(departamento);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "Departamento actualizado correctamente";
                //}

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1040/api/");

                    //HTTP PUT

                    var putTask = client.PutAsJsonAsync<ML.Departamento>("departamento", departamento);
                    putTask.Wait();

                    var resultAPI = putTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Departamento actualizado correctamente";
                        result.Correct = true;
                    }
                }

             
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el departamento " + result.ErrorMessage;
            }

            return PartialView("ValidationModal");

        }

        [HttpGet]
        public ActionResult Delete(int IdDepartamento)
        {
            //ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
            //var result = client.Delete(IdDepartamento);
            //ML.Result result = BL.Departamento.DeleteEF(IdDepartamento);
            ML.Result result = new ML.Result();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1040/api/");

                //HTTP DELETE

                var deleteTask = client.DeleteAsync("departamento/" + IdDepartamento);
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
                ViewBag.Message = "Ocurrió un error al eliminar el departamento " + result.ErrorMessage;
                return PartialView("ValidationModal");
            }      
        }



      
    }




	
    
}