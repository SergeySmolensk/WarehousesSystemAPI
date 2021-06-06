using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.WarehouseContents;
using WarehousesSystemAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehousesSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseContentsController : ControllerBase
    {

        private WarehouseContentsService _warehouseContentsService;

        public WarehouseContentsController(WarehouseContentsService warehouseContentsService)
        {
            _warehouseContentsService = warehouseContentsService;
        }

        [HttpGet]
        public GetWarehouseContentsResponse Get()
        {
            IEnumerable<WarehouseContentDto> warehouseContentDtos = _warehouseContentsService.GetWarehousesContents();
            GetWarehouseContentsResponse productOnWarhouseResponse = new GetWarehouseContentsResponse(warehouseContentDtos, "Success");
            return productOnWarhouseResponse;
        }

        [HttpPost]
        public SaveProductOnWarhouseResponse SaveProductOnWarhouse([FromBody] SaveProductOnWarhouseRequest request)
        {
            WarehouseContentDto warehouseContentDto = request.WarehouseContent;
            _warehouseContentsService.SaveWarehouseContent(warehouseContentDto);
            SaveProductOnWarhouseResponse productOnWarhouseResponse = new SaveProductOnWarhouseResponse("Success");
            return productOnWarhouseResponse;
        }

        [HttpPut]
        public UpdateWarehouseContentCountResponse Put([FromBody] UpdateWarehouseContentCountRequest request)
        {
            WarehouseContentDto warehouseContentDto = request.WarehouseContent;
            _warehouseContentsService.UpdateWarehouseContentCount(warehouseContentDto);
            UpdateWarehouseContentCountResponse productOnWarhouseResponse = new UpdateWarehouseContentCountResponse("Success");
            return productOnWarhouseResponse;


        }

        [HttpDelete]
        public DeleteWarehouseContentResponse Delete(int productId, int warehouseId)
        {
            _warehouseContentsService.DeleteWarehouseContent(productId, warehouseId);
            DeleteWarehouseContentResponse productOnWarhouseResponse = new DeleteWarehouseContentResponse("Success");
            return productOnWarhouseResponse;
        }
    }
}
