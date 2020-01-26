using SuperApp.EntityFramework;
using SuperApp.EntityFramework.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.Models.Entity
{
        [Serializable]
        [Table("media_item")]
        public class MediaItem : EntityBase<MediaItem>
        {
                [AutoIncrease]
                [PrimakyKey]
                [Column("id", true)]
                public int ID
                {
                        get;
                        set;
                }

                [Column("identity_key", false)]
                public string IdentityKey
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


                [Column("name", true)]
                public string Name
                {
                        get;
                        set;
                }

                [Column("item_type", true)]
                public int ItemType
                {
                        get;
                        set;
                }

                [Column("size", false)]
                public long? Size
                {
                        get;
                        set;
                }

                [Column("is_new", false)]
                public int? IsNew
                {
                        get;
                        set;
                }
        }
}
