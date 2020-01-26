using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperApp.Shell.Controls
{
        public interface INavigation
        {
                void BrowseBack();
                bool CanBrowseBack();
                void BrowseForward();
                bool CanBrowseForward();
                void ClearNavigateHistory();
        }
}
