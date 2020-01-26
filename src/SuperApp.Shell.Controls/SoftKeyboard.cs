using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperApp.Shell.Controls
{
        /// <summary>
        /// 影响该键状态的键
        /// </summary>
        public enum EffectiveKey
        {
                /// <summary>
                /// 无
                /// </summary>
                None,
                /// <summary>
                /// 大写锁定
                /// </summary>
                CapsLock,
                /// <summary>
                /// Shift
                /// </summary>
                Shift,
                /// <summary>
                /// 中英(拓展用，暂未实现)
                /// </summary>
                CH_EN
        }

        internal delegate void HandleKey(int flag, KeyEventArgs e);

        /// <summary>
        /// 数字键盘按键
        /// </summary>
        public class NumPadKey : Control
        {
                /// <summary>
                /// 显示的键
                /// </summary>
                public string DisplayKey
                {
                        get { return (string)GetValue(DisplayKeyProperty); }
                        set { SetValue(DisplayKeyProperty, value); }
                }
                /// <summary>
                /// 显示的键
                /// </summary>
                public static readonly DependencyProperty DisplayKeyProperty = DependencyProperty.Register("DisplayKey", typeof(string), typeof(NumPadKey), new PropertyMetadata(string.Empty));

                /// <summary>
                /// 是否按下
                /// </summary>
                public bool IsPressed
                {
                        get { return (bool)GetValue(IsPressedProperty); }
                        set { SetValue(IsPressedProperty, value); }
                }
                /// <summary>
                /// 是否按下
                /// </summary>
                public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register("IsPressed", typeof(bool), typeof(NumPadKey), new PropertyMetadata(false));

                static NumPadKey()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumPadKey), new FrameworkPropertyMetadata(typeof(NumPadKey)));
                }
                #region Mouse

                public NumPadKey()
                {
                        this.AddHandler(NumPadKey.MouseDownEvent, new MouseButtonEventHandler(HandleMouseDown), true);
                        this.AddHandler(NumPadKey.MouseUpEvent, new MouseButtonEventHandler(HandleMouseUp), true);
                }

                private void HandleMouseUp(object sender, MouseButtonEventArgs e)
                {
                        this.ReleaseMouseCapture();
                        if (!this.IsMouseCaptured)
                        {
                                this.IsPressed = false;
                        }
                        this.HandleKeyDown();
                        e.Handled = true;
                }

                private void HandleMouseDown(object sender, MouseButtonEventArgs e)
                {
                        this.CaptureMouse();
                        if (this.IsMouseCaptured)
                        {
                                this.IsPressed = true;
                        }
                        e.Handled = true;
                }
                private void HandleKeyDown()
                {
                        if (!string.IsNullOrEmpty(this.DisplayKey))
                        {
                                if (this.DisplayKey.ToUpper() == "C")
                                {
                                        IInputElement targetelement = Keyboard.FocusedElement;
                                        if (targetelement != null)
                                        {
                                                if (targetelement as TextBox != null)
                                                {
                                                        (targetelement as TextBox).Text = string.Empty;
                                                }
                                                else if (targetelement as PasswordBox != null)
                                                {
                                                        (targetelement as PasswordBox).Password = string.Empty;
                                                }
                                        }
                                        return;
                                }

                                for (int i = 0; i < this.DisplayKey.Length; i++)
                                {
                                        SoftKeyboardManager.PressSoftKey(this.DisplayKey[i] + "");
                                }
                        }
                }
                #endregion
        }
        /// <summary>
        /// 键
        /// </summary>
        public class SoftKey : Control
        {
                private SoftKeyboard _parentKeyboard = null;
                /// <summary>
                /// 拥有它的键盘
                /// </summary>
                public SoftKeyboard ParentKeyboard
                {
                        get
                        {
                                if (this.Tag != null && _parentKeyboard == null)
                                {
                                        _parentKeyboard = this.Tag as SoftKeyboard;
                                }
                                return _parentKeyboard;
                        }
                }

                #region Propertys
                /// <summary>
                /// 中文键(拓展用，暂未实现)
                /// </summary>
                public string CHKey
                {
                        get { return (string)GetValue(CHKeyProperty); }
                        set { SetValue(CHKeyProperty, value); }
                }
                /// <summary>
                /// 中文键(拓展用，暂未实现)
                /// </summary>
                public static readonly DependencyProperty CHKeyProperty = DependencyProperty.Register("CHKey", typeof(string), typeof(SoftKey), new PropertyMetadata(string.Empty));

                /// <summary>
                /// 按键
                /// </summary>
                public string Key
                {
                        get { return (string)GetValue(KeyProperty); }
                        set { SetValue(KeyProperty, value); }
                }
                /// <summary>
                /// 按键
                /// </summary>
                public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(string), typeof(SoftKey), new PropertyMetadata(string.Empty));

                /// <summary>
                /// 大写
                /// </summary>
                public string UpperKey
                {
                        get { return (string)GetValue(UpperKeyProperty); }
                        set { SetValue(UpperKeyProperty, value); }
                }
                /// <summary>
                /// 大写
                /// </summary>
                public static readonly DependencyProperty UpperKeyProperty = DependencyProperty.Register("UpperKey", typeof(string), typeof(SoftKey), new PropertyMetadata(string.Empty));


                /// <summary>
                /// Shift按下时显示的键
                /// </summary>
                public string ShiftKey
                {
                        get { return (string)GetValue(ShiftKeyProperty); }
                        set { SetValue(ShiftKeyProperty, value); }
                }
                /// <summary>
                /// Shift按下时显示的键
                /// </summary>
                public static readonly DependencyProperty ShiftKeyProperty = DependencyProperty.Register("ShiftKey", typeof(string), typeof(SoftKey), new PropertyMetadata(string.Empty));

                /// <summary>
                /// UI显示的字母
                /// </summary>
                public string DisplayKey
                {
                        get { return (string)GetValue(DisplayKeyProperty); }
                        set { SetValue(DisplayKeyProperty, value); }
                }
                /// <summary>
                /// UI显示的字母
                /// </summary>
                public static readonly DependencyProperty DisplayKeyProperty = DependencyProperty.Register("DisplayKey", typeof(string), typeof(SoftKey), new PropertyMetadata(string.Empty));

                /// <summary>
                /// 鼠标是否按下
                /// </summary>
                public bool IsPressed
                {
                        get { return (bool)GetValue(IsPressedProperty); }
                        private set { SetValue(IsPressedProperty, value); }
                }
                /// <summary>
                /// 鼠标是否按下
                /// </summary>
                public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register("IsPressed", typeof(bool), typeof(SoftKey), new PropertyMetadata(false));
                /// <summary>
                /// 是否大写锁定
                /// </summary>
                public bool IsCapsLock
                {
                        get { return (bool)GetValue(IsCapsLockProperty); }
                        private set { SetValue(IsCapsLockProperty, value); }
                }
                /// <summary>
                /// 是否大写锁定
                /// </summary>
                public static readonly DependencyProperty IsCapsLockProperty = SoftKeyboard.IsCapsLockProperty.AddOwner(typeof(SoftKey), new FrameworkPropertyMetadata(null));

                /// <summary>
                /// 是否Shift按下状态
                /// </summary>
                public bool IsShiftPressed
                {
                        get { return (bool)GetValue(IsShiftPressedProperty); }
                        private set { SetValue(IsShiftPressedProperty, value); }
                }
                /// <summary>
                /// 是否Shift按下状态
                /// </summary>
                public static readonly DependencyProperty IsShiftPressedProperty = SoftKeyboard.IsShiftPressedProperty.AddOwner(typeof(SoftKey), new FrameworkPropertyMetadata(null));

                /// <summary>
                /// 影响该键状态的键
                /// </summary>
                public EffectiveKey EffectiveKey
                {
                        get { return (EffectiveKey)GetValue(EffectiveKeyProperty); }
                        set { SetValue(EffectiveKeyProperty, value); }
                }
                /// <summary>
                /// 影响该键状态的键
                /// </summary>
                public static readonly DependencyProperty EffectiveKeyProperty = DependencyProperty.Register("EffectiveKey", typeof(EffectiveKey), typeof(SoftKey), new PropertyMetadata(EffectiveKey.None));

                /// <summary>
                /// 是否已切换状态（某些有状态的键，如Caps Lock）
                /// </summary>
                public bool IsToggled
                {
                        get { return (bool)GetValue(IsToggledProperty); }
                        set { SetValue(IsToggledProperty, value); }
                }
                /// <summary>
                /// 是否已切换状态（某些有状态的键，如Caps Lock）
                /// </summary>
                public static readonly DependencyProperty IsToggledProperty = DependencyProperty.Register("IsToggled", typeof(bool), typeof(SoftKey), new PropertyMetadata(false));

                /// <summary>
                /// 是否可切换状态
                /// </summary>
                public bool IsCanTogled
                {
                        get { return (bool)GetValue(IsCanTogledProperty); }
                        set { SetValue(IsCanTogledProperty, value); }
                }
                /// <summary>
                /// 是否可切换状态
                /// </summary>
                public static readonly DependencyProperty IsCanTogledProperty = DependencyProperty.Register("IsCanTogled", typeof(bool), typeof(SoftKey), new PropertyMetadata(false));

                #endregion

                #region Events

                /// <summary>
                /// 软键盘按下事件
                /// </summary>
                public event RoutedEventHandler SoftKeyDown
                {
                        add
                        {
                                base.AddHandler(SoftKey.SoftKeyDownEvent, value);
                        }
                        remove
                        {
                                base.RemoveHandler(SoftKey.SoftKeyDownEvent, value);
                        }
                }
                /// <summary>
                /// 软键盘按下事件
                /// </summary>
                public static readonly RoutedEvent SoftKeyDownEvent = EventManager.RegisterRoutedEvent("SoftKeyDown", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SoftKey));
                protected virtual void OnSoftKeyDown()
                {
                        RoutedEventArgs e = new RoutedEventArgs(SoftKey.SoftKeyDownEvent, this);
                        base.RaiseEvent(e);
                }

                #endregion
                static SoftKey()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SoftKey), new FrameworkPropertyMetadata(typeof(SoftKey)));
                }

                public SoftKey()
                {
                        this.SetBinding(SoftKey.IsCapsLockProperty, new Binding
                        {
                                RelativeSource = new RelativeSource
                                {
                                        AncestorType = typeof(SoftKeyboard),
                                        Mode = RelativeSourceMode.FindAncestor
                                },
                                Path = new PropertyPath("IsCapsLock")
                        });
                        this.SetBinding(SoftKey.IsShiftPressedProperty, new Binding
                        {
                                RelativeSource = new RelativeSource
                                {
                                        AncestorType = typeof(SoftKeyboard),
                                        Mode = RelativeSourceMode.FindAncestor
                                },
                                Path = new PropertyPath("IsShiftPressed")
                        });
                        this.AddHandler(SoftKey.MouseDownEvent, new MouseButtonEventHandler(HandleMouseDown), true);
                        this.AddHandler(SoftKey.MouseUpEvent, new MouseButtonEventHandler(HandleMouseUp), true);
                }

                private void HandleMouseUp(object sender, MouseButtonEventArgs e)
                {
                        this.ReleaseMouseCapture();
                        if (!this.IsMouseCaptured)
                        {
                                this.IsPressed = false;
                        }
                        this.HandleKeyDown();
                }

                private void HandleMouseDown(object sender, MouseButtonEventArgs e)
                {
                        this.CaptureMouse();
                        if (this.IsMouseCaptured)
                        {
                                this.IsPressed = true;
                        }
                        this.OnSoftKeyDown();
                }
                void HandleKeyDown()
                {
                        if (!string.IsNullOrEmpty(this.DisplayKey))
                        {
                                if (this.DisplayKey == "Shift" && this.ParentKeyboard != null)
                                {
                                        this.ParentKeyboard.IsShiftPressed = !this.ParentKeyboard.IsShiftPressed;
                                        return;
                                }

                                if (this.ParentKeyboard == null)
                                {
                                        SoftKeyboardManager.PressSoftKey(this.DisplayKey, this.EffectiveKey, this.IsShiftPressed, this.IsCapsLock);
                                }
                                else
                                {
                                        SoftKeyboardManager.PressSoftKey(this.DisplayKey, this.EffectiveKey, this.ParentKeyboard.IsShiftPressed, this.ParentKeyboard.IsCapsLock);
                                }
                        }
                }
        }

        /// <summary>
        /// 键盘
        /// </summary>
        [TemplatePart(Name = PART_KEYPANEL, Type = typeof(Grid))]
        [StyleTypedProperty(Property = "KeyStyle", StyleTargetType = typeof(Border))]
        public sealed class SoftKeyboard : Control
        {
                private const string PART_KEYPANEL = "PART_KEYPANEL";

                private Grid _softKeyboardGrid = null;

                /// <summary>
                /// 按键样式
                /// </summary>
                public Style KeyStyle
                {
                        get { return (Style)GetValue(KeyStyleProperty); }
                        set { SetValue(KeyStyleProperty, value); }
                }
                /// <summary>
                /// 按键样式
                /// </summary>
                public static readonly DependencyProperty KeyStyleProperty = DependencyProperty.Register("KeyStyle", typeof(Style), typeof(SoftKeyboard), new PropertyMetadata(null));

                /// <summary>
                /// 是否大写锁定
                /// </summary>
                public bool IsCapsLock
                {
                        get { return (bool)GetValue(IsCapsLockProperty); }
                        private set { SetValue(IsCapsLockProperty, value); }
                }
                /// <summary>
                /// 是否大写锁定
                /// </summary>
                public static readonly DependencyProperty IsCapsLockProperty = DependencyProperty.Register("IsCapsLock", typeof(bool), typeof(SoftKeyboard), new PropertyMetadata(false));

                /// <summary>
                /// 是否Shift按下状态
                /// </summary>
                public bool IsShiftPressed
                {
                        get { return (bool)GetValue(IsShiftPressedProperty); }
                        internal set { SetValue(IsShiftPressedProperty, value); }
                }
                /// <summary>
                /// 是否Shift按下状态
                /// </summary>
                public static readonly DependencyProperty IsShiftPressedProperty = DependencyProperty.Register("IsShiftPressed", typeof(bool), typeof(SoftKeyboard), new PropertyMetadata(false));

                /// <summary>
                /// 标题内容可见性
                /// </summary>
                public Visibility HeadVisibility
                {
                        get { return (Visibility)GetValue(HeadVisibilityProperty); }
                        set { SetValue(HeadVisibilityProperty, value); }
                }
                /// <summary>
                /// 标题内容可见性
                /// </summary>
                public static readonly DependencyProperty HeadVisibilityProperty = DependencyProperty.Register("HeadVisibility", typeof(Visibility), typeof(SoftKeyboard), new PropertyMetadata(Visibility.Visible));

                public static SoftKeyboard Instance { get; }

                static SoftKeyboard()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SoftKeyboard), new FrameworkPropertyMetadata(typeof(SoftKeyboard)));
                        Instance = new SoftKeyboard();
                }

                internal SoftKeyboard()
                {
                        this.Loaded += (sender, e) =>
                        {
                                if (Application.Current.MainWindow != null)
                                {
                                        Application.Current.MainWindow.Activated += MainWindow_Activated;
                                        Application.Current.MainWindow.AddHandler(Window.PreviewKeyDownEvent, new KeyEventHandler(HandleKeyDown), true);
                                        Application.Current.MainWindow.AddHandler(Window.PreviewKeyUpEvent, new KeyEventHandler(HandleKeyUp), true);
                                }
                        };
                }
                #region KeyChanged

                void HandleKey(int flag, KeyEventArgs e)
                {
                        CurrentWindow_KeyChanged(flag, e);
                }
                /// <summary>
                /// 激活窗口时发生
                /// </summary>
                /// <param name="e"></param>
                void MainWindow_Activated(object sender, EventArgs e)
                {
                        this.HandleKey(0, null);
                }
                private void HandleKeyUp(object sender, KeyEventArgs e)
                {
                        this.HandleKey(2, e);
                }
                private void HandleKeyDown(object sender, KeyEventArgs e)
                {
                        this.HandleKey(1, e);
                }
                #endregion

                #region KeyStatesHandle
                void CurrentWindow_KeyChanged(int flag, KeyEventArgs e)
                {
                        switch (flag)
                        {
                                //KeyRefresh
                                case 0:
                                        this.RefreshSoftKeys();
                                        break;

                                //KeyDown
                                case 1:
                                        this.SoftKeyDown(e.Key, e.KeyStates);
                                        break;

                                //KeyUp
                                case 2:
                                        this.SoftKeyUp(e.Key, e.KeyStates);
                                        break;
                        }
                }

                /// <summary>
                /// 刷新键
                /// 目前主要处理Caps、Shift等有状态的键
                /// </summary>
                public void RefreshSoftKeys()
                {
                        this.IsCapsLock = SoftKeyboardManager.GetState(Key.CapsLock);
                        this.IsShiftPressed = (SoftKeyboardManager.GetState(Key.LeftShift) || SoftKeyboardManager.GetState(Key.RightShift));
                }
                /// <summary>
                /// 键按下
                /// </summary>
                /// <param name="key"></param>
                /// <param name="states"></param>
                public void SoftKeyDown(Key key, KeyStates states)
                {
                        switch (key)
                        {
                                case Key.ImeProcessed:
                                case Key.CapsLock:
                                        this.IsCapsLock = SoftKeyboardManager.GetState(Key.CapsLock);
                                        break;

                                case Key.LeftShift:
                                case Key.RightShift:
                                        this.IsShiftPressed = true;
                                        break;
                        }
                }
                /// <summary>
                /// 键抬起
                /// </summary>
                /// <param name="key"></param>
                /// <param name="states"></param>
                public void SoftKeyUp(Key key, KeyStates states)
                {
                        switch (key)
                        {
                                case Key.ImeProcessed:
                                case Key.CapsLock:
                                        this.IsCapsLock = SoftKeyboardManager.GetState(Key.CapsLock);
                                        break;

                                case Key.LeftShift:
                                case Key.RightShift:
                                        this.IsShiftPressed = false;
                                        break;
                        }
                }
                #endregion

                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();
                        this._softKeyboardGrid = this.GetTemplateChild(PART_KEYPANEL) as Grid;
                        if (this._softKeyboardGrid == null)
                        {
                                throw new Exception();
                        }
                        //this._softKeyboardGrid.AddHandler(SoftKey.SoftKeyDownEvent, new RoutedEventHandler(SoftKey_SoftKeyDown));
                }
        }
}
