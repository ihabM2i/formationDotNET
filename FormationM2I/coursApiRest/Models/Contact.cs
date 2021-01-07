using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursApiRest.Models
{
    [Table("contacts")]
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;

        [Key]
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public List<Email> Mails { get; set; }

        public bool Save()
        {
            DataDbContext.Instance.Contacts.Add(this);
            return DataDbContext.Instance.SaveChanges() > 0;
        }

        public bool Update()
        {
            return DataDbContext.Instance.SaveChanges() > 0;
        }
        public bool Remove()
        {
            DataDbContext.Instance.Contacts.Remove(this);
            return DataDbContext.Instance.SaveChanges() > 0;
        }

        public static List<Contact> GetContacts()
        {
            return DataDbContext.Instance.Contacts.Include(c => c.Mails).ToList();
        }

        public static Contact GetContactById(int id)
        {
            return DataDbContext.Instance.Contacts.Include(c => c.Mails).FirstOrDefault(c => c.Id == id);
        }

        public static List<Contact> SearchContacts(string search)
        {
            return DataDbContext.Instance.Contacts.Include(c => c.Mails)
                .Where(c => c.Nom.Contains(search) || c.Prenom.Contains(search) || c.Telephone.Contains(search))
                .ToList();
        }
    }
}
