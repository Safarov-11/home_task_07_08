using Domain.Entities;
using Domain.Entities.DTOs;

namespace Infrastructure.Interfaces;

public interface IProductsService
{
    string AddProduct(Products product);
    List<Products> GetAllProducts();
    string UpdateProducts(Products product);
    string DeleteProduct(int id);
    List<ProductInfoDTO> GetProductInfo();
    void AddDateTimeToProducts();
    void UpdatePricesByCategoryId(int CategoryId,  int percentage);
    List<SumPriceProdsDTO> GetSumPriceOfProductsByMarketId();
    List<Products> GetProdWithSmallestQoantity();
}
