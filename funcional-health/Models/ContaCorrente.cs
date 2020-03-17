using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace funcional_health.Models
{
    public enum OpType
    {
        Withdraw = 0,
        Deposit
    }

    public class ContaCorrente
    {
        public int Id { get; set; }
        [Required]
        [StringLength(6)]
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        private OperationResult result = new OperationResult();

        private OperationResult RealizarOperacao(double value, OpType opType)
        {
            //Bad input
            if (value <= 0)
            {
                result.IsError = true;
                result.Message = OpMgs.INVALID_INPUT;
                result.CurrentBalance = this.Balance;
                return result;
            }

            if(opType == OpType.Withdraw)
            {
                //User doesn't have enough funds
                if (value > this.Balance)
                {
                    result.IsError = false;
                    result.Message = OpMgs.INSUFFICIENT_FUNDS;
                    result.CurrentBalance = this.Balance;
                }
                else
                {
                    result.CurrentBalance = (this.Balance -= value);
                    result.IsError = false;
                    result.Message = OpMgs.SUCCESSFUL_OPERATION;
                }
            }
            else if (opType == OpType.Deposit)
            {
                result.CurrentBalance = (this.Balance += value);
                result.IsError = false;
                result.Message = OpMgs.SUCCESSFUL_OPERATION;
            }

            return result;
        }

        public OperationResult Deposit(double value)
        {
            return RealizarOperacao(value, OpType.Deposit);
        }

        public OperationResult Withdrawn(double value)
        {
            return RealizarOperacao(value, OpType.Withdraw);
        }
    }
}
