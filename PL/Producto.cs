using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Producto
    {
        //ADD
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio  del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());
             
            Console.WriteLine("Ingresa el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion");
            producto.Descripcion = Console.ReadLine();

            //ML.Result result=BL.Producto.Add(producto);
            ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
            var result = client.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto ingresado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Producto " + result.ErrorMessage);
            }
            
        }
        //DELETE
        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el id del producto que desea eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result =BL.Producto.Delete(producto);
            ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
            var result = client.Delete(producto.IdProducto);

            if (result.Correct)
            {
                Console.WriteLine("Producto eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al borrar el registro en la tabla Producto " + result.ErrorMessage);
            }

        }

        //UPDATE
        public static void Update()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el id del producto que desea modificar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la nueva descripcion del producto ");
            producto.Descripcion = Console.ReadLine();


            
            //ML.Result result = BL.Producto.Update(producto);
            ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
            var result = client.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el registro en la tabla Producto " + result.ErrorMessage);
            }

        }

        //GetAllSP
        public static void GetAll()
        {

            ML.Result result = BL.Producto.GetAll();

            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Precio: " + producto.PrecioUnitario);
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripción: " + producto.Descripcion + "\n");
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }

        //###########################################################################################

        //AddSP

        public static void AddSP()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio  del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Ingresa la descripcion");
            producto.Descripcion = Console.ReadLine();


            //ML.Result result = BL.Producto.AddSP(producto);   Add SP
            //ML.Result result = BL.Producto.AddEF(producto);
            ML.Result result = BL.Producto.AddLINQ(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto ingresado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Producto " + result.ErrorMessage);
            }

        }


        //DELETE SP
        public static void DeleteSP()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el id del producto que desea eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Producto.DeleteSP(producto);
            //ML.Result result = BL.Producto.DeleteEF(producto);
            ML.Result result = BL.Producto.DeleteLINQ(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al borrar el registro en la tabla Producto " + result.ErrorMessage);
            }

        }

        //UPDATE
        public static void UpdateSP() 
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el id del producto que desea modificar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la nueva descripcion del producto ");
            producto.Descripcion = Console.ReadLine();



            //ML.Result result = BL.Producto.UpdateSP(producto);
            //ML.Result result = BL.Producto.UpdateEF(producto);
            ML.Result result = BL.Producto.UpdateLINQ(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el registro en la tabla Producto " + result.ErrorMessage);
            }

        }

        //GetAllSP
        public static void GetAllSP()
        {

            //ML.Result result = BL.Producto.GetAllSP();
            //ML.Result result = BL.Producto.GetAllEF();
            //ML.Result result = BL.Producto.GetAllLINQ();
            ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
            var result = client.GetAll();

            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Precio: " + producto.PrecioUnitario);
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripción: " + producto.Descripcion );
                    Console.WriteLine("Imagen: " + producto.Imagen);
                    Console.WriteLine("----------------------------------------\n");

                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }

        //GetByID
        public static void GetByIdSP()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del producto que quiera visualizar ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Producto.GetByIdSP(producto.IdProducto);
            ServiceReferenceProducto.ServicioProductoClient client = new ServiceReferenceProducto.ServicioProductoClient();
            var result = client.GetById(producto.IdProducto);

            if (result.Correct)
            {
                producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                producto.Nombre = ((ML.Producto)result.Object).Nombre;
                producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                producto.Proveedor = new ML.Proveedor();
                producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                producto.Departamento = new ML.Departamento();
                producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                producto.Descripcion = ((ML.Producto)result.Object).Descripcion;

               
                
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Precio: " + producto.PrecioUnitario);
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);
                    Console.WriteLine("Descripción: " + producto.Descripcion + "\n");
               
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
    }
}
