namespace Core
{
    public class EventStore : IEventStore
    {
        private Dictionary<int, EventData> txlog = new Dictionary<int, EventData>();
        private List<EventStoreSubscription> subscriptions = new List<EventStoreSubscription>();

        public List<EventData> ReadStream(string streamType, string streamId) =>
            this.txlog
            .Values
            .Where(x => x.StreamId == streamId && x.StreamType == streamType)
            .OrderBy(x => x.StreamVersion)
            .ToList();

        public void AppendStream(string streamType, string streamId, List<EventData> events, int expectedVersion)
        {
            if (!events.Any())
                throw new InvalidOperationException("No events to append");

            int streamLastVersion = -1;
            if (this.txlog.Values.Any())
                streamLastVersion = this.txlog.Values
                   .Where(x => x.StreamType == streamType && x.StreamId == streamId)
                   .OrderByDescending(x => x.StreamVersion)
                   .FirstOrDefault()
                   ?.StreamVersion ?? -1;


            if (streamLastVersion != expectedVersion)
                throw new Exception("Unexpected stream version");

            int currentVersion = streamLastVersion;
            events.ForEach(e =>
            {
                var eventNumber = txlog.Keys.Count;
                e.SetStreamVersionBeforeAppend(++currentVersion);
                this.txlog.Add(eventNumber, e);
                this.subscriptions.ForEach(x => x.Dispatch(eventNumber, e));
            });
        }

        public EventStoreSubscription CreateSubscription(int? lastProcessedEventNumber, Action<int, EventData> handler)
        {
            var sub = new EventStoreSubscription(lastProcessedEventNumber, handler, this.RemoveSubscription);
            this.subscriptions.Add(sub);
            return sub;
        }

        private void RemoveSubscription(EventStoreSubscription sub) =>
            this.subscriptions.Remove(sub);
    }
}
