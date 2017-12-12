using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaEF2.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} no puede estar vacio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name ="DNI")]
        public int NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name = "Fecha de Nacimiento")]
        
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime FechaNacimiento { get; set; }
        
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public Direccion Direccion { get; set; } //propiedad navigacional. Desde una persona puedo ver todas las propiedades de la direccion que le corresponde a esa persona
        //esto se pone del lado N de la relacion
    }
}