using Mc2.CrudTest.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Contract
{
    public class RegisterCustomerModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]        
        public string BankAccountNumber { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
    }


}
