using System;
using System.Threading.Tasks;

namespace Framework.Core.Bus
{
    public abstract class EventBase : IDomainEvent
    {
        public DateTime OccurDate { get; set; } = DateTime.Now;
    }
}
