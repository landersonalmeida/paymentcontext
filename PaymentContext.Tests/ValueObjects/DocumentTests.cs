using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests {
    [TestClass]
    public class DocumentTests {
        // Red, Green, Refactor.

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid() {
            var Document = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(Document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid() {
            var Document = new Document("25466350000179", EDocumentType.CNPJ);
            Assert.IsTrue(Document.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid() {
            var Document = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(Document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsValid() {
            var Document = new Document("81569815020", EDocumentType.CPF);
            Assert.IsTrue(Document.Valid);
        }
    }
}