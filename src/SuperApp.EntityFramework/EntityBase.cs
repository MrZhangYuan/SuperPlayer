using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.EntityFramework
{
        public abstract class EntityBase
        {
        }

        public class EntityBase<T> : EntityBase
                where T : EntityBase<T>
        {
                public virtual T EmptyInstance()
                {
                        throw new NotImplementedException();
                }
        }
}
