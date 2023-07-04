using System;
using System.Runtime.InteropServices;

namespace Clickwherever
{
    class CursorHandler
    {
        #region Constants

        private const UInt32 MouseEventfLeftDown = 0x0002;
        private const UInt32 MouseEventfLeftUp = 0x0004;

        //Screen coord conversion factors.
        public const double ScreenXConv1024 = 64.0; //65535 / 1024
        public const double ScreenYConv768 = 85.3; //65535 / 768

        #endregion

        #region DllImports

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, long dx, long dy, uint dwData, IntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

        #endregion

        /// <summary>
        /// Sends the mouse left click.
        /// </summary>
        public static void SendMouseLeftClick()
        {
            SendMouseLeftDownClick();
            SendMouseLeftUpClick();
        }

        /// <summary>
        /// Sends the mouse left down click.
        /// </summary>
        public static void SendMouseLeftDownClick()
        {
            mouse_event(MouseEventfLeftDown, 0, 0, 0, new IntPtr());
            mouse_event(MouseEventfLeftUp, 0, 0, 0, new IntPtr());

        }

        /// <summary>
        /// Sends the mouse left up click.
        /// </summary>
        public static void SendMouseLeftUpClick()
        {
            mouse_event(MouseEventfLeftUp, 0, 0, 0, new IntPtr());
        }

        /// <summary>
        /// Moves the mouse to.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public static void MoveMouseTo(int x, int y)
        {
            //Logger.LogInformation("Move mouse to X: " + x + " Y: " + y);
            SetCursorPos(x, y);
        }
    }
}
