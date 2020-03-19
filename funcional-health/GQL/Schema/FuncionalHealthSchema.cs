using funcional_health.GQL.Queries;
using GraphQL;

namespace funcional_health.GQL.Schema
{
    public class FuncionalHealthSchema : GraphQL.Types.Schema
    {
        public FuncionalHealthSchema(IDependencyResolver resolver) 
            : base(resolver)
        {
            Query = resolver.Resolve<ContaCorrenteQuery>();
        }
    }
}
