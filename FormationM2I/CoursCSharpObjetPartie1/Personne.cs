using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1
{
    class Personne
    {
        //Attributs
        private string nom;
        private string prenom;
        private int age;
        private Adresse adresse;

        //Proprietés

        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                if (value.Length > 2)
                    nom = value;
                else
                    Console.WriteLine("Erreur nom");
            }
        }

        //Constructeurs
        public Personne()
        {
            Console.WriteLine("Construction d'un objet");
        }

        public Personne(string nom, string prenom, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
        }

        //Méthodes
        public void Afficher()
        {
            Console.WriteLine(nom + " " + prenom);
        }

        //public void SetNom(string n)
        //{
        //    if(n.Length > 2)
        //    {
        //        nom = n;
        //    }
        //    Console.WriteLine("Erreur saisi nom");
        //}
        //public string GetNom()
        //{
        //    return nom;
        //}

    }
}
