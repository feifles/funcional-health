using funcional_health.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public interface IContaCorrenteRepository
    {
        Task<IEnumerable<ContaCorrente>> GetAll();
        Task<ContaCorrente> Get(string cc);
        Task<double> GetGQL(string cc);
    }
}