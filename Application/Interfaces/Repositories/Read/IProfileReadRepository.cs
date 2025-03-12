using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IProfileReadRepository : IReadRepository<Profile>
{
    Task<Profile?> GetProfileByExternalIdAsync(string externalId, CancellationToken cancellationToken);
}