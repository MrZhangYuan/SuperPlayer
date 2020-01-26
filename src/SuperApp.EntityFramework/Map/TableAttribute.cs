using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.EntityFramework.Map
{
        //[PrimakyKey]
        //[Length(2)]
        //[Length(4)]
        //[Length(10)]
        //[Length(20)]
        //[Length(32)]
        //[Length(255)]


        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class TableAttribute : Attribute
        {
                public string Name
                {
                        get;
                }

                public ObjectType ObjectType { get; set; } = ObjectType.DataTable;

                public TableAttribute(string tablename)
                {
                        if (string.IsNullOrEmpty(tablename))
                        {
                                throw new ArgumentNullException(nameof(tablename));
                        }
                        this.Name = tablename;
                }

                public TableAttribute(string name, ObjectType objectType)
                        : this(name)
                {
                        ObjectType = objectType;
                }
        }

        public enum ObjectType
        {
                DataTable,
                View
        }
}
