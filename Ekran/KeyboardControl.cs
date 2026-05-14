using System;
using System.Runtime.InteropServices;

namespace Ekran
{
    public class KeyboardControl
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, IntPtr dwExtraInfo);

        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;

        public void SendKey(char key)
        {
            try
            {
                byte vKey = (byte)char.ToUpper(key);
                keybd_event(vKey, 0, KEYEVENTF_KEYDOWN, IntPtr.Zero);
                System.Threading.Thread.Sleep(50);
                keybd_event(vKey, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception("Tus gonderimi basarisiz: " + ex.Message);
            }
        }

        public void PressEnter()
        {
            try
            {
                byte vKey = 0x0D;
                keybd_event(vKey, 0, KEYEVENTF_KEYDOWN, IntPtr.Zero);
                System.Threading.Thread.Sleep(50);
                keybd_event(vKey, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception("Enter basma basarisiz: " + ex.Message);
            }
        }

        public void SendText(string text)
        {
            try
            {
                foreach (char c in text)
                {
                    SendKey(c);
                    System.Threading.Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Metin gonderimi basarisiz: " + ex.Message);
            }
        }
    }
}