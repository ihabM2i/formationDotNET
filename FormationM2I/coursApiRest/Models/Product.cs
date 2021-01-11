using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursApiRest.Models
{
    public class Product
    {
        private int id;
        private string title;
        private string description;
        private decimal price;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
        public List<Image> Images { get; set; }

        //public static List<Product> GetProducts()
        //{
        //    return DataDbContext.Instance.Products.Include(p => p.Images).ToList();
        //}

        //public static List<Product> SearchProducts(string filter)
        //{
        //    return DataDbContext.Instance.Products.Include(p => p.Images).Where(p => p.Title.Contains(filter) || p.Description.Contains(filter)).ToList();
        //}
        //public static Product GetProduct(int id)
        //{
        //    return DataDbContext.Instance.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
        //}
    }
}
