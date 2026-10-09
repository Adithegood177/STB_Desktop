using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using STB_desktop.Services;

namespace STB_desktop.Services
{
    public class UserApiService :BaseApiService<Users>
    {
        public UserApiService(HttpClient httpClient) : base(httpClient, "users")
        {
        }
    }
}
