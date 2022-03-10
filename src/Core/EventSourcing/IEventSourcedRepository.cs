namespace Core.EventSourcing
{
    public interface IEventSourcedRepository
    {
        T? Get<T>(string streamId) where T : EventSourced, new();
        void Save<T>(T eventSourced) where T : EventSourced;
    }
}