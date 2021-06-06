using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.Warehouses
{
    public class WarehouseDto
    {
        [JsonPropertyName("warehouseId")]
        public int WarehouseId { get; set; }

        [JsonPropertyName("warehouseName")]
        public string WarehouseName { get; set; }
        
        public WarehouseDto(int warehousId, string warehouseName)
        {
            WarehouseId = warehousId;
            WarehouseName = warehouseName;
        }

        public WarehouseDto()
        {

        }

    }
}
