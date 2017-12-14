using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaEF2.Models
{
    public class PersonaContext : DbContext
    {
        public PersonaContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }

        public bool BuscarDNI (int dni)
        {
            foreach (var item in Personas)
            {
                if(item.NumeroDocumento == dni)
                {
                    return false;
                }
            }
            return true;
        }

        public int BuscarDireccion(string calle, int numero)
        {
            foreach (var item in Direcciones)
            {
                if (item.calle == calle && item.numero==numero)
                {
                    return item.Id;
                }
            }

            return 0;
            
        }
    }
}