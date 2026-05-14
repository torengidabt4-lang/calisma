using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Ekran
{
    public class ScreenCapture
    {
        /// <summary>
        /// Ekran görüntüsünü alır ve WPF için BitmapImage olarak döndürür
        /// </summary>
        public BitmapImage CaptureScreen()
        {
            try
            {
                // Ekranın boyutlarını al
                int screenWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
                int screenHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

                // Bitmap oluştur
                Bitmap screenshot = new Bitmap(screenWidth, screenHeight);
                Graphics graphics = Graphics.FromImage(screenshot);

                // Ekranı çiz
                graphics.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));

                // Bitmap'i BitmapImage'a çevir
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
                throw new Exception("Ekran görüntüsü alınamadı: " + ex.Message);
            }
        }
    }
}