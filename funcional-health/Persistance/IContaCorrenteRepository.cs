using funcional_health.Models;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> Get(string cc);
    }
}