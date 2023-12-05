using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiBiblioteca.Model
{
    public class Contato
    {
        public int ID { get; set; }
        public String? Nome { get; set; }

        public int Celular { get; set; }

        public String? Email { get; set; }

    }
}