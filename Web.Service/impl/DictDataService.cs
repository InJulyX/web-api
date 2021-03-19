using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Web.Common;
using Web.Model;
using Web.Model.Database;
using Web.Repository;

namespace Web.Service.impl
{
    public class DictDataService : IDictDataService
    {
        private readonly IDictionaryDataRepository _dictionaryDataRepository;
        private readonly ILogger<DictDataService> _logger;
        private readonly IRedisHelper _redisClient;

        public DictDataService(IDictionaryDataRepository dictionaryDataRepository, ILogger<DictDataService> logger,
            IRedisHelper redisClient)
        {
            _dictionaryDataRepository = dictionaryDataRepository;
            _logger = logger;
            _redisClient = redisClient;
        }

        public IEnumerable<DictionaryData> GetDataInfoByDictType(string dictType)
        {
            var result = RedisHelper.Get<IEnumerable<DictionaryData>>("dict_data:" + dictType);
            if (result == null)
            {
                var data = _dictionaryDataRepository.GetDictDataList(new DictionaryData {DictType = dictType});
                RedisHelper.SetAsync("dict_data:" + dictType, data);
                _logger.LogDebug("数据 {} 从数据库获取。", dictType);
                return data;
            }

            return result;
        }

        public AjaxResult<int> UpdateDictData(DictionaryData data)
        {
            if (_dictionaryDataRepository.IsExist(data))
            {
                _logger.LogDebug("字典 {}.{} 已存在。", data.DictType, data.DictLabel);

                // todo 定义错误返回值
                throw new Exception("字典已存在");
            }

            var result = _dictionaryDataRepository.Update(data);

            RedisHelper.SetAsync("dict_data:" + data.DictType,
                _dictionaryDataRepository.GetDictDataList(new DictionaryData {DictType = data.DictType}));

            return AjaxResult<int>.Success(result);
        }

        public AjaxResult<int> AddDictData(DictionaryData data)
        {
            if (_dictionaryDataRepository.IsExist(data))
            {
                _logger.LogDebug("字典 {}.{} 已存在。", data.DictType, data.DictLabel);

                // todo 定义错误返回值
                throw new Exception("字典已存在");
            }

            var result = _dictionaryDataRepository.Insert(data);
            RedisHelper.SetAsync("dict_data:" + data.DictType,
                _dictionaryDataRepository.GetDictDataList(new DictionaryData {DictType = data.DictType}));
            return AjaxResult<int>.Success(result);
        }

        public DictionaryData GetDictDataById(long id)
        {
            return _dictionaryDataRepository.GetDictData(new DictionaryData {DictCode = id});
        }

        public int DeleteDictDataById(long id)
        {
            var dictData = GetDictDataById(id);
            var result = _dictionaryDataRepository.Delete(new DictionaryData {DictCode = id});

            RedisHelper.DelAsync("dict_data:" + dictData.DictType);
            return result;
        }

        public AjaxResult<IEnumerable<DictionaryData>> GetDictDataListToPage(DictionaryData data)
        {
            var (item1, item2) = _dictionaryDataRepository.GetDictDataListToPage(data);
            return AjaxResult<IEnumerable<DictionaryData>>.Success(item1, item2);
        }
    }
}