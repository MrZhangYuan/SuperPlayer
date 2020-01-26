using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.EntityFramework.Map
{
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class LengthAttribute : Attribute
        {
                public int Length
                {
                        get;
                }

                public bool IsVariable
                {
                        get; set;
                }

                public LengthAttribute(int length)
                {
                        Length = length;
                }
        }
}
