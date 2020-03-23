using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using funcional_health.GQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace funcional_health.Controllers
{
    [Route("api/[controller]")]
    public class ATMGraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public ATMGraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] GraphQLQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var inputs = query.Variables?.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
