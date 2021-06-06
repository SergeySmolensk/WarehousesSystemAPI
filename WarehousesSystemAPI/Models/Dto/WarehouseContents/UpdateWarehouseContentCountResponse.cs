using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class UpdateWarehouseContentCountResponse
    {
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public UpdateWarehouseContentCountResponse(string statusText)
        {
            StatusText = statusText;
        }

        public UpdateWarehouseContentCountResponse()
        {

        }
    }
}
