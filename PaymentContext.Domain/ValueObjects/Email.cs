using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects {
    public class Email : ValueObject {
        public Email(string adrress) {
            this.Address = adrress;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(this.Address, "Email.Address", "E-mail inválido.")
            );
        }

        public string Address { get; private set; }
    }
}