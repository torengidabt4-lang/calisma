using System;
using System.Runtime.InteropServices;

namespace Ekran
{
    public class MouseControl
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MOVE = 0x0001;

        public void MoveMouse(int x, int y)
        {
            try
            {
                SetCursorPos(x, y);
            }
            catch (Exception ex)
            {
                throw new Exception("Mouse hareketi basarisiz: " + ex.Message);
            }
        }

        public void SimulateClick()
        {
            try
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception("Mouse tiklamasi basarisiz: " + ex.Message);
            }
        }

        public void SimulateRightClick()
        {
            try
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception("Sag tiklama basarisiz: " + ex.Message);
            }
        }
    }
}