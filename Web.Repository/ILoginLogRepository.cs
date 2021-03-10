using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ILoginLogRepository
    {
        int Insert(LoginLog loginLog);
        IEnumerable<LoginLog> SelectListToPage(int pageNum, int pageSize, LoginLog loginLog, ref int total);
        IEnumerable<LoginLog> GetLoginLogListToPage(LoginLog loginLog, ref int count);
    }
}