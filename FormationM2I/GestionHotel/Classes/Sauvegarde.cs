using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GestionHotel.Classes
{
    public class Sauvegarde
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
        private static SqlCommand command;
        private static SqlDataReader reader;
        public Hotel CreateHotel(string nom, string adresse, string telephone)
        {
            Hotel hotel = null;
            string request = "INSERT INTO hotel (nom, adresse, telephone) OUTPUT INSERTED.ID " +
                " values (@nom, @adresse, @telephone)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@adresse", adresse));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            if(id > 0)
            {
                hotel = new Hotel(id, nom, adresse, telephone);
            }
            return hotel;
        }

        public Hotel GetHotel(string nom)
        {
            Hotel hotel = null;
            string request = "SELECT id, adresse, telephone from hotel where nom = @nom";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                hotel = new Hotel(reader.GetInt32(0), nom, reader.GetString(1), reader.GetString(2));
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return hotel;
        }

        public List<Client> GetClientsHotel(int hotelId)
        {
            List<Client> clients = new List<Client>();
            string request = "SELECT id, nom, prenom, telephone from client where hotel_id=@hotel_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Client c = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(0));
                clients.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return clients;
        }

        public List<Chambre> GetChambresHotel(int hotelId)
        {
            List<Chambre> chambres = new List<Chambre>();
            string request = "SELECT id, numero, capacite, statut, tarif from chambre where hotel_id=@hotel_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Chambre c = new Chambre(reader.GetInt32(1),reader.GetInt32(2),reader.GetString(3),reader.GetDecimal(4), reader.GetInt32(0));
                chambres.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return chambres;
        }

        public List<Reservation> GetReservationsHotel(int hotelId)
        {
            List<Reservation> reservations = new List<Reservation>();
            string request = "SELECT id, numero, client_id, total, statut from reservation where hotel_id=@hotel_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Reservation r = new Reservation(reader.GetInt32(0), reader.GetString(4), reader.GetInt32(2), reader.GetDecimal(3), reader.GetInt32(1));
                reservations.Add(r);
            }
            reservations.ForEach((r) =>
            {
                r.Client = GetClientId(r.Client.Id);
                r.Chambres = GetChambresReservation(r.Id);
            });
            reader.Close();
            command.Dispose();
            connection.Close();
            return null;
        }

        public Client GetClientId(int clientId)
        {
            Client client = null;
            string request = "SELECT  nom, prenom, telephone from client where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", clientId));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(0));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return client;
        }

        public List<Chambre> GetChambresReservation(int reservationId)
        {
            List<Chambre> chambres = new List<Chambre>();
            string request = "SELECT rc.chambre_id, c.numero, c.capacite, c.statut, c.tarif from reservation_chambre as rc " +
                "inner join chambre as c on c.id = rc.chambre_id where rc.reservation_id = @reservation_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@reservation_id", reservationId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Chambre c = new Chambre(reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDecimal(4), reader.GetInt32(0));
                chambres.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return chambres;
        }


        public Reservation GetReservation(int id)
        {
            Reservation reservation = null;
            string request = "SELECT numero, client_id, total, statut from reservation where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reservation = new Reservation(id, reader.GetString(4), reader.GetInt32(2), reader.GetDecimal(3), reader.GetInt32(1));
                
            }
            reservation.Client = GetClientId(reservation.Client.Id);
            reservation.Chambres = GetChambresReservation(reservation.Id);
            reader.Close();
            command.Dispose();
            connection.Close();
            return null;
        }

    }
}
