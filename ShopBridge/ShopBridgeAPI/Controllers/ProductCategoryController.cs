using ShopBridge.Data.Models;
using ShopBridge.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridgeAPI.Controllers
{
    [RoutePrefix("api/Category")]
    public class ProductCategoryController : ApiController
    {
        private readonly ProductCategoryRepository _productCategoryRepository;
        public ProductCategoryController(ProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public IHttpActionResult GetProductCategoryList()
        {
            try
            {
                var categoryList = _productCategoryRepository.GetProductCategoryList();
                return Ok(categoryList);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult CreateCategory([FromBody] ProductCategory category)
        {
            try
            {
                var categoryId = _productCategoryRepository.CreateProductCategory(category);
                return Ok(categoryId);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult UpdateProduct([FromBody] ProductCategory category)
        {
            try
            {
                var categoryId = _productCategoryRepository.UpdateProductCategory(category);
                return Ok(categoryId);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("{productId}")]
        public IHttpActionResult DeleteProduct([FromUri] int categoryId)
        {
            try
            {
                var id = _productCategoryRepository.DeleteProductCategory(categoryId);
                return Ok(id);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
