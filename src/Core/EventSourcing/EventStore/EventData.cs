namespace Core
{
    public class EventData
    {
        public string StreamType { get; set; } = null!;
        public string StreamId { get; set; } = null!;
        public int StreamVersion { get; private set; }
        public object Payload { get; set; } = null!;

        internal void SetStreamVersionBeforeAppend(int streamVersion) => this.StreamVersion = streamVersion;
    }
}
