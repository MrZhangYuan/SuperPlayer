using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.EntityFramework.Map
{
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class PrimakyKeyAttribute : Attribute
        {
        }
}
