using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class VentaProducto
    {
        public static void AddSP()
        {
            ML.VentaProducto ventaProducto = new ML.VentaProducto();

            Console.WriteLine("Ingresa el IdVenta");
            ventaProducto.Venta = new ML.Venta();
            ventaProducto.Venta.IdVenta = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la cantidad");
            ventaProducto.Cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el IdMetodoPago");
            ventaProducto.Producto = new ML.Producto();
            ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.VentaProducto.AddSP(ventaProducto);

            if (result.Correct)
            {
                Console.WriteLine("Departamento ingresado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Departamento " + result.ErrorMessage);
            }

        }
    }
}
