using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects {
    public class Document : ValueObject {
        public Document(string number, EDocumentType type) {
            this.Number = number;
            this.Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(this.Validate(), "Document.Number", "Documento inválido")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate() {
            if(this.Type == EDocumentType.CNPJ && this.Number.Length == 14)
                return true;

            if(this.Type == EDocumentType.CPF && this.Number.Length == 11)
                return true;

            return false;
        }
    }
}