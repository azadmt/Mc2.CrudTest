
using System;
using FluentValidation;
using Mc2.CrudTest.Shared;
using Framework.Core.Bus;
using System.Collections.Generic;

namespace Mc2.CrudTest.Application.Contract.Customer
{
    public class RegisterCustomerCommand : CommandBase
    {
        List<ValidationRule> validationRules = new List<ValidationRule>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public override void RunValidationRules()
        {
            //TODO Fluent Validation
            if(string.IsNullOrEmpty(FirstName))
                AddError("FirstName is Rquired");

            if (string.IsNullOrEmpty(LastName))
                AddError("LastName is Rquired");

            if (DateOfBirth==DateTime.MinValue || DateOfBirth>DateTime.Now)
                AddError("DateOfBirth is invalid");

            if (!Mc2.CrudTest.Shared.EmailAddress.IsValid(EmailAddress))
                AddError("EmailAddress is invalid");

            if (!MobileNumber.IsValid(PhoneNumber))
                AddError("PhoneNumber is invalid");

            if (!Shared.BankAccountNumber.IsValid(BankAccountNumber))
                AddError("BankAccountNumber is invalid");
        }
    }

    class ValidationRule
    {
        public ValidationRule(Func<bool> predicate, string message)
        {
            Predicate = predicate;
            Message = message;
        }
        public Func<bool> Predicate { get; set; }
        public string Message { get; set; }
    }
    public class CustomerValidator : AbstractValidator<RegisterCustomerCommand>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEqual(DateTime.MinValue);
            RuleFor(x => x.EmailAddress).Must(p => EmailAddress.IsValid(p));
            RuleFor(x => x.PhoneNumber).Must(p => MobileNumber.IsValid(p));
            RuleFor(x => x.BankAccountNumber).Must(p => BankAccountNumber.IsValid(p));
        }
    }

}
