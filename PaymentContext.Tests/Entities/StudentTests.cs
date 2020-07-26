using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests {
    [TestClass]
    public class StudentTests {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests() {
            this._name = new Name("Bruce", "Wayne");
            this._document = new Document("61599456028", EDocumentType.CPF);
            this._email = new Email("batman@dc.com");
            this._address = new Address("Rua Legal", "1234", "Bairro Legal", "São Paulo", "SP", "BR", "08220190");
            this._student = new Student(this._name, this._document, this._email);
            this._subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription() {
            var payment = new PayPalPayment("2E846EE4D5D852", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", this._document, this._address, this._email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment() {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription() {
            var payment = new PayPalPayment("2E846EE4D5D852", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", this._document, this._address, this._email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}