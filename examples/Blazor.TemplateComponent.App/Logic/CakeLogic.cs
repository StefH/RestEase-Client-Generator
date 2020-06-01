using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.TemplateComponent.App.Models;
using Newtonsoft.Json;

namespace Blazor.TemplateComponent.App.Logic
{
    public class CakeLogic : ICakeLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CakeLogic(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<Cake>> GetAll()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44316/api/cake/get");

            var httpClient = _httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await httpClient.SendAsync(request);
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(data))
                {
                    return JsonConvert.DeserializeObject<List<Cake>>(data);
                }
            }
            return null;
        }

    }
}
