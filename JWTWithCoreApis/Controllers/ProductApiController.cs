using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTWithCoreApis.Controllers
{
    // [Route("api/[controller]")]
   //  [Authorize]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        IProductService productService;
        public ProductApiController(IProductService productService)
        {

            this.productService = productService;
        }
        [HttpGet]
        [Route("api/product")]
        public List<ProductModel> GetAll()
        {
            string userId = User.FindFirst(ClaimTypes.Name)?.Value;
            return productService.GetProducts();
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public  ProductModel  GetById(int id)
        {
            return productService.GetProduct(id);
        }
        [HttpPost]
        [Route("api/product")]
        public ProductModel AddProduct(ProductModel product)
        {
          return   productService.AddProduct(product);
        }
        [HttpPut]
        [Route("api/product")]
        public ProductModel UpdateProduct(ProductModel product)
        {
            return productService.UpdateProduct(product);
        }

        [HttpPatch]
        [Route("api/product/{id}")]
        public ProductModel PartialUpdateProduct(int id, ProductModel p)
        {
            ProductModel pr =productService.GetProduct(id);
            pr.Rate = p.Rate;
            productService.UpdateProduct(pr);
            return pr;
        }
        [HttpDelete]
        [Route("api/product/{id}")]
        public string DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return "Product Deleted Successfully";
        }
    }
}
