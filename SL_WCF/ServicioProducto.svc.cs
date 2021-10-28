using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioProducto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioProducto.svc or ServicioProducto.svc.cs at the Solution Explorer and start debugging.
    public class ServicioProducto : IServicioProducto
    {
        public SL_WCF.Result Add(ML.Producto producto)
        {
            ML.Result resultProducto = BL.Producto.AddEF(producto);

            SL_WCF.Result result = new Result();
            result.Correct = resultProducto.Correct;
            //result.ErrorMessage = resultProducto.ErrorMessage;
            result.Object = resultProducto.Object;
            result.Objects = resultProducto.Objects;
            return result;
        }

        public SL_WCF.Result Update(ML.Producto producto)
        {
            ML.Result resultProducto = BL.Producto.UpdateEF(producto);

            SL_WCF.Result result = new Result();
            result.Correct = resultProducto.Correct;
            result.ErrorMessage = resultProducto.ErrorMessage;
            result.Object = resultProducto.Object;
            result.Objects = resultProducto.Objects;
            return result;
        }

        public SL_WCF.Result Delete(int IdProducto)
        {
            ML.Result resultProducto = BL.Producto.DeleteEF(IdProducto);

            SL_WCF.Result result = new Result();
            result.Correct = resultProducto.Correct;
            result.ErrorMessage = resultProducto.ErrorMessage;
            result.Object = resultProducto.Object;
            result.Objects = resultProducto.Objects;
            return result;
        }

        public SL_WCF.Result GetById(int IdProducto)
        {
            ML.Result resultProducto = BL.Producto.GetByIdEF(IdProducto);

            SL_WCF.Result result = new Result();
            result.Correct = resultProducto.Correct;
            result.ErrorMessage = resultProducto.ErrorMessage;
            result.Object = resultProducto.Object;
            result.Objects = resultProducto.Objects;
            return result;
        }

        public SL_WCF.Result GetAll()
        {
            ML.Result resultProducto = BL.Producto.GetAllEF();

            SL_WCF.Result result = new Result();
            result.Correct = resultProducto.Correct;
            result.ErrorMessage = resultProducto.ErrorMessage;
            result.Object = resultProducto.Object;
            result.Objects = resultProducto.Objects;
            return result;

        }
    
    }
}
