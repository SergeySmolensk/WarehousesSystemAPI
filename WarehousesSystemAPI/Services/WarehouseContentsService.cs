using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.WarehouseContents;
using WarehousesSystemAPI.Storage;

namespace WarehousesSystemAPI.Services
{
    public class WarehouseContentsService
    {
        private SqlServerDatabaseAccessor _sqlServerDatabaseAccessor;

        public WarehouseContentsService(SqlServerDatabaseAccessor sqlServerDatabaseAccessor)
        {
            _sqlServerDatabaseAccessor = sqlServerDatabaseAccessor;
        }

        public IEnumerable<WarehouseContentDto> GetWarehousesContents()
        {
            IEnumerable<WarehouseContentsEntity> warehouseContentsEntities = _sqlServerDatabaseAccessor.GetWarehousesContents();
            List<WarehouseContentDto> warehouseContentDtos = new List<WarehouseContentDto>(warehouseContentsEntities.Count());

            foreach (var warehouseContent in warehouseContentsEntities)
            {
                WarehouseContentDto warehouseContentDto = new WarehouseContentDto(warehouseContent.ProductId, warehouseContent.WarehouseId, warehouseContent.Count);
                warehouseContentDtos.Add(warehouseContentDto);
            }

            return warehouseContentDtos;

        }

        public bool DeleteWarehouseContent(int productId, int warehouseId)
        {
            return _sqlServerDatabaseAccessor.DeleteWarehouseContent(productId, warehouseId);
        }

        public bool UpdateWarehouseContentCount(WarehouseContentDto warehouseContentDto)
        {
            return _sqlServerDatabaseAccessor.UpdateWarehouseContentCount(warehouseContentDto);
        }

        public bool SaveWarehouseContent(WarehouseContentDto warehouseContentDto)
        {
            return _sqlServerDatabaseAccessor.SaveWarehouseContent(warehouseContentDto);
        }


    }
}
