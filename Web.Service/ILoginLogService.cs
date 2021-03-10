using System;
using System.Collections.Generic;
using Web.Model.Database;
using Web.Model.VO;

namespace Web.Service
{
    public interface ILoginLogService
    {
        void Insert(LoginLog loginLog);
        Tuple<int, IEnumerable<LoginLogVo>> GetLoginLogListToPage(LoginLog loginLog);
    }
}