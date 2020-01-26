using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.DBAdapter
{
        public interface IDataSource
        {
                T QueryFirst<T>();
                T QueryFirst<T>(string sql);
                object QueryFirst(Type type);
                object QueryFirst(string sql, Type type);

                T QueryFirstOrDefault<T>();
                T QueryFirstOrDefault<T>(string sql);
                object QueryFirstOrDefault(Type type);
                object QueryFirstOrDefault(string sql, Type type);

                IEnumerable<T> Query<T>();
                IEnumerable<T> Query<T>(string sql);
                IEnumerable<object> Query(Type type);
                IEnumerable<object> Query(string sql, Type type);

                void Insert(params object[] objs);
                void Inserts(params IEnumerable<object>[] items);

                int Execute(string sql, object param = null, bool istran = true);
                object ExecuteScalar(string sql, object param = null, bool istran = true);
                List<object> ExecuteScalarMany(params string[] sqls);
                T ExecuteScalar<T>(string sql, object param = null, bool istran = true);
        }
}
