using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Dashboard.WPF.Services
{
    public class DASHBOARD_API
    {
        private static HttpClient dashboard_api;

        public static HttpClient Get()
        {
            dashboard_api = new HttpClient();
            dashboard_api.DefaultRequestHeaders.Clear();
            dashboard_api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            dashboard_api.BaseAddress = new Uri("https://localhost:44316/api");
            return dashboard_api;
        }
    }
}
