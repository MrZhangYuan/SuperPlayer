using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.ViewModels
{
        public class MediaCenterViewModel : BaseViewModel
        {
                private static MediaCenterViewModel _instance = null;
                public static MediaCenterViewModel Instance
                {
                        get
                        {
                                if (_instance == null)
                                {
                                        _instance = new MediaCenterViewModel();
                                }
                                return _instance;
                        }
                }

                private MediaCenterViewModel()
                {

                }

        }
}
