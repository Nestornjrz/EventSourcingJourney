﻿namespace Core
{
    public class EventStore
    {
        private Dictionary<int, EventData> txlog = new Dictionary<int, EventData>();
        private List<EventStoreSubscription> subscriptions = new List<EventStoreSubscription>();

        public List<EventData> ReadStream(string streamType, string streamId) =>
            this.txlog
            .Values
            .Where(x => x.StreamId == streamId && x.StreamType == streamType)
            .OrderBy(x => x.StreamVersion)
            .ToList();

        public void AppendStream(string streamType, string streamId, List<EventData> events, int? expectedVersion = null)
        {
            if (!events.Any())
                throw new NotImplementedException();

            int? streamLastVersion = null;
            if (this.txlog.Values.Any())
                streamLastVersion = this.txlog.Values
                   .Where(x => x.StreamType == streamType && x.StreamId == streamId)
                   .OrderByDescending(x => x.StreamVersion)
                   .FirstOrDefault()
                   ?.StreamVersion;


            if (streamLastVersion != expectedVersion)
                throw new Exception("Unexpected stream version");

            int currentVersion = streamLastVersion ?? -1;
            events.ForEach(e =>
            {
                var eventNumber = txlog.Keys.Count;
                e.StreamVersion = ++currentVersion;
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
