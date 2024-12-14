using Domain.Validators;
using Domain.ValueObjects;


namespace Domain.Entities;

/// <summary>
/// BaseEntity поля были изменены 
/// </summary>
public sealed class Profile : BaseEntity<Profile>
{
    public Profile(string externalId, Email? email)
    {
        ExternalId = externalId;
        Email = email;

        ValidateEntity(new ProfileValidator());
    }

    /// <summary>
    /// Имя профиля
    /// </summary>
    public string ExternalId { get; private set; }
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email? Email { get; private set; }

    /// <summary>
    /// Навигационное свойство для связи с FavoriteDrug.
    /// </summary>
    public List<FavoriteDrug> FavoriteDrugs { get; private set; } = [];
}