using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaEF2.Models
{
    public class Persona : IValidatableObject
    {

       

        //propiedades
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} no puede estar vacio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name ="DNI")]
        [Remote("VerificarDni", "Persona", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Ya existe el numero de DNI")]
        [ValorDni(8)]
        
        public int NumeroDocumento { get; set; }
       

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name = "Fecha de Nacimiento")]
        
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime FechaNacimiento { get; set; }
        
        public int DireccionId { get; set; }
        [ForeignKey("DireccionId")]
        public Direccion Direccion { get; set; } //propiedad navigacional. Desde una persona puedo ver todas las propiedades de la direccion que le corresponde a esa persona

        //esto se pone del lado N de la relacion


        //validacion
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var fechaActual = DateTime.Today;
            if (FechaNacimiento != null && FechaNacimiento > fechaActual)
            {
                yield return new ValidationResult("La fecha de nacimiento no puede ser posterior a la fecha actual",
                new[] { "FechaNacimiento" });
            }
        }
    }
}