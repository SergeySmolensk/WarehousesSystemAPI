using System;
using System.Collections.Generic;
using System.Linq;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.Products;
using WarehousesSystemAPI.Models.Dto.WarehouseContents;

namespace WarehousesSystemAPI.Storage
{
    public class SqlServerDatabaseAccessor
    {
        private SqlServerContext _sqlServerAccessor;

        public SqlServerDatabaseAccessor(SqlServerContext sqlServerContext)
        {
            _sqlServerAccessor = sqlServerContext;
        }


        public IEnumerable<WarehouseEntity> GetWarehouses()
        {
            return _sqlServerAccessor.Warehouses.ToList();
        }

        public IEnumerable<ProductEntity> GetProducts()
        {

            return _sqlServerAccessor.Products.ToList();
        }

        public bool UpdateProduct(ProductDto product)
        {
            var updatingProduct = _sqlServerAccessor.Products.FirstOrDefault(x => x.Id == product.ProductId);

            if (updatingProduct == null)
            {
                throw new ArgumentException();
            }

            updatingProduct.Id = product.ProductId;
            updatingProduct.CountryId = product.CountryId;
            updatingProduct.ManufactureId = product.ManufactureId;
            updatingProduct.ProductName = product.ProductName;
            updatingProduct.CostPerUnit = product.CostPerUnit;

            _sqlServerAccessor.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var deletingProduct = _sqlServerAccessor.Products.FirstOrDefault(x => x.Id == id);

            if (deletingProduct == null)
            {
                throw new ArgumentException();
            }

            _sqlServerAccessor.Products.Remove(deletingProduct);

            _sqlServerAccessor.SaveChanges();

            return true;
        }

        public bool SaveProduct(ProductDto productDto)
        {
            ProductEntity productEntity = new ProductEntity(productDto.ProductId, productDto.ProductName, productDto.CostPerUnit, productDto.CountryId, productDto.ManufactureId);
            _sqlServerAccessor.Products.Add(productEntity);

            _sqlServerAccessor.SaveChanges();

            return true;
        }

        public IEnumerable<WarehouseContentsEntity> GetWarehousesContents()
        {
            return _sqlServerAccessor.WarehouseContents.ToList();
        }

        public bool DeleteWarehouseContent(int productId, int warehouseId)
        {
            var deletingWarehouseContent = _sqlServerAccessor.WarehouseContents.FirstOrDefault(x => x.WarehouseId == warehouseId && x.ProductId == productId);

            if (deletingWarehouseContent == null)
            {
                throw new ArgumentException();
            }

            _sqlServerAccessor.WarehouseContents.Remove(deletingWarehouseContent);

            _sqlServerAccessor.SaveChanges();

            return true;
        }

        public bool UpdateWarehouseContentCount (WarehouseContentDto warehouseContentDto)
        {
            var updatingWarehouseContent = _sqlServerAccessor.WarehouseContents.FirstOrDefault(x => x.WarehouseId == warehouseContentDto.WarehouseId &&
            x.ProductId == warehouseContentDto.ProductId);

            if (updatingWarehouseContent == null)
            {
                throw new ArgumentException();
            }

            updatingWarehouseContent.Count = warehouseContentDto.Count;

            _sqlServerAccessor.SaveChanges();

            return true;
        }

        public bool SaveWarehouseContent(WarehouseContentDto warehouseContentDto)
        {
            var foundWarehouseContentsEntity = _sqlServerAccessor.WarehouseContents.FirstOrDefault(x => x.WarehouseId == warehouseContentDto.WarehouseId &&
            x.ProductId == warehouseContentDto.ProductId);

            if (foundWarehouseContentsEntity != null)
            {
                throw new ArgumentException();
            }

            WarehouseContentsEntity warehouseContentsEntity = new WarehouseContentsEntity(warehouseContentDto.ProductId, warehouseContentDto.WarehouseId, warehouseContentDto.Count);

            _sqlServerAccessor.WarehouseContents.Add(warehouseContentsEntity);

            _sqlServerAccessor.SaveChanges();

            return true;
        }
    }
}
