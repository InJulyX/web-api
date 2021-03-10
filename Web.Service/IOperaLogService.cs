using System;
using System.Collections.Generic;
using Web.Model.Database;
using Web.Model.VO;

namespace Web.Service
{
    public interface IOperaLogService
    {
        Tuple<int, IEnumerable<OperaLogVo>> GetOperaLogListToPage(OperaLog operaLog);
    }
}