namespace PowerLoop.UI
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using MudBlazor.Services;
    using PowerLoop.UI.Play;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Register services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddMudServices();
            serviceCollection.AddScoped<PlayViewModel>();

            // Add for the webview
            this.Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
