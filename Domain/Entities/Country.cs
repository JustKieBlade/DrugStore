using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity<Country>
    {
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// Системсная валидация
        /// </summary>
        /// <param name="name">Название страны.</param>
        /// <param name="code">Код страны.</param>
        public Country(string name, string code)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            Code = Guard.Against.NullOrWhiteSpace(code, nameof(code), ValidationMessage.NullOrWhiteSpaceMustNotBe);
            
            var validator = new CountryValidator();

            validator.Validate(this);
        }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }
        
        /// <summary>
        /// Навигационное свойство для связи с препаратами.
        /// </summary>
        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
        
    }
}