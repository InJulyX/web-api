using System;
using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace Web.Common
{
    public class SqlSugarHelper
    {
        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = AppConfigHelper.Configuration.GetConnectionString("PgSQL"),
                DbType = DbType.PostgreSQL,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
                ConfigureExternalServices = new ConfigureExternalServices
                {
                    EntityNameService = (_, info) => { info.DbTableName = "public." + info.DbTableName; }
                },
                MoreSettings = new ConnMoreSettings
                {
                    PgSqlIsAutoToLower = false
                }
            });
            // sql执行前事件
            db.Aop.OnLogExecuting = (sql, param) =>
            {
                // Console.WriteLine("SQL 开始时间: " + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒fff毫秒"));
                //Console.WriteLine("SQL语句: " + sql);
                //Console.WriteLine("参数: " +
                //string.Join("\n参数: ", param.Select(it => it.ParameterName + " => " + it.Value)));
            };
            // sql执行完
            db.Aop.OnLogExecuted = (sql, param) =>
            {
                // Console.WriteLine("SQL语句: " + sql);
                // Console.WriteLine("参数: " +
                // string.Join("\n参数: ", param.Select(it => it.ParameterName + " => " + it.Value)));
                // Console.WriteLine("SQL 结束时间: "+DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒fff毫秒"));
            };
            // sql错误事件
            db.Aop.OnError = exp => { Console.WriteLine(exp.Sql); };
            return db;
        }
    }
}