using STB_desktop;
using STB_desktop.ViewModel;
using STB_desktop.AdatBazis.Models;
using STB_desktop.Services;
namespace STB_desktop.ViewModel
{
    public partial class AssetViewModel : BaseCrudViewModel<Asset>
    {
        public AssetViewModel(AssetApiService assetApiService) : base(assetApiService)
        {
        }
    }
}
