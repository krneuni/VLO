using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLO.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "Nombre de usuario ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña ")]
        public string Password { get; set; }

        //Relaciones
        //Tabla Empleado para asginar un usuario y contraseña a c/u
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

        //Tabla Roles
        public int IdRol { get; set; }
        public virtual Roles Roles { get; set; }
    }
}