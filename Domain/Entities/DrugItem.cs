using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;
using Domain.Events;

namespace Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// Системсная валидация
    /// </summary>
    public class DrugItem : BaseEntity<DrugItem>
    {
        public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count)
        {
            DrugId = Guard.Against.NullOrEmpty(drugId, nameof(drugId), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            DrugStoreId = Guard.Against.NullOrEmpty(drugStoreId, nameof(drugStoreId), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            Cost = Guard.Against.NegativeOrZero(cost, nameof(cost),ValidationMessage.NegativeOrZero);
            Count = Guard.Against.NegativeOrZero(count, nameof(count),ValidationMessage.NegativeOrZero);
            
            var validator = new DrugItemValidator();

            validator.Validate(this);
        }
    
        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }
        
        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid DrugStoreId { get; private set; }
        
        /// <summary>
        /// Стоимость препарата в данной аптеке.
        /// </summary>
        public decimal Cost { get; private set; }
        
        /// <summary>
        /// Количество препарата на складе.
        /// </summary>
        public double Count { get; private set; }
        
        
        #region Свойства
        
        // Навигационные свойства
        public Drug Drug { get; private set; }
        public DrugStore DrugStore { get; private set; }
        
        #endregion
        
        #region Методы

        // Обновление количества
        public void UpdateCount(double count)
        {
            Count = count;
        
            ValidateEntity(new DrugItemValidator());
        
            AddDomainEvent(new DrugItemUpdatedEvent(Cost, Count));
        }
        
        // Обновление цены
        public void UpdateСost(double cost)
        {
            Count = cost;
        
            ValidateEntity(new DrugItemValidator());
        
            AddDomainEvent(new DrugItemUpdatedEvent(Cost, Count));
        }

        //Удаление лекарства в магазине
        public void RemoveItem(string removalReason)
        {
            AddDomainEvent(new DrugItemRemovedEvent(DrugId, DrugStoreId));
        }
        
        //Добавление лекарства в магазине
        public void AddNewItem(decimal cost, int count)
        {
            Cost = cost;
            Count = count;

            ValidateEntity(new DrugItemValidator());

            AddDomainEvent(new DrugItemAddedEvent(DrugId, DrugStoreId, cost, count));
        }
        
        
        #endregion
        
    }
}