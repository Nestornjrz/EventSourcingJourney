namespace Core.EventSourcing
{
    public abstract class EventSourced
    {
        private readonly string streamType;
        private readonly List<object> uncommitedEvents = new List<object>();
        private int version = -1;

        public EventSourced()
        {
            this.streamType = this.GetType().Name;
        }

        public string StreamType => this.streamType;

        public string Id { get; protected set; } = null!;

        public int Version => this.version;

        public List<object> GetUncommitedEvents()
        {
            var list = new List<object>();
            list.AddRange(this.uncommitedEvents);
            this.uncommitedEvents.Clear();
            return list;
        }

        public void Update(object @event)
        {
            this.Apply(@event);
            this.uncommitedEvents.Add(@event);
            this.version++;
        }

        protected abstract void Apply(object @event);
    }
}
