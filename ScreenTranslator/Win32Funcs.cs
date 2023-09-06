using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScreenTranslator
{
    class Win32Funcs
    {
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point p);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKeyCode);
        public static int VK_MBUTTON = 0x4;
        public static int VK_CONTROL = 0x11;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);


        #region Convenience methods
        public static bool SetTopMost(IntPtr hwnd)
        {
            return Win32Funcs.SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        /// <summary>
        /// Gets the parent of the parent of parent of parent of .... the given hwnd
        /// </summary>
        /// <param name="hwnd_">The window handle whose earliest parent is to be found</param>
        /// <returns></returns>
        public static IntPtr GetEarliestParent(IntPtr hwnd_)
        {
            IntPtr hwnd = hwnd_;
            IntPtr parent;
            do
            {
                parent = hwnd;
                hwnd = Win32Funcs.GetParent(hwnd);
            } while (hwnd != IntPtr.Zero);

            return parent;
        }
        #endregion
    }
}
