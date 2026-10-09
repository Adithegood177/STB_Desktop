using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using STB_desktop.AdatBazis.Models;
using STB_desktop.Services;
namespace STB_desktop.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject _currentViewModel = null!;

        [RelayCommand]

        // navigációban ez visz át a másik oldalra és betölti a termeket
        public async Task NavigateToRooms()
        {
            // kérjük a RoomsViewModel példányt a DI-ből
            var vm = App.ServiceProvider.GetRequiredService<RoomsViewModel>();
            
            // állítsuk be a GENERATED property-t, ne a backing fieldet, hogy a UI értesüljön a változásról
            CurrentViewModel = vm;

            // töltsük be az adatokat (BaseCrudViewModel.LoadItemsAsync)
            await vm.LoadItemsAsync();
        }

        [RelayCommand]
        // navigáció az eszközökhöz és betöltés
        public async Task NavigateToAssets()
        {
            var vm = App.ServiceProvider.GetRequiredService<AssetViewModel>();
            CurrentViewModel = vm;
            await vm.LoadItemsAsync();
        }

    }
}
