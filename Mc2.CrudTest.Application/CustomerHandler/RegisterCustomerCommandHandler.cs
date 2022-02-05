using Framework.Core.Bus;
using Framework.Core.Persistence;
using Mc2.CrudTest.Application.Contract.Customer;
using Mc2.CrudTest.Domain;
using System;

namespace Mc2.CrudTest.Application.CustomerHandler
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
      
    {
        private readonly ICustomerRepository customerRepository;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Handle(RegisterCustomerCommand command)
        {
            var customer = Customer.CreateCustomer(
                command.FirstName, 
                command.LastName,
                command.DateOfBirth,
                command.BankAccountNumber,
                command.PhoneNumber,
                command.EmailAddress);
            customerRepository.Save(customer);
        }
    }
}
