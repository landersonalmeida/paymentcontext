using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests {
    [TestClass]
    public class SubscriptionHandlerTests {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists() {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "hello@dokky.io";
            command.BarCode = "123456789";
            command.BoletoNumber = "123457897";
            command.PaymentNumber = "133211";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNE CORP";
            command.PayerEmail = "batman@dc.com";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.Street = "RUA Auehue";
            command.Number = "16";
            command.Neighborhood = "asdsa";
            command.City = "SP";
            command.State = "SP";
            command.Country = "BR";
            command.ZipCode = "12345678910";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}