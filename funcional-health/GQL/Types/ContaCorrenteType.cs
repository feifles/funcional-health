using funcional_health.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.GQL.Types
{
    public class ContaCorrenteType : ObjectGraphType<ContaCorrente>
    {
        public ContaCorrenteType()
        {
            Field(x => x.Id);
            Field("conta", x => x.AccountNumber);
            Field("saldo", x => x.Balance);
        }
    }
}
