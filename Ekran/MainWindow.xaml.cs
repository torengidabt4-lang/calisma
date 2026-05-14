using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Ekran
{
    public partial class MainWindow : Window
    {
        private ScreenCapture screenCapture;
        private MouseControl mouseControl;
        private KeyboardControl keyboardControl;

        public MainWindow()
        {
            InitializeComponent();
            screenCapture = new ScreenCapture();
            mouseControl = new MouseControl();
            keyboardControl = new KeyboardControl();
            UpdateStatusBar("Uygulama başlatıldı");
        }

        private void UpdateScreen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage screenshot = screenCapture.CaptureScreen();
                ScreenImage.Source = screenshot;
                UpdateStatusBar("✓ Ekran güncellendi");
                StatusText.Text = "Son güncelleme: " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("✗ Hata: " + ex.Message);
            }
        }

        private void MouseTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mouseControl.SimulateClick();
                UpdateStatusBar("✓ Mouse tıklaması gönderildi");
                StatusText.Text = "Mouse kontrolü test edildi";
            }
            catch (Exception ex)
            {
                UpdateStatusBar("✗ Hata: " + ex.Message);
            }
        }

        private void KeyboardTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                keyboardControl.SendKey('A');
                UpdateStatusBar("✓ Klavye tuşu gönderildi");
                StatusText.Text = "Klavye kontrolü test edildi";
            }
            catch (Exception ex)
            {
                UpdateStatusBar("✗ Hata: " + ex.Message);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateStatusBar(string message)
        {
            StatusBar.Text = message + " [" + DateTime.Now.ToString("HH:mm:ss") + "]";
        }
    }
}