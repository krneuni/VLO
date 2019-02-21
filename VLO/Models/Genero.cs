using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLO.Models
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(15, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "Genero")]
        public string Nombre { get; set; }


        //Relaciones
        public virtual List<Empleado> Empleado { get; set; }
    }
}