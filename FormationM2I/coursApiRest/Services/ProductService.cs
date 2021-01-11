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

        private IDAO<Product> _dao;
        public ProductService(IConfiguration config, IDAO<Product> dao)
        {
            _config = config;
            _dao = dao;
        }
        public Product GetProduct(int id)
        {
            Product product = _dao.Get(id);
            product.Images.ForEach(i =>
            {
                if (!i.Url.Contains(_config.GetValue<string>("baseUrl")))
                    i.Url = _config.GetValue<string>("baseUrl") + i.Url;
            });
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>(_dao.GetAll());
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
            List<Product> products = new List<Product>(_dao.Search(search));
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
