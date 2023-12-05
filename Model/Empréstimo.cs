using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBiblioteca.Model
{
    public class Empréstimo
    {
        public int ID { get; set; }
        public String? Nome { get; set; }

        public String? Título { get; set; }

        public DateTime DataEmpréstimo { get; set; }

        public DateTime? DataDevolução { get; set; }

    }
}