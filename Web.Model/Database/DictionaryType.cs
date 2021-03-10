using System;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("dict_type")]
    public class DictionaryType
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true, ColumnName = "dict_id")]
        public long DictId { get; set; }

        [SugarColumn(ColumnName = "dict_name")]
        public string DictName { get; set; }

        [SugarColumn(ColumnName = "dict_type")]
        public string DictType { get; set; }

        [SugarColumn(ColumnName = "remark")] public string Remark { get; set; }

        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        [SugarColumn(ColumnName = "status")] public string Status { get; set; }
    }
}