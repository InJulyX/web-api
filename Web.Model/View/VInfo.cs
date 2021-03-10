using System;
using SqlSugar;

namespace Web.Model.View
{
    [SugarTable("v_info")]
    public class VInfo
    {
        /// <summary>
        ///     数据库
        /// </summary>
        [SugarColumn(ColumnName = "database")]
        public string Database { get; set; }

        /// <summary>
        ///     模式
        /// </summary>
        [SugarColumn(ColumnName = "schema")]
        public string Schema { get; set; }

        /// <summary>
        ///     表
        /// </summary>
        [SugarColumn(ColumnName = "table_name")]
        public string TableName { get; set; }

        /// <summary>
        ///     索引大小
        /// </summary>
        [SugarColumn(ColumnName = "index_size")]
        public string IndexSize { get; set; }

        /// <summary>
        ///     数据大小
        /// </summary>
        [SugarColumn(ColumnName = "table_size")]
        public string TableSize { get; set; }

        /// <summary>
        ///     总大小
        /// </summary>
        [SugarColumn(ColumnName = "total_size")]
        public string TotalSize { get; set; }

        /// <summary>
        ///     数据行数
        /// </summary>
        [SugarColumn(ColumnName = "table_rows")]
        public long TableRows { get; set; }

        /// <summary>
        ///     字段数量
        /// </summary>
        [SugarColumn(ColumnName = "column_count")]
        public long ColumnCount { get; set; }

        /// <summary>
        ///     索引数量
        /// </summary>
        [SugarColumn(ColumnName = "index_count")]
        public long IndexCount { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }

        /// <summary>
        ///     类型
        /// </summary>
        [SugarColumn(ColumnName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        ///     上一次统计更新时间
        /// </summary>
        [SugarColumn(ColumnName = "last_analyze")]
        public DateTime? LastAnalyze { get; set; }
    }
}