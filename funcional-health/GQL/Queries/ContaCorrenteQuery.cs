using funcional_health.GQL.Types;
using funcional_health.Persistance;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.GQL.Queries
{
    public class ContaCorrenteQuery : ObjectGraphType
    {
        public ContaCorrenteQuery(IContaCorrenteRepository repository)
        {
            Field<ListGraphType<ContaCorrenteType>>(
                "contas", 
                resolve: context => repository.GetAll());
        }
    }
}
