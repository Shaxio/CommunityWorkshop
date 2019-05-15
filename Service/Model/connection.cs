using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SQLite;
using System.IO;

namespace Model
{
    public class Connection
    {
        const string dbName = "database.db";
        const string query = "query.sql";
        public static SQLiteConnection GetConnection()
        {
            var dbPath = HttpContext.Current.Server.MapPath($"~/App_Data/{dbName}");
            var connectionString = $"Data Source ={dbPath}";
            return new SQLiteConnection(connectionString);
        }
        public static void CreateDB()
        {
            using (var db = GetConnection())
            {
                var queryPath = HttpContext.Current.Server.MapPath($"~/App_Data/{query}");
                var queries = File.ReadAllText(queryPath);
                db.Execute(queries);
            }
        }
    }
}