using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        [Required(ErrorMessage="Ingrese un username válido")]
        [MaxLength(50,ErrorMessage="EL username no puede ser mayor a 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ingrese su Nombre")]
        [MaxLength(50, ErrorMessage = "EL nombre de usuario no puede ser mayor a 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese su Apellido Paterno")]
        [MaxLength(50, ErrorMessage = "EL Apellido Paterno no puede ser mayor a 50 caracteres")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Ingrese su Apellido Materno")]
        [MaxLength(50, ErrorMessage = "EL Apellido Materno no puede ser mayor a 50 caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Ingrese un Email válido")]
        [MaxLength(50, ErrorMessage = "EL Email no puede ser mayor a 50 caracteres")]
        public string Email { get; set; }
        //public byte[] Password { get; set; }d
        //[Required(ErrorMessage = "Ingrese un Password válido")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ingrese una Fecha válida")]
        [Display(Name="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Ingrese un Teléfono válido")]
        [MaxLength(20, ErrorMessage = "EL Teléfono no puede ser mayor a 20 caracteres")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Seleccione una opción")]
        public string Sexo { get; set; }
        public bool Status { get; set; }
        public ML.Rol Rol { get; set; }
        public List<object> Usuarios { get; set; }

        public string Action { get; set; }
        public string Token { get; set; }
    }
}
