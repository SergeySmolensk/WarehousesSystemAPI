using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WarehousesSystemAPI.Models.Dto.Products;
using WarehousesSystemAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehousesSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public GetProductsResponse GetProducts()
        {
            IEnumerable<ProductDto> products = _productsService.GetProducts();
            GetProductsResponse productsResponse = new GetProductsResponse(products, "Success");
            return productsResponse;
        }

        [HttpPost]
        public SaveProductResponse Post([FromBody] SaveProductRequest request)
        {
            _productsService.SaveProduct(request.Product);
            SaveProductResponse productResponse = new SaveProductResponse("Success");
            return productResponse;
        }

        [HttpPut]
        public UpdateProductResponse Put([FromBody] UpdateProductRequest request)
        {
            _productsService.UpdateProduct(request.Product);
            UpdateProductResponse productResponse = new UpdateProductResponse("Success");
            return productResponse;
        }

        [HttpDelete]
        public DeleteProductResponse Delete(int id)
        {
            _productsService.DeleteProduct(id);
            DeleteProductResponse productResponse = new DeleteProductResponse("Success");
            return productResponse;
        }
    }
}
