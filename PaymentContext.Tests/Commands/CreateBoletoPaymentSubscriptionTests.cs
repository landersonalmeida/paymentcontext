using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests {
    [TestClass]
    public class CreateBoletoPaymentSubscriptionTests {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid() {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
    }
}