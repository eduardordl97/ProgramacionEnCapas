using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;

namespace BL
{
    public class VentaProducto
    {
        public static ML.Result AddSP(ML.VentaProducto ventaProducto) 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "VentaProductoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdVenta", SqlDbType.VarChar);
                        collection[0].Value = ventaProducto.Venta.IdVenta;

                        collection[1] = new SqlParameter("Cantidad", SqlDbType.Decimal);
                        collection[1].Value = ventaProducto.Cantidad;

                        collection[2] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[2].Value = ventaProducto.Producto.IdProducto;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
                        }
                        //cmd.Connection.Close();  
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        public static ML.Result AddEF(ML.VentaProducto ventaProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.VentaProductoAdd(ventaProducto.Venta.IdVenta, ventaProducto.Cantidad, ventaProducto.Producto.IdProducto);

                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Departamento";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetByIdVenta(int IdVenta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {


                    var departamentos = context.GetByIdVenta(IdVenta).ToList();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {

                        foreach (var obj in departamentos)
                        {
                            ML.VentaProducto ventaProducto = new ML.VentaProducto();
                            ventaProducto.IdVentaProducto = obj.IdVentaProducto;
                            ventaProducto.Cantidad = obj.Cantidad.Value;

                            ventaProducto.Venta = new ML.Venta();
                            ventaProducto.Venta.IdVenta = obj.IdVenta.Value;
                            ventaProducto.Venta.Total = obj.Total.Value;
                            ventaProducto.Venta.Usuario = new ML.Usuario();
                            ventaProducto.Venta.Usuario.Username = obj.Cliente;
                            ventaProducto.Venta.MetodoPago = new ML.MetodoPago();
                            ventaProducto.Venta.MetodoPago.IdMetodoPago = obj.IdMetodoPago.Value;
                            ventaProducto.Venta.Fecha = obj.Fecha.Value;

                            ventaProducto.Producto = new ML.Producto();
                            ventaProducto.Producto.Nombre = obj.Nombre;
                            ventaProducto.Producto.PrecioUnitario = obj.PrecioUnitario.Value;
                            ventaProducto.Producto.Imagen = obj.Imagen;
                           

                            result.Objects.Add(ventaProducto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Departamento";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    
    }
    

}
