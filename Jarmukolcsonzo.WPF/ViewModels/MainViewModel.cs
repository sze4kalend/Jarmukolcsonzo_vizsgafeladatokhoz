using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using Jarmukolcsonzo.WPF.Repositories;
namespace Jarmukolcsonzo.WPF.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            ChangeContent("Jarmuvek");
        }

        [ObservableProperty]
        private ObservableObject? selectedViewModel;

        [RelayCommand]
        // Menuelemre kattintására történő parancs
        private void ChangeContent(string menuName)
        {
            switch (menuName)
            {
                case "Jarmuvek":
                    // A kiválasztott ViewModel frissítése (ContentControl tartalma)
                    SelectedViewModel = Ioc.Default.GetRequiredService<JarmuvekViewModel>();
                    // SelectedViewModel = new JarmuvekViewModel(new JarmuLocalRepository(), new JarmuTipusLocalRepository());
                    break;
                case "Ugyfelek":
                    SelectedViewModel = new UgyfelekViewModel();
                    break;
                default:
                    break;
            }
        }

        // Ezt generálja le
        /*
        private ObservableObject _selectedViewModel;
        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { SetProperty(ref _selectedViewModel, value); }
        }
        */
    }
}
