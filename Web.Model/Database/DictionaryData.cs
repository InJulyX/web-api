using System;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("dict_data")]
    public class DictionaryData
    {
        [SugarColumn(ColumnName = "dict_code", IsIdentity = true, IsPrimaryKey = true)]
        public long? DictCode { get; set; }

        [SugarColumn(ColumnName = "dict_sort")]
        public int DictSort { get; set; }

        [SugarColumn(ColumnName = "dict_label")]
        public string DictLabel { get; set; }

        [SugarColumn(ColumnName = "dict_value")]
        public string DictValue { get; set; }

        [SugarColumn(ColumnName = "dict_type")]
        public string DictType { get; set; }

        [SugarColumn(ColumnName = "list_class")]
        public string ListClass { get; set; }

        [SugarColumn(ColumnName = "is_default")]
        public string IsDefault { get; set; }

        [SugarColumn(ColumnName = "remark")] public string Remark { get; set; }

        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; }

        [SugarColumn(ColumnName = "status")] public string Status { get; set; }
        [SugarColumn(IsIgnore = true)] public int PageNum { get; set; }
        [SugarColumn(IsIgnore = true)] public int PageSize { get; set; }
    }
}