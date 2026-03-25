using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Jarmukolcsonzo.WPF.ViewModels
{
    public abstract partial class DataTableViewModel : ObservableObject
    {
        protected abstract Task LoadDataAsync();

        #region Lapozás
        private int PageCount;
        protected int Page = 1;

        private int _itemsPerPage = 25;
        public int ItemsPerPage
        {
            get { return _itemsPerPage; }
            set { SetProperty(ref _itemsPerPage, value); LoadDataAsync(); }
        }
        public List<int> ItemsPerPageList { get; } = [10, 25, 50];

        [ObservableProperty]
        public string currentPage = string.Empty; // 5/20

        private int _totalItems;
        public int TotalItems // Backendtől kapjuk
        { 
            get { return _totalItems; }
            set
            {
                PageCount = (value - 1) / _itemsPerPage + 1;
                CurrentPage = Page + "/" + PageCount;
                SetProperty(ref _totalItems, value);
                if (Page > PageCount) // Túlcsordulás elleni védelem
                {
                    LastPage();
                }
            }
        }

        [RelayCommand] // FirstPageCommand
        private void FirstPage()
        {
            Page = 1;
            LoadDataAsync();
        }

        [RelayCommand] // PrevPageCommand
        private void PrevPage()
        {
            if (Page > 1)
            {
                Page--;
                LoadDataAsync();
            }
        }

        [RelayCommand] // NextPageCommand
        private void NextPage()
        {
            if (Page < PageCount)
            {
                Page++;
                LoadDataAsync();
            }
        }

        [RelayCommand] // LastPageCommand
        private void LastPage()
        {
            Page = PageCount;
            LoadDataAsync();
        }

        #endregion
    }
}
