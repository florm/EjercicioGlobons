using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaEF2.Models;
using System.Data.Entity;

namespace PruebaEF2.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index() //en el Index quiero retornar un listado de personas
        {
            using (var db = new PersonaContext())
            {
                var model = db.Personas.Include("Direccion").ToList();
                
                return View(model);
            }
            
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new PersonaContext())
            {
                var p = db.Personas.Include("Direccion").SingleOrDefault(x => x.Id == id);
                
                return View(p);
            }
        }

        
        
        // GET: Persona/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var fechaActual = DateTime.Today;
                if (persona.FechaNacimiento >= fechaActual)
                {
                    throw new Exception("Error");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "La fecha no puede ser posterior a la fecha actual - " + ex.Message);
                return View(persona);
            }

            try
            {
                var db2 = new PersonaContext();
                if (db2.BuscarDNI(persona.NumeroDocumento) == false)
                {
                    throw new Exception("Error");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ya existe el DNI - " + ex.Message);
                return View(persona);
            }
                
                         
                    
            using (var db = new PersonaContext())
            {
                db.Direcciones.Add(persona.Direccion);
                db.Personas.Add(persona);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
                    
                        
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            using ( var db = new PersonaContext())
            {
                Persona p = db.Personas.Include("Direccion").SingleOrDefault(x => x.Id == id);
                return View(p);
            }
            
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Persona persona)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(persona);
                }
                using (var db = new PersonaContext())
                {
                    Persona personaDB = db.Personas.Find(id);
                    personaDB.Nombre = persona.Nombre;
                    personaDB.Apellido = persona.Apellido;
                    personaDB.NumeroDocumento = persona.NumeroDocumento;
                    personaDB.FechaNacimiento = persona.FechaNacimiento;

                    //necesito cambiar la DireccionId, porque esa misma direccion la pueden tener varias personas, entonces no puedo cambiar el contenido de calle y numero para 
                    //ese mismo id porque estaria alterando los datos de otra persona que tiene el mismo DireccionId.
                    //por lo tanto necesito generar un nuevo registro en la table direccion y asignarlo a esta persona
                    //lo que todavia no se como hacer es buscar si existe ese mismo registro de calle + numero y asignarle ese id de direccion al DireccionId de la persona
                        Direccion nueva = new Direccion();
                        nueva.calle = persona.Direccion.calle;
                        nueva.numero = persona.Direccion.numero;
                        db.Direcciones.Add(nueva);
                        db.SaveChanges();

                        personaDB.DireccionId = nueva.Id;
                        db.SaveChanges();
                    //esto funciona bien, solo faltaria preguntar si la calle y numero que recibe es diferente a lo que tiene, pero al
                    ///hacer el if personaDB.Domicilio.calle y lo mismo .numero me dice que es null... Por lo tanto asi como esta me genera un registro nuevo de
                    //calle y numero que se agrega a la tabla direccion
                   
                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception)
            {
                return View();
            }
            
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (var  db = new PersonaContext())
                {
                    Persona p = db.Personas.Find(id);
                    db.Personas.Remove(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                
            }
            return View();
        }

        
    }
}
