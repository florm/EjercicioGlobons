using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaEF2.Models
{
    public class Direccion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [StringLength(50)]
        [Display(Name = "Calle")]
        public string calle { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name = "Numero")]
        public int numero { get; set; }
        public List<Persona> Personas { get; set; }
        //como una direccion puede tener N personas, yo puedo pedirle a la direccion que me muestre la
        //lista de personas que tienen esta direccion
    }
}