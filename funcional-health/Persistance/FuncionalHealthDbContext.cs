using funcional_health.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public class FuncionalHealthDbContext : DbContext
    {
        public FuncionalHealthDbContext(DbContextOptions<FuncionalHealthDbContext> options)
            : base (options)
        {

        }

        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
    }
}
