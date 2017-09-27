using Cii.Lar.ExpClass;
using Cii.Lar.SysClass;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cii.Lar
{
    static class Program
    {
        private static double dpiFactor = 1;
        /// <summary>
        /// system dpi setting, default is 100%
        /// </summary>
        public static double DpiFactor
        {
            get { return dpiFactor; }
            set { dpiFactor = value; }
        }

        private static ExpManager expManager;

        /// <summary>
        /// The exp document manager
        /// </summary>
        public static ExpManager ExpManager
        {
            get { return expManager; }
        }

        public static EntryForm EntryForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MiniDump.Init();
            Initialize(SysConfig.GetSysConfig().GetSysDefaultCulture());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EntryForm = new EntryForm();
            Application.Run(EntryForm);
        }

        private static void Initialize(CultureInfo sysDefault)
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(IntPtr.Zero);
            DpiFactor = g.DpiX / 96.0;
            g.Dispose();

            Thread.CurrentThread.CurrentUICulture = sysDefault;

            expManager = new ExpManager();
        }
    }
}
