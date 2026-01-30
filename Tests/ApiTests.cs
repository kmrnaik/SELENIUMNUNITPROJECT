using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using SeleniumNUnitProject.Utilities;
using SeleniumNUnitProject.Models;

namespace ApiTests.Tests
{
    [TestFixture]
    public class ProductApiTests : APITestBase
    {
        private fakestoreapiModel productModel; 
        [Test]
        public async Task GetProduct_ReturnsProduct()
        {
            // Arrange
            int productId = 1;

            // Act
            var response = await _httpClient.GetAsync($"/products/{productId}");
            var content = await response.Content.ReadAsStringAsync(); // To read as string
            var product = JsonConvert.DeserializeObject<fakestoreapiModel.Product>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(product, Is.Not.Null);
            Assert.That(product.Id, Is.EqualTo(productId));
            Assert.That(product.Title, Is.Not.Empty);
            Assert.That(product.Price, Is.GreaterThan(0));
        }
        /*
        [Test]
        public async Task GetAllProducts_ReturnsMultipleProducts()
        {
            // Act
            var response = await _httpClient.GetAsync("/products");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(products, Is.Not.Null);
            Assert.That(products.Count, Is.GreaterThan(0));
            Assert.That(products, Has.All.Matches<Product>(p => p.Id > 0));
            Assert.That(products, Has.All.Matches<Product>(p => !string.IsNullOrEmpty(p.Title)));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public async Task GetProduct_WithDifferentIds_ReturnsCorrectProduct(int productId)
        {
            // Act
            var response = await _httpClient.GetAsync($"/products/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(product.Id, Is.EqualTo(productId));
        }

        [Test]
        public async Task GetProducts_WithQueryParameters_ReturnsFilteredResults()
        {
            // Arrange
            string category = "electronics";

            // Act
            var response = await _httpClient.GetAsync($"/products/category/{category}");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(products, Is.Not.Empty);
            Assert.That(products, Has.All.Matches<Product>(
                p => p.Category.ToLower() == category));
        }
        */
    }
}