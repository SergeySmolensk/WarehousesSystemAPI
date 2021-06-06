using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models.Dto.Warehouses;
using WarehouseTests;
using Xunit;

namespace WarehousesSystemAPI.IntegrationTests
{
    public class WarehouseTests : ApiTestBase
    {

        [Fact]
        public async Task GetWarhousesTest()
        {
            var response = await HttpClient.GetAsync("api/warehouses");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetWarhousesListTest()
        {
            var response = await HttpClient.GetAsync("api/warehouses");

            var jsonString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<GetWarehousesResponse>(jsonString);

            List<WarehouseDto> warehouses = (List<WarehouseDto>) deserializedResponse.Warehouses;

            Assert.Equal(3, warehouses.Count);
        }
    }
}
