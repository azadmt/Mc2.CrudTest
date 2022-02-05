using Framework.Core.Bus;
using Framework.Core.IOC;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Bus.MassTransit
{
    public class MassTransitBus : IEventBus
    {
        private readonly IBusControl _massTransitBus;
        public MassTransitBus(IBusControl massTransitBus)
        {
            _massTransitBus = massTransitBus;
        }

        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IDomainEvent
        {
           _massTransitBus.Publish(eventToPublish).GetAwaiter().GetResult();          
        }
    }
}
