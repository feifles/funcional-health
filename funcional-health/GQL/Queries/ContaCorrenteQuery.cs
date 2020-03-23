using funcional_health.GQL.Types;
using funcional_health.Models;
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

            Field<ContaCorrenteType>(
                "saldo",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "conta" }),
                resolve: context => {

                    var cc = context.GetArgument<int?>("conta").ToString();

                    //return repository.Get(cc);
                    return new ContaCorrente { AccountNumber = "123456", Balance = 32, Id = 3 };
                });
        }
    }
}
