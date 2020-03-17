using funcional_health.Models;
using NUnit.Framework;

namespace funcional_health.UnitTest
{
    public class Tests
    {
        private readonly ContaCorrente _cc;

        public Tests(ContaCorrente cc)
        {
            _cc = new ContaCorrente { Id = 1, AccountNumber = "123456", Balance = 100 };
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Withdrawn_WithBalance_ReturnsTrue()
        {
            Assert.Pass();

            var withdrawnValue = 100;
            OperationResult opResult = new OperationResult();

            //Expected result
            opResult.Message = OpMgs.SUCCESSFUL_OPERATION;
            opResult.CurrentBalance = 0;
            opResult.IsError = false;

            var result = _cc.Withdrawn(withdrawnValue);

            Assert.(valueToTest_bool, Is.EqualTo(true));

            Assert.Equal(opResult, result);

            Assert.That


        }
    }
}