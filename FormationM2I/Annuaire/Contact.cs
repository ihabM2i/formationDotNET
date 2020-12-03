using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Annuaire
{
    class Contact
    {
        int id;
        string nom;
        string prenom;
        string telephone;

        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
       
        public Contact()
        {

        }
        public Contact(string nom, string prenom, string telephone)
        {           
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }
        public Contact(int id, string nom, string prenom, string telephone) : this(nom,prenom,telephone)
        {
            Id = id;            
        }
        public bool Save()
        {
            string request = "INSERT INTO contact (nom, prenom, telephone) OUTPUT INSERTED.id values (@nom, @prenom, @telephone)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));

            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            return Id > 0;
        }

        public bool Delete()
        {
            return false;
        }

        public bool Update()
        {
            return false;
        }

        public static Contact GetContactById(int id)
        {
            Contact contact = null;
            string request = "SELECT id, nom, prenom, telephone from contact where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                contact = new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return contact;
        }
        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }
    }
}
