using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiBiblioteca.Model;
using WebApiBiblioteca.Context;

namespace WebApiBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly ILogger<AutorController> _logger;
        private readonly WebApiBibliotecaContext _context;

         public AutorController(ILogger<AutorController> logger, WebApiBibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            var autores = _context.Autores.ToList();
            if(autores is null)
                return NotFound();  

            return autores;
        }

        [HttpPost]
        public ActionResult Post(Autor autor){
            _context.Autores.Add(autor);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetAutor", new{ id = autor.ID}, autor);
        }

        [HttpGet ("{id:int}", Name ="GetAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = _context.Autores.FirstOrDefault(p => p.ID == id);
            if(autor is null)
                return NotFound("Não foi possível localizar o autor.");

                return autor;
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Autor autor){
            if(id != autor.ID)
                return BadRequest();

            _context.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(autor);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var autor = _context.Autores.FirstOrDefault(p => p.ID == id);

            if(autor is null)
                return NotFound();

            _context.Autores.Remove(autor);
            _context.SaveChanges();

            return Ok(autor);
        }

    }
}