using System.Collections.Generic;
using Xunit;

namespace Core.Tests
{
    public class GivenEventStore
    {
        private EventStore sut = new EventStore();

        [Fact]
        public void when_appending_stream_them_can_read()
        {
            // When
            var events = new List<EventData>() {
                new EventData()
                {
                    StreamType="Personas",
                    StreamId="1",
                    Payload="Lo que sea :)"
                },
                new EventData()
                {
                    StreamType="Personas",
                    StreamId="1",
                    Payload="Lo que sea 2 :)"
                },
                new EventData()
                {
                    StreamType="Personas",
                    StreamId="1",
                    Payload="Lo que sea 3 :)"
                }
             };
            this.sut.AppendStream("Personas", "1", events);

            // Them
            var streams = this.sut.ReadStream("Personas", "1");

            Assert.Collection(streams,
                x => Assert.Equal(0, x.StreamVersion),
                x => Assert.Equal(1, x.StreamVersion),
                x => Assert.Equal(2, x.StreamVersion));

            Assert.Equal(3, streams.Count);
        }
        [Fact]
        public void given_subscription_when_appending_stream_then_can_handle()
        {
            // Given
            var eventData = new EventData()
            {
                StreamType = "Personas",
                StreamId = "1",
                Payload = "Lo que sea :)"
            };
            var wasHanled = false;
            var sub = this.sut.CreateSubscription(null, (eventNumber, e) =>
            {
                Assert.Equal(0, eventNumber);
                Assert.Equal(eventData, e);
                wasHanled = true;
            });

            // When
            this.sut.AppendStream("Personas", "1", new List<EventData>() { eventData });

            Assert.True(wasHanled);
         }
    }

}