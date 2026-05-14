using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Ekran
{
    public class ScreenCapture
    {
        public BitmapImage CaptureScreen()
        {
            try
            {
                int screenWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
                int screenHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

                Bitmap screenshot = new Bitmap(screenWidth, screenHeight);
                Graphics graphics = Graphics.FromImage(screenshot);

                graphics.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));

                BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    screenshot.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    memoryStream.Position = 0;
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                }

                graphics.Dispose();
                screenshot.Dispose();

                return bitmapImage;
            }
            catch (Exception ex)
            {
                throw new Exception("Ekran goruntus alınamadı: " + ex.Message);
            }
        }
    }
}