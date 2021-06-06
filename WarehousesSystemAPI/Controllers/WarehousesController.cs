using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.Warehouses;
using WarehousesSystemAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehousesSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {

        private WarehousesService _warehousesService;

        public WarehousesController(WarehousesService warehousesService)
        {
            _warehousesService = warehousesService;
        }

        [HttpGet]
        public GetWarehousesResponse GetWarhouses()
        {
            IEnumerable<WarehouseDto> warehouses = _warehousesService.GetWarehouses();
            GetWarehousesResponse warehousesResponse = new GetWarehousesResponse(warehouses, "Success");
            return warehousesResponse;
        }
    }
}
