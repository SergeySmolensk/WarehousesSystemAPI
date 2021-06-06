using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WarehousesSystemAPI;
using WarehousesSystemAPI.IntegrationTests;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.Products;
using WarehousesSystemAPI.Models.Dto.Warehouses;

namespace WarehouseTests
{
    public class ApiTestBase
    {
        protected HttpClient HttpClient { get; private set; }

        protected SqlServerContext SqlServerContext { get; set; }

        protected ApiTestBase()
        {
            SqlServerContext = new SqlServerContext(DbOptionsFactory.DbContextOptions);


            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            HttpClient = testServer.CreateClient();
        }

        protected async Task<List<ProductDto>> GetProductsListAsync()
        {
            var response = await HttpClient.GetAsync("api/products");

            var jsonString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<GetProductsResponse>(jsonString);

            List<ProductDto> products = (List<ProductDto>)deserializedResponse.Products;

            return products;
        }

        protected async Task<List<WarehouseDto>> GetWarehousesListAsync()
        {
            var response = await HttpClient.GetAsync("api/warehouses");

            var jsonString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<GetWarehousesResponse>(jsonString);

            List<WarehouseDto> warehouses = (List<WarehouseDto>) deserializedResponse.Warehouses;

            return warehouses;
        }
    }
}
