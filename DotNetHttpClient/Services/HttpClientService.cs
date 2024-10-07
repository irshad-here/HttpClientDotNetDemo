using DotNetHttpClient.DTO;
using System.Text;
using System.Text.Json;

namespace DotNetHttpClient.Services
{
    public class HttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public async Task GetProductData()
        public async Task<List<ProductDTO>> GetProductData()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://fakestoreapi.com/products"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();

                // Deserialize the JSON into a List of ProductDTO objects
                List<ProductDTO> products = JsonSerializer.Deserialize<List<ProductDTO>>(response);

                return products;
            };
        }
    }
}
