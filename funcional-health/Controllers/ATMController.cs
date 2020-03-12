using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using funcional_health.Models;
using funcional_health.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace funcional_health.Controllers
{
    [Route("api/[controller]")]
    public class ATMController : Controller
    {

        private readonly ILogger<ATMController> _logger;
        private readonly FuncionalHealthDbContext context;

        public ATMController(ILogger<ATMController> logger, FuncionalHealthDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<ContaCorrente>> GetAsync()
        {
            return await context.ContasCorrentes.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
