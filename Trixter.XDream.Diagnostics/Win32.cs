﻿using System;
using System.Runtime.InteropServices;

namespace Trixter.XDream.Diagnostics
{
    static class Win32
    {
        const int SetIcon = 0x80;

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int AllocConsole();

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int FreeConsole();

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        public static void SetWindowIcon(System.Drawing.Icon icon)
        {
            IntPtr mwHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            IntPtr result01 = SendMessage(mwHandle, SetIcon, 0, icon.Handle);
            IntPtr result02 = SendMessage(mwHandle, SetIcon, 1, icon.Handle);
        }// SetWindowIcon()

    }
}
