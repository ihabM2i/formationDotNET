using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoursAspNETCORE.Models
{
    public class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;
        List<Email> mails;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public List<Email> Mails { get => mails; set => mails = value; }

        public static List<Contact> GetContacts()
        {
            DataContext data = new DataContext();
            return new List<Contact>(data.Contacts.Include(c => c.Mails));
        }

        public static Contact GetContactById(int id)
        {
            DataContext data = new DataContext();
            return data.Contacts.Include(c => c.Mails).FirstOrDefault(c => c.Id == id);
        }
    }
}
