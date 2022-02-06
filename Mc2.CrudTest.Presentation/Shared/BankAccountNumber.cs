using Framework.Domain;
using System.Collections.Generic;

namespace Mc2.CrudTest.Shared
{
    public class BankAccountNumber : ValueObject
    {
        public string Value { get; private set; }

        public BankAccountNumber(string number)
        {
            Value = number;
        }
        public static BankAccountNumber Create(string number)
        {
            return new BankAccountNumber(number);
        }
        //I dont find  account number validate rule in task definition!!
        public static bool IsValid(string number)
        {
            return true;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
