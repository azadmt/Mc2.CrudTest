using Framework.Core.Bus;
using System;

namespace Mc2.CrudTest.Domain.Contract
{
    public class CustomerRegistredEvent : EventBase
    {
        public CustomerRegistredEvent(string firstName, string lastName, DateTime dateOfBirth, string bankAccountNumber,string phoneNumber,string emailAddress)
        {
            Id = $"{firstName}_{lastName}_{dateOfBirth.Ticks}"; 
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            BankAccountNumber = bankAccountNumber;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string BankAccountNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
    }
}
