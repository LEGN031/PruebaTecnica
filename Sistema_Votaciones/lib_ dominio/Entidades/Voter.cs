using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Voter
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Cedula { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        public bool HasVoted { get; set; } = false;
    }
}
