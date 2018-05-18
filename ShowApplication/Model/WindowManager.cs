using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShowApplication.Model
{
    class WindowManager
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void RestoreWindow(Process processByName)
        {

            var hWnd = processByName.MainWindowHandle;

            //https://msdn.microsoft.com/en-us/library/windows/desktop/ms633548(v=vs.85).aspx
            // SW_SHOWMINIMIZED
            //ShowWindowAsync(hWnd, 2);
            // SW_RESTORE
            //ShowWindowAsync(hWnd, 9);
            // SW_SHOWNORMAL
            //ShowWindowAsync(hWnd, 1);

            // just in case we set it on the forground
            SetForegroundWindow(hWnd);
        }
    }
}
