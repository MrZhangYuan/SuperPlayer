using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections;
using SuperPlayer.Core.Utilities;

namespace SuperPlayer.Business.Generates
{
        public enum StatusFlag
        {
                WaitForStart,
                Running,
                Complated,
                Finished
        }
        public abstract class ItemProducer<S, T> : DisposableObject
        {
                public StatusFlag Status
                {
                        get;
                        set;
                }

                public Func<S, T> ItemSelector
                {
                        get;
                }

                public Func<S, bool> ItemFilter
                {
                        get;
                }

                public IEnumerator<T> ItemEnumerator
                {
                        get;
                        protected set;
                }

                protected ItemProducer(Func<S, T> itemSelector, Func<S, bool> itemFilter)
                {
                        ItemSelector = itemSelector ?? throw new ArgumentNullException(nameof(itemSelector));
                        ItemFilter = itemFilter ?? throw new ArgumentNullException(nameof(itemFilter));
                }

                public void Initialization(object param)
                {
                        this.ThrowIfDisposed();

                        this.InitializationCore(param);
                }

                protected abstract void InitializationCore(object param);

                protected override void DisposeManagedResources()
                {
                        base.DisposeManagedResources();

                        this.ItemEnumerator?.Dispose();
                }
        }
}
