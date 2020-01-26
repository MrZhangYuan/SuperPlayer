using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SuperPlayer.Business
{
        public class PlayList
        {

        }
        public class PlayItem
        {

        }

        public interface IPlayListService
        {
                ReadOnlyObservableCollection<PlayList> PlayLists
                {
                        get;
                }

                PlayList CurrentPlayList
                {
                        get;
                }

                PlayItem CurrentPlayItem
                {
                        get;
                }

                bool HasNextPlayList();

                bool HasNextPlayItem();
        }
}
