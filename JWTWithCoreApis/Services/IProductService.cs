using JWTWithCoreApis.Models;

namespace JWTWithCoreApis.Services 
{
    public interface IProductService
    {
        ProductModel AddProduct(ProductModel product);
        ProductModel UpdateProduct(ProductModel product);
        void DeleteProduct(int Id);
        List<ProductModel> GetProducts();
        ProductModel GetProduct(int Id);
    }
}
