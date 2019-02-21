using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VLO.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "Nombres ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "Apellidos ")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(9, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "DUI ")]
        public string Dui { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$",
                   ErrorMessage="Ingrese un número válido")]
        [Display(Name ="Número de teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(150, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "Dirección ")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no es válido")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "No puede ingresar menos de {0} caracteres")]
        [MaxLength(10, ErrorMessage = "No puede ingresar más de {0} caracteres")]
        [Display(Name = "Cargo ")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Salario")]
        [Range(0, double.MaxValue, ErrorMessage = "Ingrese una cantidad válida")]
        public double Salario { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        //Relaciones con Genero
        public int IdGenero {get;set;}
        public virtual Genero Genero { get; set; }

        //Listar la tabla en las siguientes tablas
        public virtual List<HExtras> HExtras { get; set; }
        public virtual List<Pedido> Pedido { get; set; }
        public virtual List<Usuarios> Usuarios { get; set; }
        public virtual List<Turnos> Turnos { get; set; }
        public virtual List<Prestamos> Prestamos { get; set; }

    }
}