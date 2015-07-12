using System.Windows;
using agkik.desktopclient.Services;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace agkik.businesslogic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceInjector.InjectServices();
        }
    }
}
