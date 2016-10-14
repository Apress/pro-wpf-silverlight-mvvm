using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PortChecker_ModelView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            portChecker = new PortChecker.Model.PortChecker();
        }        

        private void CheckPortsClick(object sender, RoutedEventArgs e)
        { 
            PortChecker.Model.PortChecker portChecker = new PortChecker.Model.PortChecker();

            portChecker.ScanPorts(machineNameOrIpAddress.Text);

            ports.ItemsSource = portChecker.Ports;
        }

        private PortChecker.Model.PortChecker portChecker;
    }
}
