using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Products
{
    public class GetProductsResponse
    {
        [JsonPropertyName("products")]
        public IEnumerable<ProductDto> Products { get; set; }
        
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public GetProductsResponse(IEnumerable<ProductDto> products, string statusText)
        {
            Products = products;
            StatusText = statusText;
        }

        public GetProductsResponse()
        {

        }
    }
}
