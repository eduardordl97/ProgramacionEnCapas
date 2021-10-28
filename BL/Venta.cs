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
    public class Venta
    {
        public static ML.Result AddSP(ML.Venta venta, List<object> Objects)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "VentaAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[0].Direction = ParameterDirection.Output;

                        collection[1] = new SqlParameter("IdCliente", SqlDbType.VarChar);
                        //collection[1].Value = venta.Cliente.Username;

                        collection[2] = new SqlParameter("Total", SqlDbType.Decimal);
                        collection[2].Value = venta.Total;

                        collection[3] = new SqlParameter("IdMetodoPago", SqlDbType.Int);
                        collection[3].Value = venta.MetodoPago.IdMetodoPago;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        venta.IdVenta = (int)cmd.Parameters["IdVenta"].Value;

                        foreach (ML.VentaProducto ventaProducto in Objects)
                        {
                            ventaProducto.Venta = new ML.Venta();
                            ventaProducto.Venta.IdVenta = venta.IdVenta;

                            BL.VentaProducto.AddSP(ventaProducto);
                        }

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

        public static ML.Result GetByIdSP(int IdVenta)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "VentaGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[0].Value = IdVenta;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableVenta = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableVenta);

                        if (tableVenta.Rows.Count > 0)
                        {
                            DataRow row = tableVenta.Rows[0];    

                            ML.Venta venta = new ML.Venta();
                            venta.IdVenta = int.Parse(row[0].ToString());
                            //venta.Cliente.Username = row[1].ToString();
                            venta.Total = decimal.Parse(row[2].ToString());
                            venta.MetodoPago.IdMetodoPago = int.Parse(row[3].ToString());
                            venta.Fecha = DateTime.Parse(row[4].ToString());

                            result.Object = venta;
                            

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";
                        }
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

        public static ML.Result AddEF(ML.Venta venta,List<object> Objects)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    ObjectParameter IdVenta = new ObjectParameter("IdVenta", typeof(int));
                    //IdVenta = venta.IdVenta;

                    var resultQuery = context.VentaAdd(venta.Usuario.Username, venta.Total, venta.MetodoPago.IdMetodoPago, IdVenta);

                    venta.IdVenta = (int)IdVenta.Value;
                    foreach (ML.VentaProducto ventaProducto in Objects)
                    {
                        ventaProducto.Venta = new ML.Venta();                     
                        ventaProducto.Venta.IdVenta = venta.IdVenta;

                        BL.VentaProducto.AddEF(ventaProducto);
                    }

                    if (resultQuery >= 1)
                    {
                        result.Object = venta;
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

        //public static ML.Result GetByIdVenta(int IdVenta)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
        //        {

        //            var obj = context.GetByIdVenta(IdVenta).ToList();

        //            result.Objects = new List<object>();

        //            if (obj != null)
        //            {

        //                ML.VentaProducto ventaProducto = new ML.VentaProducto();
        //                ventaProducto.IdVentaProducto = obj.IdVentaProducto;
        //                ventaProducto.Producto.IdProducto = obj.
        //                //ventaProducto.IdVentaProducto = objProducto.

        //                //ML.Producto producto = new ML.Producto();
        //                //producto.IdProducto = objProducto.IdProducto;
        //                //producto.Nombre = objProducto.Nombre;
        //                //producto.PrecioUnitario = objProducto.PrecioUnitario.Value;
        //                //producto.Stock = objProducto.Stock.Value;
        //                //producto.Proveedor = new ML.Proveedor();
        //                //producto.Proveedor.IdProveedor = objProducto.IdProveedor.Value;
        //                //producto.Proveedor.Nombre = objProducto.NombreProveedor;
        //                //producto.Departamento = new ML.Departamento();
        //                //producto.Departamento.IdDepartamento = objProducto.IdDepartamento.Value;
        //                //producto.Descripcion = objProducto.Descripcion;
        //                //producto.Imagen = objProducto.Imagen;
        //                //producto.Departamento.Area = new ML.Area();
        //                //producto.Departamento.Area.IdArea = objProducto.IdArea.Value;
        //                //producto.Departamento.Area.Nombre = objProducto.NombreArea;



        //                //result.Object = producto;

        //                //}
        //                //if (result.Objects == null)
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Departamento";
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}
    }


}
