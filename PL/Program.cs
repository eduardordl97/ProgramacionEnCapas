using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Globalization;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Producto

            //Producto.Add();
            Producto.Update();
            Producto.Delete();
           
            //Producto.GetAll();
            //Producto.AddSP();    
            //Producto.DeleteSP();
            //Producto.UpdateSP();
            Producto.GetAllSP();
            Producto.GetByIdSP();

            //Departamento

            //Departamento.AddSP(); 
            //Departamento.DeleteSP();
            //Departamento.UpdateSP();
            //Departamento.DeleteSP();
            //Departamento.GetAllSP();
            //Departamento.GetByIdSP();
         
            //Menu();

            //Venta
            //Venta.AddSP();
            //Venta.Add();

            //Venta Producto
            //VentaProducto.AddSP();

            //string FileToRead = @"C:\Users\ALIEN 14\Documents\EDUARDO RIVERA DE LUCIO\LayoutUsuarios.txt";
            //using (StreamReader ReaderObject = new StreamReader(FileToRead))
            //{
            //    string Line;
            //    // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
            //    while ((Line = ReaderObject.ReadLine()) != "")
            //    {
            //        string[] datosUsuario = Line.Split('|');
            //        ML.Usuario usuario = new ML.Usuario();
            //        usuario.Username = datosUsuario[0];
            //        usuario.Nombre = datosUsuario[1];
            //        usuario.ApellidoPaterno = datosUsuario[2];           
            //        usuario.ApellidoMaterno = datosUsuario[3];
            //        usuario.FechaNacimiento = DateTime.ParseExact(datosUsuario[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //        usuario.Email = datosUsuario[5];

            //        usuario.Sexo = "Hombre";
            //        usuario.Password = "pass";
            //        usuario.Rol = new ML.Rol();
            //        usuario.Rol.IdRol = 1;
            //        usuario.Telefono = "5546374667";
                    
                    

            //        ML.Result result = BL.Usuario.AddEF(usuario);
            //        if (result.Correct)
            //        {
            //            System.Console.WriteLine("Usuario añadido correctamente");
            //        }
            //        else
            //        {
            //            var texto = "Hubo un error "+result.ErrorMessage;
            //            //GenerarTXT(texto);
            //        }

            //        Console.WriteLine(Line);
            //    }
            //}

            Console.ReadLine();


        }
        public static void GenerarTXT(string texto)
        {

            string rutaCompleta = @"C:\Users\ALIEN 14\Documents\EDUARDO RIVERA DE LUCIO\ERiveraProgramacionNCapas\PL\ErrorLog";
            //string texto = "HOLA MUNDO ";

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                mylogs.WriteLine(texto);

                mylogs.Close();


            }
        }
        
        static void Menu()
        {
            bool continuar = true;
            int opcion1;
            while (continuar)
            {
                Console.WriteLine("-¿Qué tabla deseas Visualizar?-  \n");
                Console.WriteLine("1.Producto");
                Console.WriteLine("2.Departamento");
                Console.WriteLine("3.Salir");
                opcion1 = int.Parse(Console.ReadLine());

                switch (opcion1)
                {
                    case 1:
                        Producto.GetAllSP();
                        int opcion2;
                        Console.WriteLine("-Seleccion la accion desea realizar: - \n");
                        Console.WriteLine("1.Añadir Producto");
                        Console.WriteLine("2.Borrar Producto");
                        Console.WriteLine("3.Editar Producto");
                        Console.WriteLine("4.Mostrat por ID");
                        Console.WriteLine("5.Salir");

                        opcion2 = int.Parse(Console.ReadLine());
                        switch (opcion2)
                        {
                            case 1:
                                Producto.AddSP();
                                break;
                            case 2:
                                Producto.DeleteSP();
                                break;
                            case 3:
                                Producto.UpdateSP();
                                break;
                            case 4:
                                Producto.GetByIdSP();
                                break;
                            case 5:
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Digite una opción correcta");
                                break;
                        }
                        break;

                   case 2:
                        Departamento.GetAllSP();
                        int opcion3;
                        Console.WriteLine("-Seleccion la accion desea realizar: -");
                        Console.WriteLine("1.Añadir Producto");
                        Console.WriteLine("2.Borrar Producto");
                        Console.WriteLine("3.Editar Producto");
                        Console.WriteLine("4.Mostrat por ID");
                        Console.WriteLine("5.Salir");

                        opcion3 = int.Parse(Console.ReadLine());
                        switch (opcion3)
                        {
                            case 1:
                                Departamento.AddSP();
                                break;
                            case 2:
                                Departamento.DeleteSP();
                                break;
                            case 3:
                                Departamento.UpdateSP();
                                break;
                            case 4:
                                Departamento.GetByIdSP();
                                break;
                            case 5:
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Digite una opción correcta");
                                break;
                        }
                        break;

                    case 3:
                        continuar = false;
                        break;

                    default:

                        Console.WriteLine("Digite una opción correcta");

                        break;           

                }
            }

            Console.Read();
        }
        

    }
}
