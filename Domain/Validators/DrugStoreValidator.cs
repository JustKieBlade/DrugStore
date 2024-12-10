using Domain.Entities;
using FluentValidation;
using Domain.Primitives;


namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация для DrugStore
/// </summary>
public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    
    /// <summary>
    /// Примеры ISO - кодов (здесь это в теории не должно быть, для примера)
    /// </summary>
    private static readonly HashSet<string> ValidCountryCodes = new HashSet<string>
    {
        "US", "GB", "DE", "FR", "RU", "CA", "IN", "AU", "CN", "BR", // Пример ISO-кодов стран
        // Добавьте сюда остальные ISO-коды стран
    };
    
    public DrugStoreValidator()
    {
        RuleFor(ds => ds.DrugNetwork)
            .Length(2, 100).WithMessage(ValidationMessage.LengthMessage);
        
        RuleFor(ds => ds.Address.Street)
            .Length(3, 100).WithMessage(ValidationMessage.LengthMessage);
        
        RuleFor(ds => ds.Address.City)
            .Length(2, 50).WithMessage(ValidationMessage.LengthMessage);
        
        RuleFor(ds => ds.Address.PostalCode)
            .Must(count => count == (int)count).WithMessage(ValidationMessage.MustInt);
        RuleFor(ds=>ds.Address.PostalCode.ToString())
            .Length(5, 6).WithMessage(ValidationMessage.LengthMessage);
        
        RuleFor(d => d.Address.ISO)
            .Matches(@"[A-Z]").WithMessage(ValidationMessage.AllMustBeBig)
            .Must(BeAValidCountryCode).WithMessage(ValidationMessage.BeAValidISPCode);
    }
    
    /// <summary>
    /// Метод проверки ISO - кода
    /// </summary>
    private bool BeAValidCountryCode(string countryCode)
    {
        return ValidCountryCodes.Contains(countryCode);
    }
}