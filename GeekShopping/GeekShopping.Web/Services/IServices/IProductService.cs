using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> FindAllProducts();
    Task<ProductModel> FindProductById(long id);
    Task<ProductModel> CreateProduct(ProductModel model);
    Task<ProductModel> UpdateteProduct(ProductModel model);
    Task<bool> DeleteProductById(long id);

}
