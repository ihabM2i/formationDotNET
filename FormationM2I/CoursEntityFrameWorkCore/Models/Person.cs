using System;
using System.Collections.Generic;
using System.Text;

namespace CoursEntityFrameWorkCore.Models
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
