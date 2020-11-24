using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class CompteEpargne : Compte
    {
        decimal taux;
        public decimal Taux { get => taux; set => taux = value; }

        public CompteEpargne(Client client, decimal taux, decimal solde = 0) : base(client, solde)
        {
            Taux = taux;
        }

        public void CalculeInteret()
        {
            Depot(Solde * Taux / 100);
        }

    }
}
