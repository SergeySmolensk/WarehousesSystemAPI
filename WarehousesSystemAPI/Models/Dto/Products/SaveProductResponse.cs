using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Products
{
    public class SaveProductResponse
    {
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public SaveProductResponse(string statusText)
        {
            StatusText = statusText;
        }

        public SaveProductResponse()
        {

        }
    }
}
