using System;
using System.Collections.Generic;
using System.Text;

namespace coursWPF.Classes
{
    public class Personne
    {
        private string nom;
        private string prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public override string ToString()
        {
            return Nom + " "+ prenom;
        }
    }
}
