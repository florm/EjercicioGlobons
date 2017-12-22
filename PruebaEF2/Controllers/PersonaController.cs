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

                                        
                    var numeroId = db.BuscarDireccion(persona.Direccion.calle, persona.Direccion.numero);
                    if (numeroId!=0)
                    {
                        personaDB.DireccionId = numeroId;
                        db.SaveChanges();
                    }
                    else
                    {
                        Direccion nueva = new Direccion();
                        nueva.calle = persona.Direccion.calle;
                        nueva.numero = persona.Direccion.numero;
                        db.Direcciones.Add(nueva);
                        personaDB.DireccionId = nueva.Id;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
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

        [HttpPost]
        public JsonResult VerificarDni(int NumeroDocumento, int? Id)
        {

            using (var db = new PersonaContext())
            {
                Persona persona = db.Personas.Find(Id);
                if(Id!=null && persona.NumeroDocumento == NumeroDocumento)
                {
                    return Json(true);
                }
                var dni = (from u in db.Personas
                                where u.NumeroDocumento == NumeroDocumento
                                select new { NumeroDocumento }).FirstOrDefault();


                if (dni != null)
                {
                    //ya esta registrado 
                    return Json(false);
                }
                else
                {
                    //dni no registrado 
                    return Json(true);
                }
            }
                

            

        }

        
    


}
}
