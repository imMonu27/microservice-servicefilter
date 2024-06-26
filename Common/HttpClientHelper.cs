using System.Text;

namespace Employe_Management_System.Common
{
    public class HttpClientHelper
    {
        public static async Task<string> MakePostRequest(string baseUrl, string endpoint, string requestResponce)
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                MaxConnectionsPerServer = 10
            };
            using (HttpClient httpClient = new HttpClient(socketsHandler))
            {
                httpClient.Timeout = TimeSpan.FromMinutes(10);
                httpClient.BaseAddress = new Uri(baseUrl);
                StringContent Apireqcontent = new StringContent(requestResponce, Encoding.UTF8, "application/json");
                var httpresponce = httpClient.PostAsync(endpoint, Apireqcontent).Result;
                var httpresponcestring = httpresponce.Content.ReadAsStringAsync().Result;

                if (!httpresponce.IsSuccessStatusCode)
                {
                    throw new Exception(httpresponcestring);
                }
                return httpresponcestring;
            }
        }
        

        public static async Task<string> MakeGetRequest(string baseUrl, string endpoint)
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                MaxConnectionsPerServer = 10
            };
            using (HttpClient httpClient = new HttpClient(socketsHandler))
            {
                httpClient.Timeout = TimeSpan.FromMinutes(10);
                httpClient.BaseAddress = new Uri(baseUrl);

                var httpresponce = await httpClient.GetAsync(endpoint);
                var httpresponcestring = await httpresponce.Content.ReadAsStringAsync();

                if (!httpresponce.IsSuccessStatusCode)
                {
                    throw new Exception(httpresponcestring);
                }
                return httpresponcestring;
            }
        }

        public static async Task<string> MakeGetByIdRequest(string baseUrl, string endpoint, string requestResponce)
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                MaxConnectionsPerServer = 10
            };
            using (HttpClient httpClient = new HttpClient(socketsHandler))
            {
                httpClient.Timeout = TimeSpan.FromMinutes(10);
                httpClient.BaseAddress = new Uri(baseUrl);

                StringContent Apireqcontent = new StringContent(requestResponce, Encoding.UTF8, "application/json");
                
                var HttpResponce = httpClient.PostAsync(endpoint, Apireqcontent);
                var httpresponce =  httpClient.GetAsync(endpoint).Result;
                var httpresponcestring =  httpresponce.Content.ReadAsStringAsync().Result;

                if (!httpresponce.IsSuccessStatusCode)
                {
                    throw new Exception(httpresponcestring);
                }
                return httpresponcestring;
            }
        }
    }
}
