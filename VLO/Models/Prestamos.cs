using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLO.Models
{
    public class Prestamos
    {
        [Key]
        public int IdPrestamo { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Cantidad a retirar")]
        [Range(0, double.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        public double Cantidad { get; set; }

        //Relaciones
        public int IdProducto { get; set; }
        public virtual Productos Productos { get; set; }
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

    }
}