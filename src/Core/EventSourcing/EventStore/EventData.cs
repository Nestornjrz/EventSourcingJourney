namespace Core
{
    public class EventData
    {
        public string StreamType { get; set; }
        public string StreamId { get; set; }
        public int StreamVersion { get; set; }
        public object Payload { get; set; }
    }
}
