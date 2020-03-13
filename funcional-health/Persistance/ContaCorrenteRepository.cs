using funcional_health.Controllers.Resources;
using funcional_health.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Persistance
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly FuncionalHealthDbContext context;
        private readonly IUnitOfWork unitOfWork;

        public ContaCorrenteRepository(FuncionalHealthDbContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ContaCorrente> Get(string cc)
        {
            return await context
                .ContasCorrentes
                .Where(x => x.AccountNumber.Equals(cc))
                .FirstOrDefaultAsync();
        }

        //public async Task<ContaCorrente> Withdraw (OperacaoResource operacao)
        //{

        //}
    }
}
