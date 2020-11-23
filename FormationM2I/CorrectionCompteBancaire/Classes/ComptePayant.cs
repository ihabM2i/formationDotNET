using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class ComptePayant : Compte
    {
        public ComptePayant(Client client, decimal solde = 0) : base(client, solde)
        {
        }
    }
}
