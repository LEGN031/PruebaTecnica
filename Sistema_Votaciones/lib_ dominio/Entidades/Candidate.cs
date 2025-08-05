using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Cedula { get; set; }
        public string? Party { get; set; }
        public int Votes { get; set; } = 0;
    }
}
