using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Compte
    {
        private static int compteur = 1;

        private int numero;
        private decimal solde;
        private Client client;
        private List<Operation> operations;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public event Action<decimal, int> ADecouvert;
        public int Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public Compte(Client client, decimal solde = 0)
        {
            Client = client;
            //numero = compteur++;
            Operations = new List<Operation>();
            this.solde = solde;
        }
        public Compte(int numero,Client client, decimal solde = 0) : this(client, solde)
        {
            this.numero = numero;
        }

        public bool Save()
        {
            if(Client.Save())
            {
                string request = "INSERT INTO Compte (solde, client_id) OUTPUT INSERTED.ID values (@solde,@client_id)";
                command = new SqlCommand(request, Tools.Connection);
                command.Parameters.Add(new SqlParameter("@solde", Solde));
                command.Parameters.Add(new SqlParameter("@client_id", Client.Id));
                Tools.Connection.Open();
                numero = (int)command.ExecuteScalar();
                command.Dispose();
                Tools.Connection.Close();
                return numero > 0;
            }
            return false;
        }

        public static Compte GetCompteById(int id)
        {
            return null;
        }

        public bool Update()
        {
            return false;
        }
        public virtual bool Depot(decimal montant)
        {
            Operation o = new Operation(montant);
            Operations.Add(o);
            o.Save();
            solde += montant;
            return true;
        }

        public virtual bool Retrait(decimal montant)
        {
            //if(Solde >= montant)
            //{
            //    Operation o = new Operation(montant * -1);
            //    Operations.Add(o);
            //    solde -= montant;
            //    return true;
            //}
            //return false;
            Operation o = new Operation(montant * -1);
            Operations.Add(o);
            solde -= montant;
            if(solde < 0)
            {
                if(ADecouvert != null)
                {
                    ADecouvert(solde, Numero);
                }
            }
            return true;

        }

        public override string ToString()
        {
            string retour = $"Numero {Numero}\n";
            retour += Client.ToString() + "\n";
            foreach(Operation o in Operations)
            {
                retour += o.ToString() + "\n";
            }
            retour += $"Solde : {Solde} euros";
            return retour;
        }
    }
}
