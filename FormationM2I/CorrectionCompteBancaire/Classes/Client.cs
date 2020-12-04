using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public string Nom
        {
            get => nom; set
            {
                if (Tools.CheckName(value))
                    nom = value;
                else
                    throw new Exception("Erreur nom");
            }
        }
        public string Prenom
        {
            get => prenom; set
            {
                if (Tools.CheckName(value))
                    prenom = value;
                else
                    throw new Exception("Erreur prénom");
            }
        }
        public string Telephone
        {
            get => telephone; set
            {
                if (Tools.CheckPhone(value))
                    telephone = value;
                else
                    throw new Exception("Erreur téléphone");
            }
        }

        public int Id { get => id; set => id = value; }

        public Client()
        {

        }
        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public bool Save()
        {
            string request = "INSERT INTO Client (nom, prenom, telephone) OUTPUT INSERTED.Id values (@nom, @prenom, @telephone)";
            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            Tools.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Tools.Connection.Close();
            return Id > 0;

        }

        public Client GetClientById(int id)
        {
            return null;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }


    }
}
