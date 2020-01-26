using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperPlayer
{
        public class Program
        {
                private static Mutex _mutex = null;

                [STAThread]
                public static void Main(string[] args)
                {
                        _mutex = new Mutex(true, "DCC52EBE-CA50-4D75-BABE-60F8650DDF66", out bool nothasinstance);
                        if (!nothasinstance)
                        {
                                return;
                        }

                        App app = new App();
                        app.InitializeComponent();
                        app.Run();
                }
        }
}
