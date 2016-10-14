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
using System.Windows.Shapes;

namespace MyMoney.View
{
    /// <summary>
    /// Interaction logic for CreateAccountDialog.xaml
    /// </summary>
    public partial class CreateAccountDialog : Window
    {
        public CreateAccountDialog()
        {
            InitializeComponent();
        }

        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
