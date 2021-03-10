using System;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("api_log")]
    public class ApiLog
    {
        public long? Id { get; set; }
        public string Username { get; set; }
        public string RequestPath { get; set; }
        public string RequestParams { get; set; }
        public string RequestMethod { get; set; }
        public int UseTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}