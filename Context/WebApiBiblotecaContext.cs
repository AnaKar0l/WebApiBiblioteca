using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiBiblioteca.Model;

namespace WebApiBiblioteca.Context
{
    public class WebApiBibliotecaContext : DbContext
    {
        public WebApiBibliotecaContext(DbContextOptions options) : base(options) { }

        public DbSet<Livro>? Livros { get; set; }

        public DbSet<Autor>? Autores { get; set; }

        public DbSet<Genero>? Generos { get; set; }
    }
}