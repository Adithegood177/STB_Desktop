using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using STB_desktop.Services;
namespace STB_desktop.Services
{
    public class AssetApiService : BaseApiService<Asset>
    {
        public AssetApiService(HttpClient httpClient) : base(httpClient, "assets")
        {

        }
    }
}
