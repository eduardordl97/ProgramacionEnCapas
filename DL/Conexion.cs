using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //Añadir

namespace DL
{
     public class Conexion
    {       
        public static string GetConnectionString()
        {
           // string Conexion = ConfigurationManager.ConnectionStrings["ERiveraProgramacionNCapas"].ConnectionString;
            string Conexion = System.Configuration.ConfigurationManager.ConnectionStrings["ERiveraProgramacionNCapas"].ConnectionString;
            
            return Conexion;

        }
        
    }
}
