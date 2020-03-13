using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Models
{
    public class Operacao
    {
        [Required]
        public string Cc { get; set; }
        [Required]
        public double Valor { get; set; }
    }
}
