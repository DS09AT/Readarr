using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Instrumentation;
using Shelvance.Host;
using Shelvance.SysTray;

namespace Shelvance
{
    public static class WindowsApp
    {
        private static readonly Logger Logger = ShelvanceLogger.GetLogger(typeof(WindowsApp));

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            try
            {
                var startupArgs = new StartupContext(args);

                ShelvanceLogger.Register(startupArgs, false, true);

                Bootstrap.Start(args, e => { e.ConfigureServices((_, s) => s.AddSingleton<IHostedService, SystemTrayApp>()); });
            }
            catch (Exception e)
            {
                Logger.Fatal(e, "EPIC FAIL");
                MessageBox.Show($"{e.GetType().Name}: {e}", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error, caption: "Epic Fail!");
            }
        }
    }
}
