using ShopBridge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Repository.Repository
{
    public interface IProductCategoryRepository
    {
        Task<int> CreateProductCategory(ProductCategory productCategory);
        Task<int> DeleteProductCategory(int id);
        Task<List<ProductCategory>> GetProductCategoryList();
        Task<int> UpdateProductCategory(ProductCategory productcategory);

    }
}
