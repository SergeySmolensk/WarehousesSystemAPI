using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models.Dto.Products;
using WarehousesSystemAPI.Models.Dto.WarehouseContents;
using WarehousesSystemAPI.Models.Dto.Warehouses;
using WarehouseTests;
using Xunit;

namespace WarehousesSystemAPI.IntegrationTests
{
    public class WarehoueContentsTests : ApiTestBase
    {

        private void CleanWarehouseContentsTable()
        {
            SqlServerContext.WarehouseContents.RemoveRange(SqlServerContext.WarehouseContents);
            SqlServerContext.SaveChanges();
        }

        private async Task<List<WarehouseContentDto>> GetWarehouseContentsListAsync()
        {
            var response = await HttpClient.GetAsync("api/warehousecontents");

            var jsonString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<GetWarehouseContentsResponse>(jsonString);

            List<WarehouseContentDto> warehouseContents = (List<WarehouseContentDto>) deserializedResponse.WarehouseContents;

            return warehouseContents;
        }

        private async Task SendProductAsync()
        {
            var jsonRequest = JsonSerializer.Serialize<SaveProductRequest>(new SaveProductRequest(new ProductDto(0, "test", 1, 1, 1)));

            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync("api/products", httpContent);
        }

        private async Task SendWarehouseContentAsync(List<ProductDto> products, List<WarehouseDto> warehouses)
        {
            var jsonRequest = JsonSerializer.Serialize<SaveProductOnWarhouseRequest>(new SaveProductOnWarhouseRequest(
                new WarehouseContentDto(products[0].ProductId, warehouses[0].WarehouseId, 1)));

            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync("api/warehousecontents", httpContent);
        }

        [Fact]
        public async Task GetWarehouseContentsTestAsync()
        {
            var response = await HttpClient.GetAsync("api/warehousecontents");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetWarehouseContentsListTestAsync()
        {
            List<WarehouseContentDto> warehouseContents = await GetWarehouseContentsListAsync();

            Assert.NotNull(warehouseContents);
        }

        [Fact]
        public async Task PostWarehouseContentsTestAsync()
        {
            CleanWarehouseContentsTable();
            await SendProductAsync();
            var products = await GetProductsListAsync();
            var warehouses = await GetWarehousesListAsync();


            var jsonRequest = JsonSerializer.Serialize<SaveProductOnWarhouseRequest>(new SaveProductOnWarhouseRequest(
                new WarehouseContentDto(products[0].ProductId, warehouses[0].WarehouseId, 1)));

            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync("api/warehousecontents", httpContent);

            var jsonString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<SaveProductOnWarhouseResponse>(jsonString);

            Assert.Equal("Success", deserializedResponse.StatusText);
        }

        [Fact]
        public async Task PutWarehouseContentsTestAsync()
        {
            List<WarehouseContentDto> warehouseContents = await GetWarehouseContentsListAsync();

            var isEmptyProducts = warehouseContents.Count == 0 ? true : false;

            var jsonRequestPut = JsonSerializer.Serialize<UpdateWarehouseContentCountRequest>(new UpdateWarehouseContentCountRequest(
                new WarehouseContentDto(isEmptyProducts ? 1 : warehouseContents[0].ProductId, 
                isEmptyProducts ? 1 : warehouseContents[0].WarehouseId, 1)));

            var httpContent = new StringContent(jsonRequestPut, Encoding.UTF8, "application/json");

            if (isEmptyProducts)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => HttpClient.PutAsync("api/warehousecontents", httpContent));
            }
            else
            {
                var response = await HttpClient.PutAsync("api/warehousecontents", httpContent);

                var jsonString = await response.Content.ReadAsStringAsync();

                var deserializedResponse = JsonSerializer.Deserialize<UpdateWarehouseContentCountResponse>(jsonString);

                Assert.Equal("Success", deserializedResponse.StatusText);
            }
        }

        [Fact]
        public async Task DeleteWarehouseContentsTestAsync()
        {
            List<WarehouseContentDto> warehouseContents = await GetWarehouseContentsListAsync();

            var isEmptyProducts = warehouseContents.Count == 0 ? true : false;

            if (isEmptyProducts)
            {
                await Assert.ThrowsAsync<ArgumentException>(() => HttpClient.DeleteAsync(
                    "api/warehousecontents?productId=1&warehouseId=1"));
            }
            else
            {
                CleanWarehouseContentsTable();
                await SendProductAsync();
                var products = await GetProductsListAsync();
                var warehouses = await GetWarehousesListAsync();
                await SendWarehouseContentAsync(products, warehouses);

                var response = await HttpClient.DeleteAsync("api/warehousecontents?productId=" + products[0].ProductId +
                    "&warehouseId=" + warehouses[0].WarehouseId);

                var jsonString = await response.Content.ReadAsStringAsync();

                var deserializedResponse = JsonSerializer.Deserialize<DeleteWarehouseContentResponse>(jsonString);

                Assert.Equal("Success", deserializedResponse.StatusText);
            }
        }


    }
}
