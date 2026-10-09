using STB_desktop;
using STB_desktop.ViewModel;
using STB_desktop.AdatBazis.Models;
using STB_desktop.Services;

namespace STB_desktop.ViewModel;

// Örököljük a BaseCrudViewModel-t, és megmondjuk neki, hogy a <T> most a 'Room'
public partial class RoomsViewModel : BaseCrudViewModel<Room>
{
// A konstruktorban megkapjuk a RoomApiService-t, és rögtön tovább is adjuk az ősosztálynak (base)
    public RoomsViewModel(RoomApiService roomApi) : base(roomApi)
    {
    }

    
    // Ide csak olyan speciális dolgokat kell írni.
}