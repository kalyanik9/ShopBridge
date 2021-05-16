using ShopBridge.Data.Context;
using ShopBridge.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Repository.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ShopBridgeDbContext _shopBridgeDbContext;
        public ProductCategoryRepository(ShopBridgeDbContext shopBridgeDbContext)
        {
            _shopBridgeDbContext = shopBridgeDbContext;
        }

        public async Task<int> CreateProductCategory(ProductCategory productCategory)
        {
            _shopBridgeDbContext.ProductCategoryList.Add(productCategory);
            await _shopBridgeDbContext.SaveChangesAsync();
            return productCategory.CategoryId;
        }

        public async Task<int> DeleteProductCategory(int id)
        {
            var productCategory = await _shopBridgeDbContext.ProductCategoryList.FindAsync(id);
            _shopBridgeDbContext.ProductCategoryList.Remove(productCategory);
            await _shopBridgeDbContext.SaveChangesAsync();
            return productCategory.CategoryId;
        }

        public async Task<List<ProductCategory>> GetProductCategoryList()
        {
            var query = from item in _shopBridgeDbContext.ProductCategoryList
                        select item;
            return await query.ToListAsync();
        }

        public async Task<int> UpdateProductCategory(ProductCategory productcategory)
        {
            ProductCategory foundProduct = await _shopBridgeDbContext.ProductCategoryList.FindAsync(productcategory.CategoryId);
            foundProduct.CategoryName = productcategory.CategoryName;
            await _shopBridgeDbContext.SaveChangesAsync();
            return productcategory.CategoryId;
        }

       

    }
}
