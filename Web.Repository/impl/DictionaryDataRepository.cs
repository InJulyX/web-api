using System;
using System.Collections.Generic;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class DictionaryDataRepository : IDictionaryDataRepository
    {
        public List<DictionaryData> GetDictDataList(DictionaryData data, int pageNum, int pageSize, ref int total)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<DictionaryData>()
                .WhereIF(data.DictCode > 0, d => d.DictCode == data.DictCode)
                .WhereIF(!string.IsNullOrEmpty(data.DictLabel), d => d.DictLabel == data.DictLabel)
                .WhereIF(!string.IsNullOrEmpty(data.DictType), d => d.DictType == data.DictType)
                .ToPageList(pageNum, pageSize, ref total);
            return result;
        }

        public int Insert(DictionaryData data)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(data)
                .IgnoreColumns(it => new {it.CreateTime})
                .IgnoreColumns(true)
                .ExecuteCommand();
            return rows;
        }

        public int Update(DictionaryData data)
        {
            using var db = SqlSugarHelper.GetInstance();
            var rows = db.Updateable(data)
                .IgnoreColumns(it => new {it.CreateTime, it.CreateBy})
                .IgnoreColumns(true)
                .Where(it => it.DictCode == data.DictCode)
                .ExecuteCommand();
            return rows;
        }

        public int Delete(DictionaryData data)
        {
            using var db = SqlSugarHelper.GetInstance();
            var result = db.Deleteable<DictionaryData>()
                .Where(it => it.DictCode == data.DictCode)
                .ExecuteCommand();
            return result;
        }

        public IEnumerable<DictionaryData> GetDictDataList(DictionaryData data)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<DictionaryData>()
                .WhereIF(!string.IsNullOrEmpty(data.DictType), it => it.DictType == data.DictType)
                .ToList();
            return result;
        }

        public bool IsExist(DictionaryData data)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<DictionaryData>()
                .Where(it => it.DictType == data.DictType)
                .Where(it => it.DictLabel == data.DictLabel || it.DictValue == data.DictValue)
                .WhereIF(data.DictCode != null, it => it.DictCode != data.DictCode)
                .Any();
            return result;
        }

        public DictionaryData GetDictData(DictionaryData data)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<DictionaryData>()
                .WhereIF(data.DictCode != null, it => it.DictCode == data.DictCode)
                .First();
            return result;
        }

        public Tuple<int, IEnumerable<DictionaryData>> GetDictDataListToPage(DictionaryData data)
        {
            var db = SqlSugarHelper.GetInstance();
            var count = 0;
            var result = db.Queryable<DictionaryData>()
                .WhereIF(!string.IsNullOrEmpty(data.DictType), it => it.DictType == data.DictType)
                .ToPageList(data.PageNum, data.PageSize, ref count);
            return new Tuple<int, IEnumerable<DictionaryData>>(count, result);
        }
    }
}