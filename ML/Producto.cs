using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
 
        [Required(ErrorMessage="El nombre es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public ML.Proveedor Proveedor { get; set; }
        public ML.Departamento Departamento { get; set; }  
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }

        public List<object> Productos { get; set; }

        //public ML.Producto Productos { get; set; }

    }
}
