namespace Domain.Events;
using Domain.Interfaces;
using Domain.ValueObjects;

internal class DrugStoreCreatedEvent : IDomainEvent
{

    internal DrugStoreCreatedEvent(string drugNetwork, int number, Address address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
    }

    public string DrugNetwork { get; }

    public int Number { get; }

    public Address Address { get; }
}