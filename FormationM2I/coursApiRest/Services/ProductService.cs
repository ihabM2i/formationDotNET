using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursApiRest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace coursApiRest.Services
{
    public class ProductService : IProduct
    {
        private IConfiguration _config;

        private IDAO<Product> _dao;

        private IUpload _upload;
        public ProductService(IConfiguration config, IDAO<Product> dao, IUpload upload)
        {
            _config = config;
            _dao = dao;
            _upload = upload;
        }
        public Product GetProduct(int id)
        {
            Product product = _dao.Get(id);
            product.Images.ForEach(i =>
            {
                //if (!i.Url.Contains(_config.GetValue<string>("baseUrl")))
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
                    //if(!i.Url.Contains(_config.GetValue<string>("baseUrl")))
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
                    //if (!i.Url.Contains(_config.GetValue<string>("baseUrl")))
                        i.Url = _config.GetValue<string>("baseUrl") + i.Url;
                });
            });
            return products;
        }

        public bool SaveProduct(Product product)
        {
            //Logique métier pour vérifier les champs de notre entité
            //....
            return _dao.Save(product);
        }

        public Product SaveProductImage(int id, IFormFile image)
        {
            Product product = _dao.Get(id);
            if(product != null)
            {
                //Logique métier pour l'image
                //....
                product.Images.Add(new Image() { Url = _upload.Upload(image) });
                if (_dao.Update())
                {
                    return product;
                }
                else
                {
                    return null;
                }
            }
            return product;
        }
    }
}
