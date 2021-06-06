using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Products
{
    public class ProductDto
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("cost")]
        public float CostPerUnit { get; set; }
        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }
        [JsonPropertyName("manufactureId")]
        public int ManufactureId { get; set; }

        public ProductDto(int productId, string productName, float costPerUnit, int countryId, int manufactureId)
        {
            ProductId = productId;
            ProductName = productName;
            CostPerUnit = costPerUnit;
            CountryId = countryId;
            ManufactureId = manufactureId;
        }

        public ProductDto()
        {
            
        }

    }
}
