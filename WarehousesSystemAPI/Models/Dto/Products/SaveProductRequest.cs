using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Products
{
    public class SaveProductRequest
    {
        [JsonPropertyName("product")]
        public ProductDto Product { get; set; }

        public SaveProductRequest(ProductDto product)
        {
            Product = product;
        }

        public SaveProductRequest()
        {

        }
    }
}
