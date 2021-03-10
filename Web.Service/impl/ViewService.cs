using Web.Model;
using Web.Model.View;
using Web.Repository;

namespace Web.Service.impl
{
    public class ViewService : IViewService
    {
        private readonly IInfoViewRepository _infoViewRepository;

        public ViewService(IInfoViewRepository infoViewRepository)
        {
            _infoViewRepository = infoViewRepository;
        }

        public AjaxResult<object> GetVInfoListToPage(int pageNum, int pageSize, VInfo vInfo)
        {
            var count = 0;
            var result = _infoViewRepository.GetListToPage(pageNum, pageSize, vInfo, ref count);
            return AjaxResult<object>.Success(count, result);
        }
    }
}