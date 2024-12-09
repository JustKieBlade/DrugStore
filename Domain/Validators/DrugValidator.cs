using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d=>d.Name)
            .Length(2,150).WithMessage(ValidationMessage.LenghthMessage)
            .Matches("[A-Z]").WithMessage(ValidationMessage.LenghthMessage);

        RuleFor(d => d.Manufacturer);
    }
}