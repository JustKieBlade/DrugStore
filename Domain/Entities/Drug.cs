using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;
using Domain.Events;


namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// Системсная валидация
    /// </summary>
    public class Drug : BaseEntity<Drug>
    {
        public Drug(string name, string manufacturer, string countryCodeId, Country country, Func<string, bool> countryExistsFunc)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            Manufacturer = Guard.Against.NullOrWhiteSpace(manufacturer, nameof(manufacturer), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            CountryCodeId = Guard.Against.NullOrWhiteSpace(countryCodeId, nameof(countryCodeId), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            Country = country;
            
            var validator = new DrugValidator();

            validator.Validate(this);
            AddDomainEvent(new DrugCreatedEvent(name, manufacturer, countryCodeId, country));
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
        
        /// <summary>
        /// Код страны производителя.
        /// </summary>
        public Country Country { get; private set; }
        
        /// <summary>
        /// Навигационное свойство для связи с DrugItem.
        /// </summary>
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        
        #region  Методы

        public void UpdateDrug(string name, string manufacturer, string countrycodeid, Country country)
        {
            ValidateEntity(new DrugValidator());

            AddDomainEvent(new DrugUpdatedEvent(name, manufacturer, countrycodeid, country));
        }

        #endregion
    }
}