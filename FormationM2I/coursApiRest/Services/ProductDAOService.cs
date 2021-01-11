using coursApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursApiRest.Services
{
    public class ProductDAOService : IDAO<Product>
    {
        private DataDbContext _data;
        public ProductDAOService(DataDbContext data)
        {
            _data = data;
        }
        public Product Get(int id)
        {

            return _data.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            return _data.Products.Include(p => p.Images).ToList();
        }

        public List<Product> Search(string filter)
        {
            return _data.Products.Include(p => p.Images).Where(p => p.Title.Contains(filter) || p.Description.Contains(filter)).ToList();
        }

       public bool Save(Product product)
       {
            _data.Products.Add(product);
            return _data.SaveChanges() > 0;
       }

        public bool Update()
        {
            return _data.SaveChanges() > 0;
        }
    }
}
