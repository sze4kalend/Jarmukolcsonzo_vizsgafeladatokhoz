using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jarmukolcsonzo.Shared.DTOs;
using Jarmukolcsonzo.Shared.Models;
using Jarmukolcsonzo.Shared.Repositories;
using Jarmukolcsonzo.WPF.Repositories;
using System.Collections.ObjectModel;

namespace Jarmukolcsonzo.WPF.ViewModels
{
    public partial class JarmuvekViewModel : ObservableObject
    {
        private readonly IDataTableRepository<Jarmu> _jarmuRepo;
        private readonly IGenericRepository<JarmuTipus> _jarmuTipusRepo;

        public JarmuvekViewModel(IDataTableRepository<Jarmu> jarmuRepo, IGenericRepository<JarmuTipus> jarmuTipusRepo)
        {
            _jarmuRepo = jarmuRepo;
            _jarmuTipusRepo = jarmuTipusRepo;
            New();
            _ = LoadDataAsync();
        }

        [ObservableProperty]
        private ObservableCollection<Jarmu>? jarmuvek;
        [ObservableProperty]
        private ObservableCollection<JarmuTipus>? jarmuTipusok;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private Jarmu? selectedItem;

        private async Task LoadDataAsync()
        {
            // ObservableCollection-nek a konstruktora tud listát fogadni, de nem egyenlő vele
            //
            TableDto<Jarmu> result = await _jarmuRepo.GetAllAsync(Page, ItemsPerPage);
            Jarmuvek = new ObservableCollection<Jarmu>(result.Data);
            TotalItems = result.TotalItems;
            JarmuTipusok = new(await _jarmuTipusRepo.GetAllAsync() ?? []);
        }

        [RelayCommand] 
        // Generál egy parancsot metódusnév+Command
        // Kivétel Async végződésűeket levágja pl. SaveCommand
        private void New()
        {
            SelectedItem = new();
        }

        [RelayCommand]
        private async Task SaveAsync(Jarmu jarmu)
        {
            bool exists = await _jarmuRepo.ExistsByIdAsync(jarmu.id);
            if (exists) // Módosítás
            {
                await _jarmuRepo.UpdateAsync(jarmu.id, jarmu);
                // A View-ben automatikusan módosul az ObservableCollection miatt
            }
            else // Létrehozás
            {
                jarmu = await _jarmuRepo.InsertAsync(jarmu); // ID kulcs frissítése
                Jarmuvek?.Insert(0, jarmu); // Nézet frissítése
            }
        }

        private bool CanDelete(Jarmu jarmu) // Törlés gomb inaktiválása
        {
            if (jarmu != null)
            {
                return jarmu.id > 0; // Új elem esetén
            }
            return false;
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        private async Task DeleteAsync(Jarmu jarmu)
        {
            await _jarmuRepo.DeleteAsync(jarmu.id); // Ez a háttér tárolóból szedi ki (DB)
            Jarmuvek?.Remove(jarmu); // Nézet frissítése
        }
    }
}
