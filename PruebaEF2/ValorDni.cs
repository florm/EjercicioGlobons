using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaEF2
{
    public class ValorDni : ValidationAttribute
    {

        private readonly int _minimo;

        public ValorDni(int minimo) : base("{0} no puede contener menos de 8 numeros")
        {
             _minimo= minimo;
        }

        protected override ValidationResult IsValid(object valor, ValidationContext validationContext)
        {
            if (valor != null)
            {
                var valorAString = valor.ToString();
                if (valorAString.Length < _minimo)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        
    }
}