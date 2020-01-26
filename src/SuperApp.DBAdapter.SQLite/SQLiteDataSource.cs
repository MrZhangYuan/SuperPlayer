using SuperApp.DBAdapter.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using Dapper;
using System.Collections.Concurrent;
using System.Collections;
using SuperApp.EntityFramework;

namespace SuperApp.DBAdapter.SQLite
{
        internal class SQLiteDataSource : IDataSource
        {
                private bool _isReading = false;
                private bool _isWriting = false;

                internal IDictionary<string, object> DBKeywords { get; set; }

                public static SQLiteDataSource Instance { get; }

                static SQLiteDataSource()
                {
                        Instance = new SQLiteDataSource();
                }
                private SQLiteDataSource()
                {

                }
                private T ExecureCore<T>(Func<T> func)
                {
                        if (SpinWait.SpinUntil(() => !this._isReading && !this._isWriting, TimeSpan.FromSeconds(10)))
                        {
                                try
                                {
                                        this._isWriting = true;
                                        return func();
                                }
                                finally
                                {
                                        this._isWriting = false;
                                }
                        }
                        else
                        {
                                throw new DataBaseExecuteTimeoutException();
                        }
                }

                private void ExecureCore(Action action)
                {
                        if (SpinWait.SpinUntil(() => !this._isReading && !this._isWriting, TimeSpan.FromSeconds(10)))
                        {
                                try
                                {
                                        this._isWriting = true;
                                        action();
                                }
                                finally
                                {
                                        this._isWriting = false;
                                }
                        }
                        else
                        {
                                throw new DataBaseExecuteTimeoutException();
                        }
                }

                private T QueryCore<T>(Func<T> func)
                {
                        if (SpinWait.SpinUntil(() => !this._isWriting, TimeSpan.FromSeconds(10)))
                        {
                                try
                                {
                                        this._isReading = true;
                                        return func();
                                }
                                finally
                                {
                                        this._isReading = false;
                                }
                        }
                        else
                        {
                                throw new DataBaseExecuteTimeoutException();
                        }
                }

                public int Execute(string sql, object param = null, bool istran = true)
                {
                        return this.ExecureCore<int>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords))
                                {
                                        if (istran)
                                        {
                                                connection.Open();

                                                using (SQLiteTransaction tran = connection.BeginTransaction())
                                                {
                                                        try
                                                        {
                                                                int effectrows = connection.Execute(sql, param, tran);
                                                                tran.Commit();
                                                                return effectrows;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                                tran.Rollback();
                                                                throw e;
                                                        }
                                                }
                                        }
                                        else
                                        {
                                                return connection.Execute(sql, param);
                                        }
                                }
                        });
                }

                public object ExecuteScalar(string sql, object param = null, bool istran = true)
                {
                        return this.ExecureCore<object>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords))
                                {
                                        if (istran)
                                        {
                                                connection.Open();

                                                using (SQLiteTransaction tran = connection.BeginTransaction())
                                                {
                                                        try
                                                        {
                                                                object result = connection.ExecuteScalar(sql, param, tran);
                                                                tran.Commit();
                                                                return result;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                                tran.Rollback();
                                                                throw e;
                                                        }
                                                }
                                        }
                                        else
                                        {
                                                return connection.ExecuteScalar(sql, param);
                                        }
                                }
                        });
                }

                public List<object> ExecuteScalarMany(params string[] sqls)
                {
                        return this.ExecureCore<List<object>>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords))
                                {
                                        connection.Open();

                                        using (SQLiteTransaction tran = connection.BeginTransaction())
                                        {
                                                try
                                                {
                                                        List<object> results = new List<object>();
                                                        for (int i = 0; i < sqls.Length; i++)
                                                        {
                                                                results.Add(connection.ExecuteScalar(sqls[i], null, tran));
                                                        }
                                                        tran.Commit();
                                                        return results;
                                                }
                                                catch (Exception e)
                                                {
                                                        tran.Rollback();
                                                        throw e;
                                                }
                                        }
                                }
                        });
                }

                public T ExecuteScalar<T>(string sql, object param = null, bool istran = true)
                {
                        return this.ExecureCore<T>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords))
                                {
                                        if (istran)
                                        {
                                                connection.Open();

                                                using (SQLiteTransaction tran = connection.BeginTransaction())
                                                {
                                                        try
                                                        {
                                                                T result = connection.ExecuteScalar<T>(sql, param, tran);
                                                                tran.Commit();
                                                                return result;
                                                        }
                                                        catch (Exception e)
                                                        {
                                                                tran.Rollback();
                                                                throw e;
                                                        }
                                                }
                                        }
                                        else
                                        {
                                                return connection.ExecuteScalar<T>(sql, param);
                                        }
                                }
                        });
                }

                public void Insert(params object[] objs)
                {
                        if (objs == null
                                && objs.Length == 0)
                        {
                                return;
                        }

                        this.ExecureCore(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords))
                                {
                                        connection.Open();

                                        using (SQLiteTransaction tran = connection.BeginTransaction())
                                        {
                                                bool flag = false;
                                                try
                                                {
                                                        foreach (object item in objs)
                                                        {
                                                                if (item == null)
                                                                {
                                                                        continue;
                                                                }

                                                                flag = true;

                                                                IEnumerable ienu = item as IEnumerable;
                                                                if (ienu != null)
                                                                {
                                                                        List<object> temp = new List<object>();
                                                                        foreach (var inner in ienu)
                                                                        {
                                                                                if (inner != null)
                                                                                {
                                                                                        temp.Add(inner);
                                                                                }
                                                                        }
                                                                        if (temp.Count > 0)
                                                                        {
                                                                                connection.Execute(StandardSQLGenerate.GetInsertSQL(temp[0]), temp, tran);
                                                                        }
                                                                }
                                                                else
                                                                {
                                                                        connection.Execute(StandardSQLGenerate.GetInsertSQL(item), item, tran);
                                                                }
                                                        }

                                                        if (flag)
                                                        {
                                                                tran.Commit();
                                                        }

                                                }
                                                catch (Exception e)
                                                {
                                                        if (flag)
                                                        {
                                                                tran.Rollback();
                                                        }
                                                        throw e;
                                                }
                                        }
                                }
                        });
                }

                public void Inserts(params IEnumerable<object>[] items)
                {
                        if (items == null
                                || items.Length == 0)
                        {
                                return;
                        }

                        this.ExecureCore(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords))
                                {
                                        connection.Open();

                                        using (SQLiteTransaction tran = connection.BeginTransaction())
                                        {
                                                bool flag = false;
                                                try
                                                {
                                                        foreach (var item in items)
                                                        {
                                                                if (item == null)
                                                                {
                                                                        continue;
                                                                }

                                                                object first = item.FirstOrDefault(_ => _ != null);
                                                                if (first != null)
                                                                {
                                                                        flag = true;

                                                                        connection.Execute(StandardSQLGenerate.GetInsertSQL(first), item.Where(_ => _ != null).ToList(), tran);
                                                                }
                                                        }

                                                        if (flag)
                                                        {
                                                                tran.Commit();
                                                        }
                                                }
                                                catch (Exception e)
                                                {
                                                        if (flag)
                                                        {
                                                                tran.Rollback();
                                                        }
                                                        throw e;
                                                }
                                        }
                                }
                        });
                }

                public IEnumerable<T> Query<T>()
                {
                        return this.Query<T>(StandardSQLGenerate.GetSelectSQL<T>());
                }

                public IEnumerable<T> Query<T>(string sql)
                {
                        return this.QueryCore<IEnumerable<T>>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords, true))
                                {
                                        return connection.Query<T>(sql);
                                }
                        });
                }

                public IEnumerable<object> Query(Type type)
                {
                        return this.Query(StandardSQLGenerate.GetSelectSQL(type), type);
                }

                public IEnumerable<object> Query(string sql, Type type)
                {
                        return this.QueryCore<IEnumerable<object>>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords, true))
                                {
                                        return connection.Query(type, sql);
                                }
                        });
                }

                public T QueryFirst<T>()
                {
                        return this.QueryFirst<T>(StandardSQLGenerate.GetSelectSQL<T>());
                }

                public T QueryFirst<T>(string sql)
                {
                        return this.QueryCore<T>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords, true))
                                {
                                        return connection.QueryFirst<T>(sql);
                                }
                        });
                }

                public object QueryFirst(Type type)
                {
                        return this.QueryFirst(StandardSQLGenerate.GetSelectSQL(type), type);
                }

                public object QueryFirst(string sql, Type type)
                {
                        return this.QueryCore<object>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords, true))
                                {
                                        return connection.QueryFirst(type, sql);
                                }
                        });
                }

                public T QueryFirstOrDefault<T>()
                {
                        return this.QueryFirstOrDefault<T>(StandardSQLGenerate.GetSelectSQL<T>());
                }

                public T QueryFirstOrDefault<T>(string sql)
                {
                        return this.QueryCore<T>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords, true))
                                {
                                        return connection.QueryFirstOrDefault<T>(sql);
                                }
                        });
                }

                public object QueryFirstOrDefault(Type type)
                {
                        return this.QueryFirstOrDefault(StandardSQLGenerate.GetSelectSQL(type), type);
                }

                public object QueryFirstOrDefault(string sql, Type type)
                {
                        return this.QueryCore<object>(() =>
                        {
                                using (SQLiteConnection connection = ConnectionHelper.GetDbConnection(this.DBKeywords, true))
                                {
                                        return connection.QueryFirstOrDefault(type, sql);
                                }
                        });
                }
        }
}
