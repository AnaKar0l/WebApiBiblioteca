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

    
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _logger;
        private readonly WebApiBibliotecaContext _context;

         public LivroController(ILogger<LivroController> logger, WebApiBibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            var livros = _context.Livros.ToList();
            if(livros is null)
                return NotFound();  

            return livros;
        }

        [HttpPost]
        public ActionResult Post(Livro livro){
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return new CreatedAtRouteResult ("GetLivro", new{ id = livro.ID}, livro);
        }

        [HttpGet ("{id:int}", Name ="GetLivro")]
        public ActionResult<Livro> Get(int id)
        {
            var livro = _context.Livros.FirstOrDefault(p => p.ID == id);
            if(livro is null)
                return NotFound("Não foi possível localizar o livro.");

                return livro;
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Livro livro){
            if(id != livro.ID)
                return BadRequest();

            _context.Entry(livro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(livro);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var livro = _context.Cursos.FirstOrDefault(p => p.ID == id);

            if(livro is null)
                return NotFound();

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return Ok(livro);
        }

    }
}