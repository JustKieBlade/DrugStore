using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IDrugReadRepository : IReadRepository<Drug>
{
    Task<List<Drug>> SearchDrugsByName(string name, CancellationToken cancellationToken);
    Task<List<Drug>> SearchDrugsByManufacturer(string manufacturer, CancellationToken cancellationToken);
}