using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SuperApp.DBAdapter.SQLite
{
        static class ConnectionHelper
        {
                private static SQLiteConnectionStringBuilder GenerateSqlBuilder(IDictionary<string, object> keywords, bool isreadonly)
                {
                        SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder
                        {
                                DataSource = keywords["DBFilePath"].ToString(),

                                // SQLite使用预写日志而不是回滚日志来实现事务。
                                // WAL日记模式是持久的; 被设置后，它将保持有效
                                //多个数据库连接和关闭并重新打开数据库后。 一个
                                // WAL日记模式下的数据库只能由SQLite 3.7.0版本访问
                                //或更晚
                                //JournalMode = SQLiteJournalModeEnum.Wal,
                                JournalMode = SQLiteJournalModeEnum.Default,

                                Pooling = true,

                                ReadOnly = isreadonly,

                                DateTimeFormatString = "yyyy-MM-dd HH:mm:ss",

                                //事务的隔离级别
                                DefaultIsolationLevel = IsolationLevel.Serializable,

                                //建议改为8000
                                //查询或修改SQLite一次存储在内存中的数据库文件页数。
                                //每页使用约1.5K内存，缺省的缓存大小是2000.若需要使用改变大量多行的UPDATE或DELETE命令，
                                //并且不介意SQLite使用更多的内存的话，可以增大缓存以提高性能。
                                //CacheSize = 8000,

                                //当synchronous设置为FULL,
                                //SQLite数据库引擎在紧急时刻会暂停以确定数据已经写入磁盘。
                                //这使系统崩溃或电源出问题时能确保数据库在重起后不会损坏。
                                //FULL synchronous很安全但很慢。

                                //当synchronous设置为NORMAL,
                                //SQLite数据库引擎在大部分紧急时刻会暂停，但不像FULL模式下那么频繁。
                                //NORMAL模式下有很小的几率(但不是不存在)发生电源故障导致数据库损坏的情况。
                                //但实际上，在这种情况 下很可能你的硬盘已经不能使用，或者发生了其他的不可恢复的硬件错误。

                                //当设置为synchronous OFF时，SQLite在传递数据给系统以后直接继续而不暂停。
                                //若运行SQLite的应用程序崩溃， 数据不会损伤，但在系统崩溃或写入数据时意外断电的情况下数据库可能会损坏。
                                //另一方面，在synchronous OFF时 一些操作可能会快50倍甚至更多。
                                //在SQLite 2中，缺省值为NORMAL.而在3中修改为FULL。
                                SyncMode = SynchronizationModes.Normal
                                //Password = keywords["Password"].ToString(),
                        };

                        return builder;
                }
                public static SQLiteConnection GetDbConnection(IDictionary<string, object> keywords) => new SQLiteConnection(GenerateSqlBuilder(keywords, false).ToString());

                public static SQLiteConnection GetDbConnection(IDictionary<string, object> keywords, bool isreadonly) => new SQLiteConnection(GenerateSqlBuilder(keywords, isreadonly).ToString());
        }

}
