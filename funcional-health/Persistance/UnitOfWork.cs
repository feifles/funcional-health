using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FuncionalHealthDbContext context;

        public UnitOfWork(FuncionalHealthDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
