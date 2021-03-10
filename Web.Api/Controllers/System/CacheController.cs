using Microsoft.AspNetCore.Mvc;
using Web.Model;

namespace Web.Api.Controllers.System
{
    public class CacheController : BaseController
    {
        [HttpDelete]
        [Route("/system/dict/type/clearCache")]
        [Log("缓存管理", "清除字典缓存")]
        public AjaxResult<object> ClearDictCache()
        {
            // TODO 删除指定前缀的缓存
            var s1 = RedisHelper.Keys("dict_data:*");
            foreach (var s in s1) RedisHelper.DelAsync(s);

            return AjaxResult<object>.Success();
        }
    }
}