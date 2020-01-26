using SuperApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SuperApp.DBAdapter.SQLite
{
        public class SQLiteDBContext : IDisposable, IDBContext
        {
                public IDataSource DataSource
                {
                        get => SQLiteDataSource.Instance;
                }

                private DbConnection _connection;
                public DbConnection Connection
                {
                        get => this._connection ?? (this._connection = ConnectionHelper.GetDbConnection(SQLiteDataSource.Instance.DBKeywords));
                }

                public SQLiteDBContext(IDictionary<string, object> keyvalues)
                {
                        if (SQLiteDataSource.Instance.DBKeywords == null)
                        {
                                if (keyvalues == null)
                                {
                                        throw new ArgumentNullException(nameof(keyvalues));
                                }

                                if (!keyvalues.ContainsKey("DBFilePath"))
                                {
                                        throw new ArgumentException("缺少DBFilePath参数。");
                                }

                                SQLiteDataSource.Instance.DBKeywords = keyvalues;
                        }
                }

                public bool CreateDataBaseIfNotExists()
                {
                        string filepath = SQLiteDataSource.Instance.DBKeywords["DBFilePath"] + "";

                        if (!File.Exists(filepath))
                        {
                                try
                                {
                                        //SQLite Open的时候会自己创建数据库，这样建的数据库没问题
                                        this.Connection.Open();
                                        DbCommand cmd = this.Connection.CreateCommand();
                                        cmd.CommandText = StandardSQLGenerate.GenerateTablesCreate((Assembly)SQLiteDataSource.Instance.DBKeywords["EntityAssembly"], typeof(EntityBase));
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();

                                        return true;
                                }
                                catch (Exception e)
                                {
                                        if (File.Exists(filepath))
                                        {
                                                File.Delete(filepath);
                                        }
                                        throw e;
                                }
                        }

                        return false;
                }


        #region Dispose

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (this._connection != null)
                    {
                        this._connection.Close();
                        this._connection.Dispose();
                    }
                }

                // unmanaged resources here.

                _disposed = true;
            }
        }
        ~SQLiteDBContext()
        {
            Dispose(false);
        }

        #endregion

    }
}
