using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Warehouses
{
    public class GetWarehousesResponse
    {
        [JsonPropertyName("warehouses")]
        public IEnumerable<WarehouseDto> Warehouses { get; set; }

        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public GetWarehousesResponse(IEnumerable<WarehouseDto> warehouses, string statusText)
        {
            Warehouses = warehouses;
            StatusText = statusText;
        }

        public GetWarehousesResponse()
        {

        }

    }
}
