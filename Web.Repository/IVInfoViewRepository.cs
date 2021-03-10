using System.Collections.Generic;
using Web.Model.View;

namespace Web.Repository
{
    public interface IInfoViewRepository
    {
        IEnumerable<VInfo> GetListToPage(int pageNum, int pageSize, VInfo vInfo, ref int count);
    }
}