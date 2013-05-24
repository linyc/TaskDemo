using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyControlEngine;
using System.Collections;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //CWin32CBTHook cw = new CWin32CBTHook();
            //cw.WindowCreated += new CWin32CBTHook.CbtEventHandler(cw_WindowCreated);
            //cw.WindowDestroyed += new CWin32CBTHook.CbtEventHandler(cw_WindowDestroyed);
            //cw.InstallHook();
            Application.Run(new Form4());
        }

        static void cw_WindowDestroyed(object sender, CWin32CBTHook.CbtEventArgs e)
        {
            System.IO.File.AppendAllText("b.txt", (i--).ToString() + ',');
        }
        static int i = 0;
        static void cw_WindowCreated(object sender, CWin32CBTHook.CbtEventArgs e)
        {
            System.IO.File.AppendAllText("a.txt", (i++).ToString()+',');
        }
    }
}
