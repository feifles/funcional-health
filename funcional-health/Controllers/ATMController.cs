using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funcional_health.Controllers.Resources;
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
        private readonly IMapper mapper;
        private readonly IContaCorrenteRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ATMController(ILogger<ATMController> logger, IMapper mapper, IContaCorrenteRepository repository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        /*
            DADO QUE eu consuma a API GraphQL
            QUANDO eu chamar a query saldo informando o número da conta
            ENTÃO a query retornará o saldo atualizado.
         */

        // GET: api/<controller>/saldo
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Saldo([FromBody]string contaCorrente)
        {
            //Basic sanity check
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Check for empty value
            if (String.IsNullOrEmpty(contaCorrente))
            {
                ModelState.AddModelError("erro", "Número de conta não pode ser vazio");
                return BadRequest(ModelState);
            }

            //Try to get the account
            var ccs = await repository.Get(contaCorrente);

            //Account not found
            if (ccs == null)
            {
                ModelState.AddModelError("erro", "Account not found");
                return NotFound(ModelState);
            }

            return Ok(mapper.Map<ContaCorrente, ContaCorrenteResource>(ccs));
        }

        /**
            DADO QUE eu consuma a API GraphQL
            QUANDO eu chamar a mutation sacar informando o número da conta e um valor válido
            ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo
            E a mutation retornará o saldo atualizado.

            DADO QUE eu consuma a API GraphQL
            QUANDO eu chamar a mutation sacar informando o número da conta e um valor maior do que o meu saldo
            ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente
         */

        // POST api/<controller>/Sacar
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Sacar([FromBody]OperacaoResource operacaoResource)
        {
            //Basic sanity check
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Negative value cannot be withdrawn
            if (operacaoResource.Valor <= 0)
            {
                ModelState.AddModelError("Erro", "Valor não pode ser menor ou igual 0.");
                return BadRequest(ModelState);
            }

            //Try to get the account
            var ccs = await repository.Get(operacaoResource.Cc);

            //Found the account
            if (ccs != null)
            {
                //User doesn't have enough funds
                if(operacaoResource.Valor > ccs.Balance)
                {
                    ModelState.AddModelError("erro", "Saldo insuficiente.");
                    return Ok(ModelState);
                }
                else
                {
                    ccs.Balance -= operacaoResource.Valor;
                    await unitOfWork.CompleteAsync();
                }
            }

            ccs = await repository.Get(operacaoResource.Cc);

            return Ok(mapper.Map<ContaCorrente, ContaCorrenteResource>(ccs));
        }

        /*
            DADO QUE eu consuma a API GraphQL
            QUANDO eu chamar a mutation depositar informando o número da conta e um valor válido
            ENTÃO a mutation atualizará o saldo da conta no banco de dados
            E a mutation retornará o saldo atualizado.
         */

        // POST api/<controller>/Sacar
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Depositar([FromBody]OperacaoResource operacaoResource)
        {
            //Basic sanity check
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Negative value cannot be withdrawn
            if (operacaoResource.Valor <= 0)
            {
                ModelState.AddModelError("Erro", "Valor não pode ser menor ou igual 0.");
                return BadRequest(ModelState);
            }

            //Try to get the account
            var ccs = await repository.Get(operacaoResource.Cc);

            //Found the account
            if (ccs != null)
            {
                ccs.Balance += operacaoResource.Valor;
                await unitOfWork.CompleteAsync();
            }

            ccs = await repository.Get(operacaoResource.Cc);

            return Ok(mapper.Map<ContaCorrente, ContaCorrenteResource>(ccs));
        }
    }
}
