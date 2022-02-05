using System;
using System.Threading.Tasks;

namespace Framework.Core.Bus
{
    public interface IDomainEvent
    {
        DateTime OccurDate { get; set; }
    }

}
