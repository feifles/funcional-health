﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Controllers.Resources
{
    public class ContaCorrenteResource
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }
        public double Balance { get; set; }
    }
}
