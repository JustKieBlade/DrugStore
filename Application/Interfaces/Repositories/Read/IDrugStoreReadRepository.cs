using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Interfaces.Repositories.Read;

public interface IDrugStoreReadRepository : IReadRepository<DrugStore>
{
    Task<List<DrugStore>> SearchDrugStoreByAddress(Address address, CancellationToken cancellationToken);
    Task<List<DrugStore>> GetDrugStoresByNetworkAsync(string drugNetwork, CancellationToken cancellationToken);
}