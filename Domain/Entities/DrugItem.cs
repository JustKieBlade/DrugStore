using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// Системсная валидация
    /// </summary>
    public class DrugItem : BaseEntity
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
        public int Count { get; private set; }
    }
}