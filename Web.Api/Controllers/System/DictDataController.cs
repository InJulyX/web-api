using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Model;
using Web.Model.Database;
using Web.Service;

namespace Web.Api.Controllers.System
{
    [Route("/system/dict/data")]
    public class DictDataController : BaseController
    {
        private readonly IDictDataService _dictDataService;

        public DictDataController(IDictDataService dictDataService)
        {
            _dictDataService = dictDataService;
        }

        [Route("type/{dictType}")]
        [HttpGet]
        public AjaxResult<IEnumerable<DictionaryData>> GetDataInfo(string dictType)
        {
            var result = _dictDataService.GetDataInfoByDictType(dictType);
            return AjaxResult<IEnumerable<DictionaryData>>.Success(result);
        }

        [Route("list")]
        [HttpGet]
        public AjaxResult<IEnumerable<DictionaryData>> GetDictDataListToPage(DictionaryData data)
        {
            return _dictDataService.GetDictDataListToPage(data);
        }

        [HttpPost]
        [Log("字典管理", "添加字典数据")]
        public AjaxResult<int> AddDictData([FromBody] DictionaryData data)
        {
            return _dictDataService.AddDictData(data);
        }

        [HttpDelete]
        [Log("字典管理", "删除字典数据")]
        [Route("{dictDataId}")]
        public AjaxResult<int> DeleteDictData(long dictDataId)
        {
            var result = _dictDataService.DeleteDictDataById(dictDataId);
            return AjaxResult<int>.Success(result);
        }

        [Route("{dictDataId}")]
        [HttpGet]
        public AjaxResult<DictionaryData> GetDictData(long dictDataId)
        {
            var result = _dictDataService.GetDictDataById(dictDataId);
            return AjaxResult<DictionaryData>.Success(result);
        }

        [HttpPut]
        [Log("字典管理", "更新字典数据")]
        public AjaxResult<int> UpdateDictData([FromBody] DictionaryData data)
        {
            return _dictDataService.UpdateDictData(data);
        }
    }
}