using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

        public virtual bool IsEqual(ValueObject other)
        {
            if (other == null)
            {
                return false;
            }
            return GetAttributesToIncludeInEqualityCheck().SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {

            return GetAttributesToIncludeInEqualityCheck()
           .Select(x => x != null ? x.GetHashCode() : 0)
           .Aggregate((hash, item) => hash ^ item);
        }

        public override bool Equals(object obj)
        {
            return IsEqual((ValueObject)obj);
        }


    }
}
