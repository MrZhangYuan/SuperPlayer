using SuperApp.EntityFramework.Map;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperApp.EntityFramework
{
        public static class StandardSQLGenerate
        {
                private class CacheItem
                {
                        private string _insert = string.Empty;
                        public string Insert
                        {
                                get
                                {
                                        if (string.IsNullOrEmpty(this._insert))
                                        {
                                                string sql = "INSERT INTO " + this.TableName;

                                                string columns = this.PropertyNames.Aggregate
                                                        (
                                                                new StringBuilder().Append("("),
                                                                (__, _) => __.Append(_).Append(","),
                                                                _ => _.Remove(_.Length - 1, 1)
                                                        )
                                                        .Append(")")
                                                        .ToString();

                                                string values = this.PropertyNames.Aggregate
                                                        (
                                                                new StringBuilder().Append("("),
                                                                (__, _) => __.Append("@").Append(_).Append(","),
                                                                _ => _.Remove(_.Length - 1, 1)
                                                        )
                                                        .Append(")")
                                                        .ToString();

                                                this._insert = sql + columns + " VALUES " + values;
                                                this.ClearNames();
                                        }

                                        return this._insert;
                                }
                        }

                        private string _delete = string.Empty;
                        public string Delete
                        {
                                get
                                {
                                        if (string.IsNullOrEmpty(this._delete))
                                        {
                                                this._delete = "DELETE FROM " + this.TableName;
                                                this.ClearNames();
                                        }

                                        return this._delete;
                                }
                        }

                        private string _update = string.Empty;
                        public string Update
                        {
                                get
                                {
                                        if (string.IsNullOrEmpty(this._update))
                                        {
                                                string sql = "UPDATE " + this.TableName + " SET ";

                                                string setters = this.PropertyNames.Aggregate
                                                        (
                                                                new StringBuilder(),
                                                                (__, _) => __.Append(_).Append("=@").Append(_).Append(","),
                                                                _ => _.Remove(_.Length - 1, 1)
                                                        )
                                                        .Append(";")
                                                        .ToString();

                                                this._update = sql + setters;

                                                this.ClearNames();
                                        }

                                        return this._update;
                                }
                        }

                        public string Select
                        {
                                get => "SELECT * FROM " + this.TableName;
                        }
                        public string TableName
                        {
                                get; set;
                        }
                        public List<string> PropertyNames
                        {
                                get; set;
                        }

                        public RuntimeTypeHandle TypeHandle
                        {
                                get; set;
                        }

                        public CacheItem(RuntimeTypeHandle typeHandle)
                        {
                                TypeHandle = typeHandle;
                        }

                        private void ClearNames()
                        {
                                if (!string.IsNullOrEmpty(this._insert)
                                        && !string.IsNullOrEmpty(this._delete)
                                        && !string.IsNullOrEmpty(this._update))
                                {
                                        this.PropertyNames = null;
                                }
                        }
                }
                private class _ColumnInfo
                {
                        public PropertyInfo Property
                        {
                                get; set;
                        }
                        public PrimakyKeyAttribute PrimakyKey
                        {
                                get; set;
                        }
                        public LengthAttribute Length
                        {
                                get; set;
                        }
                        public ColumnAttribute Column
                        {
                                get; set;
                        }
                }

                private static readonly ConcurrentDictionary<RuntimeTypeHandle, CacheItem> _sqlCaches = new ConcurrentDictionary<RuntimeTypeHandle, CacheItem>();

                private static CacheItem GetCacheItem(Type type)
                {
                        RuntimeTypeHandle handle = type.TypeHandle;
                        CacheItem cacheItem = _sqlCaches.GetOrAdd(handle, _p => new CacheItem(handle));
                        return cacheItem;
                }

                private static void SetPropertys(Type type, CacheItem cacheItem)
                {
                        lock (cacheItem)
                        {
                                if (cacheItem.PropertyNames == null)
                                {
                                        TableAttribute attribute = Attribute.GetCustomAttribute(type, typeof(TableAttribute), true) as TableAttribute;

                                        string tablename = attribute != null ? attribute.Name : type.Name;

                                        cacheItem.TableName = tablename;

                                        List<_ColumnInfo> properties = GetColumnsInfo(type);

                                        cacheItem.PropertyNames = properties.Select(_ => _.Column != null ? _.Column.Name : _.Property.Name).ToList();
                                }
                        }
                }

                public static Type GetEntityType(string typeortablename)
                {
                        if (!string.IsNullOrEmpty(typeortablename))
                        {
                                CacheItem item = _sqlCaches.Values.FirstOrDefault(_ => _.TableName == typeortablename);
                                if (item != null)
                                {
                                        return Type.GetTypeFromHandle(item.TypeHandle);
                                }
                        }
                        return null;
                }

                public static string GetTableName(Type type)
                {
                        CacheItem cacheItem = GetCacheItem(type);
                        SetPropertys(type, cacheItem);
                        return cacheItem.TableName;
                }

                public static string GetInsertSQL(Type type)
                {
                        CacheItem cacheItem = GetCacheItem(type);
                        SetPropertys(type, cacheItem);
                        return cacheItem.Insert;
                }
                public static string GetUpdateSQL(Type type)
                {
                        CacheItem cacheItem = GetCacheItem(type);
                        SetPropertys(type, cacheItem);
                        return cacheItem.Update;
                }
                public static string GetDeleteSQL(Type type)
                {
                        CacheItem cacheItem = GetCacheItem(type);
                        SetPropertys(type, cacheItem);
                        return cacheItem.Delete;
                }
                public static string GetSelectSQL(Type type)
                {
                        CacheItem cacheItem = GetCacheItem(type);
                        SetPropertys(type, cacheItem);
                        return cacheItem.Select;
                }
                public static string GetSelectSQL<T>()
                {
                        Type type = typeof(T);

                        CacheItem cacheItem = GetCacheItem(type);
                        SetPropertys(type, cacheItem);
                        return cacheItem.Select;
                }


                public static string GetInsertSQL<T>()
                {
                        return GetInsertSQL(typeof(T));
                }
                public static string GetInsertSQL(object obj)
                {
                        if (obj != null)
                        {
                                return GetInsertSQL(obj.GetType());
                        }
                        return string.Empty;
                }

                public static string GetUpdateSQL<T>()
                {
                        return GetUpdateSQL(typeof(T));
                }
                public static string GetUpdateSQL(object obj)
                {
                        if (obj != null)
                        {
                                return GetUpdateSQL(obj.GetType());
                        }
                        return string.Empty;
                }

                public static string GetDeleteSQL<T>()
                {
                        return GetDeleteSQL(typeof(T));
                }
                public static string GetDeleteSQL(object obj)
                {
                        if (obj != null)
                        {
                                return GetDeleteSQL(obj.GetType());
                        }
                        return string.Empty;
                }

                public static string GetTableName<T>()
                {
                        return GetTableName(typeof(T));
                }
                public static string GetTableName(object obj)
                {
                        if (obj != null)
                        {
                                return GetTableName(obj.GetType());
                        }
                        return string.Empty;
                }

                private static List<_ColumnInfo> GetColumnsInfo(Type entitytype)
                {
                        List<_ColumnInfo> properties = entitytype.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                .Select
                                (
                                        _ => new _ColumnInfo
                                        {
                                                Property = _,
                                                PrimakyKey = Attribute.GetCustomAttribute(_, typeof(PrimakyKeyAttribute), true) as PrimakyKeyAttribute,
                                                Column = Attribute.GetCustomAttribute(_, typeof(ColumnAttribute), true) as ColumnAttribute,
                                                Length = Attribute.GetCustomAttribute(_, typeof(LengthAttribute), true) as LengthAttribute
                                        }
                                )
                                .ToList();

                        return properties;
                }

                public static string GenerateTablesCreate(Assembly entityassembly, Type entitybase)
                {
                        var entitytypes = entityassembly.GetTypes().Where(_ => Attribute.GetCustomAttribute(_, typeof(TableAttribute), false) != null);

                        StringBuilder sqlbuilder = new StringBuilder();

                        foreach (var entitytype in entitytypes)
                        {
                                sqlbuilder.Append(GenerateTableCreate(entitytype, true));
                        }

                        return sqlbuilder.ToString();
                }

                public static string GenerateTableCreate(Type entitytype, bool withdrop = false)
                {
                        StringBuilder tablebuilder = new StringBuilder();

                        TableAttribute tableattr = Attribute.GetCustomAttribute(entitytype, typeof(TableAttribute)) as TableAttribute;

                        string tablename = tableattr != null ? tableattr.Name : entitytype.Name;
                        //string tablename = entitytype.Name;

                        if (withdrop)
                        {
                                tablebuilder.Append("DROP TABLE IF EXISTS " + tablename).Append(";");
                        }

                        List<_ColumnInfo> properties = GetColumnsInfo(entitytype);

                        properties
                                .Aggregate
                                (
                                        tablebuilder.Append($"CREATE TABLE {tablename} ("),
                                        (__, _) => __.Append(GenerateColumnSQL(_)).Append(","),
                                        __ => __.Append
                                                        (
                                                                GeneratePrimaryKeySQL(properties.Where(_p => _p.PrimakyKey != null))
                                                        )
                                                        .Append(");")
                                );

                        return tablebuilder.ToString();
                }
                private static string GenerateColumnSQL(_ColumnInfo columninfo)
                {
                        string name = columninfo.Column != null ? columninfo.Column.Name : columninfo.Property.Name;

                        return $"{name} {GenerateDBType(columninfo)}";
                }
                private static string GeneratePrimaryKeySQL(IEnumerable<_ColumnInfo> columninfos)
                {
                        if (!columninfos.Any())
                        {
                                throw new Exception("缺少主键信息。");
                        }
                        return columninfos.Aggregate
                                (
                                        new StringBuilder("PRIMARY KEY ("),
                                        (__, _) => __.Append(_.Column != null ? _.Column.Name : _.Property.Name).Append(","),
                                        __ => __.Remove(__.Length - 1, 1)
                                                        .Append(")").ToString()
                                );
                }
                private static string GenerateDBType(_ColumnInfo columninfo)
                {
                        string typestring = string.Empty;

                        Type propertytype = columninfo.Property.PropertyType;

                        if (propertytype == typeof(string))
                        {
                                string nullflag = "";
                                if (columninfo.Column != null
                                        && columninfo.Column.NotNull)
                                {
                                        nullflag = "NOT NULL";
                                }

                                if (columninfo.Length != null)
                                {
                                        typestring = $"VARCHAR({columninfo.Length.Length}) {nullflag}";
                                }
                                else
                                {
                                        typestring = $"TEXT {nullflag}";
                                }
                        }
                        else if (propertytype == typeof(int))
                        {
                                typestring = "INT NOT NULL";
                        }
                        else if (propertytype == typeof(int?))
                        {
                                typestring = "INT";
                        }
                        else if (propertytype == typeof(decimal))
                        {
                                typestring = $"DECIMAL(18, 6) NOT NULL";

                        }
                        else if (propertytype == typeof(decimal?))
                        {
                                typestring = $"DECIMAL(18, 6)";

                        }
                        else if (propertytype == typeof(DateTime))
                        {
                                typestring = "TIMESTAMP NOT NULL";
                        }
                        else if (propertytype == typeof(DateTime?))
                        {
                                typestring = "TIMESTAMP";
                        }
                        else
                        {
                                throw new Exception("类型未知");
                        }

                        return typestring;
                }
        }
}
