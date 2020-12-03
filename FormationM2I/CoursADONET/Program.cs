using System;
using System.Data.SqlClient;

namespace CoursADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            #region cours ADO.NET
            //Connexion à la base de donnée
            string connectionString = @"Data Source=(LocalDb)\coursM2I;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);


            //Executer les requetes => on utilise un objet de Command
            //Préparation de la commande
            //string request = "INSERT INTO personne (nom, prenom, telephone) values ('ado', 'net', 'core')";
            //string request = "INSERT INTO personne (nom, prenom, telephone) OUTPUT INSERTED.id values ('ado', 'net', 'core')";
            string request = "SELECT * from personne";
            SqlCommand command = new SqlCommand(request, connection);
            //ouverture de la connexion
            connection.Open();
            //1ere maniere d'executer la commande => executer une requete sans retour
            //int nbRow = command.ExecuteNonQuery();
            //2eme maniere d'executer la commande => executer une requete avec la récupération d'une seule valeur
            //int id = (int)command.ExecuteScalar();
            //3eme maniere d'executer la commande => executer une requete pour récupérer un ensemble de resultat
            SqlDataReader reader = command.ExecuteReader();
            //Lire la totalité des données
            while(reader.Read())
            {
                Console.WriteLine($"Personne Id : {reader.GetInt32(0)}, Nom : {reader.GetString(1)}, Prénom : {reader.GetString(2)}");
            }
            //Fermeture du reader
            reader.Close();
            //Liberer la connexion pour avoir la possibilité de l'utilier avec une autre commande
            command.Dispose();
            //Fermeture de la connexion
            connection.Close();
            #endregion
        }
    }
}
