using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class GetWarehouseContentsResponse
    {
        [JsonPropertyName("warehouseContents")]
        public IEnumerable<WarehouseContentDto> WarehouseContents { get; set; }

        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public GetWarehouseContentsResponse(IEnumerable<WarehouseContentDto> warehouseContents, string statusText)
        {
            WarehouseContents = warehouseContents;
            StatusText = statusText;
        }

        public GetWarehouseContentsResponse()
        {

        }
    }
}
