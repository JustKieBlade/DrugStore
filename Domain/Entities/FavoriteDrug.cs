namespace Domain.Entities;

/// <summary>
/// Избранный препарат
/// </summary>
public class FavoriteDrug : BaseEntity<FavoriteDrug>
{
    
    /// <summary>
    /// Конструкор
    /// </summary>
    public FavoriteDrug(Guid profileId, Guid drugId, Guid? drugStoreId, 
        Profile profile, Drug drug, DrugStore? drugStore = null)
    {
        ProfileId = profileId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Profile = profile;
        Drug = drug;
        DrugStore = drugStore;
    }

    /// <summary>
    /// Идентификатор профиля
    /// </summary>
    public Guid ProfileId { get; private set; }

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId { get; private set; }

    /// <summary>
    /// Идентификатор аптеки (необязательно)
    /// </summary>
    public Guid? DrugStoreId { get; private set; }

    /// <summary>
    /// Навигационное свойство к профилю
    /// </summary>
    public Profile Profile { get; private set; }

    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; }

    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore? DrugStore { get; private set; }
}