using System.Text.Json.Serialization;

namespace WarehousesSystemAPI.Models.Dto.Products
{
    public class UpdateProductResponse
    {
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public UpdateProductResponse(string statusText)
        {
            StatusText = statusText;
        }

        public UpdateProductResponse()
        {

        }
    }
}
