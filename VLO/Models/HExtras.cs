using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLO.Models
{
    public class HExtras
    {
        [Key]
        public int IdExtras { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        [Display(Name = "Horas Extras")]
        public int Cantidad { get; set; }

        [Display(Name ="Total a pagar")]
        public double TotalSalario { get; set; }

        //Relaciones 
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}