using funcional_health.GQL.Types;
using funcional_health.Models;
using funcional_health.Persistance;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.GQL.Mutations
{
    public class ContaCorrenteMutation : ObjectGraphType
    {
        public ContaCorrenteMutation(IContaCorrenteRepository repository, IUnitOfWork unitOfWork)
        {
            Field<ContaCorrenteType>(
                "sacar",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                    new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "valor" }
                    ),
                resolve: context =>
                {
                    var conta = context.GetArgument<int?>("conta").ToString();
                    var valor = context.GetArgument<double>("valor");

                    var cc = repository.Get(conta).Result;

                    if(cc == null)
                    {
                        context.Errors.Add(new ExecutionError(OpMgs.ACCOUNT_NOT_FOUND));
                        return new ContaCorrente()
                        {
                            AccountNumber = conta
                        };
                    }

                    var result = cc.Withdrawn(valor);

                    if (result.IsError)
                    { 
                        context.Errors.Add(new ExecutionError(result.Message));
                        return cc;
                    }

                    if (result.Message.Equals(OpMgs.INSUFFICIENT_FUNDS))
                    {
                        context.Errors.Add(new ExecutionError(result.Message));
                        return cc;
                    }

                    unitOfWork.CompleteAsync();

                    return cc;

                });
            Field<ContaCorrenteType>(
               "depositar",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                   new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "valor" }
                   ),
               resolve: context =>
               {
                   var conta = context.GetArgument<int?>("conta").ToString();
                   var valor = context.GetArgument<double>("valor");

                   var cc = repository.Get(conta).Result;

                   if (cc == null)
                   {
                       context.Errors.Add(new ExecutionError(OpMgs.ACCOUNT_NOT_FOUND));
                       return new ContaCorrente()
                       {
                           AccountNumber = conta
                       };
                   }

                   var result = cc.Deposit(valor);

                   if (result.IsError)
                   {
                       context.Errors.Add(new ExecutionError(result.Message));
                       return cc;
                   }

                   unitOfWork.CompleteAsync();

                   return cc;

               });
        }
    }
}
