using Jarmukolcsonzo.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jarmukolcsonzo.WPF.Views
{
    /// <summary>
    /// Interaction logic for JarmuvekView.xaml
    /// </summary>
    public partial class JarmuvekView : UserControl
    {
        public JarmuvekView()
        {
            InitializeComponent();
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            JarmuvekViewModel? vm = DataContext as JarmuvekViewModel;
            if (vm is not null)
            {
                vm.SortKey = e.Column.SortMemberPath;
                e.Column.SortDirection = vm.Ascending ?
                    ListSortDirection.Ascending :
                    ListSortDirection.Descending;
  
            }
        }
    }
}
