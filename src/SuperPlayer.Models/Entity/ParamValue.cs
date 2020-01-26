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
    [Table("param_value")]
    public class ParamValue : EntityBase<ParamValue>
    {
        [PrimakyKey]
        [Column("id", true)]
        public int ID
        {
            get;
            set;
        }

        [Column("value", false)]
        public string Value
        {
            get;
            set;
        }
    }
}
