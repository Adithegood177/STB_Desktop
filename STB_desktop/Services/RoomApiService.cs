using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using STB_desktop;
using STB_desktop.AdatBazis.Models;
namespace STB_desktop.Services
{
    public class RoomApiService :BaseApiService<Room>
    {
        public RoomApiService(HttpClient httpClient) : base(httpClient, "rooms")
        {
        }

    }
}
