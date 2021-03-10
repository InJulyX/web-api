using System.Collections.Generic;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class DictionaryTypeRepository : IDictionaryTypeRepository
    {
        public List<DictionaryType> GetDictionaryTypeList(DictionaryType dictionaryType)
        {
            var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<DictionaryType>()
                .ToPageList(1, 10);
            return result;
        }

        public int Delete(long dictId)
        {
            var db = SqlSugarHelper.GetInstance();

            var result = db.Deleteable<DictionaryType>()
                .Where(o => o.DictId == dictId).ExecuteCommand();
            return result;
        }

        public DictionaryType GetDictionaryType(DictionaryType data)
        {
            var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<DictionaryType>()
                .WhereIF(data.DictId > 0, o => o.DictId == data.DictId)
                .First();
            return result;
        }

        public int Update(DictionaryType dictionaryType)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Updateable(dictionaryType)
                .UpdateColumns(it => new {it.DictName, it.DictType, it.Status, it.Remark})
                .ExecuteCommand();
            return result;
        }

        public int Insert(DictionaryType dictionaryType)
        {
            using var db = SqlSugarHelper.GetInstance();
            var result = db.Insertable(dictionaryType)
                .IgnoreColumns(true)
                .ExecuteCommand();
            return result;
        }
    }
}