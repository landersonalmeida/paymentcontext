using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities {
    public class Student : Entity {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email) {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this._subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription) {
            bool hasSubscriptionsActive = false;

            foreach(var sub in _subscriptions) {
                if(sub.Active)
                    hasSubscriptionsActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionsActive, "Student.Subscriptions", "Você já tem uma assinatura aqui")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Essa assinatura não possúi pagamentos")
            );
        }
    }
}