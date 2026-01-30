using OpenQA.Selenium;
using System.Net.Http;
using System.Threading.Tasks;

namespace SeleniumNUnitProject.Utilities
{
    public class APITestBase
    {
        public HttpClient _httpClient;
        private const string BaseUrl = "https://fakestoreapi.com";

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient?.Dispose();
        }
    }
}