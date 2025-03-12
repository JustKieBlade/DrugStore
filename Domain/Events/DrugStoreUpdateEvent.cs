namespace Domain.Events;
using Domain.Interfaces;
using Domain.ValueObjects;

public class DrugStoreUpdatedEvent : IDomainEvent
{

    public DrugStoreUpdatedEvent(string drugNetwork, int number, Address address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
    }

    public string DrugNetwork { get; }

    public int Number { get; }

    public Address Address { get; }
}