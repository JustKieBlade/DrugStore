using Ardalis.GuardClauses;
using Domain.ValueObjects;
using Domain.Primitives;
using Domain.Validators;
using Domain.Events;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// Системная валидация
    /// </summary>
    public sealed class DrugStore : BaseEntity<DrugStore>
    {
        public DrugStore(string drugNetwork, int number, Address address)
        {
            DrugNetwork = Guard.Against.NullOrWhiteSpace(drugNetwork, nameof(drugNetwork), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            Number = Guard.Against.NegativeOrZero(number, nameof(number), ValidationMessage.NegativeOrZero);
            Address = Guard.Against.Null(address, nameof(address), ValidationMessage.NullOrWhiteSpaceMustNotBe);

            var validator = new DrugStoreValidator();

            validator.Validate(this);
            
            AddDomainEvent(new DrugStoreCreatedEvent(drugNetwork, number, address));
        }

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
        
        
        #region Методы

        public void UpdateDrugStore(string drugNetwork, int number, Address address)
        {
            ValidateEntity(new DrugStoreValidator());

            AddDomainEvent(new DrugStoreUpdatedEvent(drugNetwork, number, address));
        }
        #endregion
    }
}