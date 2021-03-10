using Web.Model;
using Web.Model.View;

namespace Web.Service
{
    public interface IViewService
    {
        AjaxResult<object> GetVInfoListToPage(int pageNum, int pageSize, VInfo vInfo);
    }
}