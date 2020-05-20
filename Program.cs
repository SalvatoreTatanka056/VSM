using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VMS
{
    public static class Kernel32 
    {
        public const uint PROCESS_CALLBACK_FILTER_ENABLED = 0x1;

        [DllImport("Kernel32.dll")]
        public static extern bool SetProcessUserModeExceptionPolicy(UInt32 dwFlags);

        [DllImport("Kernel32.dll")]
        public static extern bool GetProcessUserModeExceptionPolicy(out UInt32 lpFlags);


        public static void DisableUMCallbackFilter()
        {
            uint flags;
            GetProcessUserModeExceptionPolicy(out flags);

            flags &= ~PROCESS_CALLBACK_FILTER_ENABLED;
            SetProcessUserModeExceptionPolicy(flags);
        }
    }

     static class Program 
    {
 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAppInit());
        }
    }
}
