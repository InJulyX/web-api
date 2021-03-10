using System.Collections.Generic;
using SqlSugar;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class OperaLogRepository : IOperaLogRepository
    {
        public int Insert(OperaLog operaLog)
        {
            using var db = SqlSugarHelper.GetInstance();

            var result = db.Insertable(operaLog)
                .IgnoreColumns(it => new {it.CreateTime})
                .ExecuteCommand();
            return result;
        }

        public IEnumerable<OperaLog> GetOperaLogListToPage(OperaLog operaLog, ref int count)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<OperaLog>()
                .WhereIF(operaLog.BeginTime != null, it => it.CreateTime >= operaLog.BeginTime)
                .WhereIF(operaLog.EndTime != null, it => it.CreateTime <= operaLog.EndTime)
                .WhereIF(!string.IsNullOrEmpty(operaLog.Username), it => it.Username == operaLog.Username)
                .WhereIF(!string.IsNullOrEmpty(operaLog.Module), it => it.Module == operaLog.Module)
                .OrderBy(it => it.Id, OrderByType.Desc)
                .ToPageList(operaLog.PageNum, operaLog.PageSize, ref count);
            return result;
        }
    }
}