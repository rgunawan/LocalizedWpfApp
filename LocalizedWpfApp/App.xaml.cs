using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LocalizedWpfApp.Properties;

namespace LocalizedWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Commands.SwitchToJpCommand = new RelayCommand(o => SwitchTo("ja-JP")); // Japanese in Japan
            Commands.SwitchToEnCommand = new RelayCommand(o => SwitchTo("en-US")); // English in US
        }

        private void SwitchTo(string cultureName)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(cultureName);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(cultureName);

            ResetMainWindow();
        }

        private void ResetMainWindow()
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            MainWindow.Close();
            MainWindow = new MainWindow();
            ShutdownMode = ShutdownMode.OnLastWindowClose;
            MainWindow.ShowDialog();
        }
    }

    public static class Commands
    {
        public static ICommand SwitchToJpCommand { get; set; }
        public static ICommand SwitchToEnCommand { get; set; }
    }
}
