using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class WarehouseContentDto
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
        [JsonPropertyName("warehouseId")]
        public int WarehouseId { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        

        public WarehouseContentDto(int productId, int warehouseId, int count)
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            Count = count;
        }

        public WarehouseContentDto()
        {

        }

    }
}
