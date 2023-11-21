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

    
    public class GeneroController : ControllerBase
    {
        private readonly ILogger<GeneroController> _logger;
        private readonly WebApiBibliotecaContext _context;

         public GeneroController(ILogger<GeneroController> logger, WebApiBibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> Get()
        {
            var generos = _context.Generos.ToList();
            if(generos is null)
                return NotFound();  

            return generos;
        }

        [HttpPost]
        public ActionResult Post(Genero genero){
            _context.Generos.Add(genero);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetGenero", new{ id = genero.ID}, genero);
        }

        [HttpGet ("{id:int}", Name ="GetGenero")]
        public ActionResult<Genero> Get(int id)
        {
            var genero = _context.Generos.FirstOrDefault(p => p.ID == id);
            if(genero is null)
                return NotFound("Não foi possível localizar o genero.");

                return genero;
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Genero genero){
            if(id != genero.ID)
                return BadRequest();

            _context.Entry(genero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(genero);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var genero = _context.Generos.FirstOrDefault(p => p.ID == id);

            if(genero is null)
                return NotFound();

            _context.Generos.Remove(genero);
            _context.SaveChanges();

            return Ok(genero);
        }

    }
}