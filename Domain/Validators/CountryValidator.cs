using Domain.Entities;
using FluentValidation;
using Domain.Primitives;

namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация для Country
/// </summary>
public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .Length(2, 100).WithMessage(ValidationMessage.LengthMessage) 
            .Matches(@"^[A-Za-z\s]+$").WithMessage(ValidationMessage.CostMaxPrecision);  

        RuleFor(c => c.Code)
            .Length(2).WithMessage(ValidationMessage.LengthMessage)  
            .Matches(@"^[A-Z]{2}$").WithMessage(ValidationMessage.CountMaxValue); 
    }
}