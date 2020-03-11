using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Models
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        [Required]
        [StringLength(6)]
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
    }
}
