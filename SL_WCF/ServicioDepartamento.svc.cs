using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioDepartamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioDepartamento.svc or ServicioDepartamento.svc.cs at the Solution Explorer and start debugging.
    public class ServicioDepartamento : IServicioDepartamento
    {
        public string Saludar(string Nombre)
        {
  
            return "Hola " + Nombre;
        }

        //complejo
        //Departamento//Producto --Add-Update-Delete -

        public SL_WCF.Result Add(ML.Departamento departamento)
        {
            ML.Result resultDepartamento = BL.Departamento.AddEF(departamento);

            SL_WCF.Result result = new Result();
            result.Correct = resultDepartamento.Correct;
            result.ErrorMessage = resultDepartamento.ErrorMessage;
            result.Object = resultDepartamento.Object;
            result.Objects = resultDepartamento.Objects;
            return result;
        }

        public SL_WCF.Result Update(ML.Departamento departamento)
        {
            ML.Result resultDepartamento = BL.Departamento.UpdateEF(departamento);

            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result Delete(int IdDepartamento)
        {
            ML.Result resultDepartamento = BL.Departamento.DeleteEF(IdDepartamento);

            SL_WCF.Result result = new Result();
            result.Correct = resultDepartamento.Correct;
            result.ErrorMessage = resultDepartamento.ErrorMessage;
            return result;
        }

        public SL_WCF.Result GetById(int IdDepartamento)
        {
            ML.Result resultDepartamento = BL.Departamento.GetByIdEF(IdDepartamento);

            SL_WCF.Result result = new Result();
            result.Correct = resultDepartamento.Correct;
            result.ErrorMessage = resultDepartamento.ErrorMessage;
            result.Object = resultDepartamento.Object;
            result.Objects = resultDepartamento.Objects;
            return result;
        }

        public SL_WCF.Result GetAll()
        {
            ML.Result resultDepartamento = BL.Departamento.GetAllEF();

            SL_WCF.Result result = new Result();
            result.Correct = resultDepartamento.Correct;
            result.ErrorMessage = resultDepartamento.ErrorMessage;
            result.Object = resultDepartamento.Objects;
            result.Objects = resultDepartamento.Objects;
            return result;

        }
    }
}
