using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLO.Models
{
    public class AsignacionTurno
    {
        [Key]
        public int IdAsignacion { get; set; }


        public int IdTurno { get; set; }
        public virtual Turnos Turnos { get; set; }

        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}