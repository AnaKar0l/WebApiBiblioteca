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
    public class EmpréstimoController : ControllerBase
    {
        private readonly ILogger<EmpréstimoController> _logger;
        private readonly WebApiBibliotecaContext _context;

        public EmpréstimoController(ILogger<EmpréstimoController> logger, WebApiBibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empréstimo>> Get()
        {
            var empréstimos = _context.Empréstimos.ToList();
            if (empréstimos is null)
                return NotFound();

            return empréstimos;
        }

        [HttpPost]
        public ActionResult Post(Empréstimo empréstimo)
        {
            _context.Empréstimos.Add(empréstimo);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetEmpréstimo", new { id = empréstimo.ID }, empréstimo);
        }

        [HttpGet("{id:int}", Name = "GetEmpréstimo")]
        public ActionResult<Empréstimo> Get(int id)
        {
            var empréstimo = _context.Empréstimos.FirstOrDefault(p => p.ID == id);
            if (empréstimo is null)
                return NotFound("Não foi possível localizar o empréstimo.");

            return empréstimo;
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Empréstimo empréstimo)
        {
            if (id != empréstimo.ID)
                return BadRequest();

            _context.Entry(empréstimo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(empréstimo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var empréstimo = _context.Empréstimos.FirstOrDefault(p => p.ID == id);

            if (empréstimo is null)
                return NotFound();

            _context.Empréstimos.Remove(empréstimo);
            _context.SaveChanges();

            return Ok(empréstimo);
        }

    }
}