using Cii.Lar.DrawTools;
using Cii.Lar.ExpClass;
using Cii.Lar.SysClass;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            //int diameter1 = 20;
            //List<Circle> circles = new List<Circle>();
            //circles.Add(new Circle(new PointF(1023, 675), new Size(diameter1, diameter1)));
            //circles.Add(new Circle(new PointF(691, 541), new Size(diameter1, diameter1)));
            //circles.Add(new Circle(new PointF(975, 278), new Size(diameter1, diameter1)));
            //circles.Add(new Circle(new PointF(1209, 182), new Size(diameter1, diameter1)));
            //circles.Add(new Circle(new PointF(1153, 805), new Size(diameter1, diameter1)));
            //circles.Add(new Circle(new PointF(367, 762), new Size(diameter1, diameter1)));
            //circles.Add(new Circle(new PointF(408, 142), new Size(diameter1, diameter1)));
            //var v = JsonFile.GetJsonTextFromConfig(circles);
            //JsonFile.WriteConfigToLocal(v);
            //List<Circle> circles2 = new List<Circle>();

            //var v2 = JsonFile.ReadJsonConfigString();
            //circles2 = JsonFile.GetConfigFromJsonText<List<Circle>>(v2);
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
