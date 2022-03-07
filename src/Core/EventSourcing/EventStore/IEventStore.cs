
namespace Core
{
    public interface IEventStore
    {
        void AppendStream(string streamType, string streamId, List<EventData> events, int expectedVersion);
        EventStoreSubscription CreateSubscription(int? lastProcessedEventNumber, Action<int, EventData> handler);
        List<EventData> ReadStream(string streamType, string streamId);
    }
}