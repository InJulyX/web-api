using System.Collections.Generic;
using Web.Model;
using Web.Model.Database;

namespace Web.Service
{
    public interface IDictDataService
    {
        /// <summary>
        ///     根据类型查询字典数据
        /// </summary>
        /// <param name="dictType"></param>
        /// <returns></returns>
        IEnumerable<DictionaryData> GetDataInfoByDictType(string dictType);

        /// <summary>
        ///     更新字典数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AjaxResult<int> UpdateDictData(DictionaryData data);

        /// <summary>
        ///     根据ID查询字典数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DictionaryData GetDictDataById(long id);

        /// <summary>
        ///     根据ID删除字典数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteDictDataById(long id);

        /// <summary>
        ///     添加字典数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AjaxResult<int> AddDictData(DictionaryData data);

        /// <summary>
        ///     查询字典分页数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AjaxResult<IEnumerable<DictionaryData>> GetDictDataListToPage(DictionaryData data);
    }
}