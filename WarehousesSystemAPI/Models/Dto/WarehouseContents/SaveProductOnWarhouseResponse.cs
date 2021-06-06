using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WarehousesSystemAPI.Models.Dto.WarehouseContents
{
    public class SaveProductOnWarhouseResponse
    {
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; }

        public SaveProductOnWarhouseResponse(string statusText)
        {
            StatusText = statusText;
        }

        public SaveProductOnWarhouseResponse()
        {

        }

    }
}
