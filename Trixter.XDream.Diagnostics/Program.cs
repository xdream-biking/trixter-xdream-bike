using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixter.XDream.Diagnostics.Properties;
using Trixter.XDream.Diagnostics.Update;

namespace Trixter.XDream.Diagnostics
{

    internal static class Program
    {
        

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            UpdateManager updateManager = new UpdateManager(Settings.Default, Constants.GithubUpdateUrl);

            Task.Delay(10000).ContinueWith(_ => updateManager.CheckForUpdatesIfNeeded(false));

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm() { DataAccess = dataAccess, UpdateManager = updateManager };
            Application.Run(mainForm);


            return 0;
        }
    }
}
