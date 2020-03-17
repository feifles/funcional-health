using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Models
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsError = false;
        }

        public bool IsError { get; set; }
        public double CurrentBalance { get; set; }
        public string Message { get; set; }


    }

    public static class OpMgs {
        public const string SUCCESSFUL_OPERATION = "Operação realizada com sucesso.";
        public const string INSUFFICIENT_FUNDS = "Saldo Insuficiente.";

        public const string INVALID_INPUT = "Input inválido";

    }


    
}
