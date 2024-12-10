using Domain.Entities;
using Domain.Primitives;
using FluentValidation;


namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация для Drug
/// </summary>
public class DrugValidator : AbstractValidator<Drug>
{
    
    private readonly Func<string, bool> _countryCodeExists;
    public DrugValidator()
    {
        RuleFor(d=>d.Name)
            .Length(2,150).WithMessage(ValidationMessage.LengthMessage)
            .Matches(@"^[a-zA-Z\s]+$").WithMessage(ValidationMessage.SpecialCharactersNotAllowed);

        RuleFor(d => d.Manufacturer)
            .Length(2, 100).WithMessage(ValidationMessage.LengthMessage)
            .Matches(@"^[a-zA-Z\s\-]+$").WithMessage(ValidationMessage.InvalidCharactersInManufacturer);

        RuleFor(d => d.CountryCodeId)
            .Matches(@"^[A-Z]{2}$").WithMessage(ValidationMessage.InvalidCountryCodeFormat)
            .Must(IsCountryCodeValid).WithMessage(ValidationMessage.CountryCodeNotFound);
    } 
    
    /// <summary>
    /// Валидация на существованеи в справочнике стран
    /// </summary>
    private bool IsCountryCodeValid(string countryCode)
    {
        return _countryCodeExists(countryCode);
    }
}
