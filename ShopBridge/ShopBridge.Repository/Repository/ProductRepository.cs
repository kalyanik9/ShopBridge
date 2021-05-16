using ShopBridge.Data.Context;
using ShopBridge.Data.Models;
using ShopBridge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopBridgeDbContext _shopBridgeDbContext;
       
        public ProductRepository(ShopBridgeDbContext shopBridgeDbContext)
        {
            _shopBridgeDbContext = shopBridgeDbContext;
        }

        public  async Task<int> CreateProduct(Product product)
        {
            _shopBridgeDbContext.ProductsList.Add(product);
            await _shopBridgeDbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _shopBridgeDbContext.ProductsList.FindAsync(id);
            _shopBridgeDbContext.ProductsList.Remove(product);
            await _shopBridgeDbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<List<Product>> GetProductsList()
        {
            var query = from item in _shopBridgeDbContext.ProductsList
                        select item;
            return await query.ToListAsync();
        }

        public async Task<List<Product>> SearchProducts(SearchModel searchModel)
        {
            var query = from pr in _shopBridgeDbContext.ProductsList
                        select pr;
            if (!string.IsNullOrEmpty(searchModel.ProductName))
                query = query.Where(x => x.Name == searchModel.ProductName);
            if (!string.IsNullOrEmpty(searchModel.ProductCategory))
                query = query.Where(x => x.Category.CategoryName == searchModel.ProductCategory);
            return await query.ToListAsync();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            Product foundProduct = await _shopBridgeDbContext.ProductsList.FindAsync(product.ProductId);
            foundProduct.Name = product.Name;
            foundProduct.Price = product.Price;
            foundProduct.QuantityAvailable = product.QuantityAvailable;
            await _shopBridgeDbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var query = (from item in _shopBridgeDbContext.ProductsList
                        where item.ProductId == Id
                        select item).SingleOrDefaultAsync();
            return await query;
        }
    }
}
