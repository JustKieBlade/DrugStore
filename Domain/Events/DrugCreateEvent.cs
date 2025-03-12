using Domain.Interfaces;
using Domain.Entities;

namespace Domain.Events;

internal class DrugCreatedEvent : IDomainEvent
{

    internal DrugCreatedEvent(string name, string manufacturer, string countryCode, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCode = countryCode;
        Country = country;
    }

    public string Name { get; }

    public string Manufacturer { get; }

    public string CountryCode { get; }

    public Country Country { get; }
}