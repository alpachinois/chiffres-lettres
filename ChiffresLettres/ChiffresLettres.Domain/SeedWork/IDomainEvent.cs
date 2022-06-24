using System;

namespace ChiffresLettres.Domain.SeedWork
{
    public interface IDomainEvent
    {
        DateTime TimeStampUtc { get; }
    }
}
