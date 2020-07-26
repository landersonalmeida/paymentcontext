using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities {
    public class Subscription : Entity {
        private readonly IList<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            this.CreateDate = DateTime.Now;
            this.LastUpdateTime = DateTime.Now;
            this.ExpireDate = expireDate;
            this.Active = true;
            this._payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateTime { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment) {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura.")
            );

            this._payments.Add(payment);
        }

        public void Activate() {
            this.Active = true;
            this.LastUpdateTime = DateTime.Now;
        }

        public void Inactivate() {
            this.Active = false;
            this.LastUpdateTime = DateTime.Now;
        }
    }
}