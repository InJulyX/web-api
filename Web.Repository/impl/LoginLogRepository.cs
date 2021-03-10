using System.Collections.Generic;
using SqlSugar;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class LoginLogRepository : ILoginLogRepository
    {
        public int Insert(LoginLog loginLog)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Insertable(loginLog)
                .IgnoreColumns(true)
                .IgnoreColumns(it => new {it.LoginTime, it.Id})
                .ExecuteCommand();
            return result;
        }

        public IEnumerable<LoginLog> SelectListToPage(int pageNum, int pageSize, LoginLog loginLog, ref int total)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<LoginLog>()
                .WhereIF(!string.IsNullOrEmpty(loginLog.Username), it => it.Username == loginLog.Username)
                .WhereIF(loginLog.Status != null, it => it.Status == loginLog.Status)
                .WhereIF(!string.IsNullOrEmpty(loginLog.ClientIp), it => it.ClientIp.Contains(loginLog.ClientIp))
                .WhereIF(loginLog.BeginTime != null, it => it.LoginTime >= loginLog.BeginTime)
                .WhereIF(loginLog.EndTime != null, it => it.LoginTime <= loginLog.EndTime)
                .OrderBy(it => it.Id, OrderByType.Desc)
                .ToPageList(pageNum, pageSize, ref total);
            return result;
        }

        public IEnumerable<LoginLog> GetLoginLogListToPage(LoginLog loginLog, ref int count)
        {
            var db = SqlSugarHelper.GetInstance();
            return
                db.Queryable<LoginLog>()
                    .WhereIF(!string.IsNullOrEmpty(loginLog.Username), it => it.Username == loginLog.Username)
                    .WhereIF(loginLog.Status != null, it => it.Status == loginLog.Status)
                    .WhereIF(!string.IsNullOrEmpty(loginLog.ClientIp), it => it.ClientIp.Contains(loginLog.ClientIp))
                    .WhereIF(loginLog.BeginTime != null, it => it.LoginTime >= loginLog.BeginTime)
                    .WhereIF(loginLog.EndTime != null, it => it.LoginTime <= loginLog.EndTime)
                    .OrderBy(it => it.Id, OrderByType.Desc)
                    .ToPageList(loginLog.PageNum, loginLog.PageSize, ref count);
        }
    }
}