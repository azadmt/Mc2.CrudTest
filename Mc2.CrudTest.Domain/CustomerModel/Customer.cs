using Framework.Core.Bus;
using Framework.Domain;
using Mc2.CrudTest.Domain.Contract;
using Mc2.CrudTest.Shared;
using System;

namespace Mc2.CrudTest.Domain
{
    public class Customer : EventSourcedAggregate<CustomerId>
    {   
        public Customer()
        {

        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public BankAccountNumber BankAccountNumber { get; private set; }
        public MobileNumber PhoneNumber { get; private set; }
        public EmailAddress EmailAddress { get; private set; }

        public static Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, string bankAccountNumber, string phoneNumber, string emailAddress)
        {
            var customer = new Customer();
            customer.Causes(new CustomerRegistredEvent(firstName, lastName, dateOfBirth, bankAccountNumber, phoneNumber, emailAddress));
            return customer;
        }

        private void When(CustomerRegistredEvent @event)
        {
            Id = new CustomerId(@event.FirstName, @event.LastName, @event.DateOfBirth);
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            DateOfBirth = @event.DateOfBirth;
            BankAccountNumber = BankAccountNumber.Create(@event.BankAccountNumber);
            EmailAddress = EmailAddress.Create(@event.EmailAddress);
            PhoneNumber = MobileNumber.Create(@event.PhoneNumber);
        }
        private void Causes(IDomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }
        public override void Apply(IDomainEvent domainEvent)
        {
            When((dynamic)domainEvent);
            Version += 1;
        }
    }
}
