using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class UpdateWarehouseContentCountRequest
    {
        [JsonPropertyName("warehouseContent")]
        public WarehouseContentDto WarehouseContent { get; set; }

        public UpdateWarehouseContentCountRequest(WarehouseContentDto warehouseContent)
        {
            WarehouseContent = warehouseContent;
        }

        public UpdateWarehouseContentCountRequest()
        {

        }
    }
}
