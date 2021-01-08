using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursApiRest.Models;
using Microsoft.Extensions.Configuration;

namespace coursApiRest.Services
{
    public class ProductService : IProduct
    {
        private IConfiguration _config;
        public ProductService(IConfiguration config)
        {
            _config = config;
        }
        public Product GetProduct(int id)
        {
            Product product = Product.GetProduct(id);
            product.Images.ForEach(i =>
            {
                if (!i.Url.Contains(_config.GetValue<string>("baseUrl")))
                    i.Url = _config.GetValue<string>("baseUrl") + i.Url;
            });
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>(Product.GetProducts());
            products.ForEach(p =>
            {
                p.Images.ForEach(i =>
                {
                    if(!i.Url.Contains(_config.GetValue<string>("baseUrl")))
                        i.Url = _config.GetValue<string>("baseUrl") + i.Url;
                });
            });
            return products;
        }

        public List<Product> SearchProducts(string search)
        {
            List<Product> products = new List<Product>(Product.SearchProducts(search));
            products.ForEach(p =>
            {
                p.Images.ForEach(i =>
                {
                    if (!i.Url.Contains(_config.GetValue<string>("baseUrl")))
                        i.Url = _config.GetValue<string>("baseUrl") + i.Url;
                });
            });
            return products;
        }
    }
}
