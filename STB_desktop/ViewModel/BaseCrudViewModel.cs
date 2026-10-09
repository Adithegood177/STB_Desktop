using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using STB_desktop.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using STB_desktop.Services; // A BaseApiService miatt kell

namespace STB_desktop.ViewModel;

// Az 'abstract' jelzi, hogy ezt az osztályt önmagában nem példányosítjuk, csak örökölünk belőle
public abstract partial class BaseCrudViewModel<T> : ObservableObject where T : class
{
    // Ezt a szolgáltatást a gyerekosztályoktól (pl. RoomsViewModel) kapjuk meg
    protected readonly BaseApiService<T> _apiService;

    // Ez lesz az ÁLTALÁNOS lista, amit a XAML-hez kötünk (a neve 'Items' lesz)
    [ObservableProperty]
    private ObservableCollection<T> _items = new();

    public BaseCrudViewModel(BaseApiService<T> apiService)
    {
        _apiService = apiService;
    }

    // A közös betöltő parancs
    [RelayCommand]
    public virtual async Task LoadItemsAsync()
    {
        var fetchedData = await _apiService.GetAllAsync();

        _items.Clear();
        foreach (var item in fetchedData)
        {
            _items.Add(item);
        }
    }

    // Törlés
    // [RelayCommand]
    // public virtual async Task DeleteItemAsync(T item) { ... }
}