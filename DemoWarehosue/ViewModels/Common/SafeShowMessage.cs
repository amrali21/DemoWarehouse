using System;
using System.IO;
using System.Windows;
//using xcd = Xceed.Wpf.Toolkit;

namespace SpectroBridge
{
    internal class SafeMessageBox
    {
        public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            Application.Current?.Dispatcher.Invoke(() => Application.Current.MainWindow?.Show());
            if(Application.Current.MainWindow != null && !Application.Current.MainWindow.Topmost) Application.Current.MainWindow.Topmost = true;
            return Application.Current?.Dispatcher.Invoke(() => MessageBox.Show(Application.Current.MainWindow, messageText, caption, button, icon))
                    ?? MessageBoxResult.None;
        }

        public static void WriteLog(string fileName, string message)
        {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName,
                  message + "\n");
            
        }
    }
}