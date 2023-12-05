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
    public class ContatoController : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly WebApiBibliotecaContext _context;

        public ContatoController(ILogger<ContatoController> logger, WebApiBibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contato>> Get()
        {
            var contatos = _context.Contatos.ToList();
            if (contatos is null)
                return NotFound();

            return contatos;
        }

        [HttpPost]
        public ActionResult Post(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetContato", new { id = contato.ID }, contato);
        }

        [HttpGet("{id:int}", Name = "GetContato")]
        public ActionResult<Contato> Get(int id)
        {
            var contato = _context.Contatos.FirstOrDefault(p => p.ID == id);
            if (contato is null)
                return NotFound("Não foi possível localizar o contato.");

            return contato;
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Contato contato)
        {
            if (id != contato.ID)
                return BadRequest();

            _context.Entry(contato).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(contato);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var contato = _context.Contatos.FirstOrDefault(p => p.ID == id);

            if (contato is null)
                return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return Ok(contato);
        }

    }
}