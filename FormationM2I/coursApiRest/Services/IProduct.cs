using coursApiRest.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursApiRest.Services
{
    public interface IProduct
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        List<Product> SearchProducts(string search);

        bool SaveProduct(Product product);

        Product SaveProductImage(int id, IFormFile image);
    }
}
