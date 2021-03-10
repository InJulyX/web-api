using System;
using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface IDictionaryDataRepository
    {
        // List<DictionaryData> GetDictDataList(DictionaryData data);
        List<DictionaryData> GetDictDataList(DictionaryData data, int pageNum, int pageSize, ref int total);
        int Insert(DictionaryData data);
        int Update(DictionaryData data);
        int Delete(DictionaryData data);
        DictionaryData GetDictData(DictionaryData data);
        IEnumerable<DictionaryData> GetDictDataList(DictionaryData data);
        bool IsExist(DictionaryData data);
        Tuple<int, IEnumerable<DictionaryData>> GetDictDataListToPage(DictionaryData data);
    }
}