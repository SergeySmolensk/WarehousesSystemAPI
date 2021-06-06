using System.Collections.Generic;
using System.Linq;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.Warehouses;
using WarehousesSystemAPI.Storage;

namespace WarehousesSystemAPI.Services
{
    public class WarehousesService
    {
        private SqlServerDatabaseAccessor _sqlServerDatabaseAccessor;
        
        public WarehousesService(SqlServerDatabaseAccessor sqlServerDatabaseAccessor)
        {
            _sqlServerDatabaseAccessor = sqlServerDatabaseAccessor;
        }

        public IEnumerable<WarehouseDto> GetWarehouses()
        {
            IEnumerable<WarehouseEntity> warehouseEntities = _sqlServerDatabaseAccessor.GetWarehouses();
            List<WarehouseDto> warehouses = new List<WarehouseDto>(warehouseEntities.Count());
            foreach (var warehouse in warehouseEntities)
            {
                WarehouseDto warehouseDto = new WarehouseDto(warehouse.Id, warehouse.WarehouseName);
                warehouses.Add(warehouseDto);
            }
            return warehouses;
        }



    }
}
