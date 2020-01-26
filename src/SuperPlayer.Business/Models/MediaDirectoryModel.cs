using SuperPlayer.Business.Generates;
using SuperPlayer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.Business.Models
{
        public class MediaDirectoryModel : ModelBase<MediaDirectory>
        {
                private ObservableCollection<MediaItemModel> _mediaItems;
                public ObservableCollection<MediaItemModel> MediaItems
                {
                        get
                        {
                                if (_mediaItems == null)
                                {
                                        _mediaItems = new ObservableCollection<MediaItemModel>();
                                }
                                return _mediaItems;
                        }
                }

                public FileItemProducer<MediaItemModel> ItemProducer
                {
                        get;
                        set;
                }
        }
}
