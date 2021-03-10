using Microsoft.AspNetCore.Mvc;
using Web.Model;
using Web.Model.Database;
using Web.Repository;
using Web.Service;

namespace Web.Api.Controllers.System
{
    [Route("/system/dict/type")]
    public class DictTypeController : BaseController
    {
        private readonly IDictionaryTypeRepository _dictionaryTypeRepository;
        private readonly IRedisService _redisService;

        public DictTypeController(IDictionaryTypeRepository dictionaryTypeRepository, IRedisService redisService)
        {
            _dictionaryTypeRepository = dictionaryTypeRepository;
            _redisService = redisService;
        }

        [Route("list")]
        [HttpGet]
        public AjaxResult<object> GetList(long pageNum, long pageSize, DictionaryType dictionaryType)
        {
            var s1 = _dictionaryTypeRepository.GetDictionaryTypeList(dictionaryType);
            return AjaxResult<object>.Success(s1);
        }

        [HttpPost]
        [Log("字典管理", "添加字典类型")]
        public AjaxResult<object> AddDictType([FromBody] DictionaryType dictionaryType)
        {
            var s1 = _dictionaryTypeRepository.Insert(dictionaryType);
            return AjaxResult<object>.Success(s1);
        }

        [HttpDelete]
        [Log("字典管理", "删除字典类型")]
        [Route("{dictId}")]
        public AjaxResult<object> DeleteDictType(long dictId)
        {
            var s1 = _dictionaryTypeRepository.Delete(dictId);
            return AjaxResult<object>.Success(s1);
        }

        [HttpGet]
        [Route("{dictID}")]
        public AjaxResult<DictionaryType> GetDictionaryType(long dictId)
        {
            var s1 = _dictionaryTypeRepository.GetDictionaryType(new DictionaryType {DictId = dictId});
            return AjaxResult<DictionaryType>.Success(s1);
        }

        [HttpPut]
        [Log("字典管理", "更新字典类型")]
        public AjaxResult<object> Put([FromBody] DictionaryType dictionaryType)
        {
            var s1 = _dictionaryTypeRepository.Update(dictionaryType);
            return AjaxResult<object>.Success(s1);
        }
    }
}