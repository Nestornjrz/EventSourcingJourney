namespace Core
{
    public class EventStoreSubscription
    {
        private readonly int? lastProcessedEventNumber;
        private readonly Action<int, EventData> handler;
        private readonly Action<EventStoreSubscription> stop;

        public EventStoreSubscription(int? lastProcessedEventNumber, Action<int, EventData> handler, Action<EventStoreSubscription> stop)
        {
            this.lastProcessedEventNumber = lastProcessedEventNumber;
            this.handler = handler;
            this.stop = stop;
        }

        public void Stop() => this.stop(this);

        internal void Dispatch(int eventNumber, EventData e)
        {
            if (eventNumber > this.lastProcessedEventNumber)
                this.handler(eventNumber, e);
        }
    }
}
