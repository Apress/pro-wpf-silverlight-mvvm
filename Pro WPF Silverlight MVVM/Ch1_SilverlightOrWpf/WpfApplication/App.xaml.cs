using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string message =
#if SILVERLIGHT
                "This is a Silverlight application";
#else
                "This is a WPF application";
#endif
            MessageBox.Show(message);
        }
    }
}
