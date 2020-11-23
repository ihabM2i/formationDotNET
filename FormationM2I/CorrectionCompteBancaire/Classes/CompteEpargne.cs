using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class CompteEpargne : Compte
    {
        public CompteEpargne(Client client, decimal solde = 0) : base(client, solde)
        {
        }
    }
}
