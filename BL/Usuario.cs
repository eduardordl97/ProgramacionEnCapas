using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {
                    
                    var usuarios = context.UsuarioGetAll1(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno).ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {

                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuarioObj = new ML.Usuario();
                            usuarioObj.Username = obj.Username;
                            usuarioObj.Nombre = obj.Nombre;
                            usuarioObj.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarioObj.ApellidoMaterno = obj.ApellidoMaterno;
                            usuarioObj.Email = obj.Email;
                            //usuarioObj.Password = obj.Password;
                            usuarioObj.Telefono = obj.Telefono;
                            usuarioObj.Sexo = obj.Sexo;
                            usuarioObj.Status = obj.Status.Value;
                            usuarioObj.Rol = new ML.Rol();
                            usuarioObj.Rol.IdRol = obj.IdRol.Value;
                            usuarioObj.Rol.Nombre = obj.NombreRol;

                            result.Objects.Add(usuarioObj);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Usuario";
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

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.UsuarioAdd(usuario.Username, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, Encoding.ASCII.GetBytes(usuario.Password), usuario.FechaNacimiento, usuario.Telefono, usuario.Sexo, usuario.Rol.IdRol);

                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Usuario";
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

        public static ML.Result GetByIdEF(string Username)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var obj = context.UsuarioGetById(Username).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Username = obj.Username;
                        usuario.Nombre = obj.Nombre;
                        usuario.ApellidoPaterno = obj.ApellidoPaterno;
                        usuario.ApellidoMaterno = obj.ApellidoMaterno;
                        usuario.Email = obj.Email;
                        usuario.Password = Encoding.ASCII.GetString(obj.Password);
                        usuario.FechaNacimiento = obj.FechaNacimiento.Value;
                        usuario.Telefono = obj.Telefono;
                        usuario.Sexo = obj.Sexo;
                        usuario.Status = obj.Status.Value;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = obj.IdRol.Value;
                        usuario.Rol.Nombre = obj.NombreRol;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Usuario";
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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.UsuarioUpdate(usuario.Username, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, Encoding.ASCII.GetBytes(usuario.Password), usuario.FechaNacimiento, usuario.Telefono, usuario.Sexo, usuario.Status, usuario.Rol.IdRol);

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

        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ERiveraProgramacionNCapasEntities context = new DL_EF.ERiveraProgramacionNCapasEntities())
                {

                    var resultQuery = context.UsuarioDelete(usuario.Username);

                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al borrar el registro en la tabla Usuario";
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
