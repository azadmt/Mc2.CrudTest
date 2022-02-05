using Mc2.CrudTest.Application.Contract.Customer;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Mc2.CrudTest.Spec.CustomerManagement
{
    [Binding]
    public class CustomerRegisterationSteps
    {
        private RegisterCustomerCommand _registerCustomerCommand;
        private Domain.Customer _customer;
        private Exception _actualException;
        [Given(@"I want Register as a new customer")]
        public void GivenIWantRegisterAsANewCustomer()
        {

        }

        [When(@"I register with following data")]
        public void WhenIRegisterWithFollowingData(Table table)
        {
            _registerCustomerCommand = table.CreateInstance<RegisterCustomerCommand>();
            try
            {
                _customer = Domain.Customer.CreateCustomer(
                          _registerCustomerCommand.FirstName,
                          _registerCustomerCommand.LastName,
                          _registerCustomerCommand.DateOfBirth,
                          _registerCustomerCommand.BankAccountNumber,
                          _registerCustomerCommand.PhoneNumber,
                          _registerCustomerCommand.EmailAddress);
            }
            catch (Exception ex)
            {
                _actualException = ex;
            }
       
        }

        [Then(@"I must be registered as new customer")]
        public void ThenIMustBeRegisteredAsNewCustomer()
        {
            Assert.NotNull(_customer.Id);
        }

        [Then(@"I must Get Invalid PhonNumber Error")]
        public void ThenIMustGetInvalidPhonNumberError()
        {
            var expectedMessage = $"{_registerCustomerCommand.PhoneNumber} is not a valid mobile number!!!";

            Assert.Equal(expectedMessage, _actualException.Message);
        }

        [Then(@"I must Get Invalid EmailAddress Error")]
        public void ThenIMustGetInvalidEmailAddressError()
        {
            var expectedMessage = $"{_registerCustomerCommand.EmailAddress} is not valid!!!";

            Assert.Equal(expectedMessage, _actualException.Message);
        }

    }
}
