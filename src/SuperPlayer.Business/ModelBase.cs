using SuperPlayer.Core.Utilities.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.Business
{
        public abstract class ModelBase<T> : ObservableObject
        {
                private T _entity;
                public T Entity
                {
                        get
                        {
                                return this._entity;
                        }
                        set
                        {
                                _entity = value;
                                this.NotifyEntityChanged();
                        }
                }

                public virtual void NotifyEntityChanged()
                {
                        this.RaisePropertyChanged("Entity");
                }
        }

}
