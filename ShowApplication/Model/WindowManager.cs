using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ShowApplication.Model
{
    class WindowManager
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);

        private enum WindowPlacementEnum
        {
            Normal = 1,
            Minimized = 2,
            Maximized = 3
        }

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        private struct WindowPlacement
        {
            public int length;
            public int flags;
            public int showCmd;
            public Point ptMinPosition;
            public Point ptMaxPosition;
            public Rectangle rcNormalPosition;
        }

        public static void RestoreWindow(Process processByName)
        {
            var hWnd = processByName.MainWindowHandle;

            //https://msdn.microsoft.com/en-us/library/windows/desktop/ms633548(v=vs.85).aspx
            // SW_SHOWMINIMIZED
            //ShowWindowAsync(hWnd, 2);
            // SW_RESTORE
            var placement = new WindowPlacement();
            GetWindowPlacement(hWnd, ref placement);
            if (placement.showCmd == (int)WindowPlacementEnum.Minimized)
                ShowWindowAsync(hWnd, (int)ShowWindowEnum.Restore);
            // SW_SHOWNORMAL
            //ShowWindowAsync(hWnd, 1);



            // just in case we set it on the forground
            SetForegroundWindow(hWnd);
        }
    }
}
