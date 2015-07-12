namespace agkik.desktopclient.Services
{
    public static class ServiceInjector
    {
        // Loads service objects into the ServiceContainer on startup.
        public static void InjectServices()
        {
            ServiceContainer.Instance.AddService<IMessageBoxService>(new MessageBoxService());
        }
    }
}
