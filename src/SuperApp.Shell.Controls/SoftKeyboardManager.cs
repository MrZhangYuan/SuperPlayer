using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;

namespace SuperApp.Shell.Controls
{
        internal static class SoftKeyboardManager
        {
                public const uint KEYEVENTF_EXTENDEDKEY = 0x1;
                public const uint KEYEVENTF_KEYUP = 0x2;
                [DllImport("user32.dll")]
                private static extern short GetKeyState(int nVirtKey);
                [DllImport("user32.dll")]
                private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


                /// <summary>
                /// 返回具有状态的键的状态
                /// </summary>
                /// <param name="key"></param>
                /// <returns></returns>
                public static bool GetState(Key key)
                {
                        return SoftKeyboardManager.GetKeyState(KeyInterop.VirtualKeyFromKey(key)) == 1;
                }
                /// <summary>
                /// 设置具有状态的键的状态
                /// </summary>
                /// <param name="key"></param>
                /// <param name="state"></param>
                public static void SetState(Key key, bool state)
                {
                        if (state != SoftKeyboardManager.GetState(key))
                        {
                                byte vkey = (byte)KeyInterop.VirtualKeyFromKey(key);
                                SoftKeyboardManager.keybd_event(vkey, 69, 1u, 0u);
                                SoftKeyboardManager.keybd_event(vkey, 69, 3u, 0u);
                        }
                }

                static void PressAKey(byte keycode)
                {
                        //按键
                        SoftKeyboardManager.keybd_event(keycode, 0x45, SoftKeyboardManager.KEYEVENTF_EXTENDEDKEY | 0, 0);
                        //释放按键
                        SoftKeyboardManager.keybd_event(keycode, 0x45, SoftKeyboardManager.KEYEVENTF_EXTENDEDKEY | SoftKeyboardManager.KEYEVENTF_KEYUP, 0);
                }
                static void PressDoubleKey(byte keycode, byte keycode2)
                {
                        //按键
                        SoftKeyboardManager.keybd_event(keycode, 0x45, SoftKeyboardManager.KEYEVENTF_EXTENDEDKEY | 0, 0);
                        SoftKeyboardManager.keybd_event(keycode2, 0x45, SoftKeyboardManager.KEYEVENTF_EXTENDEDKEY | 0, 0);
                        //释放按键
                        SoftKeyboardManager.keybd_event(keycode2, 0x45, SoftKeyboardManager.KEYEVENTF_EXTENDEDKEY | SoftKeyboardManager.KEYEVENTF_KEYUP, 0);
                        SoftKeyboardManager.keybd_event(keycode, 0x45, SoftKeyboardManager.KEYEVENTF_EXTENDEDKEY | SoftKeyboardManager.KEYEVENTF_KEYUP, 0);
                }

                #region FullKeyboard
                static Key KeyFromStringFullKeyboard(string key, EffectiveKey effectiveKey, bool isshiftpressed, bool iscapslock)
                {
                        if (!string.IsNullOrEmpty(key))
                        {
                                switch (key)
                                {
                                        case "1":
                                        case "!":
                                                return Key.D1;

                                        case "2":
                                        case "@":
                                                return Key.D2;

                                        case "3":
                                        case "#":
                                                return Key.D3;

                                        case "4":
                                        case "$":
                                                return Key.D4;

                                        case "5":
                                        case "%":
                                                return Key.D5;

                                        case "6":
                                        case "^":
                                                return Key.D6;

                                        case "7":
                                        case "&":
                                                return Key.D7;

                                        case "8":
                                        case "*":
                                                return Key.D8;

                                        case "9":
                                        case "(":
                                                return Key.D9;

                                        case "0":
                                        case ")":
                                                return Key.D0;

                                        case "-":
                                        case "_":
                                                return Key.OemMinus;

                                        case "=":
                                        case "+":
                                                return Key.OemPlus;

                                        case ";":
                                        case ":":
                                                return Key.OemSemicolon;

                                        case ",":
                                        case "<":
                                                return Key.OemComma;

                                        case ".":
                                        case ">":
                                                return Key.OemPeriod;

                                        case "\"":
                                        case "'":
                                                return Key.OemQuotes;

                                        case "?":
                                        case "/":
                                                return Key.OemQuestion;

                                        case "[":
                                        case "{":
                                                return Key.OemOpenBrackets;

                                        case "]":
                                        case "}":
                                                return Key.OemCloseBrackets;

                                        case "Space":
                                                return Key.Space;

                                        case "Caps":
                                                return Key.CapsLock;

                                        case "Shift":
                                                return Key.LeftShift;

                                        case "Enter":
                                                return Key.Enter;
                                        case "←":
                                        case "System.Windows.Controls.Image":
                                                return Key.Back;

                                        case "ch/en":
                                                return Key.LeftShift | Key.LeftCtrl;

                                        default:
                                                Key result = Key.None;
                                                if (Enum.TryParse(key.ToUpper(), out result))
                                                {
                                                        return result;
                                                }
                                                break;
                                }
                        }
                        return Key.None;
                }
                public static void PressSoftKey(string keystring, EffectiveKey effectiveKey, bool isshiftpressed, bool iscapslock)
                {
                        Key key = KeyFromStringFullKeyboard(keystring, effectiveKey, isshiftpressed, iscapslock);
                        if (key != Key.None)
                        {
                                byte keyCode = unchecked((byte)KeyInterop.VirtualKeyFromKey(key));

                                //处理输入法切换，不同的系统不同的处理方式
                                if (key == (Key.LeftShift | Key.LeftCtrl))
                                {
                                        SoftKeyboardManager.PressAKey(16);

                                        ////win8-win10Shift
                                        //if (OSVersionHelper.IsWindows8OrGreater)
                                        //{
                                        //        //16是Shift虚拟键值
                                        //        SoftKeyboardManager.PressAKey(16);
                                        //}
                                        ////XP-win7 Shift+Ctrl
                                        //else if (OSVersionHelper.IsWindowsXPOrGreater)
                                        //{
                                        //        byte keyCodectrl = unchecked((byte)KeyInterop.VirtualKeyFromKey(Key.LeftCtrl));
                                        //        SoftKeyboardManager.PressDoubleKey(16, keyCodectrl);
                                        //}
                                }
                                else
                                {
                                        if (!isshiftpressed)
                                        {
                                                SoftKeyboardManager.PressAKey(keyCode);
                                        }
                                        else
                                        {
                                                SoftKeyboardManager.PressDoubleKey(16, keyCode);
                                        }
                                }
                        }
                }
                #endregion

                #region NumpadKeyboard
                static Key KeyFromStringNumPadKeyboard(string key)
                {
                        if (!string.IsNullOrEmpty(key))
                        {
                                switch (key)
                                {
                                        case "9":
                                                return Key.NumPad9;
                                        case "8":
                                                return Key.NumPad8;
                                        case "7":
                                                return Key.NumPad7;
                                        case "6":
                                                return Key.NumPad6;
                                        case "5":
                                                return Key.NumPad5;
                                        case "4":
                                                return Key.NumPad4;
                                        case "3":
                                                return Key.NumPad3;
                                        case "2":
                                                return Key.NumPad2;
                                        case "1":
                                                return Key.NumPad1;
                                        case "0":
                                                return Key.NumPad0;
                                        case ".":
                                                return Key.Decimal;
                                        case "←":
                                                return Key.Back;
                                }
                        }
                        return Key.None;
                }
                public static void PressSoftKey(string keystring)
                {
                        Key key = KeyFromStringNumPadKeyboard(keystring);
                        if (key != Key.None)
                        {
                                byte keyCode = unchecked((byte)KeyInterop.VirtualKeyFromKey(key));
                                SoftKeyboardManager.PressAKey(keyCode);
                        }
                }
                #endregion
        }

}
