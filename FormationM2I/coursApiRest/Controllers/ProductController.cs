using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursApiRest.Models;
using coursApiRest.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coursApiRest.Controllers
{
    [Route("api/v1/products")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _productService;
        public ProductController(IProduct productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Product> Get()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProduct(id);
        }
        [HttpGet("filter/{filter}")]
        public List<Product> GetWithFilter(string filter)
        {
            return _productService.SearchProducts(filter);
        }
    }
}