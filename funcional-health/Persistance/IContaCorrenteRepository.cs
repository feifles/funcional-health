using funcional_health.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public interface IContaCorrenteRepository
    {
        Task<List<ContaCorrente>> GetAll();
        Task<ContaCorrente> Get(string cc);
    }
}