using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models;
using WarehousesSystemAPI.Models.Dto.Products;
using WarehousesSystemAPI.Storage;

namespace WarehousesSystemAPI.Services
{
    public class ProductsService
    {
        private SqlServerDatabaseAccessor _sqlServerDatabaseAccessor;

        public ProductsService(SqlServerDatabaseAccessor sqlServerDatabaseAccessor)
        {
            _sqlServerDatabaseAccessor = sqlServerDatabaseAccessor;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            IEnumerable<ProductEntity> productEntities = _sqlServerDatabaseAccessor.GetProducts();

            int productsCount = productEntities.Count();

            List<ProductDto> products = new List<ProductDto>(productsCount);

            foreach (var product in productEntities)
            {
                ProductDto productDto = new ProductDto(product.Id, product.ProductName, product.CostPerUnit, product.CountryId, product.ManufactureId);
                products.Add(productDto);
            }

            return products;
        }

        public bool UpdateProduct(ProductDto productDto)
        {
            return _sqlServerDatabaseAccessor.UpdateProduct(productDto);
        }

        public bool DeleteProduct(int id)
        {
            return _sqlServerDatabaseAccessor.DeleteProduct(id);
        }

        public bool SaveProduct(ProductDto productDto)
        {
            return _sqlServerDatabaseAccessor.SaveProduct(productDto);
        }


    }
}
