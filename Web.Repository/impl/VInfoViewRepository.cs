using System.Collections.Generic;
using SqlSugar;
using Web.Common;
using Web.Model.View;

namespace Web.Repository.impl
{
    public class InfoViewRepository : IInfoViewRepository
    {
        public IEnumerable<VInfo> GetListToPage(int pageNum, int pageSize, VInfo vInfo, ref int count)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<VInfo>()
                .Where(it => it.Kind == "r")
                .OrderBy(it => it.TableRows, OrderByType.Desc)
                .ToPageList(pageNum, pageSize, ref count);
            return result;
        }
    }
}