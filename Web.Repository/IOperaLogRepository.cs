using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface IOperaLogRepository
    {
        int Insert(OperaLog operaLog);
        IEnumerable<OperaLog> GetOperaLogListToPage(OperaLog operaLog, ref int count);
    }
}