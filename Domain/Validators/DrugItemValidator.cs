using Domain.Entities;
using FluentValidation;
using Domain.Primitives;

namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация для DrugItem
/// </summary>
public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(d1 => d1.Cost)
            .Must(cost => cost == Math.Round(cost, 2)).WithMessage(ValidationMessage.CostMustBePositive);  

        RuleFor(d1 => d1.Count)
            .Must(count => count == (int)count).WithMessage(ValidationMessage.MustInt) 
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.CountMaxValue);  
    }
}