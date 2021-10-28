using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Venta
    {
        //public static void AddSP()
        //{
        //    ML.Venta venta = new ML.Venta();

        //    Console.WriteLine("Ingresa el IdCliente");
        //    venta.Cliente = new ML.Cliente();
        //    venta.Cliente.IdCliente = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingresa total de la venta");
        //    venta.Total = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingresa el IdMetodoPago");
        //    venta.IdMetodoPago = int.Parse(Console.ReadLine());

        //    ML.Result result = BL.Venta.AddSP(venta, result.Objects);

        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Departamento ingresado correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Departamento " + result.ErrorMessage);
        //    }

        //}

        public static void AddMe()
        {
            //ML.Producto producto = new ML.Producto();
            ML.VentaProducto ventaProducto = new ML.VentaProducto();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            bool continuar = true;
            int opcion1;
            int comprar;

            ML.Venta venta = new ML.Venta();

            //while (continuar)
            //{
            Console.WriteLine("-¿Desea comprar algún producto");
            Console.WriteLine("1.Si");
            Console.WriteLine("2.No, Salir");

            opcion1 = int.Parse(Console.ReadLine());
            while (continuar)
            {
                switch (opcion1)
                {

                    case 1:
                        Producto.GetAllSP();
                        Console.WriteLine("-Ingresa el Id del producto que deseas comprar");
                        //Instanciar Producto porque esta dentro de otro modelo
                        ventaProducto.Producto = new ML.Producto();
                        ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la cantidad");
                        ventaProducto.Cantidad = int.Parse(Console.ReadLine());
                        //result.Objects.Add(producto);
                        result.Objects.Add(ventaProducto); //Id Cantidad
                        Console.WriteLine("Desea comprar otro producto?");
                        Console.WriteLine("1.Sí");
                        Console.WriteLine("2.No(salir)");
                        comprar = int.Parse(Console.ReadLine());
                        break;

                    case 2:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Digite una opción correcta");
                        break;

                }

            }

            //}
        }

        public static void Add()
        {
            
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            byte opcion;

            ML.Venta venta = new ML.Venta();
            
            //venta.Cliente = new ML.Cliente();
            //venta.Cliente.IdCliente = 2;
            //venta.MetodoPago = new ML.MetodoPago();
            //venta.MetodoPago.IdMetodoPago = 1;

            Console.WriteLine("-¿Desea comprar algún producto");
            Console.WriteLine("1.Si");
            Console.WriteLine("2.No, Salir");
            opcion = byte.Parse(Console.ReadLine());

            while (opcion == 1)
            {
                Producto.GetAllSP();
                Console.WriteLine("-Ingresa el Id del producto que deseas comprar");
                //Para sobreescribir el objeto
                ML.VentaProducto ventaProducto = new ML.VentaProducto();

                //Instanciar Producto porque esta dentro de otro modelo
                ventaProducto.Producto = new ML.Producto();
                ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la cantidad");
                ventaProducto.Cantidad = int.Parse(Console.ReadLine());

                //Get By Id
                ML.Result resultProducto = BL.Producto.GetByIdSP(ventaProducto.Producto.IdProducto);
          

                if (resultProducto.Correct)
                {
                    //unboxing
                    venta.Total += ((ML.Producto)resultProducto.Object).PrecioUnitario * ventaProducto.Cantidad;
                    result.Objects.Add(ventaProducto); //Añadir lista de objetos
                    Console.WriteLine("Su total es de :" + venta.Total);
                    Console.WriteLine("Desea comprar otro producto?");
                    Console.WriteLine("1.Sí");
                    Console.WriteLine("2.No(salir)");
                    opcion = byte.Parse(Console.ReadLine());
                    
      
                }
                else
                {
                    Console.WriteLine("El Id del producto ingresado no existe");
                }
                     

            }

            Console.WriteLine("Ingrese el Id del Cliente");
            //venta.Cliente = new ML.Cliente();
            //venta.Cliente.Username = Console.ReadLine();

            Console.WriteLine("Ingrese el Id del Metodo de pago");
            venta.MetodoPago = new ML.MetodoPago();
            venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());

            if (opcion == 2)
            {
                //result = BL.Venta.AddSP(venta, result.Objects);
                result = BL.Venta.AddEF(venta, result.Objects);

            }
        }

    }
}
