using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EventSourcing
{
    public abstract class EventSourced
    {
        private readonly string streamType;

        public EventSourced()
        {
            this.streamType = this.GetType().Name;
        }

        public string StreamType => this.streamType;

        public string Id { get; protected set; } = null!;
    }
}
