using System.Collections.Generic;

namespace ChiffresLettres.Domain.SeedWork
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IDomainEvent> Events { get; }

        void AddEvent(IDomainEvent domainEvent);
    }
}
