using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;



namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// Системсная валидация
    /// </summary>
    public class Drug : BaseEntity
    {
        public Drug(string name, string manufacturer, string countryCodeId)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            Manufacturer = Guard.Against.NullOrWhiteSpace(manufacturer, nameof(manufacturer), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            CountryCodeId = Guard.Against.NullOrWhiteSpace(countryCodeId, nameof(countryCodeId), ValidationMessage.NullOrWhiteSpaceMustNotBe);

            var validator = new DrugValidator();

            validator.Validate(this);
            
        }

        /// <summary>
        /// Название препарата.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Производитель препарата.
        /// </summary>
        public string Manufacturer { get; private set; }
        
        /// <summary>
        /// Код страны производителя.
        /// </summary>
        public string CountryCodeId { get; private set; }
    }
}