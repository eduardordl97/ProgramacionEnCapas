using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Producto
    {
        //ADD
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //context.ConnectionString="";

                    //string query = "INSERT INTO [Producto]([Nombre],[PrecioUnitario],[Stock],[Categoria] )VALUES (@Nombre, @Marca ,@Costo ,@Categoria )";
                    string query = "INSERT INTO Producto(Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion) VALUES (@Nombre,@PrecioUnitario,@Stock,@IdProveedor,@IdDepartamento,@Descripcion)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

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

        //DELETE
        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "DELETE FROM [Producto]WHERE IdProducto=@IdProducto";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

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

        //Update 
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
             try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                    {
                        //context.ConnectionString="";

                        string query = "UPDATE Producto SET Nombre = @Nombre , PrecioUnitario = @PrecioUnitario, Stock = @Stock, IdProveedor = @IdProveedor, IdDepartamento = @IdDepartamento ,Descripcion = @Descripcion WHERE IdProducto =  @IdProducto";


                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = context;
                            cmd.CommandText = query;

                            SqlParameter[] collection = new SqlParameter[7];

                            collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                            collection[0].Value = producto.IdProducto;

                            collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                            collection[1].Value = producto.Nombre;

                            collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                            collection[2].Value = producto.PrecioUnitario;

                            collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                            collection[3].Value = producto.Stock;

                            collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                            collection[4].Value = producto.Proveedor.IdProveedor;

                            collection[5] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                            collection[5].Value = producto.Departamento.IdDepartamento;

                            collection[6] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                            collection[6].Value = producto.Descripcion;



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
                                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Producto";
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

        ////GET ALL
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SELECT IdProducto,Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion FROM Producto;";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        DataTable tableProducto = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableProducto);

                        if (tableProducto.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableProducto.Rows)
                            {
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                                producto.Descripcion = row[6].ToString();
                                result.Objects.Add(producto);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla producto";
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

        //public static void GetAll(ML.Producto producto) 
        //{
           
      
        //    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //    {

        //        string query = "SELECT * FROM Producto";

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = context;
        //            cmd.CommandText = query;

        //            DataTable tableProductos = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);

        //            cmd.Connection.Open();

        //            da.Fill(tableProductos);

        //            //foreach (DataRow row in tableProductos.Rows)
        //            //{
                        
        //            //}
        //        }

        //    }

            
        //}
        ////GetById SP
        //public static ML.Result GetByIdSP(ML.Producto producto)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {

        //            string query = "SELECT IdDepartamento,Nombre,IdArea FROM Departamento WHERE IdDepartamento = 3;";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Connection = context;
        //                cmd.CommandText = query;

        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
        //                collection[0].Value = producto.IdProducto;

        //                cmd.Parameters.AddRange(collection);

        //                DataTable tableProductos = new DataTable();
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);

        //                cmd.Connection.Open();

        //                da.Fill(tableProductos);


        //                int RowsAffected = cmd.ExecuteNonQuery();

        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Producto";
        //                }


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

        //ADD SP
        public static ML.Result AddSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                  
                    string query = "ProductoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

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

        //DELETE SP
        public static ML.Result DeleteSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "ProductoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

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

        //Update SP
        public static ML.Result UpdateSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "ProductoUpdate";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;

                        collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[2].Value = producto.PrecioUnitario;

                        collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[3].Value = producto.Stock;

                        collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[4].Value = producto.Proveedor.IdProveedor;

                        collection[5] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[5].Value = producto.Departamento.IdDepartamento;

                        collection[6] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[6].Value = producto.Descripcion;



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
                            result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Producto";
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


        //GET ALL SP

        public static ML.Result GetAllSP() 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ProductoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableProducto = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableProducto);

                        if (tableProducto.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableProducto.Rows)
                            {
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                                producto.Descripcion = row[6].ToString();
                                result.Objects.Add(producto);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla producto";
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

        public static ML.Result GetByIdSP(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ProductoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProducto;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableProducto = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableProducto);

                        if (tableProducto.Rows.Count > 0)
                        {
                            DataRow row = tableProducto.Rows[0];
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = int.Parse(row[0].ToString());
                            producto.Nombre = row[1].ToString();
                            producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                            producto.Stock = int.Parse(row[3].ToString());
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                            producto.Descripcion = row[6].ToString();
                            
                            result.Object = producto;
                            

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla producto";
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

        //Entity Framework

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);
                        
                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
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

        public static ML.Result DeleteEF(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.ProductoDelete(IdProducto);

                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al borrar el registro en la tabla Producto";
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.ProductoUpdate(producto.IdProducto,producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);

                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al modificar el registro en la tabla Producto";
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


        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var productos = context.ProductoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (productos != null)
                    {

                        foreach (var obj in productos)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario.Value;
                            producto.Stock = obj.Stock.Value;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor.Value;
                            producto.Proveedor.Nombre = obj.NombreProveedor;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                            producto.Departamento.Nombre = obj.NombreDepartamento;
                            producto.Descripcion = obj.Descripcion;
                            producto.Imagen = obj.Imagen;
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = obj.IdArea.Value;
                            producto.Departamento.Area.Nombre = obj.NombreArea;

                            result.Objects.Add(producto);
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

        public static ML.Result GetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var objProducto = context.ProductoGetById(IdProducto).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objProducto != null)
                    {

                        //foreach (var obj in departamentos)
                        //{
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = objProducto.IdProducto;
                        producto.Nombre = objProducto.Nombre;
                        producto.PrecioUnitario = objProducto.PrecioUnitario.Value;
                        producto.Stock = objProducto.Stock.Value;
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = objProducto.IdProveedor.Value;
                        producto.Proveedor.Nombre = objProducto.NombreProveedor;
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = objProducto.IdDepartamento.Value;
                        producto.Descripcion = objProducto.Descripcion;
                        producto.Imagen = objProducto.Imagen;
                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.IdArea = objProducto.IdArea.Value;
                        producto.Departamento.Area.Nombre = objProducto.NombreArea;



                        result.Object = producto;

                        //}
                        //if (result.Objects == null)
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
        public static ML.Result AddLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {
                    DL_EF.Producto productoDL = new DL_EF.Producto();

                    productoDL.Nombre = producto.Nombre;
                    productoDL.PrecioUnitario = producto.PrecioUnitario;
                    productoDL.Stock = producto.Stock;
                    //producto.Proveedor = new ML.Proveedor();           
                    productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                    //productoDL.Departamento = new DL_EF.Departamento();
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                    productoDL.Descripcion = producto.Descripcion;
                    
                    context.Productoes.Add(productoDL);

                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el registro";
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


        public static ML.Result DeleteLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var query = (from a in context.Productoes
                                 where a.IdProducto == producto.IdProducto
                                 select a).First();

                    context.Productoes.Remove(query);

                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al borrar el registro";
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

        public static ML.Result UpdateLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {
                   

                    var query = (from a in context.Productoes
                                 where a.IdProducto == producto.IdProducto
                                 select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.PrecioUnitario = producto.PrecioUnitario;
                        query.Stock = producto.Stock;
                        query.IdProveedor = producto.Proveedor.IdProveedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        query.Descripcion = producto.Descripcion;
                        context.SaveChanges();

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el grupo" + producto.IdProducto;
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

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    //var query = (from prdct in context.Productoes
                    //             join producto in context.Productoes on prdct.IdProducto equals producto.IdProducto
                    //             where prdct.IdProducto == producto.IdProducto
                    //             select new { IdProducto = producto.IdProducto, Nombre = producto.Nombre, PrecioUnitario = producto.PrecioUnitario, Stock = producto.Stock, IdProveedor = producto.IdProveedor, IdDepartamento = producto.IdDepartamento, Descripcion = producto.Descripcion });

                    var query = (from producto in context.Productoes
                                 //where depto.IdDepartamento==1
                                 select new { IdProducto = producto.IdProducto, Nombre = producto.Nombre, PrecioUnitario = producto.PrecioUnitario, Stock = producto.Stock, IdProveedor = producto.IdProveedor, IdDepartamento = producto.IdDepartamento, Descripcion = producto.Descripcion });

                                // select depto).ToList();

                    result.Objects = new List<object>();


                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto pd = new ML.Producto();
                            pd.IdProducto = obj.IdProducto;
                            pd.Nombre = obj.Nombre;
                            pd.PrecioUnitario = obj.PrecioUnitario.Value;
                            pd.Stock = obj.Stock.Value;
                            pd.Proveedor = new ML.Proveedor();
                            pd.Proveedor.IdProveedor = obj.IdProveedor.Value;
                            pd.Departamento = new ML.Departamento();
                            pd.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                            pd.Descripcion = obj.Descripcion;
                           

                            result.Objects.Add(pd);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
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

        public static ML.Result ProductoGetByIdDepartamento(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {


                    var productos = context.ProductoGetByIdDepartamento(IdDepartamento).ToList();

                    result.Objects = new List<object>();

                    if (productos != null)
                    {

                        foreach (var obj in productos)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.NombreProducto;
                            producto.PrecioUnitario = obj.PrecioUnitario.Value;
                            producto.Stock = obj.Stock.Value;
                            producto.Descripcion = obj.Descripcion;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Departamento.Nombre = obj.Nombre;
                            producto.Imagen = obj.Imagen;


                            result.Objects.Add(producto);
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

        //public static ML.Result getall2()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "ProductoGetAll";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Connection = context;
        //                cmd.CommandText = query;



        //                DataTable tabla = new DataTable();
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);

        //                da.Fill(tabla);

        //                if (tabla.Rows.Count > 0)
        //                {
        //                    result.Objects = new List<object>();

        //                    foreach (DataRow row in tabla.Rows)
        //                    {
        //                        ML.Producto producto = new ML.Producto();
        //                        producto.IdProducto = int.Parse(row[0].ToString());
        //                        result.Objects.Add(producto);
        //                    }

        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "Hola soy un error";
        //                }
                       
        //            }
        //        }
                
        //    }
        //    catch(Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;

        //    }

        //    return result;
        //}

    //    public static ML.Result add(ML.Producto producto)
    //    {
    //        ML.Result result = new ML.Result();
    //        try
    //        {
    //            using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
    //            {
    //                string query = "ProductoAdd";

    //                using (SqlCommand cmd = new SqlCommand())
    //                {
    //                    cmd.CommandType = CommandType.StoredProcedure;
    //                    cmd.Connection = context;
    //                    cmd.CommandText = query;

    //                    SqlParameter[] collection = new SqlParameter[1];

    //                    collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
    //                    collection[0].Value = producto.IdProducto;

    //                    cmd.Parameters.AddRange(collection);
    //                    cmd.Connection.Open();

    //                    int RowsAffected = cmd.ExecuteNonQuery();

    //                    if (RowsAffected > 0)
    //                    {
    //                        result.Correct = true;
    //                    }
    //                    else
    //                    {
    //                        result.Correct = false;
    //                        result.ErrorMessage = "Soy un error";
    //                    }
    //                }
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            result.Correct = false;
    //            result.ErrorMessage = ex.Message;
    //            result.Ex = ex;
    //        }

    //        return result;
    //    }
    }
}
