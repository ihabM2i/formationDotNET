using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Banque
    {
        List<Compte> comptes;
        public List<Compte> Comptes { get => comptes; set => comptes = value; }

        public Banque()
        {
            Comptes = new List<Compte>();
        }
        public Compte GetCompteById(int id)
        {
            //Compte compte = null;
            //foreach(Compte c in Comptes)
            //{
            //    if(c.Numero == id)
            //    {
            //        compte = c;
            //        break;
            //    }
            //}
            //Compte compte = Comptes.FirstOrDefault(c => c.Numero == id);
            //return compte;
            return Comptes.Find(c => c.Numero == id);
        }
    }
}
