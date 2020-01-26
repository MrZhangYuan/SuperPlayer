using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.Shell.Controls
{
        public interface IPageNavigation
        {
                void PageUp();
                void PageDown();
                void PageLeft();
                void PageRight();

                bool CanPageUp();
                bool CanPageDown();
                bool CanPageLeft();
                bool CanPageRight();
        }
}
