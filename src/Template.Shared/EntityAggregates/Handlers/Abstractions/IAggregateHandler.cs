using System.Threading.Tasks;

namespace Template.Shared.EntityAggregates.Handlers.Abstractions
{
    /// <summary>
    /// Aggregate handler.
    /// </summary>
    public interface IAggregateHandler
    {
        IAggregateHandler SetNext(IAggregateHandler handler);
        object Handle(object aggregate);
        Task<IAggregateHandler> SetNextAsync(IAggregateHandler handler);
        Task<object> HandleAsync(object aggregate);
    }
}