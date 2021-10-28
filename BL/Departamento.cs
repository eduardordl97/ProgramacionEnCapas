using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Añadir
using System.Data.SqlClient;//Añadir

namespace BL
{
    public class Departamento
    {
        //ADD SP
        public static ML.Result AddSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "DepartamentoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

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
        public static ML.Result DeleteSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "DepartamentoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

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

        //UPDATE SP
        public static ML.Result UpdateSP(ML.Departamento departamento) 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "DepartamentoUpdate";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = departamento.Nombre;

                        collection[2] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[2].Value = departamento.Area.IdArea;

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
                    string query = "DepartamentoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableDepartamento = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableDepartamento);

                        if (tableDepartamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableDepartamento.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla departamento";
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

        public static ML.Result GetByIdSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DepartamentoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableDepartamento = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableDepartamento);

                        if (tableDepartamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableDepartamento.Rows)
                            {
                                //ML.Producto producto = new ML.Producto();
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());
                              
                                result.Objects.Add(departamento);
                            }

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

        ///////////////////////////ENTITY FRAMEWORK///////////////////////////////
        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);

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

        public static ML.Result DeleteEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.DepartamentoDelete(IdDepartamento);

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

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);

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

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var departamentos = context.DepartamentoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {
                        
                        foreach (var obj in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea.Value;
                            departamento.Area.Nombre = obj.AreaNombre;

                            result.Objects.Add(departamento);
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

        //public static ML.Result GetByIdSP(int IdDepartamento)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "DepartamentoGetById";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = context;
        //                cmd.CommandText = query;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
        //                collection[0].Value = IdDepartamento;

        //                cmd.Parameters.AddRange(collection);

        //                DataTable tableProducto = new DataTable();

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);

        //                da.Fill(tableProducto);

        //                if (tableProducto.Rows.Count > 0)
        //                {
        //                    DataRow row = tableProducto.Rows[0];
        //                    ML.Departamento departamento = new ML.Departamento();
        //                    departamento.IdDepartamento = int.Parse(row[0].ToString());
        //                    departamento.Nombre = row[1].ToString();
        //                    departamento.Area = new ML.Area();
        //                    departamento.Area.IdArea = int.Parse(row[2].ToString());

        //                    result.Object = departamento;


        //                    result.Correct = true;

        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "No existen registros en la tabla departamento";
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

        public static ML.Result GetByIdEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var objDepartamento= context.DepartamentoGetById(IdDepartamento).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objDepartamento != null)
                    {

                        //foreach (var obj in departamentos)
                        //{
                        ML.Departamento departamento = new ML.Departamento();
                        departamento.IdDepartamento = objDepartamento.IdDepartamento;
                        departamento.Nombre = objDepartamento.Nombre;
                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = objDepartamento.IdArea.Value;
                        result.Object = departamento;
                            
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
        ///////////////////////////////////LINQ/////////////////////////////////////
        public static ML.Result AddLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {
                    DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    departamentoDL.Nombre = departamento.Nombre;                 
                    departamentoDL.IdArea = departamento.Area.IdArea;

                    context.Departamentoes.Add(departamentoDL);

                    int rowsAffected= context.SaveChanges();

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

        public static ML.Result DeleteLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var query = (from a in context.Departamentoes
                                 where a.IdDepartamento == departamento.IdDepartamento
                                 select a).FirstOrDefault();

                    context.Departamentoes.Remove(query);

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

        public static ML.Result UpdateLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {
           

                    var query = (from a in context.Departamentoes
                                 where a.IdDepartamento == departamento.IdDepartamento
                                 select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;
                        query.IdArea = departamento.Area.IdArea;
                      
                        context.SaveChanges();

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el departamento" + departamento.IdDepartamento;
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

                    //var query = (from depto in context.Departamentoes
                    //             join departamento in context.Departamentoes on depto.IdDepartamento equals departamento.IdDepartamento
                    //             where depto.IdDepartamento == departamento.IdDepartamento                              
                    //             select new {IdDepartamento = departamento.IdDepartamento,Nombre = departamento.Nombre, IdArea = departamento.IdArea });
//SINGLE FIRST

//4
                    var query = (from depto in context.Departamentoes
                                 //where depto.IdArea==4
                                 select new { IdDepartamento= depto.IdDepartamento, Nombre= depto.Nombre, IdArea=depto.IdArea}).ToList();
                                // select depto).ToList(); //8

                    result.Objects = new List<object>();


                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Departamento dp = new ML.Departamento();
                            dp.IdDepartamento = obj.IdDepartamento;
                            dp.Nombre = obj.Nombre;
                            dp.Area = new ML.Area();
                            dp.Area.IdArea = obj.IdArea.Value;
   
                            result.Objects.Add(dp);
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

        public static ML.Result GetByIdArea(int IdArea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {


                    var departamentos = context.AreaGetById(IdArea).ToList();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {

                        foreach (var obj in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea.Value;
                            departamento.Area.Nombre = obj.NombreArea;

                            result.Objects.Add(departamento);
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
