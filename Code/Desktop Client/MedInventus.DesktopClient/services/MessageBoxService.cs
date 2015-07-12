using System.Windows;

namespace agkik.desktopclient.Services
{
    internal class MessageBoxService : IMessageBoxService
    {
        public void Show(string text)
        {
            MessageBox.Show(text);
        }
        public void Show(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }

        public void Show(string text, string caption, string image)
        {
            MessageBox.Show(text, caption);
        }

        public MessageBoxResult Show(string text, string caption, MessageBoxButton buttons, MessageBoxImage image)
        {
            return MessageBox.Show(text, caption, buttons, image);
        }
    }
}
