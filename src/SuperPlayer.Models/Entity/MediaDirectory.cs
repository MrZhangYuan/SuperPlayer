using SuperApp.EntityFramework;
using SuperApp.EntityFramework.Map;
using System;

namespace SuperPlayer.Models.Entity
{
    [Serializable]
    [Table("media_directory")]
    public class MediaDirectory : EntityBase<MediaDirectory>
    {
        [AutoIncrease]
        [PrimakyKey]
        [Column("id", true)]
        public int ID
        {
            get;
            set;
        }

        [Column("path", true)]
        public string Path
        {
            get;
            set;
        }


        /// <summary>
        /// 是否递归子目录
        /// </summary>
        [Column("is_recursive", false)]
        public int? IsRecursive
        {
            get;
            set;
        }
    }
}
