using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Vote
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public int VoterId { get; set; }

        [ForeignKey("VoterId")] public Voter? Voter_ { get; set; }

        public int CandidateId { get; set; }

        [field: ForeignKey("CandidateId")] public Candidate? Candidate_ { get; set; }


    }
}
