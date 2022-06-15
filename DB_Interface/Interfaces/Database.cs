using Dapper;
using Dapper.Contrib.Extensions;
using DB_Interface.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Interface.Interfaces
{
    public class Database
    {
        public static List<T> AllRecords<T>() where T : class, new()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {                
                var records = cnn.GetAll<T>().ToList();
                return records;
            }
        }

        public static T GetRecord<T>(long id) where T: class, new ()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Get<T>(id);
                return output;
            }
        }

        public static long CreateRecord<T>(T record) where T : class, new()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                long inserted = cnn.Insert<T>(record);
                return inserted;
            }
        }

        public static bool UpdateRecord<T>(T record) where T: class, new()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                bool updated = cnn.Update<T>(record);
                return updated;
            }
        }

        public static bool DeleteRecord<T>(T record) where T: class, new()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Delete(record);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
