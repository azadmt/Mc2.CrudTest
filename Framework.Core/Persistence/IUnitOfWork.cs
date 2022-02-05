using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }


}
