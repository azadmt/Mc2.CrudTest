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
            if (IsValidPhoneNumber(number, out PhoneNumberType? phoneNumberType) )
            {
                return phoneNumberType is PhoneNumberType.MOBILE or PhoneNumberType.FIXED_LINE_OR_MOBILE;
            }

            return false;
        }

        private static bool IsValidPhoneNumber(string number, out PhoneNumberType? phoneNumberType)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber mobileNumber = GetPhoneNumber(number);
                phoneNumberType = phoneUtil.GetNumberType(mobileNumber);
                return true;
            }
            catch
            {
                phoneNumberType = null;
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
