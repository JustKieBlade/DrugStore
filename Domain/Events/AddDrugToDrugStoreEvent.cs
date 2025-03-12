using Domain.Interfaces;

namespace Domain.Events;

internal class AddDrugToDrugStoreEvent : IDomainEvent
{

    internal AddDrugToDrugStoreEvent(Guid drugId, Guid drugStoreId, decimal cost, double count)
    {
        _drugId = drugId;
        _drugStoreId = drugStoreId;
        _cost = cost;
        _count = count;
    }

    private readonly Guid? _drugId;

    private readonly Guid? _drugStoreId;

    private readonly decimal? _cost;

    private readonly double? _count;
}