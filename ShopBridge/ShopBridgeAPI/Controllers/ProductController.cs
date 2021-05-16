using ShopBridge.Data.Models;
using ShopBridge.Repository.Models;
using ShopBridge.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridgeAPI.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductController : ApiController
    {
        private readonly ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IHttpActionResult GetProductsList()
        {
            try
            {
               var productList = _productRepository.GetProductsList();
                return Ok(productList);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult SearchProducts([FromBody] SearchModel searchModel)
        {
            try
            {
                var productList = _productRepository.SearchProducts(searchModel);
                return Ok(productList);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{productId}")]
        public IHttpActionResult GetProduct([FromUri] int productId)
        {
            try
            {
                var product = _productRepository.GetProductById(productId);
                return Ok(product);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                var productId = _productRepository.CreateProduct(product);
                return Ok(productId);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                var productId = _productRepository.UpdateProduct(product);
                return Ok(productId);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("{productId}")]
        public IHttpActionResult DeleteProduct([FromUri] int productId)
        {
            try
            {
                var id = _productRepository.DeleteProduct(productId);
                return Ok(id);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
