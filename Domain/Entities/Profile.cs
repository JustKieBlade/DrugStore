using System.Collections.ObjectModel;


namespace Domain.Entities;

/// <summary>
/// Профиль пользователя (Его не было в дз по сущностям, но было навигационное свойство
/// на этот объект в FavoriteDrug, поэтому вот он примерно накинутый)
/// </summary>
public class Profile : BaseEntity
{
    public Profile(string name)
    {
        Name = name;
        FavoriteDrugs = new Collection<FavoriteDrug>();
    }

    /// <summary>
    /// Имя профиля
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Избранные препараты
    /// </summary>
    public Collection<FavoriteDrug> FavoriteDrugs { get; private set; }
}