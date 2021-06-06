using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models.Dto.Products;
using WarehouseTests;
using Xunit;

namespace WarehousesSystemAPI.IntegrationTests
{
    public class ProductsTests : ApiTestBase
    {
       
        [Fact]
        public async Task GetProductsTestAsync()
        {
            var response = await HttpClient.GetAsync("api/products");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductsListTestAsync()
        {
            List<ProductDto> products = await GetProductsListAsync();

            Assert.NotNull(products);
        }

        [Fact]
        public async Task PostProductTestAsync()
        {
            var jsonRequest = JsonSerializer.Serialize<SaveProductRequest>( new SaveProductRequest(new ProductDto(0, "test", 1, 1, 1)));            
            
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync("api/products", httpContent);

            var jsonString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<SaveProductResponse>(jsonString);

            Assert.Equal("Success", deserializedResponse.StatusText);
        }

        [Fact]
        public async Task PutProductTestAsync()
        {
            List<ProductDto> products = await GetProductsListAsync();
            
            var isEmptyProducts = products.Count == 0 ? true : false; 
            
            var jsonRequestPut = JsonSerializer.Serialize<UpdateProductRequest>(new UpdateProductRequest(
                new ProductDto(isEmptyProducts ? 1 : products[0].ProductId, "test", 1, 1, 1)));
            
            var httpContent = new StringContent(jsonRequestPut, Encoding.UTF8, "application/json");
            
            if (isEmptyProducts)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => HttpClient.PutAsync("api/products", httpContent));
            }
            else
            {
                var response = await HttpClient.PutAsync("api/products", httpContent);

                var jsonString = await response.Content.ReadAsStringAsync();

                var deserializedResponse = JsonSerializer.Deserialize<SaveProductResponse>(jsonString);

                Assert.Equal("Success", deserializedResponse.StatusText);                
            }
        }

        [Fact]
        public async Task DeleteProductTestAsync()
        {
            List<ProductDto> products = await GetProductsListAsync();

            var isEmptyProducts = products.Count == 0 ? true : false;

            if (isEmptyProducts)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => HttpClient.DeleteAsync("api/products?id=" + (isEmptyProducts ? 1 : products[0].ProductId)));
            }
            else
            {
                var response = await HttpClient.DeleteAsync("api/products?id=" + (isEmptyProducts ? 1 : products[0].ProductId));

                var jsonString = await response.Content.ReadAsStringAsync();

                var deserializedResponse = JsonSerializer.Deserialize<DeleteProductResponse>(jsonString);

                Assert.Equal("Success", deserializedResponse.StatusText);
            }
        }


    }
}
