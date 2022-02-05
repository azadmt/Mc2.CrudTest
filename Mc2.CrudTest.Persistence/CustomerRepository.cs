using Framework.Core.Persistence;
using Mc2.CrudTest.Domain;
using System;

namespace Mc2.CrudTest.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEventStore eventStore;

        public CustomerRepository(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        public Customer Get(string customerId)
        {
            //TODO : Implement Snapshot
            var eventStream = eventStore.GetStream<Customer>(customerId, 0, int.MaxValue);
            var customr = new Customer();
            foreach (var domainEvent in eventStream)
            {
                customr.Apply(domainEvent);
            }
            return customr;
        }

        public void Save(Customer customer)
        {
            eventStore.CreateNewStream<Customer>(customer.Id.DbId, customer.Changes);
        }


    }
}
