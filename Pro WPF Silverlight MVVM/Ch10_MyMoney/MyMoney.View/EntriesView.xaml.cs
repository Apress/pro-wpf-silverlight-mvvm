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

using MyMoney.ViewModel;

namespace MyMoney.View
{
    /// <summary>
    /// Interaction logic for EntriesView.xaml
    /// </summary>
    public partial class EntriesView : UserControl
    {
        public EntriesView()
        {
            InitializeComponent();
        }

        private void DataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            //(e.NewItem as EntryViewModel).AccountViewModel = DataContext as AccountViewModel;
        }
    }
}
