using MediatR;
namespace Application.UseCases.Commands;

public record CreateDrugCommand(string Name, string Manufacturer, string CountryCodeId, string CountryName) : IRequest<Guid>;