using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class SaveProductOnWarhouseRequest
    {
        [JsonPropertyName("warehouseContent")]
        public WarehouseContentDto WarehouseContent { get; set; }

        public SaveProductOnWarhouseRequest(WarehouseContentDto warehouseContent)
        {
            WarehouseContent = warehouseContent;
        }

        public SaveProductOnWarhouseRequest()
        {

        }
    }
}
