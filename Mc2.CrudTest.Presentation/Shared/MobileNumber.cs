using Framework.Domain;
using PhoneNumbers;
using System;
using System.Collections.Generic;

namespace Mc2.CrudTest.Shared
{
    public class MobileNumber : ValueObject
    {
        public string Value { get; private set; }

        private MobileNumber(string number)
        {
            Value = number;
        }


        public static MobileNumber Create(string number)
        {    
            if (!IsValid(number))
                throw new ArgumentException($"{number} is not a valid mobile number!!!");

            return new MobileNumber(number);
        }

        public static bool IsValid(string number)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var mobileNumber = GetPhoneNumber(number);
                return (phoneUtil.IsValidNumber(mobileNumber) && phoneUtil.GetNumberType(mobileNumber) == PhoneNumberType.MOBILE);

            }
            catch
            {
                return false;
            }

        }

        private static PhoneNumber GetPhoneNumber(string number)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                return phoneUtil.Parse(number, null);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{number} is not a valid mobile number!!!{ex.Message}",ex);
            }
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
