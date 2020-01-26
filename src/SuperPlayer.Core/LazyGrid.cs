using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using UltimateCore;

namespace SuperPlayer.Core
{
    public enum ArrangeMode
    {
        Nomal,
        Lazy,
        LazyOneTime
    }

    public class LazyGrid : Grid
    {
        public ArrangeMode ArrangeMode
        {
            get
            {
                return (ArrangeMode)GetValue(ArrangeModeProperty);
            }
            set
            {
                SetValue(ArrangeModeProperty, value);
            }
        }
        public static readonly DependencyProperty ArrangeModeProperty = DependencyProperty.Register("ArrangeMode", typeof(ArrangeMode), typeof(LazyGrid), new PropertyMetadata(ArrangeMode.LazyOneTime, ArrangeModeChanged));

        private static void ArrangeModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LazyGrid)d).OnArrangeModeChanged();
        }


        public LazyGrid()
        {
            this.OnArrangeModeChanged();
        }

        private TimerBuffer<object> _buffer = null;
        private bool _isMeasureArrangedFirstFlag = false;
        protected virtual void OnArrangeModeChanged()
        {
            switch (this.ArrangeMode)
            {
                case ArrangeMode.Nomal:
                    if (this._buffer != null)
                    {
                        this._buffer.Stop();
                        this._buffer = null;
                    }
                    break;
                case ArrangeMode.Lazy:
                case ArrangeMode.LazyOneTime:
                    if (this._buffer == null)
                    {
                        _buffer = new TimerBuffer<object>(DispatcherPriority.Loaded);
                        _buffer.DueTime = 100;
                        _buffer.Action = this.MeasureArrange;
                    }
                    break;
            }
        }
        private void MeasureArrange(object obj)
        {
            this._isMeasureArrangedFirstFlag = true;
            this.MeasureCore();
            this.ArrangeCore();
        }

        private Size _finalSize;
        private void MeasureCore()
        {
            base.MeasureOverride(_finalSize);
        }

        private void ArrangeCore()
        {
            base.ArrangeOverride(_finalSize);
        }


        protected override Size MeasureOverride(Size constraint)
        {
            this._finalSize = constraint;

            switch (this.ArrangeMode)
            {
                case ArrangeMode.Nomal:
                    this.MeasureCore();
                    break;
                case ArrangeMode.Lazy:
                    this._buffer.ReSet(null);
                    break;
                case ArrangeMode.LazyOneTime:
                    if (this._isMeasureArrangedFirstFlag)
                    {
                        this.MeasureCore();
                    }
                    else
                    {
                        this._buffer.ReSet(null);
                    }
                    break;
            }

            return constraint;
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            this._finalSize = arrangeSize;

            switch (this.ArrangeMode)
            {
                case ArrangeMode.Nomal:
                    this.ArrangeCore();
                    break;

                case ArrangeMode.Lazy:
                    this._buffer.ReSet(null);
                    break;

                case ArrangeMode.LazyOneTime:
                    if (this._isMeasureArrangedFirstFlag)
                    {
                        this.ArrangeCore();
                    }
                    else
                    {
                        this._buffer.ReSet(null);
                    }
                    break;
            }

            return arrangeSize;
        }
    }

}
