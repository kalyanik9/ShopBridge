using ShopBridge.Data.Models;
using ShopBridge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Repository.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsList();
        Task<int> CreateProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int id);
        Task<List<Product>> SearchProducts(SearchModel searchModel);
        Task<Product> GetProductById(int Id);
    }
}
