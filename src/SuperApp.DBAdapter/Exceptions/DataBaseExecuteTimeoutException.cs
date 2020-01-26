using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.DBAdapter.Exceptions
{
    public class DataBaseExecuteTimeoutException : Exception
    {
        public DataBaseExecuteTimeoutException()
        {

        }
        public DataBaseExecuteTimeoutException(string message)
                : base(message)
        {

        }
        public DataBaseExecuteTimeoutException(string message, Exception innerException)
                : base(message, innerException)
        {

        }
    }
}
