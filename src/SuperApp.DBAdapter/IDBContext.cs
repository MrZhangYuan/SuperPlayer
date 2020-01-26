using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SuperApp.DBAdapter
{
        public interface IDBContext : IDisposable
        {
                IDataSource DataSource
                {
                        get;
                }

                DbConnection Connection
                {
                        get;
                }

                bool CreateDataBaseIfNotExists();
        }
}