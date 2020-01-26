using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.EntityFramework.Map
{
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class ColumnAttribute : Attribute
        {
                public ColumnAttribute(string columnname, bool notnull)
                {
                        if (string.IsNullOrEmpty(columnname))
                        {
                                throw new ArgumentNullException(nameof(columnname));
                        }
                        this.Name = columnname;
                        this.NotNull = notnull;
                }
                public string Name
                {
                        get;
                }
                public bool NotNull
                {
                        get;
                }
        }
}
