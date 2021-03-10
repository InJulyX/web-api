using System;
using SqlSugar;

namespace Web.Model.Database
{
    public class BaseModel
    {
        /// <summary>
        ///     查询条件: 开始时间
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        ///     查询条件: 结束时间
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        ///     分页条件: pageSize
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int PageSize { get; set; }

        /// <summary>
        ///     分页条件: pageNum
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int PageNum { get; set; }
    }
}