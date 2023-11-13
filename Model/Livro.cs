using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBiblioteca.Model
{
    public class Livro
    {
        public int ID { get; set; }

        public String? Titulo { get; set; }

        public DateTime DataLancamento { get; set; }

        public List<Autor> Autores { get; set; }

        public List<Genero> Generos { get; set; }

        public Livro()
        {
            Autores = new List<Autor>();
            Generos = new List<Genero>();
        }

    }
}