using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.GQL.Types
{
    public class ContaCorrenteInputType : InputObjectGraphType
    {
        public ContaCorrenteInputType()
        {
            Field<NonNullGraphType<IntGraphType>>("conta");
            Field<NonNullGraphType<FloatGraphType>>("valor");
        }
    }
}
