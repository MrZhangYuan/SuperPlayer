using ActiproSoftware.Products;
using ActiproSoftware.Windows.Themes;
using SuperPlayer.Business;
using SuperPlayer.Components;
using SuperPlayer.Core;
using SuperPlayer.Core.Service;
using SuperPlayer.Core.Utilities;
using SuperPlayer.Services;
using SuperPlayer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using UltimateCore.Dispatcher;
using UltimateCore.Services;

namespace SuperPlayer
{
        /// <summary>
        /// App.xaml 的交互逻辑
        /// </summary>
        public partial class App : Application
        {
                public App()
                {
                        this.DispatcherUnhandledException += App_DispatcherUnhandledException;
                        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                        this.InitServices();
                }

                private void InitServices()
                {
                        Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        ServiceProvider.Instance.RegisterService<IDispatcherService>(new DispatcherService());
                        ServiceProvider.Instance.RegisterService<IDataContext>(new DataContext());
                        ServiceProvider.Instance.RegisterService<IBitmapCreater>(new FileThumbnailBitmapCreater());
                        ServiceProvider.Instance.RegisterService<IPlayerHost>(new APlayerHost());

                        this.RegisterAcControls();
                }

                private void RegisterAcControls()
                {
                        //----------------------------------------------------------------------------------------------
                        //
                        // 此种方式不需注册表
                        //
                        //----------------------------------------------------------------------------------------------
                        ConstructorInfo construct = typeof(ActiproLicense).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[1];
                        ActiproLicense license = (ActiproLicense)construct.Invoke
                                (
                                        new object[]
                                        {
                                                ActiproSoftware.Products.Docking.AssemblyInfo.Instance,
                                                "Actipro Customer",
                                                "WPF172X240WU201VCL119WKGG",
                                                ActiproLicenseSourceLocation.None,
                                                0,
                                                131071u,
                                                (byte)17,
                                                (byte)2,
                                                AssemblyLicenseType.Full,
                                                (byte)1,
                                                AssemblyPlatform.Wpf,
                                                (ushort)180,
                                                DateTime.Now
                                        }
                                );

                        FieldInfo licensefield = typeof(ActiproLicenseManager).GetField("#pBb", BindingFlags.Static | BindingFlags.NonPublic);
                        Dictionary<Type, ActiproLicense> licensediction = new Dictionary<Type, ActiproLicense>();
                        licensefield.SetValue(null, licensediction);

                        //使用哪个dll，注册那个dll的AssemblyInfo
                        licensediction.Add(ActiproSoftware.Products.Docking.AssemblyInfo.Instance.GetType(), license);
                        licensediction.Add(ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetType(), license);
                        licensediction.Add(ActiproSoftware.Products.Views.AssemblyInfo.Instance.GetType(), license);

                        //Stopwatch sw = Stopwatch.StartNew();
                        ////ThemeManager.CurrentTheme = ThemeName.MetroLight.ToString();
                        //ThemeManager.CurrentTheme = "MetroLightBlue";
                        //sw.Stop();
                }

                private readonly object _lockobj = new object();
                private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
                {
                        lock (this._lockobj)
                        {
                                File.WriteAllText("log.txt", e.ExceptionObject + "");
                        }
                }
                private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
                {
                        lock (this._lockobj)
                        {
                                File.WriteAllText("log.txt", e.Exception + "");
                        }
                        e.Handled = true;
                }
        }
}
