using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Products
{
    public class DeleteProductResponse
    {
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public DeleteProductResponse(string statusText)
        {
            StatusText = statusText;
        }

        public DeleteProductResponse()
        {

        }
    }
}
