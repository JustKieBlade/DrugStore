using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Событие добавления нового препарата в аптеку.
/// </summary>
internal class DrugItemAddedEvent : IDomainEvent
{
    private readonly Guid _drugId;
    private readonly Guid _drugStoreId;
    private readonly decimal _cost;
    private readonly double _count;
    
    internal DrugItemAddedEvent(Guid drugId, Guid drugStoreId, decimal cost, double count)
    {
        _drugId = drugId;
        _drugStoreId = drugStoreId;
        _cost = cost;
        _count = count;
    }
}