using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface IDrugWriteRepository : IWriteRepository<Drug>
{
    Task UpdateManufacturer(string manufacturer, CancellationToken cancellationToken);

    Task UpdateName(string name, CancellationToken cancellationToken);

    Task UpdateCountryCode(string countryCode, CancellationToken cancellationToken);

    Task UpdateCountry(Country country, CancellationToken cancellationToken);
}