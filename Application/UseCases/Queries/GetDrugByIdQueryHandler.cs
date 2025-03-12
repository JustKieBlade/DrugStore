using Application.Interfaces.Repositories.Read;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries;

public class GetDrugByIdQueryHandler (IDrugReadRepository drugReadRepository) : IRequestHandler<GetDrugByIdQuery, Drug>
{
    public async Task<Drug> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var drug = await drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return drug;
    }

}