using SuperPlayer.Business;
using SuperPlayer.Core.Utilities;
using SuperPlayer.Core.Utilities.Mvvm;
using System;

namespace SuperPlayer.ViewModels
{
        public class BaseViewModel : ObservableObject
        {
                public readonly Lazy<IDataContext> _dataContext = new Lazy<IDataContext>(() => ServiceProvider.Instance.GetService<IDataContext>());
                public IDataContext BusinessDataContext
                {
                        get => this._dataContext.Value;
                }
        }
}
