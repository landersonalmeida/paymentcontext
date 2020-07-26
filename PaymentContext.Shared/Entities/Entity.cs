using System;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entities {
    public abstract class Entity : Notifiable {
        protected Entity() {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}