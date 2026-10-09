# WPF MVVM Új Képernyő (Menüpont) Hozzáadása

Ez a dokumentum lépésről lépésre bemutatja, hogyan lehet egy új menüpontot (pl. Eszközök) felvenni a meglévő MVVM architektúrába.

## 1\. Az API Service létrehozása

**Fájl:** `Services/AssetApiService.cs` **Feladata:** Az adatkapcsolat biztosítása az új végponthoz.

using System.Net.Http;

using STB\_desktop.AdatBazis.Models;

namespace STB\_desktop.Services;

public class AssetApiService : BaseApiService\<Asset\>

{

    public AssetApiService(HttpClient httpClient) : base(httpClient, "assets")

    {

    }

}

## 2\. A ViewModel létrehozása

**Fájl:** `ViewModels/AssetsViewModel.cs` **Feladata:** A felületi logika és az adatok összekötése (örökli a listakezelést).

using STB\_desktop.AdatBazis.Models;

using STB\_desktop.Services;

namespace STB\_desktop.ViewModels;

public partial class AssetsViewModel : BaseCrudViewModel\<Asset\>

{

    public AssetsViewModel(AssetApiService assetApi) : base(assetApi)

    {

    }

}

## 3\. A View (Felület) megrajzolása

**Fájl:** `Views/AssetsView.xaml` (Új WPF UserControl) **Feladata:** A táblázat és a gombok megjelenítése.

\<UserControl x:Class="STB\_desktop.Views.AssetsView"\>

    \<Grid\>

        \<Button Content="Eszközök letöltése" Command="{Binding LoadItemsCommand}" /\>

        \<DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False" Margin="0,40,0,0"\>

            \<DataGrid.Columns\>

                \<DataGridTextColumn Header="Név" Binding="{Binding Name}" /\>

                \<\!-- További oszlopok ide jönnek \--\>

            \</DataGrid.Columns\>

        \</DataGrid\>

    \</Grid\>

\</UserControl\>

## 4\. A DI Konténer frissítése

**Fájl:** `App.xaml.cs` **Feladata:** Az új osztályok regisztrálása a rendszerben.

private void ConfigureServices(IServiceCollection services)

{

    // ... korábbi regisztrációk ...

    services.AddTransient\<AssetApiService\>();

    services.AddTransient\<AssetsViewModel\>();

}

## 5\. A Navigációs parancs felvétele

**Fájl:** `ViewModels/MainViewModel.cs` **Feladata:** Az oldalsó menü gombnyomásának kezelése.

\[RelayCommand\]

public async Task NavigateToAssets()

{

    var vm \= App.ServiceProvider.GetRequiredService\<AssetsViewModel\>();

    CurrentViewModel \= vm;

    await vm.LoadItemsAsync(); 

}

## 6\. A Menügomb és a sablon bekötése

**Fájl:** `MainWindow.xaml` **Feladata:** A gomb megjelenítése és a ViewModel \- View párosítás.

A Window.Resources részbe:

\<DataTemplate DataType="{x:Type viewmodels:AssetsViewModel}"\>

    \<views:AssetsView /\>

\</DataTemplate\>

A bal oldali menü sávba (StackPanel):

\<Button Content="Eszközök" Command="{Binding NavigateToAssetsCommand}" /\>