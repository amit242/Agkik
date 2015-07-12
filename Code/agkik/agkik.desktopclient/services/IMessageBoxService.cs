using System.Windows;

namespace agkik.desktopclient.Services
{
    internal interface IMessageBoxService
    {
        void Show(string text);
        void Show(string text, string caption);
        void Show(string text, string caption, string image);

        MessageBoxResult Show(
            string text,
            string caption,
            MessageBoxButton buttons,
            MessageBoxImage image);
    }
}
