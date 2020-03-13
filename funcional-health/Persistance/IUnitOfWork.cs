using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
