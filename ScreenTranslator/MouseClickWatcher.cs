using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenTranslator
{
    /// <summary>
    /// This class provides an event that's fired upon middle mouse button click (key up)
    /// </summary>
    class MouseWatcher
    {
        private static Thread mouseClickWatcherThread;
        private static Thread cursorPositionWatcherThread;

        public delegate void OnMiddleClick();
        public delegate void OnCursorMovedToTopLeftCorner();
        public static event OnMiddleClick MiddleClickEventHandler;
        public static event OnCursorMovedToTopLeftCorner CursorMovedToTopLeftCorner;

        private static volatile bool buttonPressed;
        private static volatile bool cursorMovedToTopLeftCorner;
        static MouseWatcher()
        {
            mouseClickWatcherThread = new Thread(MouseClickWatcherThreadProc) { IsBackground = true };
            mouseClickWatcherThread.Start();

            cursorPositionWatcherThread = new Thread(CursorPositionWatcherThreadProc) { IsBackground = true };
            cursorPositionWatcherThread.Start();
        }

        private static void MouseClickWatcherThreadProc()
        {
            while (true)
            {
                if ((Win32Funcs.GetAsyncKeyState(Win32Funcs.VK_MBUTTON) & 0x8000) == 0x8000) // middle click button is in pressed state
                    buttonPressed = true;
                else if ((Win32Funcs.GetAsyncKeyState(Win32Funcs.VK_MBUTTON) & 0x8000) != 0x8000) // middle click button is no longer in pressed state
                {
                    if (buttonPressed)
                    {
                        buttonPressed = false; // reset
                        if (MiddleClickEventHandler != null)
                        {
                            new Thread(() => MiddleClickEventHandler()) { IsBackground = true }.Start(); // call the event handler in a new thread, don't want our watcher loop interrupted
                        }

                    }
                }

                Thread.Sleep(10);
            }

        }

        private static void CursorPositionWatcherThreadProc()
        {
            while (true)
            {
                Point cursorPos;
                Win32Funcs.GetCursorPos(out cursorPos);

                if (cursorPos.X <= 20 && cursorPos.Y <= 20) // tolerance of 20 pixels
                {
                    if (!cursorMovedToTopLeftCorner)
                    {
                        if (CursorMovedToTopLeftCorner != null)
                        {
                            new Thread(() => CursorMovedToTopLeftCorner()) { IsBackground = true }.Start(); // call the event handler in a new thread, don't want our watcher loop interrupted
                        }
                    }

                    cursorMovedToTopLeftCorner = true;
                }
                else
                {
                    cursorMovedToTopLeftCorner = false;
                }

                Thread.Sleep(10);
            }
        }
    }
}
