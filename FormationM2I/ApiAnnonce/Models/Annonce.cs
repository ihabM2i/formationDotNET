using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnnonce.Models
{
    public class Annonce
    {
        private int id;
        private string titre;
        private string description;
        private decimal prix;
        private DateTime dateCreation;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public List<Image> Images { get; set; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }

        public Annonce()
        {
            Images = new List<Image>();
        }
        public static List<Annonce> Search(string search)
        {
            List<Annonce> annonces = new List<Annonce>(
                search != null ?
                DataContext.Instance.Annonces.Include(a => a.Images)
                .Where(a => a.Titre.Contains(search) || a.Description.Contains(search))
                 : DataContext.Instance.Annonces.Include(a => a.Images));
            annonces.ForEach(a =>
            {
                a.Images.ForEach(i =>
                {
                    if (!i.Url.Contains("http://localhost:60413/"))
                    {
                        i.Url = "http://localhost:60413/" + i.Url;
                    }
                });
            });
            return annonces;
        }

        public static Annonce GetAnnonce(int id)
        {
            return DataContext.Instance.Annonces.Find(id);
        }

        public bool Update()
        {
            return DataContext.Instance.SaveChanges() > 0;
        }

        public bool Save()
        {
            DateCreation = DateTime.Now;
            DataContext.Instance.Annonces.Add(this);
            return DataContext.Instance.SaveChanges() > 0;
        }
    }
}
