using funcional_health.Models;
using System;
using Xunit;

namespace funcional_health.UnitTests
{
    public class FuncionalHealthAccountTests
    {
        private readonly ContaCorrente _cc;

        public FuncionalHealthAccountTests()
        {
            _cc = new ContaCorrente { Id = 1, AccountNumber = "123456", Balance = 100 };

        }

        #region Withdraw
        [Fact]
        public void Withdrawn_WithBalance_ReturnsTrue()
        {
            var withdrawnValue = 100;
            OperationResult opResult = new OperationResult
            {
                //Expected result
                Message = OpMgs.SUCCESSFUL_OPERATION,
                CurrentBalance = 0,
                IsError = false
            };

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void Withdrawn_WithoutBalance_ReturnsTrue()
        {
            var withdrawnValue = 101;
            OperationResult opResult = new OperationResult();
            //Expected result
            opResult.Message = OpMgs.INSUFFICIENT_FUNDS;
            opResult.CurrentBalance = 100;
            opResult.IsError = false;

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void Withdrawn_NegativeValue_ReturnsTrue()
        {
            var withdrawnValue = -100;
            OperationResult opResult = new OperationResult();
            //Expected result
            opResult.Message = OpMgs.INVALID_INPUT;
            opResult.CurrentBalance = 100;
            opResult.IsError = true;

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }
        #endregion

        #region Deposit
        [Fact]
        public void Deposit_Correctly_ReturnsTrue()
        {
            var depositValue = 100;
            OperationResult opResult = new OperationResult
            {
                //Expected result
                Message = OpMgs.SUCCESSFUL_OPERATION,
                CurrentBalance = 200,
                IsError = false
            };

            var result = _cc.Deposit(depositValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void Deposit_NegativeValue_ReturnsTrue()
        {
            var depositValue = -100;
            OperationResult opResult = new OperationResult();
            //Expected result
            opResult.Message = OpMgs.INVALID_INPUT;
            opResult.CurrentBalance = 100;
            opResult.IsError = true;

            var result = _cc.Deposit(depositValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }
        #endregion
        #region RealizarOperacao

        [Fact]
        public void RealizarOperacao_WithdrawnWithBalance_ReturnsTrue()
        {
            var withdrawnValue = 100;
            OperationResult opResult = new OperationResult
            {
                //Expected result
                Message = OpMgs.SUCCESSFUL_OPERATION,
                CurrentBalance = 0,
                IsError = false
            };

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void RealizarOperacao_WithdrawnWithoutBalance_ReturnsTrue()
        {
            var withdrawnValue = 101;
            OperationResult opResult = new OperationResult();
            //Expected result
            opResult.Message = OpMgs.INSUFFICIENT_FUNDS;
            opResult.CurrentBalance = 100;
            opResult.IsError = false;

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void RealizarOperacao_WithdrawnNegativeValue_ReturnsTrue()
        {
            var withdrawnValue = -100;
            OperationResult opResult = new OperationResult();
            //Expected result
            opResult.Message = OpMgs.INVALID_INPUT;
            opResult.CurrentBalance = 100;
            opResult.IsError = true;

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void RealizarOperacao_DepositCorrectly_ReturnsTrue()
        {
            var depositValue = 100;
            OperationResult opResult = new OperationResult
            {
                //Expected result
                Message = OpMgs.SUCCESSFUL_OPERATION,
                CurrentBalance = 200,
                IsError = false
            };

            var result = _cc.Deposit(depositValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }

        [Fact]
        public void RealizarOperacao_DepositNegativeValue_ReturnsTrue()
        {
            var depositValue = -100;
            OperationResult opResult = new OperationResult();
            //Expected result
            opResult.Message = OpMgs.INVALID_INPUT;
            opResult.CurrentBalance = 100;
            opResult.IsError = true;

            var result = _cc.Deposit(depositValue);

            Assert.Equal(opResult.CurrentBalance, result.CurrentBalance);
            Assert.Equal(opResult.Message, result.Message);
            Assert.Equal(opResult.IsError, result.IsError);
        }
        #endregion
    }
}