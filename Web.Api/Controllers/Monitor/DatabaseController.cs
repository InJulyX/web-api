using Microsoft.AspNetCore.Mvc;
using Web.Model;
using Web.Model.View;
using Web.Service;

namespace Web.Api.Controllers.Monitor
{
    [Route("/monitor/database")]
    public class DatabaseController : BaseController
    {
        private readonly IViewService _viewService;

        public DatabaseController(IViewService viewService)
        {
            _viewService = viewService;
        }

        [HttpGet]
        [Route("list")]
        public AjaxResult<object> GetListToPage(int pageNum, int pageSize, VInfo info)
        {
            return _viewService.GetVInfoListToPage(pageNum, pageSize, info);
        }
    }
}