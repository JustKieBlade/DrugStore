using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Событие удаления препарата из аптеки.
/// </summary>
internal class DrugItemRemovedEvent : IDomainEvent
{
    private readonly Guid? _drugId;
    private readonly Guid? _drugStoreId;

    internal DrugItemRemovedEvent(Guid? drugId, Guid? drugStoreId)
    {
        _drugId = drugId;
        _drugStoreId = drugStoreId;
    }
}