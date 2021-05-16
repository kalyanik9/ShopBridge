using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Data.Context;
using ShopBridge.Repository.Repository;
using ShopBridge.Data.Models;
using System;
using System.Threading.Tasks;
using ShopBridge.Repository.Models;

namespace ShopBridge.Test.RepositoryTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private ShopBridgeDbContext _shopBridgeDb;
        private IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;

        [TestInitialize]
        public virtual void Setup()
        {
            _shopBridgeDb = new ShopBridgeDbContext();
            _productRepository = new ProductRepository(_shopBridgeDb);
            _productCategoryRepository = new ProductCategoryRepository(_shopBridgeDb);
        }

        [TestCleanup]
        public virtual void Teardown()
        {
            _shopBridgeDb?.Dispose();
        }
        //public ProductRepositoryTest()
        //{

        //}

        [TestMethod]
        public async Task CreateProductTestAsync()
        {
            //Arrange
            var ProductCategory = new ProductCategory()
            {
                CategoryName = "Food"
            };
            var id = await _productCategoryRepository.CreateProductCategory(ProductCategory);
            var Product = new Product()
            {
                Name = "Red lable Tea",
                Description = "Tea",
                Price = 100,
                QuantityAvailable = 50,
                CategoryId = id
            };
            //Act
            var productId = await _productRepository.CreateProduct(Product);
            var res = await _productRepository.GetProductById(productId);
            //Assert
            Assert.AreEqual<Product>(res, Product);

        }

        [TestMethod]
        public async Task UpdateProductTestAsync()
        {
            //Arrange
            var ProductCategory = new ProductCategory()
            {
                CategoryName = "Electronics"
            };
            var id = await _productCategoryRepository.CreateProductCategory(ProductCategory);
            var Product = new Product()
            {
                Name = "Induction",
                Description = "Induction stove",
                Price = 2000,
                QuantityAvailable = 10,
                CategoryId = id
            };
            //Act
            var productId = await _productRepository.CreateProduct(Product);
            Product.ProductId = productId;
            Product.QuantityAvailable = 20;
            await _productRepository.UpdateProduct(Product);
            var res = await _productRepository.GetProductById(productId);
            //Assert
            Assert.AreEqual<Product>(res, Product);

        }

        [TestMethod]
        public async Task DeleteProductTestAsync()
        {
            //Arrange
            var ProductCategory = new ProductCategory()
            {
                CategoryName = "Food"
            };
            var id = await _productCategoryRepository.CreateProductCategory(ProductCategory);
            var Product = new Product()
            {
                Name = "Red lable Tea",
                Description = "Tea",
                Price = 100,
                QuantityAvailable = 50,
                CategoryId = id
            };
            //Act
            var productId = await _productRepository.CreateProduct(Product);
            await _productRepository.DeleteProduct(productId);
            var res = await _productRepository.GetProductById(productId);
            //Assert
            Assert.AreEqual<Product>(res, null);
        }

        [TestMethod]
        public async Task GetAllProductsTestAsync()
        {
            //Arrange
            var ProductCategory = new ProductCategory()
            {
                CategoryName = "Food"
            };
            var id = await _productCategoryRepository.CreateProductCategory(ProductCategory);
           
           
            //Act
            for (var i = 1; i <= 10; i++)
            {
                var product = new Product()
                {
                    Name = "Red lable Tea" + i,
                    Description = "Tea",
                    Price = 100+i,
                    QuantityAvailable = 50,
                    CategoryId = id
                };
                await _productRepository.CreateProduct(product);
            }
            var res = await _productRepository.GetProductsList();
            //Assert
            Assert.AreEqual<int>(res.Count, 10);

        }

        [TestMethod]
        public async Task SearchProductsTestAsync()
        {
            //Arrange
            var ProductCategory = new ProductCategory()
            {
                CategoryName = "Food"
            };
            var id = await _productCategoryRepository.CreateProductCategory(ProductCategory);


            //Act
          
                var product = new Product()
                {
                    Name = "Red lable Tea",
                    Description = "Tea",
                    Price = 100,
                    QuantityAvailable = 50,
                    CategoryId = id
                };
                await _productRepository.CreateProduct(product);
                var product2 = new Product()
                {
                    Name = "Oil",
                    Description = "oil",
                    Price = 150,
                    QuantityAvailable = 50,
                    CategoryId = id
                };
                await _productRepository.CreateProduct(product2);

            var searchModel = new SearchModel
            {
                ProductName = "Oil",
                ProductCategory = "Food"
            };
            var res = await _productRepository.SearchProducts(searchModel);
            //Assert
            Assert.AreEqual<int>(res.Count, 1);

        }


    }
}
