using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class DeleteWarehouseContentResponse
    {
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public DeleteWarehouseContentResponse(string statusText)
        {
            StatusText = statusText;
        }

        public DeleteWarehouseContentResponse()
        {

        }
    }
}
